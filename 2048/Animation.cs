using System;
using System.Drawing;
using System.Threading.Tasks;

using static _2048.Game2048;

namespace _2048 {
    class Animation {

        private bool IsAnimation { get; }
        public bool IsProcess { get; set; }
        private int Speed { get; set; }
        private Move move { get; set; }
        private bool isMix { get; set; }
        private int CageDistance { get; }
        private bool IsHorisontal { get; set; }
        private int CounterForMulti { get; set; } = 0;

        private Action<Cage> callback;

        public Animation(int CageDistance, int Speed, bool IsAnimation, Action<Cage> callback = null) {
            this.CageDistance = CageDistance;
            this.Speed = Speed;
            this.IsAnimation = IsAnimation;
            this.callback = callback;
        }

        public async void Move(Move move, Cage cage, bool isMix) {
            CounterForMulti++;
            this.move = move;
            this.isMix = isMix;
            IsHorisontal = move == Game2048.Move.Left || move == Game2048.Move.Right;
            if (IsAnimation) {
                IsProcess = true;
                await MoveCageAsync(cage);
                IsProcess = false;
            }
            else {
                callback?.Invoke(cage);
                MoveCage(cage);
            }
        }

        public async void Mix(Cage cage) {
            if (!IsAnimation)
                return;
            IsProcess = true;
            for (int i = 0; i < 4; i++, await Task.Delay(IsAnimation ? Speed : 0)) {
                cage.Size = new Size(cage.Size.Width + 2, cage.Size.Height + 2);
                cage.Location = new Point(cage.Location.X - 1, cage.Location.Y - 1);
            }
            for (int i = 0; i < 4; i++, await Task.Delay(IsAnimation ? Speed : 0)) {
                cage.Size = new Size(cage.Size.Width - 2, cage.Size.Height - 2);
                cage.Location = new Point(cage.Location.X + 1, cage.Location.Y + 1);
            }
            IsProcess = false;
        }

        private async Task MoveCageAsync(Cage cage) {
            for (int i = 0; i < ((IsHorisontal) ? cage.Size.Width / Speed : cage.Size.Height / Speed); i++, await Task.Delay(1)) {
                cage.Location = new Point(
                    cage.Location.X + (IsHorisontal ? ((move == Game2048.Move.Left) ? -Speed : Speed) : 0),
                    cage.Location.Y + ((!IsHorisontal) ? ((move == Game2048.Move.Up) ? -Speed : Speed) : 0)
                    );
            }
            for (int j = 0; j < CageDistance; j++) {
                cage.Location = new Point(
                    cage.Location.X + (IsHorisontal ? ((move == Game2048.Move.Left) ? -1 : 1) : 0),
                    cage.Location.Y + ((!IsHorisontal) ? ((move == Game2048.Move.Up) ? -1 : 1) : 0)
                );
            }
            if (isMix)
                callback?.Invoke(cage);
        }

        private void MoveCage(Cage cage) {
            for (int i = 0; i < ((IsHorisontal) ? cage.Size.Width / Speed : cage.Size.Height / Speed); i++) {
                cage.Location = new Point(
                    cage.Location.X + (IsHorisontal ? ((move == Game2048.Move.Left) ? -Speed : Speed) : 0),
                    cage.Location.Y + ((!IsHorisontal) ? ((move == Game2048.Move.Up) ? -Speed : Speed) : 0)
                    );
            }
            for (int j = 0; j < CageDistance; j++) {
                cage.Location = new Point(
                    cage.Location.X + (IsHorisontal ? ((move == Game2048.Move.Left) ? -1 : 1) : 0),
                    cage.Location.Y + ((!IsHorisontal) ? ((move == Game2048.Move.Up) ? -1 : 1) : 0)
                );
            }
        }

        //public async void EndOfTurn(Cage cage) {
        //    if (IsAnimation)
        //        await Task.Delay(72);
        //    OnEndOfTurn?.Invoke(cage);
        //}

        public async void ShowCage(Cage cage, Color backColor) {
            if (!IsAnimation)
                return;
            for (int i = 50; i <= 255; i += 15, await Task.Delay(IsAnimation ? (int)(Speed * 1.5) : 0))
                cage.BackColor = Color.FromArgb(i, cage.BackColor);
        }
    }
}
