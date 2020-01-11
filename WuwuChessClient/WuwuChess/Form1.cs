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

/* 主界面，用于注册/登录/查看本地棋谱 */

namespace WuwuChess
{
    public partial class Form1 : Form
    {
        Sender mySender;
        public Form1()
        {
            InitializeComponent();
            mySender = new Sender("", ":2110");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Registration_Click(object sender, EventArgs e)  //注册，会调用Register窗口，在该窗口内完成注册
        {
            Register register = new Register(mySender);
            register.Show();
        }
        private void Login_Click(object sender, EventArgs e)  //登录，获取用户信息，将界面跳转为游戏大厅
        {
            int check = mySender.SendLogin(ID.Text,Password.Text);
            if (check == 200)
            {
                Lobby lobby = new Lobby(ID.Text,mySender);//在游戏大厅中显示用户信息
                lobby.Show();
                this.Hide();//主界面只能隐藏而不能关闭，否则整个进程都会结束
            }
            else if(check==901)
            {
                MessageBox.Show("用户名或密码错误");
            }
            else
            {
                MessageBox.Show("未知错误");
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
