using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WuwuChess
{
    class Chess_ma : Chess
    {
        public Chess_ma(player_type b)
        {
            base.type = chess_type.ma;
            base.side = b;
        }
        public override bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard)
        {
            if (Math.Abs(Chess.chosenX - X) == 1 && Math.Abs(Chess.chosenY - Y) == 2)//移动X方向绝对值为1y方向为2
            {
                if (checkerboard[Chess.chosenX][Chess.chosenY + (Y - Chess.chosenY) / Math.Abs(Y - Chess.chosenY)].side != player_type.blank)//不是撇脚马
                {
                    return false;
                }
            }
            else if (Math.Abs(Chess.chosenX - X) == 2 && Math.Abs(Chess.chosenY - Y) == 1)//移动y方向绝对值为2x方向为1
            {
                if (checkerboard[Chess.chosenX + (X - Chess.chosenX) / Math.Abs(X - Chess.chosenX)][Chess.chosenY].side != player_type.blank)//不是撇脚马
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public override void Put_picture()
        {
            if (base.side == player_type.red)
                this.PB.Image = global::象棋_封_.Properties.Resources.红马;
            else
                this.PB.Image = global::象棋_封_.Properties.Resources.蓝马;
        }
    }
}
