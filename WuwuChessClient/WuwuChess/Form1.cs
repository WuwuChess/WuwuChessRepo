using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        private void Registration_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
        private void Login_Click(object sender, EventArgs e)
        {
            if(Check(ID.Text,Password.Text))
            {
                User user = Get_User(ID.Text);
                Lobby lobby = new Lobby(user);
                lobby.Show();
                this.Hide();
                //this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }
    }
}
