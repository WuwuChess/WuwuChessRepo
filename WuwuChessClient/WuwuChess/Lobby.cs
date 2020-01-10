using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 游戏大厅，进入游戏 */

namespace WuwuChess
{
    public partial class Lobby : Form
    {
        public Lobby(User user)
        {
            InitializeComponent();
            user1 = user;
        }

        User user1;

        private void Finish(object sender, FormClosingEventArgs e)  //关闭游戏大厅时，直接令整个程序结束
        {
            Application.Exit();
        }

        private void FriendStart_Click(object sender, EventArgs e)  //创建好友房间
        {
            NewRoom newroom = new NewRoom(this);
            newroom.Show();
        }

        private void FriendIn_Click(object sender, EventArgs e)  //加入好友房间
        {
            Joinin joinin = new Joinin(this);
            joinin.Show();
        }
    }
}
