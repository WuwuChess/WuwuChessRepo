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

/* 游戏大厅，进入游戏 */

namespace WuwuChess
{
    public partial class Lobby : Form
    {
        public Lobby(string username,Sender s)
        {
            InitializeComponent();
            userName = username;
            mySender = s;
            string[] result=mySender.SendSearch("users").Split('\n');
            for(int i = 0; i < result.Length; ++i)
            {
                users.Add(new User(result[i]));
            }
        }

        string userName;
        public Sender mySender;
        public List<User> users=new List<User>();
        public string tables;

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
