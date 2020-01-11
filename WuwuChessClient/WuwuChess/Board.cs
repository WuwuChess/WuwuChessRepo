using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 对局界面 */

namespace WuwuChess
{
    public partial class Board : Form
    {
        public Board(Lobby the_lobby)
        {
            lobby = the_lobby;
            pictureBox1.Location = ChessBoard.Location;
            pictureBox1.Height = ChessBoard.Height;
            pictureBox1.Width = ChessBoard.Width;
            pictureBox1.BackColor = Color.Transparent;
            InitializeComponent();
            for (int i = 0; i < 10; i++)
            {
                checkerboard[i] = new Chess[9];//10行9列
            }
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 9; j++)
                {
                    checkerboard[i][j] = new Chess_blank();
                }
            checkerboard[0][0] = new Chess_che(enemy);
            checkerboard[0][1] = new Chess_ma(enemy);
            checkerboard[0][2] = new Chess_xiang(enemy);
            checkerboard[0][3] = new Chess_shi(enemy);
            checkerboard[0][4] = new Chess_jiang(enemy);
            checkerboard[0][5] = new Chess_shi(enemy);
            checkerboard[0][6] = new Chess_xiang(enemy);
            checkerboard[0][7] = new Chess_ma(enemy);
            checkerboard[0][8] = new Chess_che(enemy);
            checkerboard[2][1] = new Chess_pao(enemy);
            checkerboard[2][7] = new Chess_pao(enemy);
            checkerboard[3][0] = new Chess_zu(enemy);
            checkerboard[3][2] = new Chess_zu(enemy);
            checkerboard[3][4] = new Chess_zu(enemy);
            checkerboard[3][6] = new Chess_zu(enemy);
            checkerboard[3][8] = new Chess_zu(enemy);


            checkerboard[6][0] = new Chess_zu(me);
            checkerboard[6][2] = new Chess_zu(me);
            checkerboard[6][4] = new Chess_zu(me);
            checkerboard[6][6] = new Chess_zu(me);
            checkerboard[6][8] = new Chess_zu(me);
            checkerboard[7][1] = new Chess_pao(me);
            checkerboard[7][7] = new Chess_pao(me);
            checkerboard[9][0] = new Chess_che(me);
            checkerboard[9][1] = new Chess_ma(me);
            checkerboard[9][2] = new Chess_xiang(me);
            checkerboard[9][3] = new Chess_shi(me);
            checkerboard[9][4] = new Chess_jiang(me);
            checkerboard[9][5] = new Chess_shi(me);
            checkerboard[9][6] = new Chess_xiang(me);
            checkerboard[9][7] = new Chess_ma(me);
            checkerboard[9][8] = new Chess_che(me);
            Clearground(this,ref checkerboard);

            for(int i = 0;i != 9;++i)
            {
                for(int j = 0;j != 10;++j)
                {
                    ChessBoard.Controls.Add(checkerboard[j][i].PB);
                }
            }
        }
        public static Chess[][] checkerboard = new Chess[10][];

        player_type me = player_type.red;
        player_type enemy = player_type.blue;
       
        public Stack<Chess> EatenRed = new Stack<Chess>();
        public Stack<Chess> EatenBlack = new Stack<Chess>();
        public Chess[] RedChess = new Chess[16];//双方的各个棋子现在在哪里
        //车马像是帅事项马车左炮右炮兵兵兵兵兵
        public Chess[] BlueChess = new Chess[16];
        //0车1马2像3是4帅5事6项7马8车9左炮10右炮11卒12卒13卒14卒15卒
        Lobby lobby;//这盘棋在那个大厅里
        bool Chosen = false;//当前选中没有
        int ChosenX, ChosenY;
        List<Chess> avail = new List<Chess>();
        public static void Clearground(Control f, ref Chess[][] checkerboard)//布置战场
        {
           
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 9; j++)
                {
                    checkerboard[i][j].Put_picture();
                }
        }
        private int tx(int x)  //将1~9的横坐标转换为picturebox上的横坐标
        {
            return -38 + 80 * x;
        }

        private int ty(int y) //将1~10的棋盘纵坐标转换为picturebox上的纵坐标
        {
            return 805 - 80 * y;
        }
        private int TxBack(float X)
        {
            return (int)((X - 2) / 80);
        }
        private int TyBack(float Y)
        {
            return (int)((845 - Y) / 80);
        }
        private void Finish(object sender, FormClosingEventArgs e)  //关闭对局房间
        {
            lobby.Show();  //再次显示游戏大厅
        }
        private Chess FindObject(Control c)
        {
            int x = TxBack(c.Location.X);
            int y = TyBack(c.Location.Y);
            return checkerboard[x][y];
        }
        
        private void 悔棋_Click(object sender, EventArgs e)
        {

            //之后向服务器发请求
        }

        private void ChessBoard_MouseDown(object sender, MouseEventArgs e)
        {
            int CurX = TxBack(e.X);
            int CurY = TyBack(e.Y);
            //MessageBox.Show(ChosenX.ToString() + " " + ChosenY.ToString());
            if (CurX < 1 || CurX > 8 || CurY < 0 || CurY > 9)
                return;
            if (!Chosen)
            {
                if (checkerboard[CurX][CurY].side == me)
                {
                    Chosen = true;
                    ChosenX = CurX;
                    ChosenY = CurY;
                }
            }
            else
            {
                if (checkerboard[CurX][CurY].side == player_type.blank)
                {
                    bool CanMove = false;
                    foreach (Chess i in avail)
                        if (i.GetX() == CurX && i.GetY() == CurY)
                        {
                            CanMove = true;
                            break;
                        }
                    if (CanMove)
                    {
                        Chess.Change(ref checkerboard[ChosenX][ChosenY], ref checkerboard[CurX][CurY]);
                    }
                    avail.Clear();
                }
                Chosen = false;
            }
        }

    

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Green, 1);
            if (Chosen)
            {
                float x = tx(ChosenX), y = ty(ChosenY);                
                g.DrawEllipse(p, x - 3, y - 3, 6, 6);
            }
            foreach(Chess i in avail)
            {
                float x = tx(i.GetX()), y = ty(i.GetY());
                Pen p1 = new Pen(Color.Purple, 1);
                g.DrawRectangle(p1, x - 4, y - 4, 8, 8);
            }
        }
    }
}
