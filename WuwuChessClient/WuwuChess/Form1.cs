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

        private bool login(string id, string password)  //与数据库对比，判断账号密码是否正确
        {
            return true;
        }
        private void Registration_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if(login(ID.Text,Password.Text))
            {

            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }
    }
}
