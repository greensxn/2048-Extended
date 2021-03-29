using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static _2048.Game2048;

namespace _2048 {
    public partial class Form1 : Form {

        Game2048 game;
        List<ToolStripMenuItem> GameMode;

        public Form1() {
            InitializeComponent();
            GameMode = режимToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().Where(m => m.Tag != null && m.Tag.ToString() == "GameMode").ToList();

            game = new Game2048(this, new Point(50, 290), new Point(4, 4), new Size(80, 80), Game_OnMove);
            game.SetBackgroundCell();
            game.NewGame();

            game.OnScore += Game_OnScore;
            game.OnGameOver += Game_OnGameOver;
            game.OnRecord += Game_OnRecord;
            game.OnMove += Game_OnMove;
        }

        private void Game_OnMove(Game2048Args e) => lbCountMove.Text = e.CountMove.ToString();

        private void Game_OnRecord(Game2048Args e) => lbRecord.Text = e.GetLastRecord().CountScore.ToString();

        private void Game_OnScore(Game2048Args e) => lbScore.Text = e.GetLastScore().CountScore.ToString();

        private void Game_OnGameOver(Game2048Args e) {
            if (e.IsWin)
                lbReply.Enabled = true;
            lbGameOver.Visible = true;
            lbGameOver.ForeColor = e.IsWin ? Color.Green : Color.Red;
            lbGameOver.Text = "Game " + (e.IsWin ? "Win" : "Lost") + "!";
        }

        private void Game_OnMove(Move move) {
            if (!game.IsGameOver)
                game.Motion(move);
        }

        private void NewGame_Click(object sender, EventArgs e) {
            lbGameOver.Visible = false;
            int defNum;
            int.TryParse(tbDefaultNumber.Text, out defNum);
            game.DefaultNumber = defNum;
            game.NewGame(2);
        }

        private void сеткаToolStripMenuItem_Click(object sender, EventArgs e) {
            if (game.IsBackground)
                game.RemoveBackgroundCell();
            else
                game.SetBackgroundCell();
            lbCellTrigger.Checked = game.IsBackground;
        }

        private void infinityMode_Click(object sender, EventArgs e) {
            GameMode.ForEach(m => {
                if (m != sender as ToolStripMenuItem)
                    m.Checked = false;
            });
            lbInfinityModeTrigger.Checked = game.InfinityMode;
            game.InfinityMode = !game.InfinityMode;
        }

        private void автоматическийToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem modeButton = sender as ToolStripMenuItem;
            GameMode.ForEach(m => {
                if (m != modeButton)
                    m.Checked = false;
            });
            modeButton.Checked = game.AutoMode;
            game.AutoMode = true;
        }

        private void lbReply_Click(object sender, EventArgs e) {
            game.Reply();
        }

        private void доЧислаToolStripMenuItem_Click(object sender, EventArgs e) {
            ToolStripMenuItem modeButton = sender as ToolStripMenuItem;
            GameMode.ForEach(m => {
                if (m != sender as ToolStripMenuItem)
                    m.Checked = false;
            });
            int numberForWin;
            int.TryParse(tbNumberForWin.Text, out numberForWin);
            if (numberForWin == 0)
                numberForWin = 2048;
            modeButton.Text = numberForWin.ToString();
            modeButton.Checked = game.AutoMode;
            game.NumberForWin = numberForWin;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => Close();
    }
}
