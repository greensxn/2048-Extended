using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static _2048.Game2048;

namespace _2048 {
    class _2048Controller {

        public event Action<Game2048Args> OnScore;
        public event Action<Game2048Args> OnGameOver;
        public event Action<Game2048Args> OnNoWays;
        public event Action<Game2048Args> OnRecord;
        public event Action<Game2048Args> OnMove;

        public bool IsBackground { get; private set; }

        private List<Cage> BackgroundCages { get; set; }
        public Game2048 Game { get; }

        private Animation Anim;
        private Game2048Args args;
        private Point Location;
        private Point CellSize;
        private Form MainForm;
        private Size CageSize;

        public Action<Move> Callback { get; }

        public _2048Controller(Game2048 game, Form Form, Point Location, Size CageSize, Action<Move> Callback) {
            args = new Game2048Args();
            Game = game;
            MainForm = Form;
            this.Location = Location;
            this.CageSize = CageSize;
            this.Callback = Callback;
            BackgroundCages = new List<Cage>();
            //Cages = new List<Cage>();
            //setFreeCages();

            //OnScore += Game2048_OnScore;

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
                        //background.Location = new Point(Location.Y + j * CageSize.Width + (CageDistance * j), Location.X + i * CageSize.Height + (CageDistance * i));
                        //background.PreviewKeyDown += Cage_PreviewKeyDown;

                        BackgroundCages.Add(background);
                        MainForm.Controls.Add(background);
                    }
            IsBackground = true;
        }

        //public void RemoveBackgroundCell() {
        //    for (int i = 0; i < CellSize.X; i++)
        //        for (int j = 0; j < CellSize.Y; j++) {
        //            Cage background = MainForm.Controls.OfType<Cage>().Where(b => b.IsBackground && b.Position == new Point(i, j)).FirstOrDefault();
        //            if (background != null)
        //                MainForm.Controls.Remove(background);
        //        }
        //    IsBackground = false;
        //    BackgroundCages.Clear();
        //}

        //public void NewGame() {
        //    foreach (Cage cage in Game.Cages)
        //        MainForm.Controls.Remove(cage);
        //}

        //protected override bool AddRandomCage() {
        //    return base.AddRandomCage();
        //}
    }
}
