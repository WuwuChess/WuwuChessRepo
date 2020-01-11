using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 加入好友房间 */

namespace WuwuChess
{
    public partial class Joinin : Form
    {
        public Joinin(Lobby the_lobby)
        {
            lobby = the_lobby;
            InitializeComponent();
        }

        Lobby lobby;
        private void Sure_Click(object sender, EventArgs e)  //确认加入
        {
            Board board = new Board(lobby);
            board.Show();
            lobby.Hide();  //隐藏游戏大厅
            this.Close();  //关闭本窗口
        }
    }
}
