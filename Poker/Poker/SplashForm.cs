using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker
{
    public partial class SplashForm : Form
    {

        GameForm gameForm;

        public SplashForm(GameForm gameForm)
        {
            this.gameForm = gameForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> players = new List<string>();
            if (textBox1.Text != String.Empty) { players.Add(textBox1.Text); }
            if (textBox2.Text != String.Empty) { players.Add(textBox2.Text); }
            if (textBox3.Text != String.Empty) { players.Add(textBox3.Text); }
            if (textBox4.Text != String.Empty) { players.Add(textBox4.Text); }
            if (players.Count > 1)
            {
                gameForm.SetArgs(players);
                this.Hide();
                gameForm.WindowState = WindowState;
                gameForm.Size = Size;
                gameForm.Location = Location;
                gameForm.Show();
            }
            else
            {
                MessageBox.Show("Ingresa por lo menos 2 jugadores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

    }
}
