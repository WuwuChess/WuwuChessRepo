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
    public class Listener
    {

    }
    public class Sender
    {
        public string serverIp;
        public string userName;
        public Sender(string server_ip)
        {
            serverIp = server_ip;
        }

        /// <summary>
        /// 发送登录请求
        /// </summary>
        /// <param name="user_name">用户名</param>
        /// <param name="password_">未加密密码</param>
        /// <returns>成功登录返回200，其他状态见文件开始</returns>
        public int SendLogin(string user_name,string password_)
        {
            return 200;
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
            return 200;
        }
        /// <summary>
        /// 发送搜索请求，此时应已经确定用户userName
        /// </summary>
        /// <param name="obj">分为users和tables两种，分别查询在线玩家状态和游戏房间状态</param>
        /// <returns>json格式字符串，表示玩家列表或房间状态</returns>
        public string SendSearch(string obj)
        {
            return "";
        }
        /// <summary>
        /// 发送创建房间请求，此时应已经确定用户userName
        /// </summary>
        /// <param name="table_id">1-99的整数</param>
        /// <param name="password">当id为1-11时密码设置为空，其余可以设置密码</param>
        /// <param name="isRed">自己执先手为true</param>
        /// <returns>成功创建返回200，其他状态见文件开始</returns>
        public int SendCreate(int table_id,string password,bool isRed)
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
        //public int SendMove(int table_id,Point a,Point b)

    }
}