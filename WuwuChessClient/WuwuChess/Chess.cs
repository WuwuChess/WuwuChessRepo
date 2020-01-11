using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
//简化
namespace WuwuChess
{
    public enum chess_type
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
    public enum player_type
    {
        blank,
        red,
        blue,
    };//玩家类别的枚举类型
    abstract public class Chess
    {
        public static int chosenX;
        public static int chosenY;
        public static bool chosen;
        static int n = 1;//步数
        public static player_type control_side;
        public PictureBox PB;
        public chess_type type;
        public player_type side;
        public Chess()
        {
            side = player_type.blank;
            type = chess_type.blank;
            PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            PB.Size = new System.Drawing.Size(76, 76);
            PB.BackColor = System.Drawing.Color.Transparent;
        }
        public int GetX() { return chosenX; }
        public int GetY() { return chosenY; }
        public abstract bool Move_judge(object sender, int X, int Y, Chess[][] checkerboard);
        public abstract void Put_picture();
        public void Bg_Tored()
        {
            this.PB.BackColor = Color.Red;
        }//背景变为红色，这个是不是选中它啊
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
        
        public static void Nochozen_dispose(object sender, Chess[][] checkerboard)
        {
            Chess.chosen = true;           
            if (checkerboard[chosenX][chosenY].side != control_side)//选择的不是当前应该走棋的一方
            {
                chosen = false;
                return;
            }
            if (checkerboard[chosenX][chosenY].side != player_type.blank)//选择的不是空白
                checkerboard[chosenX][chosenY].Bg_Tored();
            return;
        }
        /*public static bool Chozen_dispose(object sender, Chess[][] checkerboard)
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
        }*/
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
            Chess.Change(ref checkerboard[Chess.chosenX][Chess.chosenY], ref checkerboard[X][Y]);
            Chess.chosen = false;
            if (over)
            {
                if (z == player_type.blue)
                    MessageBox.Show("红方胜利");
                else
                    MessageBox.Show("蓝方胜利");               
                return true;
            }
            if (n % 2 == 0)
                Chess.control_side = player_type.blue;
            else
                Chess.control_side = player_type.red;
            return false;
        }
        public static void Change(ref Chess a, ref Chess b)//a子位移到b子
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
        
    }

}
