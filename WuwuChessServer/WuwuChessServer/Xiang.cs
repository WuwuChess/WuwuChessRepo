using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WuwuChessServer
{
    class Chess_xiang : Chess
    {
        public Chess_xiang(player_type b)
        {
            base.type = chess_type.xiang;
            base.side = b;
        }
        public override bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard)
        {
            if (this.side == player_type.blue)
            {
                if (X > 4)
                {
                    return false;
                }
            }
            else
            {
                if (X < 5)
                {
                    return false;
                }
            }
            if ((X - Chess.chosenX) * (X - Chess.chosenX) + (Chess.chosenY - Y) * (Chess.chosenY - Y) != 8)
            {
                return false;
            }
            if (checkerboard[(X + Chess.chosenX) / 2][(Y + Chess.chosenY) / 2].side != player_type.blank)
            {
                return false;
            }
            return true;
        }
        public override void Put_picture()
        {
            if (base.side == player_type.red)
                this.PB.Image = global::象棋_封_.Properties.Resources.红象;
            else
                this.PB.Image = global::象棋_封_.Properties.Resources.蓝象;
        }
    }
}
