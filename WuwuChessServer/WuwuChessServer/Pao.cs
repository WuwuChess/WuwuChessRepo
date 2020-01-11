using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WuwuChessServer
{
    class Chess_pao : Chess
    {
        public Chess_pao(player_type b)
        {
            base.type = chess_type.pao;
            base.side = b;
        }
        public override bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard)
        {
            int p = 0;//用于记录路径上的棋子数
            int i, j, k;
            if (Chess.chosenX == X)//同列移动情况
            {
                i = Chess.chosenY < Y ? Chess.chosenY : Y;//定起始点
                j = Chess.chosenY > Y ? Chess.chosenY : Y;//定起始点
                p = 0;
                for (k = i + 1; k < j; k++)
                {
                    if (checkerboard[X][k].side != player_type.blank)
                    {
                        p++;//移动路径上有棋子的个数
                    }
                }
                if (p > 1)
                {
                    return false;
                }
            }


            else if (Chess.chosenY == Y)//同行移动情况
            {
                i = Chess.chosenX < X ? Chess.chosenX : X;
                j = Chess.chosenX > X ? Chess.chosenX : X;
                p = 0;
                for (k = i + 1; k < j; k++)
                {
                    if (checkerboard[k][Y].side != player_type.blank)
                    {
                        p++;
                    }
                }
                if (p > 1)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            if (p == 0 && checkerboard[X][Y].side != player_type.blank)//中间没有棋子炮不能吃子
            {
                return false;
            }
            if (p == 1 && checkerboard[X][Y].side == player_type.blank)//中间有棋子但是不能打空炮
            {
                return false;
            }
            return true;
        }
        public override void Put_picture()
        {
            if (base.side == player_type.red)
                this.PB.Image = global::象棋_封_.Properties.Resources.红炮;
            else
                this.PB.Image = global::象棋_封_.Properties.Resources.蓝炮;
        }
    }
}
