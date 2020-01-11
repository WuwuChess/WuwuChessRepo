using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WuwuChessServer
{
    class Chess_che : Chess
    {
        public Chess_che(player_type b)//初始化车
        {
            base.type = chess_type.che;
            base.side = b;
        }
        public override bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard)
        {
            int i, j, k;
            if (Chess.chosenX == X)
            {
                i = Chess.chosenY < Y ? Chess.chosenY : Y;
                j = Chess.chosenY > Y ? Chess.chosenY : Y;
                for (k = i + 1; k < j; k++)
                {
                    if (checkerboard[X][k].side != player_type.blank)//在移动路径上有棋子情况
                    {
                        return false;
                    }
                }
            }
            if (Chess.chosenY == Y)
            {
                i = Chess.chosenX < X ? Chess.chosenX : X;
                j = Chess.chosenX > X ? Chess.chosenX : X;
                for (k = i + 1; k < j; k++)
                {
                    if (checkerboard[k][Y].side != player_type.blank)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override void Put_picture()
        {
            if (base.side == player_type.red)
                this.PB.Image = global::象棋_封_.Properties.Resources.红車;
            else
                this.PB.Image = global::象棋_封_.Properties.Resources.蓝車;
        }
    }
}
