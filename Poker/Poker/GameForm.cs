using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Classes;

namespace Poker
{
    public partial class GameForm : Form
    {

        SplashForm splashForm;
        Master master;
        List<string> p;

        public GameForm()
        {
            InitializeComponent();
        }



        public void SetArgs(List<string> players)
        {
            button3.Enabled = true;
            p1c1.BackgroundImage = Properties.Resources.espalda;
            p1c2.BackgroundImage = Properties.Resources.espalda;
            p1c3.BackgroundImage = Properties.Resources.espalda;
            p1c4.BackgroundImage = Properties.Resources.espalda;
            p1c5.BackgroundImage = Properties.Resources.espalda;
            p2c1.BackgroundImage = Properties.Resources.espalda;
            p2c2.BackgroundImage = Properties.Resources.espalda;
            p2c3.BackgroundImage = Properties.Resources.espalda;
            p2c4.BackgroundImage = Properties.Resources.espalda;
            p2c5.BackgroundImage = Properties.Resources.espalda;
            p3c1.BackgroundImage = Properties.Resources.espalda;
            p3c2.BackgroundImage = Properties.Resources.espalda;
            p3c3.BackgroundImage = Properties.Resources.espalda;
            p3c4.BackgroundImage = Properties.Resources.espalda;
            p3c5.BackgroundImage = Properties.Resources.espalda;
            p4c1.BackgroundImage = Properties.Resources.espalda;
            p4c2.BackgroundImage = Properties.Resources.espalda;
            p4c3.BackgroundImage = Properties.Resources.espalda;
            p4c4.BackgroundImage = Properties.Resources.espalda;
            p4c5.BackgroundImage = Properties.Resources.espalda;
            ShowCompoenents();
            HideComponents(players.Count());
            p = players;
            label1.Visible = false;
            label3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            master = new Master(this, players);
            master.Next();
        }

        public void HideComponents(int i)
        {
            switch(i)
            {
                case 2:
                    p1n.Visible = false;
                    p1c1.Visible = false;
                    p1c2.Visible = false;
                    p1c3.Visible = false;
                    p1c4.Visible = false;
                    p1c5.Visible = false;
                    p2n.Visible = false;
                    p2c1.Visible = false;
                    p2c2.Visible = false;
                    p2c3.Visible = false;
                    p2c4.Visible = false;
                    p2c5.Visible = false;
                    break;
                case 3:
                    p2n.Visible = false;
                    p2c1.Visible = false;
                    p2c2.Visible = false;
                    p2c3.Visible = false;
                    p2c4.Visible = false;
                    p2c5.Visible = false;
                    break;
            }
        }

        public void ShowCompoenents()
        {
            p1n.Visible = true;
            p1c1.Visible = true;
            p1c2.Visible = true;
            p1c3.Visible = true;
            p1c4.Visible = true;
            p1c5.Visible = true;
            p2n.Visible = true;
            p2c1.Visible = true;
            p2c2.Visible = true;
            p2c3.Visible = true;
            p2c4.Visible = true;
            p2c5.Visible = true;
            p3n.Visible = true;
            p3c1.Visible = true;
            p3c2.Visible = true;
            p3c3.Visible = true;
            p3c4.Visible = true;
            p3c5.Visible = true;
            p4n.Visible = true;
            p4c1.Visible = true;
            p4c2.Visible = true;
            p4c3.Visible = true;
            p4c4.Visible = true;
            p4c5.Visible = true;

        }

        public void SetWinner(Player player)
        {
            if (player != null)
            {
                label1.Text = player.Name + " Ha ganado la partida";
                switch (player.HandLevel)
                {
                    case Mano.CartaAlta:
                        label3.Text = "Por tener la carta más alta";
                        break;
                    case Mano.Pareja:
                        label3.Text = "Con pareja";
                        break;
                    case Mano.DoblePareja:
                        label3.Text = "Con doble pareja";
                        break;
                    case Mano.Trio:
                        label3.Text = "Con trio";
                        break;
                    case Mano.Escalera:
                        label3.Text = "Con escalera";
                        break;
                    case Mano.Color:
                        label3.Text = "Con color";
                        break;
                    case Mano.Full:
                        label3.Text = "Con un full";
                        break;
                    case Mano.Poker:
                        label3.Text = "Con un póker";
                        break;
                    case Mano.EscaleraColor:
                        label3.Text = "Por tener una escalera de color";
                        break;
                    case Mano.FlorImperial:
                        label3.Text = "Por tener una for imperial";
                        break;
                }
                label1.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
            } else
            {
                label1.Text = "Empate";
                label1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetArgs(p);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (master.Next())
            {
                foreach(Player p in master.P)
                {
                    p.Deactivate();
                    p.RefreshUI();
                }
                
                SetWinner(master.Winner());
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            splashForm.Location = Location;
            splashForm.Size = Size;
            splashForm.WindowState = WindowState;
            this.Hide();
            splashForm.Show();
        }

        

        private void CardClick(object sender, EventArgs e)
        {
            if((PictureBox) sender == p3c1)
            {
                if (master.pla.p1 && master.Current.id == 1 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(1);
                    master.Current.RefreshUI();
                }
            }
            else if((PictureBox)sender == p3c2)
            {
                if (master.pla.p1 && master.Current.id == 1 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(2);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p3c3)
            {
                if (master.pla.p1 && master.Current.id == 1 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(3);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p3c4)
            {
                if (master.pla.p1 && master.Current.id == 1 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(4);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p3c5)
            {
                if (master.pla.p1 && master.Current.id == 1 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(5);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p4c1)
            {
                if (master.pla.p2 && master.Current.id == 2 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(1);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p4c2)
            {
                if (master.pla.p2 && master.Current.id == 2 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(2);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p4c3)
            {
                if (master.pla.p2 && master.Current.id == 2 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(3);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p4c4)
            {
                if (master.pla.p2 && master.Current.id == 2 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(4);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p4c5)
            {
                if (master.pla.p2 && master.Current.id == 2 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(5);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p1c1)
            {
                if (master.pla.p3 && master.Current.id == 3 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(1);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p1c2)
            {
                if (master.pla.p3 && master.Current.id == 3 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(2);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p1c3)
            {
                if (master.pla.p3 && master.Current.id == 3 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(3);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p1c4)
            {
                if (master.pla.p3 && master.Current.id == 3 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(4);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p1c5)
            {
                if (master.pla.p3 && master.Current.id == 3 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(5);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p2c1)
            {
                if (master.pla.p4 && master.Current.id == 4 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(1);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p2c2)
            {
                if (master.pla.p4 && master.Current.id == 4 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(2);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p2c3)
            {
                if (master.pla.p4 && master.Current.id == 4 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(3);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p2c4)
            {
                if (master.pla.p4 && master.Current.id == 4 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(4);
                    master.Current.RefreshUI();
                }
            }
            else if ((PictureBox)sender == p2c5)
            {
                if (master.pla.p4 && master.Current.id == 4 && master.Current.retired < 3 && master.Current.retirable)
                {
                    master.Current.RetireCard(5);
                    master.Current.RefreshUI();
                }
            }

        }

        public void initArgs(SplashForm splashForm)
        {
            this.splashForm = splashForm;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SetArgs(p);
        }

    }
}
