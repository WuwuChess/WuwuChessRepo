using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuwuChess
{
    public class User
    {
        public string name;
        public int win, lose, draw;
        public User(string str)
        {
            string[] temp = str.Split(';');
            name = temp[0];
            win = int.Parse(temp[1]);
            lose = int.Parse(temp[2]);
            draw = int.Parse(temp[3]);
        }
    }
}
