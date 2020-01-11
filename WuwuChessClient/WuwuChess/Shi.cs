using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuwuChess
{
    class Chess_shi : Chess
    {
        public Chess_shi(player_type b)
        {
            base.type = chess_type.shi;
            base.side = b;
        }
        public override bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard)
        {
            if (this.side == player_type.blue)
            {
                if (Y < 3 || Y > 5 || X > 2)//限制将的移动范围
                {
                    return false;
                }
            }
            else
            {
                if (Y < 3 || Y > 5 || X < 7)//限制将的移动范围
                {
                    return false;
                }
            }
            if (Math.Abs(X - Chess.chosenX) != 1 || Math.Abs(Chess.chosenY - Y) != 1)//只能跨一个方格
            {
                return false;
            }
            return true;
        }
        public override void Put_picture()
        {
            if (base.side == player_type.red)
                this.PB.Image = global::WuwuChess.Properties.Resources.仕;
            else
                this.PB.Image = global::WuwuChess.Properties.Resources.士;
        }
    }
}
