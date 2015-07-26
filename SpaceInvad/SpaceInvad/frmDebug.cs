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
    public partial class frmDebug : Form
    {
        public frmDebug()
        {
            InitializeComponent();
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            labelplayerx.Text = Program.game.Players[0].Location.X.ToString();
            labelplayery.Text = Program.game.Players[0].Location.Y.ToString();
            labelhouse1.Text = Program.game.HomeStates[0].ToString();
            labelhouse2.Text = Program.game.HomeStates[1].ToString();
            labelhouse3.Text = Program.game.HomeStates[2].ToString();
            labelalienspeed.Text = Program.game.timerAnimateAlien.Interval.ToString();

        }
    }
}
