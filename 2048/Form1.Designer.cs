namespace _2048 {
    partial class Form1 {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbCellTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.режимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbInfinityModeTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.lbAutoModeTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.lbDefaultNumber = new System.Windows.Forms.ToolStripMenuItem();
            this.tbDefaultNumber = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lbSaveGame = new System.Windows.Forms.ToolStripMenuItem();
            this.lbLoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbExit = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbReply = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbScore = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbRecord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbCountMove = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbGameOver = new System.Windows.Forms.Label();
            this.lbNumberForWinModeTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.tbNumberForWin = new System.Windows.Forms.ToolStripTextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.новаяИграToolStripMenuItem,
            this.lbReply});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(902, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbCellTrigger,
            this.режимToolStripMenuItem,
            this.lbDefaultNumber,
            this.toolStripSeparator1,
            this.lbSaveGame,
            this.lbLoadGame,
            this.toolStripSeparator2,
            this.lbExit});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // lbCellTrigger
            // 
            this.lbCellTrigger.Checked = true;
            this.lbCellTrigger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lbCellTrigger.Name = "lbCellTrigger";
            this.lbCellTrigger.Size = new System.Drawing.Size(180, 22);
            this.lbCellTrigger.Text = "Сетка";
            this.lbCellTrigger.Click += new System.EventHandler(this.сеткаToolStripMenuItem_Click);
            // 
            // режимToolStripMenuItem
            // 
            this.режимToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbInfinityModeTrigger,
            this.lbAutoModeTrigger,
            this.lbNumberForWinModeTrigger});
            this.режимToolStripMenuItem.Name = "режимToolStripMenuItem";
            this.режимToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.режимToolStripMenuItem.Text = "Режим";
            // 
            // lbInfinityModeTrigger
            // 
            this.lbInfinityModeTrigger.Name = "lbInfinityModeTrigger";
            this.lbInfinityModeTrigger.Size = new System.Drawing.Size(180, 22);
            this.lbInfinityModeTrigger.Tag = "GameMode";
            this.lbInfinityModeTrigger.Text = "Бесконечный";
            this.lbInfinityModeTrigger.Click += new System.EventHandler(this.infinityMode_Click);
            // 
            // lbAutoModeTrigger
            // 
            this.lbAutoModeTrigger.Name = "lbAutoModeTrigger";
            this.lbAutoModeTrigger.Size = new System.Drawing.Size(180, 22);
            this.lbAutoModeTrigger.Tag = "GameMode";
            this.lbAutoModeTrigger.Text = "Автоматический";
            this.lbAutoModeTrigger.Click += new System.EventHandler(this.автоматическийToolStripMenuItem_Click);
            // 
            // lbDefaultNumber
            // 
            this.lbDefaultNumber.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbDefaultNumber});
            this.lbDefaultNumber.Name = "lbDefaultNumber";
            this.lbDefaultNumber.Size = new System.Drawing.Size(180, 22);
            this.lbDefaultNumber.Text = "Начальное число";
            // 
            // tbDefaultNumber
            // 
            this.tbDefaultNumber.Name = "tbDefaultNumber";
            this.tbDefaultNumber.Size = new System.Drawing.Size(100, 23);
            this.tbDefaultNumber.Text = "2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // lbSaveGame
            // 
            this.lbSaveGame.Name = "lbSaveGame";
            this.lbSaveGame.Size = new System.Drawing.Size(180, 22);
            this.lbSaveGame.Text = "Сохранить игру";
            // 
            // lbLoadGame
            // 
            this.lbLoadGame.Name = "lbLoadGame";
            this.lbLoadGame.Size = new System.Drawing.Size(180, 22);
            this.lbLoadGame.Text = "Загрузить игру";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // lbExit
            // 
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(180, 22);
            this.lbExit.Text = "Выход";
            this.lbExit.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // lbReply
            // 
            this.lbReply.Enabled = false;
            this.lbReply.Name = "lbReply";
            this.lbReply.Size = new System.Drawing.Size(60, 20);
            this.lbReply.Text = "Повтор";
            this.lbReply.Click += new System.EventHandler(this.lbReply_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lbScore);
            this.panel1.Location = new System.Drawing.Point(0, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 56);
            this.panel1.TabIndex = 1;
            // 
            // lbScore
            // 
            this.lbScore.BackColor = System.Drawing.Color.Transparent;
            this.lbScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbScore.Font = new System.Drawing.Font("AlphaSmart 3000", 24F);
            this.lbScore.Location = new System.Drawing.Point(0, 0);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(233, 56);
            this.lbScore.TabIndex = 2;
            this.lbScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.lbRecord);
            this.panel2.Location = new System.Drawing.Point(669, 513);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 56);
            this.panel2.TabIndex = 1;
            // 
            // lbRecord
            // 
            this.lbRecord.BackColor = System.Drawing.Color.Transparent;
            this.lbRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRecord.Font = new System.Drawing.Font("AlphaSmart 3000", 24F);
            this.lbRecord.Location = new System.Drawing.Point(0, 0);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(233, 56);
            this.lbRecord.TabIndex = 2;
            this.lbRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("AlphaSmart 3000", 24F);
            this.label1.Location = new System.Drawing.Point(4, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("AlphaSmart 3000", 24F);
            this.label2.Location = new System.Drawing.Point(775, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Record";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.lbCountMove);
            this.panel3.Location = new System.Drawing.Point(334, 513);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 56);
            this.panel3.TabIndex = 1;
            // 
            // lbCountMove
            // 
            this.lbCountMove.BackColor = System.Drawing.Color.Transparent;
            this.lbCountMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCountMove.Font = new System.Drawing.Font("AlphaSmart 3000", 24F);
            this.lbCountMove.Location = new System.Drawing.Point(0, 0);
            this.lbCountMove.Name = "lbCountMove";
            this.lbCountMove.Size = new System.Drawing.Size(233, 56);
            this.lbCountMove.TabIndex = 2;
            this.lbCountMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("AlphaSmart 3000", 24F);
            this.label3.Location = new System.Drawing.Point(334, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "Moves";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbGameOver
            // 
            this.lbGameOver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGameOver.BackColor = System.Drawing.Color.Transparent;
            this.lbGameOver.Font = new System.Drawing.Font("AlphaSmart 3000", 24F);
            this.lbGameOver.Location = new System.Drawing.Point(2, 399);
            this.lbGameOver.Name = "lbGameOver";
            this.lbGameOver.Size = new System.Drawing.Size(902, 36);
            this.lbGameOver.TabIndex = 2;
            this.lbGameOver.Text = "Game Over!";
            this.lbGameOver.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbGameOver.Visible = false;
            // 
            // lbNumberForWinModeTrigger
            // 
            this.lbNumberForWinModeTrigger.Checked = true;
            this.lbNumberForWinModeTrigger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lbNumberForWinModeTrigger.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbNumberForWin});
            this.lbNumberForWinModeTrigger.Name = "lbNumberForWinModeTrigger";
            this.lbNumberForWinModeTrigger.Size = new System.Drawing.Size(180, 22);
            this.lbNumberForWinModeTrigger.Tag = "GameMode";
            this.lbNumberForWinModeTrigger.Text = "До числа";
            this.lbNumberForWinModeTrigger.Click += new System.EventHandler(this.доЧислаToolStripMenuItem_Click);
            // 
            // tbNumberForWin
            // 
            this.tbNumberForWin.Name = "tbNumberForWin";
            this.tbNumberForWin.Size = new System.Drawing.Size(100, 23);
            this.tbNumberForWin.Text = "2048";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 569);
            this.Controls.Add(this.lbGameOver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(918, 608);
            this.MinimumSize = new System.Drawing.Size(918, 608);
            this.Name = "Form1";
            this.Text = "2048";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lbCellTrigger;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lbInfinityModeTrigger;
        private System.Windows.Forms.ToolStripMenuItem lbDefaultNumber;
        private System.Windows.Forms.ToolStripTextBox tbDefaultNumber;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lbSaveGame;
        private System.Windows.Forms.ToolStripMenuItem lbLoadGame;
        private System.Windows.Forms.ToolStripMenuItem lbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.Label lbRecord;
        private System.Windows.Forms.ToolStripMenuItem lbAutoModeTrigger;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbCountMove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbGameOver;
        private System.Windows.Forms.ToolStripMenuItem lbReply;
        private System.Windows.Forms.ToolStripMenuItem lbNumberForWinModeTrigger;
        private System.Windows.Forms.ToolStripTextBox tbNumberForWin;
    }
}

