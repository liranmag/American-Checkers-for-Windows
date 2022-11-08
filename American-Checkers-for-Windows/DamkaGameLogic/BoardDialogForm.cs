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
    public partial class BoardDialogForm : Form
    {
        public Move NextMove { get; set; }
        private Square m_StartSqure;
        private readonly ButtonSquare[,] r_Buttons;
        private Game m_Game; // cant be read only becuase requier further changes in code
        private int m_NumberOfButtonsPushed = 0;


        public BoardDialogForm(Game i_GameEngine, bool i_IsInvalidMoveMade)
        {

            m_Game = i_GameEngine;

            InitializeComponent();

            updatePlayersLabels(i_GameEngine);

            r_Buttons = new ButtonSquare[m_Game.Board.BoardSize, m_Game.Board.BoardSize];
            InitButtonBoard();

            if (i_IsInvalidMoveMade)
            {
                MessageBox.Show("Invalid Move! Please try again", "Damka", MessageBoxButtons.OK);
            }

        }

        private void updatePlayersLabels(Game i_GameEngine)
        {
            this.labelPlayer1Points.Text = i_GameEngine.Players[0].TotalGamePoints.ToString();
            this.labelPlayer2Points.Text = i_GameEngine.Players[1].TotalGamePoints.ToString();
            this.labelPlayer1Name.Text = i_GameEngine.Players[0].PlayerName + ": ";
            this.labelPlayer2Name.Text = i_GameEngine.Players[1].PlayerName + ": ";
        }

        internal void InitButtonBoard()
        {
            int buttonWidth = panelBoardGame.Width / m_Game.Board.BoardSize;
            int buttonHeight = (panelBoardGame.Height - 5) / m_Game.Board.BoardSize;
            int buttonRow = panelBoardGame.Location.Y;
            int buttonCol;

            for (int i = 0; i < m_Game.Board.BoardSize; i++)
            {
                buttonCol = panelBoardGame.Location.X;
                for (int j = 0; j < m_Game.Board.BoardSize; j++)
                {
                    r_Buttons[i, j] = new ButtonSquare(m_Game.Board.SquareBoard[i, j]);
                    r_Buttons[i, j].Text = ((char)m_Game.Board.SquareBoard[i, j].GameToolsType).ToString();
                    r_Buttons[i, j].Location = new Point(buttonCol, buttonRow);
                    r_Buttons[i, j].Size = new Size(buttonWidth, buttonHeight);
                    r_Buttons[i, j].FlatAppearance.BorderColor = Color.DimGray;
                    r_Buttons[i, j].FlatAppearance.BorderSize = 4;
                    panelBoardGame.Controls.Add(r_Buttons[i, j]);
                    this.Controls.Add(r_Buttons[i, j]);
                    buttonCol += buttonWidth;
                }
                buttonRow += buttonHeight;

            }

            for (int row = 0; row < m_Game.Board.BoardSize; row++)
            {
                for (int col = 0; col < m_Game.Board.BoardSize; col++)
                {
                    if ((row + col) % 2 == 0)
                    {
                        r_Buttons[row, col].Enabled = false;
                        r_Buttons[row, col].BackColor = Color.DimGray;
                    }
                    else
                    {
                        r_Buttons[row, col].BackColor = Color.White;

                    }


                    r_Buttons[row, col].Click += buttonPlayerChosenSquare_Click;
                }
            }
        }

        private void buttonPlayerChosenSquare_Click(object sender, EventArgs e)
        {
            ButtonSquare clickedButton = sender as ButtonSquare;

            if (m_NumberOfButtonsPushed == 0)
            {
                if (clickedButton.Square.GameToolsType != m_Game.CurrentTurnPlayer.ToolsTypes[0]
                && clickedButton.Square.GameToolsType != m_Game.CurrentTurnPlayer.ToolsTypes[1])
                {
                    MessageBox.Show("You can only choose your own player!", "Damka", MessageBoxButtons.OK);
                }
                else
                {
                    m_NumberOfButtonsPushed++;
                    clickedButton.BackColor = Color.Azure;
                    m_StartSqure = clickedButton.Square;

                }
            }
            else
            {
                if (clickedButton.BackColor == Color.AliceBlue)
                {
                    m_NumberOfButtonsPushed = 0;
                    clickedButton.BackColor = Color.White;
                    return;
                }

                NextMove = new Move(m_Game.CurrentTurnPlayer, m_StartSqure, clickedButton.Square);
                this.Hide();
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                m_Game.PlayerRetired();
            }
            base.OnFormClosing(e);

        }

        private void BoardDialogForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBoardGame_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
