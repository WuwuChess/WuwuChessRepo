using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 查看本地棋谱 */

namespace WuwuChess
{
    public partial class ReadRecord : Form
    {
        public ReadRecord(string record_file,Form1 form1)
        {
            record = record_file;
            mainform = form1;
            InitializeComponent();
        }

        string record;
        Form1 mainform;

        private void Finish(object sender, FormClosingEventArgs e)  //关闭页面时，令主界面正常化，进行登录或其它操作
        {
            mainform.WindowState = FormWindowState.Normal;
        }
    }
}
