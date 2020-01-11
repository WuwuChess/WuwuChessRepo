using System;
using System.Collections.Generic;
using System.Text;

namespace WuwuChessServer
{
    public class User
    {
        public string name, id, password;
        public int win, lose, draw;
        public string chess_manual;//记录棋谱
    }
}
