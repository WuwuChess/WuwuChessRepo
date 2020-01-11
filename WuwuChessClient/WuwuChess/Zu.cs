using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WuwuChess
{
    class Chess_zu : Chess
    {
        public Chess_zu(player_type b)
        {
            base.type = chess_type.zu;
            base.side = b;
        }
        public override bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard)
        {
            if (this.side == player_type.blue)//蓝方卒
            {
                if (Chess.chosenX < 5 && X - Chess.chosenX != 1)//在5行后选中的卒  
                {
                    return false;
                }
                if (Chess.chosenX > 4)//移动布数不能大于1
                {
                    if (X == Chess.chosenX && Math.Abs(Y - Chess.chosenY) != 1)
                    {
                        return false;
                    }
                    if (Y == Chess.chosenY && X - Chess.chosenX != 1)
                    {
                        return false;
                    }
                }
            }
            else//红方卒
            {
                if (Chess.chosenX > 4 && Chess.chosenX - X != 1)
                {
                    return false;
                }
                if (Chess.chosenX < 5)
                {
                    if (X == Chess.chosenX && Math.Abs(Y - Chess.chosenY) != 1)
                    {
                        return false;
                    }
                    if (Y == Chess.chosenY && Chess.chosenX - X != 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override void Put_picture()
        {
            ;
        }
    }
}
