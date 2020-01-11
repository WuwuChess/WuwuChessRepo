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

/* 主界面，用于注册/登录/查看本地棋谱 */

namespace WuwuChess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionStringStr;
        string sqlStr;

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionStringStr = GetConnectionString();
        }

        public static string GetConnectionString()
        {
            return "Data Source = 127.0.0.1;Database=wuwuchess;UserID = root;Password=lzjlzq33";
        }

        private bool Check(string id, string password)  //与数据库对比，判断账号密码是否正确
        {
            sqlStr = "select * from wuwuchess.user where id = " + id + " and password = "+ password+";";
            MySqlConnection cnn = null;
            MySqlDataAdapter adapter = null;
            try
            {
                cnn = new MySqlConnection(connectionStringStr);
                cnn.Open();

                adapter = new MySqlDataAdapter(sqlStr, cnn);
                DataSet ds = new DataSet();

                if (adapter.Fill(ds) > 0)
                {
                    cnn.Close();
                    return true;
                }
                else
                {
                    cnn.Close();
                    MessageBox.Show("输入的账号或密码有误，请重新输入");
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
        }

        private User Get_User(string id)  //获取用户信息
        {
            User user = new User();
            sqlStr = "select * from wuwuchess.user where id = " + id + ";";//读取user表
            string sqlStr1 = "select * from wuwuchess.record where id = " + id + ";";//读取record表
            MySqlConnection cnn = null;
            MySqlDataAdapter adapter = null;
            DataTable dt = null;

            MySqlDataAdapter adapter1 = null;
            DataTable dt1 = null;
            try
            {
                cnn = new MySqlConnection(connectionStringStr);
                cnn.Open();

                adapter = new MySqlDataAdapter(sqlStr, cnn);
                DataSet ds = new DataSet();

                adapter1 = new MySqlDataAdapter(sqlStr1, cnn);
                DataSet ds1 = new DataSet();

                if (adapter.Fill(ds) > 0)
                {
                    dt = ds.Tables[0];//获得数据集表user(id,name,password)
                }

                if (adapter1.Fill(ds1) > 0)
                {
                    dt1 = ds1.Tables[0];//获得数据集表record(id,win,lose,draw,chess_manual)
                }
                cnn.Close();
                user.id = dt.Columns[0].ToString();
                user.name = dt.Columns[1].ToString();
                user.password = dt.Columns[1].ToString();

                user.win = Convert.ToInt32(dt1.Columns[1].ToString());
                user.lose = Convert.ToInt32(dt1.Columns[2].ToString());
                user.draw = Convert.ToInt32(dt1.Columns[3].ToString());

                user.chess_manual = dt1.Columns[4].ToString();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
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
