using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DamkaGameLogic
{
    public class OperateGame
    {
        public static void StartNewGame()
        {
            GameSettingsForm initialDialog = new GameSettingsForm();
            initialDialog.ShowDialog();

            Player player1 = new Player(initialDialog.s_Player1Name);
            Player player2 = new Player(initialDialog.s_Player2Name);
            
            if (initialDialog.s_IsComputer)
            {
                player2.IsComputer = true;
            }

            DamkaBoard gameBoard = new DamkaBoard(initialDialog.s_BoardSize);
            Game gameEngine = new Game(player1, player2, gameBoard);

            Play(gameEngine);
        }

        internal static void Play(Game io_GameEngine)
        {
            bool isUserDesiredToPlay = true;
            Move nextMove = new Move();
            BoardDialogForm moveDialog;
            while (isUserDesiredToPlay)
            {
                io_GameEngine.InitializNewGame();

                while (!io_GameEngine.IsGameEnded())
                {
                    bool invalidMove = false;

                    while (!(io_GameEngine.IsValidMove(nextMove) || io_GameEngine.CurrentTurnPlayer.IsComputer))
                    {
                        if (!io_GameEngine.CurrentTurnPlayer.IsComputer)
                        {
                            moveDialog = new BoardDialogForm(io_GameEngine, invalidMove);
                            moveDialog.ShowDialog();
                            nextMove = moveDialog.NextMove;
                        }

                        if (io_GameEngine.IsGameEnded())
                        {
                            break;
                        }
                    }

                    if (!io_GameEngine.IsGameEnded())
                    {
                        io_GameEngine.Move(nextMove);
                    }
                }

                io_GameEngine.EndCurrentGame();

                isUserDesiredToPlay = endCurrentGameAndAskUser(io_GameEngine);

            }

        }

        private static bool endCurrentGameAndAskUser(Game i_GameEngine)
        {

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            string messageToShow = "";

            if (i_GameEngine.Status == eGameStatus.X_WIN)
            {
                messageToShow = string.Format("Congratulations {0} you are the winner !!", i_GameEngine.Players[0].PlayerName);
            }
            else if (i_GameEngine.Status == eGameStatus.O_WIN)
            {
                messageToShow = string.Format("Congratulations {0} you are the winner !!", i_GameEngine.Players[1].PlayerName);
            }
            else if (i_GameEngine.Status == eGameStatus.Tie)
            {
                messageToShow = string.Format("Oh no ! it's a Tie !");
            }
            else if (i_GameEngine.Status == eGameStatus.X_Retired)
            {
                messageToShow = string.Format("{0} Has Retired!", i_GameEngine.Players[0].PlayerName);
            }
            else if (i_GameEngine.Status == eGameStatus.O_Retired)
            {
                messageToShow = string.Format("{0} Has Retired!", i_GameEngine.Players[1].PlayerName);
            }

            messageToShow += "\nAnother Round?";
            result = MessageBox.Show(messageToShow, "Damka", buttons);
            return result == DialogResult.Yes ? true : false;
        }
    
    }
}
