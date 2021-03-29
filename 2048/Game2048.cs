using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048 {
    class Game2048 {

        public event Action<Game2048Args> OnScore;
        public event Action<Game2048Args> OnGameOver;
        public event Action<Game2048Args> OnNoWays;
        public event Action<Game2048Args> OnRecord;
        public event Action<Game2048Args> OnMove;

        public int NumberForWin { get; set; } = 2048;
        public int CageDistance { get; set; } = 4;
        public int DefaultNumber { get; set; } = 2;
        public Score Score {
            get {
                return args.GetLastScore();
            }
            private set {
                args.ScoreHistory.Add(value);
            }
        }
        public Score Record {
            get {
                return args.GetLastRecord();
            }
            private set {
                args.RecordHistory.Add(value);
            }
        }
        public int CountMove {
            get {
                return args.CountMove;
            }
            private set {
                args.CountMove = value;
            }
        }
        public bool IsGameOver { get; private set; }
        public bool IsBackground { get; private set; }
        public bool InfinityMode { get; set; }
        public bool AutoMode { get; set; }
        public bool IsAnimation { get; set; } = true;

        private Animation Anim;
        private Game2048Args args;
        private Point Location;
        private Point CellSize;
        private Form MainForm;
        private Size CageSize;
        private List<Cage> Cages {
            get {
                return args.GetLastHistory();
            }
            set {
                args.History.Add(value);
            }
        }
        private bool IsWin {
            get {
                return args.IsWin;
            }
            set {
                args.IsWin = value;
            }
        }
        private int MaxNumberNow {
            get {
                return args.MaxNumberNow;
            }
            set {
                args.MaxNumberNow = value;
            }
        }
        private List<Cage> FreeCages { get; set; }
        private List<Cage> BackgroundCages { get; set; }
        private int CageCounter { get; set; } = 0;
        private Action<Move> Callback;

        public Game2048(Form Form, Point Location, Point CellSize, Size CageSize, Action<Move> Callback) {
            args = new Game2048Args();
            MainForm = Form;
            this.Location = Location;
            this.CellSize = CellSize;
            this.CageSize = CageSize;
            this.Callback = Callback;
            BackgroundCages = new List<Cage>();
            Cages = new List<Cage>();
            setFreeCages();

            OnScore += Game2048_OnScore;
        }

        public async void Reply() {
            foreach (Cage cage in Cages)
                MainForm.Controls.Remove(cage);

            foreach (List<Cage> x in args.History) {
                foreach (Cage y in x) {
                    MainForm.Controls.Add(y);
                    y.BringToFront();
                }
                await Task.Delay(1000);
                foreach (Cage y in x) {
                    MainForm.Controls.Remove(y);
                }
            }
        }

        public void SetBackgroundCell(Color color = default(Color)) {
            if (BackgroundCages.Count == 0)
                for (int i = 0; i < CellSize.X; i++)
                    for (int j = 0; j < CellSize.Y; j++) {
                        Cage background = new Cage();
                        background.IsBackground = true;
                        background.Position = new Point(i, j);
                        background.BackColor = Equals(color, default(Color)) ? Color.Gainsboro : color;
                        background.Size = CageSize;
                        background.Location = new Point(Location.Y + j * CageSize.Width + (CageDistance * j), Location.X + i * CageSize.Height + (CageDistance * i));
                        background.PreviewKeyDown += Cage_PreviewKeyDown;

                        BackgroundCages.Add(background);
                        MainForm.Controls.Add(background);
                    }
            IsBackground = true;
        }

        public void RemoveBackgroundCell() {
            for (int i = 0; i < CellSize.X; i++)
                for (int j = 0; j < CellSize.Y; j++) {
                    Cage background = MainForm.Controls.OfType<Cage>().Where(b => b.IsBackground && b.Position == new Point(i, j)).FirstOrDefault();
                    if (background != null)
                        MainForm.Controls.Remove(background);
                }
            IsBackground = false;
            BackgroundCages.Clear();
        }

        public void NewGame(int CageCount = 2) {
            foreach (Cage cage in Cages)
                MainForm.Controls.Remove(cage);
            Cages.Clear();
            IsWin = false;
            args.Clear();
            CountMove = 0;
            MaxNumberNow = 0;
            OnScore?.Invoke(args);
            OnMove?.Invoke(args);
            for (int i = 0; i < CageCount; i++)
                AddRandomCage();
            IsGameOver = false;
            CheckAutoMode();
        }

        public void Motion(Move move) => GameLogic(move);

        private async void CheckAutoMode() {
            if (AutoMode) {
                while (!IsGameOver) {
                    await Task.Delay(200);
                    Random r = new Random();
                    int num = r.Next(1, 101);
                    if (num == 1) {
                        Move randMove = (Move)r.Next(2, 4);
                        Motion(randMove);
                    }
                    else if (CheckCanMove(Move.Right) || CheckCanMove(Move.Down)) {
                        Motion((Move)new Random().Next(0, 2));
                    }
                    else if (CheckCanMove(Move.Left)) {
                        Motion(Move.Left);
                    }
                    else {
                        Motion(Move.Up);
                    }
                }
            }
        }

        private bool CheckCanMove(Move move) {
            foreach (Cage cage in Cages)
                if (CheckCageCanMove(cage, move))
                    return true;
            return false;
        }

        private void EndOfTurn() {

        }

        private void GameLogic(Move move) {

            //if (Anim.IsProcess)
            //    return;

            bool isLeft = move == Move.Left;
            bool isRight = move == Move.Right;
            bool isUp = move == Move.Up;
            bool isDown = move == Move.Down;
            bool isMoveDone = false;

            for (int i = 0; isLeft || isRight ? i < CellSize.X : i < CellSize.Y; i++) {
                for (int j = isRight ? CellSize.Y - 1 : isDown ? CellSize.X - 1 : 0; isRight || isDown ? j >= 0 : isUp ? j < CellSize.X : j < CellSize.Y; j += isRight || isDown ? -1 : 1) {
                    Cage cage = Cages.Where(c => c.Position.X == (isUp || isDown ? i : j) && c.Position.Y == (isUp || isDown ? j : i)).FirstOrDefault();
                    if (cage != null && cage.Number != -1 && CheckCageCanMove(cage, move)) {
                        for (int k = 1; isLeft || isRight ? k < CellSize.Y : k < CellSize.X; k++) {
                            Cage nearlyCage = CheckCageNearly(cage, move);
                            if (CheckCageCanMove(cage, move)) {
                                if (nearlyCage?.Number == cage.Number && nearlyCage.CanMix) {
                                    cage.Position = new Point(cage.Position.X + (isLeft ? -1 : isRight ? 1 : 0), cage.Position.Y + (isUp ? -1 : isDown ? 1 : 0));
                                    cage.Number *= 2;
                                    cage.CanMix = false;

                                    nearlyCage.Number = -1;
                                    nearlyCage.Name = cage.Name;
                                    nearlyCage.Position = new Point(-2, -2);

                                    Anim = new Animation(CageDistance, 20, IsAnimation, Animation_OnMix);
                                    Anim.Move(move, cage, true);
                                    Anim.Mix(cage);

                                    isMoveDone = true;
                                    break;
                                }
                                else if (nearlyCage == null) {
                                    cage.Position = new Point(cage.Position.X + (isLeft ? -1 : isRight ? 1 : 0), cage.Position.Y + (isUp ? -1 : isDown ? 1 : 0));
                                    Anim = new Animation(CageDistance, 20, IsAnimation);
                                    Anim.Move(move, cage, false);
                                    isMoveDone = true;
                                }
                                else
                                    break;
                            }
                            else
                                break;
                        }
                    }
                }
            }
            Cages.ForEach(c => c.CanMix = true);
            //Cages.ForEach(c=> {
            //    args.History[args.History.Count - 1].Where(c2 => c2.Name == c.Name).FirstOrDefault().Position = c.Position;
            //});
            if (isMoveDone) {
                AddRandomCage();
                CountMove++;
                args.History.Add(new List<Cage>(Cages));
                OnMove?.Invoke(args);
            }
            if (!CheckWays()) {
                OnNoWays?.Invoke(args);
                IsWin = false;
                GameOver();
            }
        }

        private bool CheckWays() {
            if (Cages.Count == CellSize.X * CellSize.Y) {
                for (int i = 0; i < CellSize.X; i++)
                    for (int j = 0; j < CellSize.Y; j++) {
                        Cage cage = Cages.Where(c => c.Position.X == j && c.Position.Y == i).FirstOrDefault();
                        if (cage == null)
                            return true;
                        else if (CheckCagesCanMove())
                            return true;
                    }
                return false;
            }
            return true;
        }

        private bool CheckCageCanMove(Cage cage, Move move) {
            if (!CheckCageBorder(cage, move)) {
                Cage nearlyCage = CheckCageNearly(cage, move);
                if (nearlyCage == null)
                    return true;
                return nearlyCage.Number == cage.Number;
            }
            return false;
        }

        private bool CheckCagesCanMove() {
            foreach (Cage cage in Cages)
                foreach (Cage near in CheckCagesNearly(cage))
                    if (near.Number == cage.Number)
                        return true;
            return false;
        }

        private Cage CheckCageNearly(Cage cage, Move move) {
            Point position = cage.Position;
            if (move == Move.Left)
                return Cages.Where(c => c.Position.X == position.X - 1 && c.Position.Y == position.Y).FirstOrDefault();
            if (move == Move.Right)
                return Cages.Where(c => c.Position.X == position.X + 1 && c.Position.Y == position.Y).FirstOrDefault();
            if (move == Move.Up)
                return Cages.Where(c => c.Position.Y == position.Y - 1 && c.Position.X == position.X).FirstOrDefault();
            if (move == Move.Down)
                return Cages.Where(c => c.Position.Y == position.Y + 1 && c.Position.X == position.X).FirstOrDefault();
            return null;
        }

        private List<Cage> CheckCagesNearly(Cage cage) {
            Point position = cage.Position;
            List<Cage> cageList = new List<Cage>();

            cageList.Add(Cages.Where(c => c.Position.X == position.X - 1 && c.Position.Y == position.Y).FirstOrDefault());
            cageList.Add(Cages.Where(c => c.Position.X == position.X + 1 && c.Position.Y == position.Y).FirstOrDefault());
            cageList.Add(Cages.Where(c => c.Position.Y == position.Y - 1 && c.Position.X == position.X).FirstOrDefault());
            cageList.Add(Cages.Where(c => c.Position.Y == position.Y + -1 && c.Position.X == position.X).FirstOrDefault());
            cageList.RemoveAll(a => a == null);

            return cageList;
        }

        private void Animation_OnMix(Cage cage) {
            List<Cage> deleteCages = Cages.Where(c => c.Number == -1).ToList();
            for (int i = 0; i < deleteCages.Count; i++) {
                MainForm.Controls.Remove(deleteCages[i]);
                Cages.Remove(deleteCages[i]);
            }

            cage.ApplyNumber();
            if (cage.Number > MaxNumberNow)
                MaxNumberNow = cage.Number;
            Score = new Score(args.GetLastScore().CountScore + cage.Number, CountMove);
            OnScore?.Invoke(args);
            if (cage.Number > 99)
                cage.Font = new Font("Google Sans", 22, FontStyle.Regular);
            if (cage.Number > 512)
                cage.Font = new Font("Google Sans", 18, FontStyle.Regular);
            if (cage.Number > 8192)
                cage.Font = new Font("Google Sans", 14, FontStyle.Regular);
        }

        private bool CheckCageBorder(Cage positionCage, Move move) {
            if (move == Move.Left)
                return positionCage.Position.X == 0;
            if (move == Move.Right)
                return positionCage.Position.X == CellSize.Y - 1;
            if (move == Move.Up)
                return positionCage.Position.Y == 0;
            return positionCage.Position.Y == CellSize.X - 1;
        }

        private bool AddRandomCage() {
            Cage randCage = GetRandomCage();
            if (randCage == null) {
                GameOver();
                return false;
            }

            Cage cage = new Cage();
            cage.Name = $"cage_{CageCounter}";
            cage.Size = CageSize;
            cage.Number = DefaultNumber;
            cage.ApplyNumber();
            cage.Position = randCage.Position;
            cage.Location = new Point(
                Location.Y + randCage.Position.X * CageSize.Width + (CageDistance * randCage.Position.X),
                Location.X + randCage.Position.Y * CageSize.Height + (CageDistance * randCage.Position.Y));
            cage.PreviewKeyDown += Cage_PreviewKeyDown;

            Cages.Add(cage);
            MainForm.Controls.Add(cage);
            cage.BringToFront();
            CageCounter++;

            new Animation(CageDistance, 20, IsAnimation).ShowCage(cage, cage.BackColor);

            return true;
        }

        private void GameOver() {
            IsGameOver = true;
            OnGameOver?.Invoke(args);
        }

        private void Cage_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            //if (AutoMode)
            //return;
            if (e.KeyCode == Keys.Up)
                Callback?.Invoke(Move.Up);
            if (e.KeyCode == Keys.Down)
                Callback?.Invoke(Move.Down);
            if (e.KeyCode == Keys.Left)
                Callback?.Invoke(Move.Left);
            if (e.KeyCode == Keys.Right)
                Callback?.Invoke(Move.Right);
        }

        private void Game2048_OnScore(Game2048Args e) {
            if (e.GetLastScore().CountScore > Record.CountScore) {
                Record = e.GetLastScore();
                OnRecord?.Invoke(args);
            }
            if (e.MaxNumberNow >= NumberForWin && !InfinityMode) {
                IsWin = true;
                GameOver();
            }
        }

        private Cage GetRandomCage() {
            List<Cage> randCages = new List<Cage>();
            randCages.AddRange(FreeCages);
            for (int i = 0; i < Cages.Count; i++)
                randCages.Remove(FreeCages.Where(b => b.Position == Cages[i].Position).FirstOrDefault());
            if (randCages.Count == 0)
                return null;
            return randCages.Shuffle()[0];
        }

        private void setFreeCages() {
            FreeCages = new List<Cage>();
            for (int i = 0; i < CellSize.Y; i++)
                for (int j = 0; j < CellSize.X; j++)
                    FreeCages.Add(new Cage() { Position = new Point(i, j) });
            FreeCages = FreeCages.Shuffle();
        }

        public enum Move {
            Right, Down, Left, Up
        }


    }

    class Game2048Args {

        public List<Score> ScoreHistory { get; private set; }
        public List<Score> RecordHistory { get; private set; }
        public int CountMove { get; set; }
        public int MaxNumberNow { get; set; }
        public bool IsWin { get; set; }
        public List<List<Cage>> History { get; private set; }

        public Score GetLastScore() => ScoreHistory[ScoreHistory.Count - 1];
        public Score GetLastRecord() => RecordHistory[RecordHistory.Count - 1];
        public List<Cage> GetLastHistory() => History[History.Count - 1];

        public void Clear() {
            ScoreHistory.Clear();
            ScoreHistory.Add(new Score());

            History.Clear();
            History.Add(new List<Cage>());
        }

        public Game2048Args() {
            ScoreHistory = new List<Score>() { new Score(0, 0) };
            RecordHistory = new List<Score>() { new Score(0, 0) };
            History = new List<List<Cage>>();
        }
    }

    class Score {

        public int CountScore { get; set; }
        public int CountMove { get; set; }

        public Score(int CountScore, int CountMove) {
            this.CountScore = CountScore;
            this.CountMove = CountMove;
        }

        public Score() {
        }
    }
}
