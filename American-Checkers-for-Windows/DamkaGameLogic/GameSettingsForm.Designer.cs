namespace DamkaGameLogic
{
    partial class GameSettingsForm
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
            this.radioButtonTen = new System.Windows.Forms.RadioButton();
            this.radioButtonEight = new System.Windows.Forms.RadioButton();
            this.radioButtonSix = new System.Windows.Forms.RadioButton();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.buttonDone = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonTen
            // 
            this.radioButtonTen.AutoSize = true;
            this.radioButtonTen.Location = new System.Drawing.Point(170, 11);
            this.radioButtonTen.Margin = new System.Windows.Forms.Padding(1);
            this.radioButtonTen.Name = "radioButtonTen";
            this.radioButtonTen.Size = new System.Drawing.Size(64, 20);
            this.radioButtonTen.TabIndex = 4;
            this.radioButtonTen.TabStop = true;
            this.radioButtonTen.Text = "10X10";
            this.radioButtonTen.UseVisualStyleBackColor = true;
            // 
            // radioButtonEight
            // 
            this.radioButtonEight.AutoSize = true;
            this.radioButtonEight.Location = new System.Drawing.Point(96, 11);
            this.radioButtonEight.Margin = new System.Windows.Forms.Padding(1);
            this.radioButtonEight.Name = "radioButtonEight";
            this.radioButtonEight.Size = new System.Drawing.Size(50, 20);
            this.radioButtonEight.TabIndex = 3;
            this.radioButtonEight.TabStop = true;
            this.radioButtonEight.Text = "8X8";
            this.radioButtonEight.UseVisualStyleBackColor = true;
            // 
            // radioButtonSix
            // 
            this.radioButtonSix.AutoSize = true;
            this.radioButtonSix.Location = new System.Drawing.Point(13, 11);
            this.radioButtonSix.Margin = new System.Windows.Forms.Padding(1);
            this.radioButtonSix.Name = "radioButtonSix";
            this.radioButtonSix.Size = new System.Drawing.Size(50, 20);
            this.radioButtonSix.TabIndex = 2;
            this.radioButtonSix.TabStop = true;
            this.radioButtonSix.Text = "6X6";
            this.radioButtonSix.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Location = new System.Drawing.Point(25, 114);
            this.checkBoxPlayer2.Margin = new System.Windows.Forms.Padding(1);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(81, 20);
            this.checkBoxPlayer2.TabIndex = 8;
            this.checkBoxPlayer2.Text = "Player 2:";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(139, 113);
            this.textBoxPlayer2.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(138, 22);
            this.textBoxPlayer2.TabIndex = 9;
            this.textBoxPlayer2.Text = "[Computer]";
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Location = new System.Drawing.Point(139, 85);
            this.textBoxPlayer1.Margin = new System.Windows.Forms.Padding(1);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(138, 22);
            this.textBoxPlayer1.TabIndex = 7;
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(19, 11);
            this.labelBoardSize.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(74, 16);
            this.labelBoardSize.TabIndex = 0;
            this.labelBoardSize.Text = "Board size:";
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(19, 62);
            this.labelPlayers.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(56, 16);
            this.labelPlayers.TabIndex = 5;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(25, 88);
            this.labelPlayer1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(59, 16);
            this.labelPlayer1.TabIndex = 6;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(189, 142);
            this.buttonDone.Margin = new System.Windows.Forms.Padding(1);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(88, 22);
            this.buttonDone.TabIndex = 10;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonTen);
            this.panel1.Controls.Add(this.radioButtonSix);
            this.panel1.Controls.Add(this.radioButtonEight);
            this.panel1.Location = new System.Drawing.Point(28, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 34);
            this.panel1.TabIndex = 1;
            // 
            // GameSettingsForm
            // 
            this.AcceptButton = this.buttonDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 175);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.buttonDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.Text = "GameSettingsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButtonTen;
        private System.Windows.Forms.RadioButton radioButtonEight;
        private System.Windows.Forms.RadioButton radioButtonSix;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Panel panel1;
    }
}