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

namespace ServerTcp
{
    //部分代码参考WebGIS相关
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
            catch(Exception e)
            {

            }

        }
    }

    public class Listener
    {
        //连接服务器数据库的接口
        string[] userNames;
        TcpListener listener;
        int port = 2110;
        public Listener()
        {
            listener = new TcpListener(IPAddress("127.0.0.1"), port);
            listener.Start();
            Console.WriteLine("WuwuChess server started at http://{0}.\n", myHttpListener.LocalEndpoint);

            while (true)
            {
                while (!listener.Pending())
                {
                    Thread.Sleep(1000);
                }
                //派生线程，处理用户请求
                HttpThreadHandler handler = new HttpThreadHandler();
                handler.myListener = listener;
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