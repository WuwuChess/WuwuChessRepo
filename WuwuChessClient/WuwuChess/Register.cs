using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 注册界面 */

namespace WuwuChess
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private bool Check_ID(string id)  //判断用户名是否与数据库中已有的重复或为空，未重复返回true，重复返回false
        {
            if(id != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Set_account(string id,string password, string name)  //向数据库中写入用户名、昵称和密码
        {

        }

        string yourID = "";
        private void Allow_Click(object sender, EventArgs e)  //可用性检测，防止用户名与数据库中的信息重复
        {
            if(Check_ID(ID.Text))
            {
                Allowed.BackgroundImage = Properties.Resources.勾;
                yourID = ID.Text;
            }
            else
            {
                Allowed.BackgroundImage = Properties.Resources.叉;
                yourID = "";
            }
        }

        private void OK_Click(object sender, EventArgs e)  //确认注册
        {
            if(Password.Text == "")
            {
                MessageBox.Show("请输入密码");
            }
            else
            {
                if (Password.Text == PasswordAgain.Text && yourID != "")  //密码无误且用户名验证有效
                {
                    Set_account(yourID, Password.Text, Nickname.Text);
                    MessageBox.Show("注册成功");
                    this.Close();
                }
                else if (Password.Text != PasswordAgain.Text)
                {
                    MessageBox.Show("两次输入的密码不一致");
                }
                else if (yourID == "")
                {
                    MessageBox.Show("用户名无效或未进行可用性检测");
                }
            }
        }
    }
}
