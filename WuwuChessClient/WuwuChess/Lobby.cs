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

        private void FriendStart_Click(object sender, EventArgs e)
        {
            NewRoom newroom = new NewRoom(this);
            newroom.Show();
        }

        private void FriendIn_Click(object sender, EventArgs e)
        {
            Joinin joinin = new Joinin();
            joinin.Show();
        }
    }
}
