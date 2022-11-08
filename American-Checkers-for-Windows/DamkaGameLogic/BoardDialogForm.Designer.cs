namespace DamkaGameLogic
{
    partial class BoardDialogForm
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
            this.labelPlayer1Points = new System.Windows.Forms.Label();
            this.labelPlayer2Points = new System.Windows.Forms.Label();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.panelBoardGame = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelPlayer1Points
            // 
            this.labelPlayer1Points.AutoSize = true;
            this.labelPlayer1Points.Location = new System.Drawing.Point(196, 29);
            this.labelPlayer1Points.Name = "labelPlayer1Points";
            this.labelPlayer1Points.Size = new System.Drawing.Size(14, 16);
            this.labelPlayer1Points.TabIndex = 3;
            this.labelPlayer1Points.Text = "0";
            // 
            // labelPlayer2Points
            // 
            this.labelPlayer2Points.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2Points.AutoSize = true;
            this.labelPlayer2Points.Location = new System.Drawing.Point(507, 29);
            this.labelPlayer2Points.Name = "labelPlayer2Points";
            this.labelPlayer2Points.Size = new System.Drawing.Size(14, 16);
            this.labelPlayer2Points.TabIndex = 2;
            this.labelPlayer2Points.Text = "0";
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Location = new System.Drawing.Point(422, 29);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(62, 16);
            this.labelPlayer2Name.TabIndex = 1;
            this.labelPlayer2Name.Text = "Player 2: ";
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Location = new System.Drawing.Point(104, 29);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(62, 16);
            this.labelPlayer1Name.TabIndex = 0;
            this.labelPlayer1Name.Text = "Player 1: ";
            this.labelPlayer1Name.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelBoardGame
            // 
            this.panelBoardGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBoardGame.Location = new System.Drawing.Point(12, 68);
            this.panelBoardGame.Name = "panelBoardGame";
            this.panelBoardGame.Size = new System.Drawing.Size(623, 542);
            this.panelBoardGame.TabIndex = 4;
            this.panelBoardGame.Visible = false;
            this.panelBoardGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBoardGame_Paint);
            // 
            // BoardDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 622);
            this.Controls.Add(this.panelBoardGame);
            this.Controls.Add(this.labelPlayer1Points);
            this.Controls.Add(this.labelPlayer2Points);
            this.Controls.Add(this.labelPlayer2Name);
            this.Controls.Add(this.labelPlayer1Name);
            this.Name = "BoardDialogForm";
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.BoardDialogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPlayer2Name;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer1Points;
        private System.Windows.Forms.Label labelPlayer2Points;
        private System.Windows.Forms.Panel panelBoardGame;
    }
}