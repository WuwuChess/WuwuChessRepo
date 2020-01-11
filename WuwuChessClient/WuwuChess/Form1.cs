using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 主界面，用于注册/登录/查看本地棋谱 */

namespace WuwuChess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool Check(string id, string password)  //与数据库对比，判断账号密码是否正确
        {
            return true;
        }

        private User Get_User(string id)  //获取用户信息
        {
            User user = new User();
            return user;
        }
        private void Registration_Click(object sender, EventArgs e)  //注册，会调用Register窗口，在该窗口内完成注册
        {
            Register register = new Register();
            register.Show();
        }
        private void Login_Click(object sender, EventArgs e)  //登录，获取用户信息，将界面跳转为游戏大厅
        {
            if(Check(ID.Text,Password.Text))
            {
                User user = Get_User(ID.Text);
                Lobby lobby = new Lobby(user);  //在游戏大厅中显示用户信息
                lobby.Show();
                this.Hide();  //主界面只能隐藏而不能关闭，否则整个进程都会结束
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }

        private void Watch_Click(object sender, EventArgs e)  //查看本地棋谱
        {
            OpenFileDialog dia = new OpenFileDialog();
            dia.Title = "打开棋谱文件";
            dia.Filter = "棋谱文件（*.pgn）|*.pgn|所有文件(*.*)|*.*";
            dia.ShowDialog();

            if(dia.FileName != "")
            {
                ReadRecord record = new ReadRecord(dia.FileName,this);  //将本地棋谱的文件路径传入ReadRecord型窗口
                record.Show();
                this.WindowState = FormWindowState.Minimized;  //主界面最小化
            }
        }
    }
}
