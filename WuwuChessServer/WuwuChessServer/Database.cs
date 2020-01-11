using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using WuwuChessServer;

namespace Database
{
    class SqlConnector
    {
        string connectionStringStr;
        string sqlStr;
        public SqlConnector()
        {
            connectionStringStr = "Data Source = 127.0.0.1;Database=wuwuchess;UserID = root;Password=lzjlzq33";
        }

        public bool Check_ID(string id)  //判断用户名是否与数据库中已有的重复或为空，未重复返回true，重复返回false
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
                    if (id == dt.Columns[0].ToString())//如果数据库中已经存在该用户id
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

        public void Set_account(string id, string password, string name)  //向数据库中写入用户名、昵称和密码
        {
            if (Check_ID(id))
            {
                MySqlConnection cnn = null;
                MySqlCommand cmd = null;
                sqlStr = "insert into user(id,name,password) values('" + id + "','" + name + "','" + password + "');";
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
        public bool Check(string id, string password)  //与数据库对比，判断账号密码是否正确
        {
            sqlStr = "select * from wuwuchess.user where id = " + id + " and password = " + password + ";";
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
                    return false;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return false;
            }
        }

        public User Get_User(string id)  //获取用户信息
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
                    dt1 = ds1.Tables[0];//获得数据集表record(id,win,lose,draw)
                }
                cnn.Close();
                user.id = dt.Columns[0].ToString();
                user.name = dt.Columns[1].ToString();
                user.password = dt.Columns[1].ToString();

                user.win = Convert.ToInt32(dt1.Columns[1].ToString());
                user.lose = Convert.ToInt32(dt1.Columns[2].ToString());
                user.draw = Convert.ToInt32(dt1.Columns[3].ToString());

                //user.chess_manual = dt1.Columns[4].ToString();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return user;
        }
    }
}