using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamkaGameLogic
{
    public class Game
    {
        private readonly Player[] r_Players = new Player[2];
        private DamkaBoard m_Board;
        private Player m_CurrentTurnPlayer;
        private Player m_PreviousTurnPlayer = null;
        private Move m_LastMove = null;
        private eGameStatus m_Status;

        public Game(Player i_Player1, Player i_Player2, DamkaBoard i_DamkaBoard)
        {
            m_Board = i_DamkaBoard;
            m_Board.ResetDamkaBoard();
            r_Players[0] = i_Player1;
            r_Players[1] = i_Player2;
            r_Players[0].PlayerDirection = ePlayerDirection.BottomUp;
            r_Players[1].PlayerDirection = ePlayerDirection.TopDown;
            r_Players[1].ToolsTypes[0] = eGameToolsType.O;
            r_Players[1].ToolsTypes[1] = eGameToolsType.O_King;
            m_CurrentTurnPlayer = i_Player1;
            m_Status = eGameStatus.Active;
            foreach (Player player in r_Players)
            {
                player.ResetCurrentGamePoints(m_Board.BoardSize);
            }
        }

        internal void InitializNewGame()
        {
            m_CurrentTurnPlayer = r_Players[0];
            m_PreviousTurnPlayer = null;
            foreach (Player player in r_Players)
            {
                player.ResetCurrentGamePoints(m_Board.BoardSize);
                player.PlayerRetierd = false;
            }

            m_Board.ResetDamkaBoard();
            m_Status = eGameStatus.Active;
            m_LastMove = null;
        }

        internal Player[] Players
        {
            get
            {
                return r_Players;
            }
        }

        internal Player CurrentTurnPlayer
        {
            get
            {
                return m_CurrentTurnPlayer;
            }

            set
            {
                m_CurrentTurnPlayer = value;
            }
        }

        internal Player PreviousTurnPlayer
        {
            get
            {
                return m_PreviousTurnPlayer;
            }

            set
            {
                m_PreviousTurnPlayer = value;
            }
        }

        internal Move LastMove
        {
            get
            {
                return m_LastMove;
            }

            set
            {
                m_LastMove = value;
            }
        }

        internal eGameStatus Status
        {
            get
            {
                return m_Status;
            }

            set
            {
                m_Status = value;
            }
        }

        internal DamkaBoard Board
        {
            get
            {
                return m_Board;
            }
        }

        private void checkBoardAndUpdateGameStatus()
        {
            if (r_Players[0].CurrentGamePoints == 0) // If player1 has no game tools
            {
                m_Status = eGameStatus.O_WIN; // Player2 wins
            }
            else if (r_Players[1].CurrentGamePoints == 0)
            {
                m_Status = eGameStatus.X_WIN;
            }

            // If there are no legal moves for any of the players -> Game status is tie, else -> game status does not change
            for (int i = 0; i < Board.BoardSize; i++)
            {
                for (int j = 0; j < Board.BoardSize; j++)
                {
                    if (hasAnotherPossibleMoveFrom(Board.GetSquare(i, j)))
                    {
                        return;
                    }
                }
            }

            m_Status = eGameStatus.Tie;
        }
        
        internal void Move(Move i_Move)
        {
            if (CurrentTurnPlayer.IsComputer)
            {
                i_Move = AI.GetBestComputerMove(this);
                if (i_Move == null)
                {
                    switchTurns();
                    return;
                }
            }

            // move start to target square
            i_Move.Target.GameToolsType = isMoveMakeYouKing(i_Move) ? CurrentTurnPlayer.ToolsTypes[1] : i_Move.Start.GameToolsType;
            CurrentTurnPlayer.CurrentGamePoints += isMoveMakeYouKing(i_Move) ? 3 : 0;
            i_Move.Start.IsOccupied = false;

            if (i_Move.HadEat())
            {
                Square squarePlayerJumpAbove = getEatenSquare(i_Move);
                PreviousTurnPlayer.CurrentGamePoints -= squarePlayerJumpAbove.GetSquarePoints();
                squarePlayerJumpAbove.IsOccupied = false;
            }

            // check for end in game and update game status
            this.checkBoardAndUpdateGameStatus();

            // switch turns
            if (!(i_Move.HadEat() && this.hasAnotherPossibleEatFrom(i_Move.Target)))
            {
                switchTurns();
            }

            // update lastMove
            this.m_LastMove = i_Move;
        }

        private bool isMoveMakeYouKing(Move i_Move)
        {
            bool isMoveMakeYouKing = false;
            if (((i_Move.Start.GameToolsType != eGameToolsType.O_King
               && i_Move.Start.GameToolsType != eGameToolsType.X_King)
              && (i_Move.Player.PlayerDirection == ePlayerDirection.BottomUp && i_Move.Target.Row == 0))
             || (i_Move.Player.PlayerDirection == ePlayerDirection.TopDown && i_Move.Target.Row == m_Board.BoardSize - 1))
            {
                isMoveMakeYouKing = true;
            }

            return isMoveMakeYouKing;
        }

        private void switchTurns()
        {
            m_PreviousTurnPlayer = m_CurrentTurnPlayer;
            m_CurrentTurnPlayer = m_CurrentTurnPlayer == r_Players[0] ? r_Players[1] : r_Players[0];
        }

        private bool hasAnotherPossibleEatFrom(Square i_Start)
        {
            Move optionalEatMove1 = new Move(CurrentTurnPlayer, i_Start, m_Board.GetSquare(i_Start.Row + 2, i_Start.Col + 2));
            Move optionalEatMove2 = new Move(CurrentTurnPlayer, i_Start, m_Board.GetSquare(i_Start.Row - 2, i_Start.Col + 2));
            Move optionalEatMove3 = new Move(CurrentTurnPlayer, i_Start, m_Board.GetSquare(i_Start.Row + 2, i_Start.Col - 2));
            Move optionalEatMove4 = new Move(CurrentTurnPlayer, i_Start, m_Board.GetSquare(i_Start.Row - 2, i_Start.Col - 2));

            return IsValidMove(optionalEatMove1) || IsValidMove(optionalEatMove2)
                || IsValidMove(optionalEatMove3) || IsValidMove(optionalEatMove4);
        }

        private bool hasAnotherPossibleMoveFrom(Square i_Start)
        {
            bool hasPossibleMove = false;
            foreach (Square square in m_Board.SquareBoard)
            {
                Move optionalMove = new Move(CurrentTurnPlayer, i_Start, square);
                hasPossibleMove = IsValidMove(optionalMove) || hasPossibleMove;
            }

            return hasPossibleMove;
        }

        internal bool IsValidMove(Move i_Move)
        {
            if (m_CurrentTurnPlayer.PlayerRetierd)
            {
                return true;
            }

            // implements rest valids move
            int currentTurnDirection = (int)CurrentTurnPlayer.PlayerDirection; // top down is -1 and buttom up is 1
            bool isValidMove = true;

            // Check if the squares are legals, and avoiding index out of bound
            if (i_Move == null || i_Move.Start == null || i_Move.Target == null)
            {
                isValidMove = false;
            }
            else if (i_Move.Start.Row >= m_Board.BoardSize || i_Move.Start.Row < 0
                || i_Move.Start.Col >= m_Board.BoardSize || i_Move.Start.Col < 0
                || i_Move.Target.Row >= m_Board.BoardSize || i_Move.Target.Row < 0
                || i_Move.Target.Col >= m_Board.BoardSize || i_Move.Target.Col < 0)
            {
                isValidMove = false;
            }
            else if (i_Move.MoveDirection == eMoveDirection.Null)
            {
                isValidMove = false;
            }
            else if (i_Move.Target.IsOccupied)
            {
                isValidMove = false;
            }
            else if (!(i_Move.Start.GameToolsType == CurrentTurnPlayer.ToolsTypes[0]
                    || i_Move.Start.GameToolsType == CurrentTurnPlayer.ToolsTypes[1]))
            {
                isValidMove = false;
            }
            else
            {
                Square theSquarePlayerJumpAbove = getEatenSquare(i_Move);
                if (theSquarePlayerJumpAbove != null
                    && (!theSquarePlayerJumpAbove.IsOccupied
                    || (theSquarePlayerJumpAbove.IsOccupied && (theSquarePlayerJumpAbove.GameToolsType == CurrentTurnPlayer.ToolsTypes[0]
                    || theSquarePlayerJumpAbove.GameToolsType == CurrentTurnPlayer.ToolsTypes[1]))))
                {
                    isValidMove = false;
                }
            }

            return isValidMove;
        }

        private Square getEatenSquare(Move i_Move)
        {
            Square eatenSquare = null;
            int currentTurnDirection = (int)CurrentTurnPlayer.PlayerDirection;

            if (i_Move.MoveDirection == eMoveDirection.ForwardRightEat)
            {
                eatenSquare = m_Board.SquareBoard[i_Move.Start.Row - currentTurnDirection, i_Move.Start.Col + currentTurnDirection];
            }
            else if (i_Move.MoveDirection == eMoveDirection.ForwardLeftEat)
            {
                eatenSquare = m_Board.SquareBoard[i_Move.Start.Row - currentTurnDirection, i_Move.Start.Col - currentTurnDirection];
            }
            else if (i_Move.MoveDirection == eMoveDirection.BackwardRightEat)
            {
                eatenSquare = m_Board.SquareBoard[i_Move.Start.Row + currentTurnDirection, i_Move.Start.Col + currentTurnDirection];
            }
            else if (i_Move.MoveDirection == eMoveDirection.BackwardLeftEat)
            {
                eatenSquare = m_Board.SquareBoard[i_Move.Start.Row + currentTurnDirection, i_Move.Start.Col - currentTurnDirection];
            }

            return eatenSquare;
        }

        internal void PlayerRetired()
        {
            // in correspond to the current player turn, update status game to ?_Retired
            if (CurrentTurnPlayer.PlayerDirection == ePlayerDirection.BottomUp)
            {
                Status = eGameStatus.X_Retired;
            }
            else
            {
                Status = eGameStatus.O_Retired;
            }
        }

        internal void EndCurrentGame()
        {
            if (Status == eGameStatus.X_Retired || Status == eGameStatus.O_WIN)
            {
                r_Players[1].TotalGamePoints += Math.Abs(r_Players[1].CurrentGamePoints - r_Players[0].CurrentGamePoints);
            }
            else if (Status == eGameStatus.O_Retired || Status == eGameStatus.X_WIN)
            {
                r_Players[0].TotalGamePoints += Math.Abs(r_Players[0].CurrentGamePoints - r_Players[1].CurrentGamePoints);
            }
        }

        internal bool IsGameEnded()
        {
            return m_Status != eGameStatus.Active;
        }
    }
}