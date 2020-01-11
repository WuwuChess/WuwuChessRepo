using System;
using System.Collections.Generic;
using System.Text;

namespace WuwuChessServer
{
    string connectionStringStr;
    string sqlStr;

    class register // 用户注册操作
    {
        public static string GetConnectionString()
        {
            return "Data Source = 127.0.0.1;Database=wuwuchess;UserID = root;Password=lzjlzq33";
        }

        public bool Check_ID(string id)  //判断用户名是否与数据库中已有的重复或为空，未重复返回true，重复返回false
        {
            sqlStr = "select * from wuwuchess.user where id = " + id + ";";
            MySqlConnection cnn = null;
            MySqlDataAdapter adapter = null;
            DataTable dt = null;
            connectionStringStr = GetConnectionString();
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
                connectionStringStr = GetConnectionString();
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
    }
}
