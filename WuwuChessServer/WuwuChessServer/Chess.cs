using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WuwuChessServer
{
    enum chess_type
    {
        blank,
        jiang,
        che,
        ma,
        pao,
        xiang,
        zu,
        shi
    };//棋类的枚举类型
    enum player_type
    {
        blank,
        red,
        blue,
    };//玩家类别的枚举类型
    abstract class Chess
    {
        private static Chess[] cover_blue = new Chess[16];
        private static int r = 0;
        private static Chess[] cover_red = new Chess[16];
        private static int f = 0;
        protected static int chosenX;
        protected static int chosenY;
        public static bool chosen;
        static int n = 1;
        public static player_type control_side;
        public chess_type type;
        public player_type side;
        public Chess()
        {
            side = player_type.blank;
            type = chess_type.blank;
        }
        public abstract bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard);
        public abstract void Put_picture();
        //public void Assignment(chess_type ct, player_type pt, Image pic)
        //{
        //    side = pt;
        //    type = ct;
        //    PB.Image = pic;
        //}//给棋子赋值
        public void Bg_Tored()
        {
            this.PB.BackColor = Color.Red;
        }//背景变为红色
        public void Bg_Toblank()
        {
            this.PB.BackColor = Color.Transparent;
        }//背景变为白色
        private void Chess_Toblank(ref Chess a, PictureBox PB)
        {
            this.Bg_Toblank();
            this.PB.Image = null;
            a = new Chess_blank(PB);
        }//棋子属性清空
        public static void Clearground(Main f, ref Chess[][] checkerboard)//布置战场
        {
            int i, j;
            Control[] col_blue = null;//控件列表，后面要删除
            Control[] col_red = null;
            Chess.control_side = player_type.red;
            Chess.chosen = false;
            //*********************初始化被吃区**************//
            for (i = 0; i < 16; i++)
            {
                cover_blue[i] = new Chess_blank();
                cover_red[i] = new Chess_blank();
            }
            for (i = 1; i <= 16; i++)
            {
                col_blue = f.Controls.Find("Cover_PBox_blue" + i, false);//检索控件
                col_red = f.Controls.Find("Cover_PBox_red" + i, false);//检索控件
                cover_blue[i - 1].PB = col_blue[0] as PictureBox;
                cover_red[i - 1].PB = col_red[0] as PictureBox;
            }
            //*********************初始话被吃区**************//

            //*****************构建棋盘********************//
            checkerboard = new Chess[10][];
            for (i = 0; i < 10; i++)
            {
                checkerboard[i] = new Chess[9];//10行9列
            }
            for (i = 0; i < 10; i++)
                for (j = 0; j < 9; j++)
                {
                    checkerboard[i][j] = new Chess_blank();
                }
            checkerboard[0][0] = new Chess_che(player_type.blue);
            checkerboard[0][1] = new Chess_ma(player_type.blue);
            checkerboard[0][2] = new Chess_xiang(player_type.blue);
            checkerboard[0][3] = new Chess_shi(player_type.blue);
            checkerboard[0][4] = new Chess_jiang(player_type.blue);
            checkerboard[0][5] = new Chess_shi(player_type.blue);
            checkerboard[0][6] = new Chess_xiang(player_type.blue);
            checkerboard[0][7] = new Chess_ma(player_type.blue);
            checkerboard[0][8] = new Chess_che(player_type.blue);
            checkerboard[2][1] = new Chess_pao(player_type.blue);
            checkerboard[2][7] = new Chess_pao(player_type.blue);
            checkerboard[3][0] = new Chess_zu(player_type.blue);
            checkerboard[3][2] = new Chess_zu(player_type.blue);
            checkerboard[3][4] = new Chess_zu(player_type.blue);
            checkerboard[3][6] = new Chess_zu(player_type.blue);
            checkerboard[3][8] = new Chess_zu(player_type.blue);


            checkerboard[6][0] = new Chess_zu(player_type.red);
            checkerboard[6][2] = new Chess_zu(player_type.red);
            checkerboard[6][4] = new Chess_zu(player_type.red);
            checkerboard[6][6] = new Chess_zu(player_type.red);
            checkerboard[6][8] = new Chess_zu(player_type.red);
            checkerboard[7][1] = new Chess_pao(player_type.red);
            checkerboard[7][7] = new Chess_pao(player_type.red);
            checkerboard[9][0] = new Chess_che(player_type.red);
            checkerboard[9][1] = new Chess_ma(player_type.red);
            checkerboard[9][2] = new Chess_xiang(player_type.red);
            checkerboard[9][3] = new Chess_shi(player_type.red);
            checkerboard[9][4] = new Chess_jiang(player_type.red);
            checkerboard[9][5] = new Chess_shi(player_type.red);
            checkerboard[9][6] = new Chess_xiang(player_type.red);
            checkerboard[9][7] = new Chess_ma(player_type.red);
            checkerboard[9][8] = new Chess_che(player_type.red);
            for (i = 0; i < 10; i++)
                for (j = 0; j < 9; j++)//control 是一个存放控件类的容器
                {
                    Control[] col = f.Controls.Find("pictureBox" + (i * 9 + j + 1), false);//检索控件
                    checkerboard[i][j].PB = col[0] as PictureBox;//类型转换
                    checkerboard[i][j].PB.Location = new Point(170 + 60 * j, 57 * i);
                }
            for (i = 0; i < 10; i++)
                for (j = 0; j < 9; j++)
                {
                    checkerboard[i][j].Put_picture();
                }
            //*****************构建棋盘********************//
        }
        protected static int Getx(object sender)
        {
            int x;
            string name = (sender as PictureBox).Name;
            string number = name.Substring(10);//在字符串中从指定位开始检索（这里是在x后也就是picturebox控件ID不同的尾号）
            int index = Convert.ToInt32(number);
            x = (index - 1) / 9;//列
            return x;
        }
        protected static int Gety(object sender)
        {
            int y;
            string name = (sender as PictureBox).Name;
            string number = name.Substring(10);//在字符串中从指定位开始检索（这里是在x后也就是picturebox控件ID不同的尾号）
            int index = Convert.ToInt32(number);
            y = (index - 1) % 9;//行
            return y;
        }
        public static void Nochozen_dispose(object sender, Chess[][] checkerboard)
        {
            Chess.chosen = true;
            chosenX = Chess.Getx(sender);
            chosenY = Chess.Gety(sender);
            if (checkerboard[chosenX][chosenY].side != control_side)//选择的不是当前应该走棋的一方
            {
                chosen = false;
                return;
            }
            if (checkerboard[chosenX][chosenY].side != player_type.blank)//选择的不是空白
                checkerboard[chosenX][chosenY].Bg_Tored();
            return;
        }
        public static bool Chozen_dispose(object sender, Chess[][] checkerboard)
        {
            Chess.chosen = false;
            int x = Getx(sender);
            int y = Gety(sender);
            if (checkerboard[chosenX][chosenY].side == checkerboard[x][y].side)//移动位置与选择位是同一阵营
            {
                checkerboard[chosenX][chosenY].Bg_Toblank();
                return false;
            }
            if (checkerboard[chosenX][chosenY].side == player_type.blank)//选中的是空白
                return false;
            if (checkerboard[chosenX][chosenY].type == chess_type.ma || checkerboard[chosenX][chosenY].type == chess_type.xiang || checkerboard[chosenX][chosenY].type == chess_type.shi)//马象士的移动不能同y或同x
            {
                if (chosenX == x || chosenY == y)
                {
                    checkerboard[chosenX][chosenY].Bg_Toblank();
                    return false;
                }
            }
            else
            {
                if (chosenX != x && chosenY != y)//其他棋类都必须同x或同y移动
                {
                    checkerboard[chosenX][chosenY].Bg_Toblank();
                    return false;
                }
            }

            if (!checkerboard[chosenX][chosenY].Move_judge(sender, x, y, checkerboard))
            {
                checkerboard[chosenX][chosenY].Bg_Toblank();
                return false;
            }
            if (Chess.Setmove(checkerboard, x, y))
                return true;
            else
                return false;
        }
        static bool Setmove(Chess[][] checkerboard, int X, int Y)
        {
            n++;
            bool over = false;
            player_type z = player_type.blank;
            if (checkerboard[X][Y].type == chess_type.jiang)
            {
                over = true;
                z = checkerboard[X][Y].side;
            }
            if (checkerboard[X][Y].PB.Image != null)
                Cover(checkerboard[X][Y]);
            Chess.Change(ref checkerboard[Chess.chosenX][Chess.chosenY], ref checkerboard[X][Y]);
            Chess.chosen = false;
            if (over)
            {
                if (z == player_type.blue)
                    MessageBox.Show("红方胜利");
                else
                    MessageBox.Show("蓝方胜利");
                End f = new End(Time.fen + "分" + Time.miao + "秒");
                f.Show();
                return true;
            }
            if (n % 2 == 0)
                Chess.control_side = player_type.blue;
            else
                Chess.control_side = player_type.red;
            return false;
        }
        private static void Change(ref Chess a, ref Chess b)//a子位移到b子
        {
            Chess c = new Chess_blank();
            c.PB = b.PB;
            switch (a.type)
            {
                case chess_type.zu:
                    b = new Chess_zu(a.side); break;
                case chess_type.pao:
                    b = new Chess_pao(a.side); break;
                case chess_type.che:
                    b = new Chess_che(a.side); break;
                case chess_type.ma:
                    b = new Chess_ma(a.side); break;
                case chess_type.xiang:
                    b = new Chess_xiang(a.side); break;
                case chess_type.shi:
                    b = new Chess_shi(a.side); break;
                case chess_type.jiang:
                    b = new Chess_jiang(a.side); break;
            }
            b.type = a.type;
            b.side = a.side;
            b.PB = c.PB;
            b.PB.Image = a.PB.Image;
            a.Chess_Toblank(ref a, a.PB);
        }
        private static void Cover(Chess a)
        {
            if (a.side == player_type.blue)
            {
                Change(ref a, ref cover_red[r]);
                r++;
            }
            else
            {
                Change(ref a, ref cover_blue[f]);
                f++;
            }

        }//棋子被吃后移动到被吃区

    }
}
