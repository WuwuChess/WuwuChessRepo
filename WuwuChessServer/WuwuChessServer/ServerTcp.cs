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

    }
    public class Sender
    {

    }
}