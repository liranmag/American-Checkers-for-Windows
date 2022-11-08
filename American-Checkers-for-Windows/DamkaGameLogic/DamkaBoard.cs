using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamkaGameLogic
{
    public class DamkaBoard
    {
        private readonly Square[,] r_SquareBoard = null;
        private int m_BoardSize;

        public DamkaBoard(int i_BoardSize)
        {
            r_SquareBoard = new Square[i_BoardSize, i_BoardSize];
            m_BoardSize = i_BoardSize;
            ResetDamkaBoard();
        }

        internal int BoardSize
        {
            get
            {
                return m_BoardSize;
            }

            set
            {
                m_BoardSize = value;
            }
        }

        internal Square[,] SquareBoard
        {
            get
            {
                return r_SquareBoard;
            }
        }

        internal Square GetSquare(int i_Row, int i_Col)
        {
            if (i_Row < 0 || i_Col < 0 || i_Row >= BoardSize || i_Col >= BoardSize)
            {
                return null;
            }

            return SquareBoard[i_Row, i_Col];
        }

        internal void ResetDamkaBoard()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                int j = i % 2 == 0 ? 1 : 0;
                for (; j < BoardSize; j += 2)
                {
                    if (i < (BoardSize / 2) - 1)
                    {
                        SquareBoard[i, j] = new Square(i, j, true, eGameToolsType.O);
                    }
                    else if (i >= (BoardSize / 2) + 1)
                    {
                        SquareBoard[i, j] = new Square(i, j, true, eGameToolsType.X);
                    }
                    else
                    {
                        SquareBoard[i, j] = new Square(i, j, false, eGameToolsType.Null);
                    }
                }

                j = i % 2 == 1 ? 1 : 0;
                for (; j < BoardSize; j += 2)
                {
                    SquareBoard[i, j] = new Square(i, j, false, eGameToolsType.Null);
                }
            }
        }
    }
}
