using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DamkaGameLogic
{
    public class ButtonSquare : Button
    {
        public Square Square { get; set; }

        public ButtonSquare(Square i_Square)
        {
            Square = i_Square;
        }
    }
}
