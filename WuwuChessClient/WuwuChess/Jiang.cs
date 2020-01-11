using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WuwuChess
{
    class Chess_jiang : Chess
    {
        public Chess_jiang(player_type b)
        {
            base.type = chess_type.jiang;
            base.side = b;
        }
        public override bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard)
        {
            int i, j, k;
            if (checkerboard[X][Y].type == chess_type.jiang && Chess.chosenY == Y)//王吃王情况
            {
                i = Chess.chosenX < X ? Chess.chosenX : X;//棋子移动的起点行
                j = Chess.chosenX > X ? Chess.chosenX : X;//棋子移动的结束行
                for (k = i + 1; k < j; k++)
                {
                    if (checkerboard[k][Y].side != player_type.blank)//中间有棋子情况
                    {
                        return false;
                    }
                }
                return true;
            }
            if (this.side == player_type.blue)
            {

                if (Y < 3 || Y > 5 || X > 2)//当控制者是蓝色方  限制将的移动范围
                {
                    return false;
                }
            }
            else
            {
                if (Y < 3 || Y > 5 || X < 7)//当控制者是红色方  限制将的移动范围
                {
                    return false;
                }
            }
            if ((Chess.chosenX - X) * (Chess.chosenX - X) + (Chess.chosenY - Y) * (Chess.chosenY - Y) != 1)//点到点距离x平方加y平方
            {
                return false;
            }
            return true;
        }
        public override void Put_picture()
        {
            if (base.side == player_type.red)
                this.PB.Image = global::象棋_封_.Properties.Resources.红帥;
            else
                this.PB.Image = global::象棋_封_.Properties.Resources.蓝将;
        }
    }
}
