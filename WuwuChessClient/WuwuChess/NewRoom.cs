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
    public partial class NewRoom : Form
    {
        public NewRoom(Lobby the_lobby)
        {
            lobby = the_lobby;
            InitializeComponent();
        }

        Lobby lobby;
        private void Sure_Click(object sender, EventArgs e)
        {
            Board board = new Board();
            board.Show();
            this.Hide();
            lobby.Hide();
        }
    }
}
