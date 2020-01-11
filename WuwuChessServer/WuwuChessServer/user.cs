using System;
using System.Collections.Generic;
using System.Text;

namespace WuwuChessServer
{
    public class User
    {
        public string name, id, listenerIp;
        public int win, lose, draw;
        public string chess_manual;//记录棋谱
        public User(string name_,string id_,string listener_ip="")
        {
            name = name_;
            id = id_;
            listenerIp = listener_ip;
        }
        override public string ToString()
        {
            return name + ";" + Convert.ToString(win) + ";" + Convert.ToString(lose) + ";" + Convert.ToString(draw);
        }
    }
}
