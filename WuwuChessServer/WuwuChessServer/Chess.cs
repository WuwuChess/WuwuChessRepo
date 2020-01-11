using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuwuChessServer
{
    struct Info
    {
        public Info(char c,int X,int Y)
        {
            id = c;
            x = X;
            y = Y;
        }
        public char id;
        public int x, y;
    }
    class Desk
    {
        public Desk()
        {
            for (int i = 0; i < 10; ++i)
                for (int j = 0; j < 10; ++j)
                    chessboard[i, j] = ' ';
            chessboard[0, 0] = chessboard[0, 8] = 'R';
            chessboard[9, 0] = chessboard[9, 8] = 'r';
            chessboard[0, 1] = chessboard[0, 7] = 'N';
            chessboard[9, 1] = chessboard[9, 7] = 'n';
            chessboard[0, 2] = chessboard[0, 6] = 'B';
            chessboard[9, 2] = chessboard[9, 6] = 'b';
            chessboard[0, 3] = chessboard[0, 5] = 'A';
            chessboard[9, 3] = chessboard[0, 5] = 'a';
            chessboard[0, 4] = 'K';
            chessboard[9, 4] = 'k';
            chessboard[2, 1] = chessboard[2, 7] = 'C';
            chessboard[7, 1] = chessboard[7, 7] = 'c';
            chessboard[3, 0] = chessboard[3, 2] = chessboard[3, 4] = chessboard[3, 6] = chessboard[3, 8] = 'P';
            chessboard[6, 0] = chessboard[6, 2] = chessboard[6, 4] = chessboard[6, 6] = chessboard[6, 8] = 'p';       
        }
        public char[,] chessboard = new char[10,9];
        public User red = null, blue = null;
        public bool redReady, blueReady;
        public List<User> audience=new List<User>();
        public List<string> comments = new List<string>();
        private Stack<Info> eaten = new Stack<Info>();
        private Stack<Info> eating = new Stack<Info>();
        public void AddComment(string s)
        {
            comments.Add(s);
            //然后发给客户端
        }
        public void RedExit(){ red = null; }
        public void BlueExit() { blue = null; }
        public void Move(int sx,int sy,int ex,int ey)
        {
            eaten.Push(new Info(chessboard[ex,ey], ex, ey));
            eating.Push(new Info(chessboard[sx,sy], sx, sy));
            chessboard[ex,ey] = chessboard[sx,sy];
            chessboard[sx,sy] = ' ';
        }
        public void Regret()
        {
            Info eaten_info = eaten.Pop();
            Info eating_info = eating.Pop();
            char cen = eaten_info.id, cing = eating_info.id;
            int xen = eaten_info.x, xing = eating_info.x;
            int yen = eaten_info.y, ying = eating_info.y;
            chessboard[xen,yen] = cen;
            chessboard[xing,ying] = cing;
        }
    }
    class Lobby
    {
        public Desk[] desks = new Desk[99];
        public List<User> users = new List<User>();
        public void CreateDesk(int num)
        {
            desks[num] = new Desk();
        }
        public void DeleteDesk(int num)
        {
            desks[num] = null;
        }
        public bool EnterDesk(User user,int num)
        {
            if (desks[num].red == null)
            {
                desks[num].red = user;
                return true;
            }
            else if (desks[num].blue == null)
            {
                desks[num].blue = user;
                return true;
            }
            else
                return false;
        }        
    }
}
