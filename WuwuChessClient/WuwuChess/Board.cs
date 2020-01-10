using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 对局界面 */

namespace WuwuChess
{
    public partial class Board : Form
    {
        public Board(Lobby the_lobby)
        {
            lobby = the_lobby;
            InitializeComponent();
        }

        Lobby lobby;
        private int tx(int x)  //将1~9的横坐标转换为picturebox上的横坐标
        {
            return -38 + 80 * x;
        }

        private int ty(int y) //将1~10的棋盘纵坐标转换为picturebox上的纵坐标
        {
            return 805 - 80 * y;
        }

        private void Finish(object sender, FormClosingEventArgs e)  //关闭对局房间
        {
            lobby.Show();  //再次显示游戏大厅
        }
    }
}
