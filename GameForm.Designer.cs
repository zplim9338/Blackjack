namespace Blackjack
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStay = new System.Windows.Forms.Button();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.lsScoringBoard = new System.Windows.Forms.ListView();
            this.lsGameState = new System.Windows.Forms.ListView();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnNewRound = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeckCardsCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(202, 25);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(15, 25);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(100, 20);
            this.txtPlayerName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Player Name:";
            // 
            // btnHit
            // 
            this.btnHit.Location = new System.Drawing.Point(713, 78);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(75, 23);
            this.btnHit.TabIndex = 5;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += new System.EventHandler(this.BtnHit_Click);
            // 
            // btnStay
            // 
            this.btnStay.Location = new System.Drawing.Point(713, 107);
            this.btnStay.Name = "btnStay";
            this.btnStay.Size = new System.Drawing.Size(75, 23);
            this.btnStay.TabIndex = 6;
            this.btnStay.Text = "Stay";
            this.btnStay.UseVisualStyleBackColor = true;
            this.btnStay.Click += new System.EventHandler(this.BtnStay_Click);
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(121, 25);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 8;
            this.btnAddPlayer.Text = "Add Player";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.BtnAddPlayer_Click);
            // 
            // lsScoringBoard
            // 
            this.lsScoringBoard.HideSelection = false;
            this.lsScoringBoard.Location = new System.Drawing.Point(15, 78);
            this.lsScoringBoard.Name = "lsScoringBoard";
            this.lsScoringBoard.Size = new System.Drawing.Size(181, 337);
            this.lsScoringBoard.TabIndex = 9;
            this.lsScoringBoard.UseCompatibleStateImageBehavior = false;
            this.lsScoringBoard.View = System.Windows.Forms.View.List;
            // 
            // lsGameState
            // 
            this.lsGameState.HideSelection = false;
            this.lsGameState.Location = new System.Drawing.Point(202, 78);
            this.lsGameState.Name = "lsGameState";
            this.lsGameState.Size = new System.Drawing.Size(505, 337);
            this.lsGameState.TabIndex = 12;
            this.lsGameState.UseCompatibleStateImageBehavior = false;
            this.lsGameState.View = System.Windows.Forms.View.List;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(713, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnNewRound
            // 
            this.btnNewRound.Location = new System.Drawing.Point(632, 25);
            this.btnNewRound.Name = "btnNewRound";
            this.btnNewRound.Size = new System.Drawing.Size(75, 23);
            this.btnNewRound.TabIndex = 14;
            this.btnNewRound.Text = "New Round";
            this.btnNewRound.UseVisualStyleBackColor = true;
            this.btnNewRound.Click += new System.EventHandler(this.BtnNewRound_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Deck Cards:";
            // 
            // txtDeckCardsCount
            // 
            this.txtDeckCardsCount.Location = new System.Drawing.Point(271, 52);
            this.txtDeckCardsCount.Name = "txtDeckCardsCount";
            this.txtDeckCardsCount.ReadOnly = true;
            this.txtDeckCardsCount.Size = new System.Drawing.Size(100, 20);
            this.txtDeckCardsCount.TabIndex = 3;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNewRound);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lsGameState);
            this.Controls.Add(this.lsScoringBoard);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.btnStay);
            this.Controls.Add(this.btnHit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDeckCardsCount);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.btnStart);
            this.Name = "GameForm";
            this.Text = "Black Jack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStay;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.ListView lsScoringBoard;
        private System.Windows.Forms.ListView lsGameState;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnNewRound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeckCardsCount;
    }
}

