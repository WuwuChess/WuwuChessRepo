using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WuwuChessServer
{
    class Time
    {
        public Timer t;
        private Label l;
        private double s;
        private double m;
        public double sum = 0;
        public static string fen = "0";
        public static string miao = "0";
        public Time(Timer t, Label L)
        {
            s = 0;
            m = 0;
            this.t = t;
            this.l = L;
        }
        public string outtime()
        {
            string second;
            string minute;
            s++;
            if (s >= 60)
            {
                m = s / 60;
                s = s % 60;
            }
            second = Convert.ToString(s);
            minute = Convert.ToString(m);
            string sum = minute + "：" + second;
            return sum;
        }
        public void clear()
        {
            fen = (Convert.ToInt32(fen) + m).ToString();
            miao = (Convert.ToInt32(miao) + s).ToString();
            l.Text = "";
            m = 0;
            s = 0;
        }
    }
}
