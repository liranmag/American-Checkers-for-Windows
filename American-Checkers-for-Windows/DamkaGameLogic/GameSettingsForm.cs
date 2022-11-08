using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamkaGameLogic
{
    public partial class GameSettingsForm : Form
    {
        public int s_BoardSize = 0;
        public bool s_IsComputer = false;
        public string s_Player1Name = "";
        public string s_Player2Name = "";

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private bool validateUserInputs()
        {
            bool validInputs = true;
            if (!this.radioButtonSix.Checked && !this.radioButtonEight.Checked && !this.radioButtonTen.Checked)
            {
                validInputs = false;
            }else if(this.textBoxPlayer1.Text == "" || this.textBoxPlayer2.Text == "")
            {
                validInputs = false;
            }

            return validInputs;
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (!validateUserInputs())
            {

                MessageBox.Show("invalid details please enter all details before you play", "Damka", MessageBoxButtons.OK);
                return;
            }

            this.Hide();

            s_Player1Name = this.textBoxPlayer1.Text;
            if (!this.checkBoxPlayer2.Checked)
            {
                s_IsComputer = true;
            }
            else
            {
                s_Player2Name = this.textBoxPlayer2.Text;
            }

            if (this.radioButtonSix.Checked)
            {
                s_BoardSize = 6;
            }
            else if (this.radioButtonEight.Checked)
            {
                s_BoardSize = 8;
            }
            else
            {
                s_BoardSize = 10;
            }

            this.Close();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxPlayer2.Checked)
            {
                this.textBoxPlayer2.Enabled = true;
                this.textBoxPlayer2.Text = "";
            }
            else
            {
                this.textBoxPlayer2.Enabled = false;
                this.textBoxPlayer2.Text = "[Computer]";
            }
        }
    }
}
