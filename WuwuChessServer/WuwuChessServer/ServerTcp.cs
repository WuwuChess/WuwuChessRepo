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
using Database;
/// <summary>
/// 状态码说明
/// 200 成功
/// 404 未知信息
/// 901 用户名或密码错误
/// 902 用户名重复
/// </summary>
namespace ServerTcp
{
    //部分代码参考WebGIS相关
    class HttpThreadHandler
    {
        public TcpListener myListener;
        public SqlConnector connector;
        public void HandleThread()
        {
            TcpClient client = myListener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();

            //请求接收报文
            byte[] data = new byte[1024];
            int bytes = stream.Read(data, 0, data.Length);
            string requestData = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine(requestData);//在控制台中查看报文内容

            string[] lines = requestData.Split("\n");
            if (lines.Length == 0)
                return;
            string[] first_line = lines[0].Split(" ");
            if (first_line.Length == 0 || !first_line[0].Equals("POST"))
                return;
            JObject postData = JsonConvert.DeserializeObject(lines[lines.Length - 1]) as JObject;
            string type = (string)postData["type"];
            string responseData = "";
            switch (type)
            {
                case "login":
                    {
                        string userName = (string)postData["username"];
                        string password = (string)postData["password"];
                        bool check=connector.Check(userName,password);//TODO:插入数据库查询接口
                        if (check)
                        {
                            responseData = "200";
                            string listenerIp = (string)postData["listenerip"];
                            //TODO:修改用户类中的监听ip地址
                        }
                        else
                        {
                            responseData = "901";
                        }
                    }
                    break;
                case "register":
                    {
                        string userName = (string)postData["username"];
                        string password = (string)postData["password"];
                        string nickName = (string)postData["nickname"];
                        connector.Set_account(userName, password, nickName);
                        responseData = "200";
                    }
                    break;
                case "search":
                    break;
                case "create":
                    break;
                case "ready":
                    break;
                case "retract":
                    break;
                case "chat":
                    break;
                case "move":
                    break;
                case "check":
                    {
                        string userName = (string)postData["username"];
                        bool check=connector.Check_ID(userName);
                        if (check)
                        {
                            responseData = "200";
                        }
                        else
                        {
                            responseData = "902";
                        }
                    }
                    break;
                default:
                    break;
            }
            int iStartPos = requestData.IndexOf("HTTP", 1);
            string sHttpVersion = requestData.Substring(iStartPos, 8);
            String sMimeType = "text/html";

            SendHeader(sHttpVersion, sMimeType, responseData.Length, " 200 OK", ref stream);
            SendToBrowser(Encoding.UTF8.GetBytes(responseData.ToString()), ref stream);
            stream.Close();
            client.Close();
        }
        public void SendHeader(string sHttpVersion, string sMIMEHeader, int iTotBytes, string sStatusCode, ref NetworkStream mySocket)
        {

            String sBuffer = "";

            if (sMIMEHeader.Length == 0)
            {
                sMIMEHeader = "text/html"; // 默认 text/html
            }

            sBuffer = sBuffer + sHttpVersion + sStatusCode + "\r\n";
            sBuffer = sBuffer + "Server: HttpServer\r\n";
            sBuffer = sBuffer + "Content-Type: " + sMIMEHeader + "\r\n";
            sBuffer = sBuffer + "Accept-Ranges: bytes\r\n";
            sBuffer = sBuffer + "Content-Length: " + iTotBytes + "\r\n\r\n";

            Byte[] bSendData = Encoding.ASCII.GetBytes(sBuffer);

            Console.Write(sBuffer);

            SendToBrowser(bSendData, ref mySocket);
        }

        public void SendToBrowser(Byte[] bSendData, ref NetworkStream mySocket)
        {
            try
            {
                if (mySocket.CanWrite)
                    mySocket.Write(bSendData, 0, bSendData.Length);

                Console.WriteLine("资源大小：" + bSendData.Length.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("发生错误 : {0} ", e);

            }
        }
    }

    public class Listener
    {
        //连接服务器数据库的接口
        string[] userNames;
        TcpListener listener;
        SqlConnector myConnector;
        int port = 2110;
        public Listener()
        {
            myConnector = new SqlConnector();
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
            listener.Start();
            Console.WriteLine("WuwuChess server started at http://{0}.\n", listener.LocalEndpoint);

            while (true)
            {
                while (!listener.Pending())
                {
                    Thread.Sleep(1000);
                }
                //派生线程，处理用户请求
                HttpThreadHandler handler = new HttpThreadHandler();
                handler.myListener = listener;
                handler.connector = myConnector;
                ThreadStart threadStart = new ThreadStart(handler.HandleThread);
                Thread handlerThread = new Thread(threadStart);
                handlerThread.Name = "Created at " + DateTime.Now.ToString();
                handlerThread.Start();
            }
        }
    }

    public class Sender
    {

    }
}