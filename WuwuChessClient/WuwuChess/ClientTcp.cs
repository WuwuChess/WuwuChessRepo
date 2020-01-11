using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientTcp
{
    /// <summary>
    /// 部分代码参考WebGIS相关
    /// </summary>
    class HttpThreadHandler
    {
        public TcpListener myListener;
        public void HandleThread()
        {
            TcpClient client = myListener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();

            //请求接收报文
            byte[] data = new byte[1024];
            int bytes = stream.Read(data, 0, data.Length);
            string requestData = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine(requestData);//在控制台中查看报文内容
            //TODO:确定报文具体格式进行解析
            try
            {

            }
            catch (Exception e)
            {

            }

        }
    }
    public class Listener
    {
        //需要一些连接棋盘逻辑和其他内存数据的接口
        public string clientIp;
        public Listener()
        {

        }

    }
    public class Sender
    {
        public string listenerIp;//需要告知服务器自己的接收端ip地址
        public string serverIp;
        public string userName;
        public Sender(string listener_ip, string server_ip)
        {
            listenerIp = listener_ip;
            serverIp = server_ip;
        }
        /// <summary>
        /// 向服务器发送一个post请求
        /// </summary>
        /// <param name="postData">json格式字符串</param>
        /// <returns>返回服务器的返回内容</returns>
        string PostUrl(string postData)
        {
            string result = "";
            HttpWebRequest req = WebRequest.Create("http://" + serverIp) as HttpWebRequest;
            req.Method = "POST";
            req.Timeout = 800;
            req.ContentType = "application/json";
            byte[] data = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = data.Length;
            using(Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Stream stream = resp.GetResponseStream();
            using(StreamReader sr=new StreamReader(stream))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            stream.Close();
            resp.Close();
            req.Abort();
            return result;
        }
        /// <summary>
        /// 发送登录请求，同时告知服务器自己的接收端口号
        /// </summary>
        /// <param name="user_name">用户名</param>
        /// <param name="password_">未加密密码</param>
        /// <returns>成功登录返回200，其他状态见文件开始</returns>
        public int SendLogin(string user_name,string password_)
        {
            JObject postData = new JObject();
            postData.Add("type", "login");
            postData.Add("userName", user_name);
            postData.Add("password", password_);
            postData.Add("listenerip", listenerIp);
            string result = PostUrl(postData.ToString());
            switch (result) {
                case "200":
                    return 200;
                case "901":
                    return 901;
                default:
                    return 404;
            }
        }
        /// <summary>
        /// 发送注册请求
        /// </summary>
        /// <param name="user_name">用户名</param>
        /// <param name="nick_name">昵称</param>
        /// <param name="password_">未加密密码</param>
        /// <returns>成功注册返回200，其他状态见文件开始</returns>
        public int SendRegister(string user_name,string nick_name,string password_)
        {
            JObject postData = new JObject();
            postData.Add("type", "register");
            postData.Add("username", user_name);
            postData.Add("nickname", nick_name);
            postData.Add("password", password_);
            string result = PostUrl(postData.ToString());
            switch (result) {
                case "200":
                    return 200;
                default:
                    return 404;
            }
        }
        /// <summary>
        /// 发送搜索请求，此时应已经确定用户userName
        /// </summary>
        /// <param name="obj">分为users和tables两种，分别查询在线玩家状态和游戏房间状态</param>
        /// <returns>json格式字符串，表示玩家列表或房间状态</returns>
        public string SendSearch(string obj)
        {
            JObject postData = new JObject();
            return "";
        }
        /// <summary>
        /// 发送创建房间请求，此时应已经确定用户userName
        /// </summary>
        /// <param name="table_id">1-99的整数</param>
        /// <param name="password">当id为1-11时密码设置为空，其余可以设置密码</param>
        /// <param name="isRed">自己执先手为true</param>
        /// <returns>成功创建返回200，其他状态见文件开始</returns>
        public int SendCreate(int table_id,bool isRed,string password="")
        {
            return 200;
        }
        /// <summary>
        /// 发送准备请求，房间中第二个准备请求视为开始，此时应已经确定用户userName
        /// </summary>
        /// <param name="table_id">当前房间号</param>
        /// <returns>成功准备返回200，其他状态见文件开始</returns>
        public int SendReady(int table_id)
        {
            return 200;
        }
        /// <summary>
        /// 请求悔棋，此时应已经确定用户userName
        /// </summary>
        /// <param name="table_id">当前房间号</param>
        /// <returns>可以悔棋返回200，其他状态见文件开始</returns>
        public int SendRetract(int table_id)
        {
            return 200;
        }
        /// <summary>
        /// 发送聊天内容，此时应已经确定用户userName
        /// </summary>
        /// <param name="table_id">当前房间号</param>
        /// <param name="content">聊天内容</param>
        /// <returns>成功发送返回200，其他状态见文件开始</returns>
        public int SendChat(int table_id,string content)
        {
            return 200;
        }
        /// <summary>
        /// 发送移动子的消息，此时应已经确定用户userName
        /// </summary>
        /// <param name="table_id">当前房间号</param>
        /// <param name="sx">起点横坐标</param>
        /// <param name="sy">起点纵坐标</param>
        /// <param name="ex">终点横坐标</param>
        /// <param name="ey">终点纵坐标</param>
        /// <returns>成功发送返回200，其他状态见文件开始</returns>
        public int SendMove(int table_id,int sx,int sy,int ex,int ey)
        {
            return 200;
        }
        /// <summary>
        /// 发送检查用户名是否已经存在的消息
        /// </summary>
        /// <param name="user_name">拟定用户名</param>
        /// <returns>不存在通过检查返回200，其他状态见文件开始</returns>
        public int SendCheck(string user_name)
        {
            JObject postData = new JObject();
            postData.Add("type", "check");
            postData.Add("username", user_name);
            string result = PostUrl(postData.ToString());
            switch (result)
            {
                case "200":
                    return 200;
                case "902":
                    return 902;
                default:
                    return 404;
            }
        }
        /// <summary>
        /// 发送请求加入房间的消息
        /// </summary>
        /// <param name="table_id">房间号</param>
        /// <param name="password">房间密码可选</param>
        /// <returns>房间状态信息，由此建立本地内存房间</returns>
        public string SendJoin(int table_id, string password=""){
            return "";
        }

    }
}