using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 创建好友房间，暂时未添加太多功能，因为不了解需求 */

namespace WuwuChess
{
    public partial class NewRoom : Form
    {
        public NewRoom(Lobby the_lobby)
        {
            lobby = the_lobby;
            InitializeComponent();
        }

        Lobby lobby;
        private void Sure_Click(object sender, EventArgs e)  //确认创建
        {
            Board board = new Board(lobby);
            board.Show();
            lobby.Hide();  //隐藏游戏大厅
            this.Close();  //关闭本窗口
        }
    }
}
