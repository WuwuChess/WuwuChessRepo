using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
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

        string connectionStringStr;
        string sqlStr;

        private void Register_Load(object sender, EventArgs e)
        {
            connectionStringStr = GetConnectionString();
        }

        public static string GetConnectionString()
        {
            return "Data Source = 127.0.0.1;Database=wuwuchess;UserID = root;Password=lzjlzq33";
        }

        private bool Check_ID(string id)  //判断用户名是否与数据库中已有的重复或为空，未重复返回true，重复返回false
        {
            sqlStr = "select * from wuwuchess.user where id = " + id + ";";
            MySqlConnection cnn = null;
            MySqlDataAdapter adapter = null;
            DataTable dt = null;
            try
            {
                cnn = new MySqlConnection(connectionStringStr);
                cnn.Open();

                adapter = new MySqlDataAdapter(sqlStr, cnn);
                DataSet ds = new DataSet();

                if (adapter.Fill(ds) > 0)
                {
                    dt = ds.Tables[0];
                    cnn.Close();
                    if(id == dt.Columns[0].ToString())//如果数据库中已经存在该用户id
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    cnn.Close();
                    return true;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
        }

        private void Set_account(string id,string password, string name)  //向数据库中写入用户名、昵称和密码
        {
            if(Check_ID(id))
            {
                MySqlConnection cnn = null;
                MySqlCommand cmd = null;
                sqlStr = "insert into user(id,name,password) values('"+id+"','"+name+"','"+password+"');";
                int result = -1;
                try
                {
                    cnn = new MySqlConnection(connectionStringStr);
                    cnn.Open();

                    cmd = new MySqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandText = sqlStr;

                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    System.Console.WriteLine(error.Message);
                }
            }
        }

        string yourID = "";
        private void Allow_Click(object sender, EventArgs e)  //可用性检测，防止用户名与数据库中的信息重复
        {
            string setID = ID.Text;
            bool legal = true;
            for (int i = 0;i != setID.Length;++i)
            {
                if ((setID[i] < '0' || setID[i] > '9') && (setID[i] < 'A' || setID[i] > 'Z') && (setID[i] < 'a' || setID[i] > 'z'))
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
                else
                {
                    MessageBox.Show("密码长度为6-16位");
                }
            }
        }

        
    }
}
