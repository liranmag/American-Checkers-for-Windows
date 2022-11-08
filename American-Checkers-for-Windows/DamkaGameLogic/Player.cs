using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamkaGameLogic
{
    public class Player
    {
        private string m_PlayerName;
        private bool m_IsComputer;
        private int m_CurrentGamePoints = 0;
        private int m_TotalGamePoints = 0;
        private bool m_PlayerRetierd = false;
        private ePlayerDirection m_PlayerDirection;
        private eGameToolsType[] m_ToolsTypes = new eGameToolsType[2]; // cant be read only becuase requier further changes in code

        public Player()
        {
            m_PlayerName = string.Empty;
            m_IsComputer = false;
            m_ToolsTypes[0] = eGameToolsType.X;
            m_ToolsTypes[1] = eGameToolsType.X_King;
        }

        public Player(string i_PlayerName)
        {
            m_PlayerName = i_PlayerName;
            m_IsComputer = false;
            m_ToolsTypes[0] = eGameToolsType.X;
            m_ToolsTypes[1] = eGameToolsType.X_King;
        }

        internal string PlayerName
        {
            get
            {
                return m_PlayerName;
            }

            set
            {
                m_PlayerName = value;
            }
        }

        internal bool PlayerRetierd
        {
            get
            {
                return m_PlayerRetierd;
            }

            set
            {
                m_PlayerRetierd = value;
            }
        }

        internal bool IsComputer
        {
            get
            {
                return m_IsComputer;
            }

            set
            {
                m_IsComputer = value;
                if (value)
                {
                    m_PlayerName = "Computer";
                }
            }
        }

        internal int CurrentGamePoints
        {
            get
            {
                return m_CurrentGamePoints;
            }

            set
            {
                m_CurrentGamePoints = value;
            }
        }

        internal int TotalGamePoints
        {
            get
            {
                return m_TotalGamePoints;
            }

            set
            {
                m_TotalGamePoints = value;
            }
        }

        internal ePlayerDirection PlayerDirection
        {
            get
            {
                return m_PlayerDirection;
            }

            set
            {
                m_PlayerDirection = value;
            }
        }

        internal eGameToolsType[] ToolsTypes
        {
            get
            {
                return m_ToolsTypes;
            }
        }

        internal void ResetCurrentGamePoints(int i_GameBoardSize)
        {
            m_CurrentGamePoints = 6;
            if (i_GameBoardSize == 8)
            {
                m_CurrentGamePoints += 6;
            }
            else if (i_GameBoardSize == 10)
            {
                m_CurrentGamePoints += 14;
            }
        }
    }
}
