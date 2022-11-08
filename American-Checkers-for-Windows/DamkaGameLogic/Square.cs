using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamkaGameLogic
{
    public class Square
    {
        private bool m_IsOccupied;
        private eGameToolsType m_OnSquareGameToolsType;
        private int m_Col;
        private int m_Row;

        public Square()
        {
            m_IsOccupied = false;
            m_Col = -1;
            m_Row = -1;
            m_OnSquareGameToolsType = eGameToolsType.Null;
        }

        public Square(int i_Row, int i_Col, bool i_IsOccupied, eGameToolsType i_OnSquareToolType)
        {
            m_IsOccupied = i_IsOccupied;
            m_Col = i_Col;
            m_Row = i_Row;
            m_OnSquareGameToolsType = i_OnSquareToolType;
        }

        internal int Col
        {
            get
            {
                return m_Col;
            }

            set
            {
                m_Col = value;
            }
        }

        internal int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }

        internal bool IsOccupied
        {
            get
            {
                return m_IsOccupied;
            }

            set
            {
                m_IsOccupied = value;
                if (!value)
                {
                    m_OnSquareGameToolsType = eGameToolsType.Null;
                }
            }
        }

        internal eGameToolsType GameToolsType
        {
            get
            {
                return m_OnSquareGameToolsType;
            }

            set
            {
                m_OnSquareGameToolsType = value;
                if (value != eGameToolsType.Null)
                {
                    m_IsOccupied = true;
                }
            }
        }

        internal int GetSquarePoints()
        {
            int squarePoints = 0;
            if (m_OnSquareGameToolsType == eGameToolsType.O
                || m_OnSquareGameToolsType == eGameToolsType.X)
            {
                squarePoints = 1;
            }
            else if (m_OnSquareGameToolsType == eGameToolsType.O_King
                || m_OnSquareGameToolsType == eGameToolsType.X_King)
            {
                squarePoints = 4;
            }

            return squarePoints;
        }
    }
}
