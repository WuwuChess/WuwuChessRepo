using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WuwuChess
{
    class Chess_blank : Chess
    {
        public Chess_blank()
        {
            base.type = chess_type.blank;
            base.side = player_type.blank;
        }
        public Chess_blank(PictureBox PB)
        {
            base.type = chess_type.blank;
            base.side = player_type.blank;
            this.PB = PB;
        }
        public override bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard)
        {
            return false;
        }
        public override void Put_picture()
        {
            this.PB.Image = null;
        }
    }
}
