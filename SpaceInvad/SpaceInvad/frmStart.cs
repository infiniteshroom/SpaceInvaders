using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvad
{
    public partial class frmStart : Form
    {

        public frmStart()
        {
            InitializeComponent();

        }

        private void timerStartText_Tick(object sender, EventArgs e)
        {
            if (label1.Visible == true)
            {
                label1.Visible = false;
            }

            else
            {
                label1.Visible = true;
            }
        }

        private void frmStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Program.game = new frmGame();
                Program.game.Location = new Point(this.Location.X, this.Location.Y);
                Program.game.Show();
                this.Hide();
            }

            else if (e.KeyCode == Keys.C)
            {
                timerStartText.Enabled = false;
                timerCredits.Enabled = true;
                pancredits.Show();
            }
        }

        private void timerCredits_Tick(object sender, EventArgs e)
        {
            lblcredits.Location = new Point(lblcredits.Location.X, lblcredits.Location.Y - 10);
        }
    }
}
