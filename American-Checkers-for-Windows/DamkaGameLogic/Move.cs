using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamkaGameLogic
{
    public class Move
    {
        private Square m_Start;
        private Square m_Target;
        private Player m_PlayerToPlayTheMove = null;
        private eMoveDirection m_MoveDirection = eMoveDirection.Null;

        public Move()
        {
            m_Start = new Square();
            m_Target = new Square();
            m_PlayerToPlayTheMove = new Player();
        }

        public Move(Player i_PlayerToPlayTheMove, Square i_Start, Square i_Target)
        {
            m_Start = i_Start;
            m_Target = i_Target;
            m_PlayerToPlayTheMove = i_PlayerToPlayTheMove;

            lableMoveDirection();
        }

        private void lableMoveDirection()
        {
            if (m_Start != null && m_Target != null)
            {
                int currentTurnDirection = (int)m_PlayerToPlayTheMove.PlayerDirection;

                // forward
                if ((currentTurnDirection * (m_Start.Row - m_Target.Row)) == 1
                    && Math.Abs(m_Start.Col - m_Target.Col) == 1) // forward one row, one col
                {
                    if (currentTurnDirection * (m_Target.Col - m_Start.Col) > 0) // played right.
                    {
                        m_MoveDirection = eMoveDirection.ForwardRight;
                    }
                    else // played left.
                    {
                        m_MoveDirection = eMoveDirection.ForwardLeft;
                    }
                }
                else if ((currentTurnDirection * (m_Start.Row - m_Target.Row)) == 2
                    && Math.Abs(m_Start.Col - m_Target.Col) == 2) // forward two rows, two cols
                {
                    if (currentTurnDirection * (m_Target.Col - m_Start.Col) > 0) // played right.
                    {
                        m_MoveDirection = eMoveDirection.ForwardRightEat;
                    }
                    else// played left.
                    {
                        m_MoveDirection = eMoveDirection.ForwardLeftEat;
                    }
                }

                // is square is player's king
                if (m_PlayerToPlayTheMove.ToolsTypes[1] == m_Start.GameToolsType)
                {
                    // backward
                    if ((currentTurnDirection * (m_Start.Row - m_Target.Row)) == -1
                        && Math.Abs(m_Start.Col - m_Target.Col) == 1) // backward one row, one col
                    {
                        if (currentTurnDirection * (m_Target.Col - m_Start.Col) <= 0) // played backward left.
                        {
                            m_MoveDirection = eMoveDirection.BackwardLeft;
                        }
                        else// played left.
                        {
                            m_MoveDirection = eMoveDirection.BackwardRight;
                        }
                    }
                    else if ((currentTurnDirection * (m_Start.Row - m_Target.Row)) == -2
                        && Math.Abs(m_Start.Col - m_Target.Col) == 2) // backward two rows two cols
                    {
                        if (currentTurnDirection * (m_Target.Col - m_Start.Col) <= 0) // Backward Left.
                        {
                            m_MoveDirection = eMoveDirection.BackwardLeftEat;
                        }
                        else// played Backward Right.
                        {
                            m_MoveDirection = eMoveDirection.BackwardRightEat;
                        }
                    }
                }
            }
        }

        internal Player Player
        {
            get
            {
                return m_PlayerToPlayTheMove;
            }

            set
            {
                m_PlayerToPlayTheMove = value;
            }
        }

        internal Square Start
        {
            get
            {
                return m_Start;
            }

            set
            {
                m_Start = value;
            }
        }

        internal Square Target
        {
            get
            {
                return m_Target;
            }

            set
            {
                m_Target = value;
            }
        }

        internal eMoveDirection MoveDirection
        {
            get
            {
                return m_MoveDirection;
            }

            set
            {
                m_MoveDirection = value;
            }
        }

        internal bool IsPlayerRetierd()
        {
            return m_PlayerToPlayTheMove.PlayerRetierd;
        }

        internal static bool IsSringIsMove(string i_StringToCheckIfMove)
        {
            bool isValidMove = true;
            if (i_StringToCheckIfMove.Length != 5 || i_StringToCheckIfMove.Length < 5)
            {
                isValidMove = false;
            }
            else if (i_StringToCheckIfMove[0] < 'A' || i_StringToCheckIfMove[0] > 'J')
            {
                isValidMove = false;
            }
            else if (i_StringToCheckIfMove[1] < 'a' || i_StringToCheckIfMove[1] > 'j')
            {
                isValidMove = false;
            }
            else if (i_StringToCheckIfMove[2] != '>')
            {
                isValidMove = false;
            }
            else if (i_StringToCheckIfMove[3] < 'A' || i_StringToCheckIfMove[3] > 'J')
            {
                isValidMove = false;
            }
            else if (i_StringToCheckIfMove[4] < 'A' || i_StringToCheckIfMove[4] > 'j')
            {
                isValidMove = false;
            }

            return isValidMove;
        }

        internal bool HadEat()
        {
            return m_MoveDirection == eMoveDirection.ForwardLeftEat
                || m_MoveDirection == eMoveDirection.ForwardRightEat
                || m_MoveDirection == eMoveDirection.BackwardRightEat
                || m_MoveDirection == eMoveDirection.BackwardLeftEat;
        }

        public override string ToString()
        {
            if (m_Start == null || m_Target == null)
            {
                return "Index out of range";
            }

            string moveToString = string.Empty + (char)(m_Start.Col + 'A');
            return moveToString + (char)(m_Start.Row + 'a') + '>' + (char)(m_Target.Col + 'A') + (char)(m_Target.Row + 'a');
        }
    }
}
