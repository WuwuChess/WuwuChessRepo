using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientTcp;

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
        Sender mySender;
        Lobby lobby;
        private void Sure_Click(object sender, EventArgs e)  //确认加入
        {
            string result = mySender.SendJoin(int.Parse(Number.Text));
            if (result.Equals("0") || result.Equals("1"))
            {
            Board board = new Board(lobby,result);
            board.Show();
            lobby.Hide();  //隐藏游戏大厅
            this.Close();  //关闭本窗口

            }
            else
            {
                MessageBox.Show("加入失败");
            }
        }
    }
}
