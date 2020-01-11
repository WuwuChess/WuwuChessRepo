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

/* 注册界面 */

namespace WuwuChess
{
    public partial class Register : Form
    {
        public Register(Sender s)
        {
            InitializeComponent();
            mySender = s;
        }

        Sender mySender;

        private void Register_Load(object sender, EventArgs e)
        {
            
        }


        private bool Check_ID(string id)  //判断用户名是否与数据库中已有的重复或为空，未重复返回true，重复返回false
        {
            int check=mySender.SendCheck(id);
            return check == 200;
        }

        string yourID = "";
        private void Allow_Click(object sender, EventArgs e)  //可用性检测，防止用户名与数据库中的信息重复
        {
            string setID = ID.Text;
            bool legal = true;
            for (int i = 0;i != setID.Length;++i)
            {
                if ((setID[i] <= '0' || setID[i] >= '9') && (setID[i] <= 'A' || setID[i] >= 'Z') && (setID[i] <= 'a' || setID[i] >= 'z'))
                    legal = false;
            }
            if (legal)
            {
                if (Check_ID(ID.Text))
                {
                    Allowed.BackgroundImage = Properties.Resources.勾;
                    yourID = ID.Text;
                }
                else
                {
                    MessageBox.Show("该用户名已存在");
                    Allowed.BackgroundImage = Properties.Resources.叉;
                    yourID = "";
                }
            }
            else
            {
                MessageBox.Show("请使用英文字母或数字");
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
                if (Password.Text.Length <= 16 && Password.Text.Length >= 6)
                {
                    if (Password.Text == PasswordAgain.Text && yourID != "")  //密码无误且用户名验证有效
                    {
                        mySender.SendRegister(yourID, Nickname.Text, Password.Text);
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
                else
                {
                    MessageBox.Show("密码长度为6-16位");
                }
            }
        }

        
    }
}
