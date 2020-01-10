using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WuwuChess
{
    public partial class Lobby : Form
    {
        public Lobby(User user)
        {
            InitializeComponent();
            user1 = user;
        }

        User user1;

        private void Finish(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
