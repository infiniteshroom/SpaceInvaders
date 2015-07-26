using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SpaceInvad
{
    public partial class frmGame : Form
    {
        int alienanimate = 0;
        int aliensmove = 10;
        int lives = 3;
        int score = 0;
        bool bonus = false;
        public List<int> HomeStates = new List<int>();
        public List<PictureBox> ALiens = new List<PictureBox>();
        public List<PictureBox> Players = new List<PictureBox>();
        public List<PictureBox> Homes = new List<PictureBox>();
        public List<PictureBox> SpaceShip = new List<PictureBox>();

        Random rnd = new Random();
        protected int GetRandomInt(int min, int max)
        {
            return rnd.Next(min, max);
        }

        public frmGame()
        {
            InitializeComponent();
            CreateHUD();
            CreatePlayer();
            CreateAliens();
            CreateHomes();
            axWindowsMediaPlayer2.URL = Application.StartupPath + @"\spaceinvaders1.mpeg";

        }

        public void CreateHUD()
        {
            for (int i = 0; i < lives; i++)
            {
                //draw life icons
                PictureBox life = new PictureBox();
                life.Image = SpaceInvad.Properties.Resources.ship;
                life.SizeMode = PictureBoxSizeMode.StretchImage;
                life.Size = new Size(41, 34);
                life.Location = new Point(3 + (i* 47) ,9);
                life.Name = "life";
                this.Controls.Add(life);
            }
            
        }
        public void CreateHomes()
        {
            PictureBox Home1 = new PictureBox();
            Home1.Image = SpaceInvad.Properties.Resources.house;
            Home1.SizeMode = PictureBoxSizeMode.AutoSize;
            Home1.Location = new Point(30, 318);
            Home1.Name = "Home";
            Homes.Add(Home1);
            this.Controls.Add(Homes[0]);
            HomeStates.Add(0);

            PictureBox Home2 = new PictureBox();
            Home2.Image = SpaceInvad.Properties.Resources.house;
            Home2.SizeMode = PictureBoxSizeMode.AutoSize;
            Home2.Location = new Point(229, 318);
            Home2.Name = "Home";
            Homes.Add(Home2);
            this.Controls.Add(Homes[1]);
            HomeStates.Add(0);

            PictureBox Home3 = new PictureBox();
            Home3.Image = SpaceInvad.Properties.Resources.house;
            Home3.SizeMode = PictureBoxSizeMode.AutoSize;
            Home3.Location = new Point(438, 318);
            Home3.Name = "Home";
            Homes.Add(Home3);
            this.Controls.Add(Homes[2]);
            HomeStates.Add(0);
        }

        public void CreatePlayer()
        {
            PictureBox player = new PictureBox();
            player.Image = SpaceInvad.Properties.Resources.ship;
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.Location = new Point(250, 375);
            player.Name = "player";
            Players.Add(player);
            this.Controls.Add(Players[0]);
        }
        public void CreateAliens()
        {
            for (int i = 0; i < 12; i++)
            {
                PictureBox alien = new PictureBox();
                alien.Image = SpaceInvad.Properties.Resources.smallalien1;
                alien.SizeMode = PictureBoxSizeMode.AutoSize;
                alien.Location = new Point(19 * i * 2, 61);
                alien.Name = "alien";
                ALiens.Add(alien);
                this.Controls.Add(ALiens[i]);
            }

            for (int i = 0; i < 12; i++)
            {
                PictureBox alien = new PictureBox();
                alien.Image = SpaceInvad.Properties.Resources.alien1;
                alien.SizeMode = PictureBoxSizeMode.AutoSize;
                alien.Location = new Point(13 * i * 3, 90);
                alien.Name = "alien";
                ALiens.Add(alien);
                this.Controls.Add(ALiens[i + 12]);
            }

            for (int i = 0; i < 12; i++)
            {
                PictureBox alien = new PictureBox();
                alien.Image = SpaceInvad.Properties.Resources.alien1;
                alien.SizeMode = PictureBoxSizeMode.AutoSize;
                alien.Location = new Point(13 * i * 3, 122);
                alien.Name = "alien";
                ALiens.Add(alien);
                this.Controls.Add(ALiens[i + 24]);
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                txtcheats.Show();
            }

            if (e.KeyCode == Keys.Space)
            {
                axWindowsMediaPlayer4.URL = Application.StartupPath + @"\shoot.wav";

                if (bonus == false)
                {
                    int ran = GetRandomInt(1, 10);
                    if (ran == 4)
                    {
                        axWindowsMediaPlayer3.URL = Application.StartupPath + @"\ufo_lowpitch.wav";
                        bonus = true;
                        PictureBox spaceship = new PictureBox();
                        spaceship.Image = SpaceInvad.Properties.Resources.spaceship;
                        spaceship.SizeMode = PictureBoxSizeMode.AutoSize;
                        spaceship.Location = new Point(3, 49);
                        spaceship.Name = "ss";
                        SpaceShip.Add(spaceship);
                        this.Controls.Add(SpaceShip[0]);
                        timerAnimateShipSpace.Enabled = true;
                    }
                }
    

                PictureBox bullet = new PictureBox();
                bullet.Image = SpaceInvad.Properties.Resources.bullet;
                bullet.SizeMode = PictureBoxSizeMode.AutoSize;
                bullet.Location = new Point(Players[0].Location.X + 9, Players[0].Location.Y - 10);
                bullet.Name = "bullet";
                this.Controls.Add(bullet);

                while (bullet.Location.Y > -30 && bullet.Visible == true)
                {
                    bullet.Location = new Point(bullet.Location.X, bullet.Location.Y - 1);
                    bullet.Refresh();

                    int count = 0;
                    foreach (PictureBox p in Homes)
                    {
                        if (bullet.Bounds.IntersectsWith(p.Bounds) && p.Visible == true)
                        {
                            if (HomeStates[count] == 0)
                            {

                                p.Image = SpaceInvad.Properties.Resources.house1;
                                HomeStates[count]++;
                                bullet.Hide();
                                Application.DoEvents();
                                break;
                            }

                            else if (HomeStates[count] == 1)
                            {
                                p.Image = SpaceInvad.Properties.Resources.house2;
                                HomeStates[count]++;
                                bullet.Hide();
                                break;
                            }

                            else if (HomeStates[count] == 2)
                            {
                                p.Hide();
                                bullet.Hide();
                                break;
                            }
                        }

                        count++;
                    }

                    foreach (PictureBox p in ALiens)
                    {

                        int ALiensvis = 0;

                        foreach (PictureBox alien in ALiens)
                        {
                            if (alien.Visible == true)
                            {
                                ALiensvis++;
                            }
                        }

                        if (ALiensvis == ALiens.Count / 2)
                        {
                            timerAnimateAlien.Interval = 300;
                        }

                        else if (ALiensvis <= 4)
                        {
                            timerAnimateAlien.Interval = 50;
                        }
                        if (bullet.Bounds.IntersectsWith(p.Bounds))
                        {
                            Application.DoEvents();
                            p.Image = SpaceInvad.Properties.Resources.aliendead;
                            p.Refresh();
                            axWindowsMediaPlayer1.URL = Application.StartupPath + @"\invaderkilled.wav";
                           
                            Stopwatch sw = new Stopwatch(); // sw cotructor
                            sw.Start(); // starts the stopwatch
                            for (int i = 0; ; i++)
                            {
                              
                                if (i % 100000 == 0) // if in 100000th iteration (could be any other large number
                                // depending on how often you want the time to be checked) 
                                {
                                    sw.Stop(); // stop the time measurement
                                    if (sw.ElapsedMilliseconds > 100) // check if desired period of time has elapsed
                                    {
                                        break; // if more than 5000 milliseconds have passed, stop looping and return
                                        // to the existing code
                                    }
                                    else
                                    {
                                        
                                        sw.Start(); // if less than 5000 milliseconds have elapsed, continue looping
                                        // and resume time measurement
                                    }
                                }
                            }
                            bullet.Hide();
                            p.Hide();
                            //hack throw picturebox off screen in -ve axis to stop multiple hits
                            p.Location = new Point(-1000, -1000);
                            score = score + 10;
                            Application.DoEvents();
                            label1.Text = score.ToString();
                            break;
                        }
                    }
                }

            }


            if (Players[0].Location.X >= 1)
            {
                if (e.KeyCode == Keys.Left)
                {
                    Players[0].Left -= 10;
                }
            }

            if (Players[0].Location.X <= this.Width - 60)
            {

                if (e.KeyCode == Keys.Right)
                {
                    Players[0].Left += 10;
                }
            }



        }

        private void timerAnimateAlien_Tick(object sender, EventArgs e)
        {
            int count = 0;
            if (alienanimate == 0)
            {
                foreach (PictureBox p in ALiens)
                {
                    if (count < 12)
                    {
                        p.Image = SpaceInvad.Properties.Resources.smallalien2;
                        p.Refresh();
                        alienanimate = 1;
                        count++;
                    }

                    else
                    {

                        p.Image = SpaceInvad.Properties.Resources.alien2;
                        p.Refresh();
                        alienanimate = 1;
                        count++;
                    }
                }


            }

            else
            {
                foreach (PictureBox p in ALiens)
                {
                    if (count < 12)
                    {
                        p.Image = SpaceInvad.Properties.Resources.smallalien1;
                        p.Refresh();
                        alienanimate = 0;
                        count++;
                    }

                    else
                    {

                        p.Image = SpaceInvad.Properties.Resources.alien1;
                        p.Refresh();
                        alienanimate = 0;
                        count++;
                    }
                }
            }

            foreach (PictureBox p in ALiens)
            {
                if (p.Visible == true)
                {

                    p.Location = new Point(p.Location.X + aliensmove, p.Location.Y);
                    if (p.Location.X >= this.Width - 60)
                    {
                        foreach (PictureBox p2 in ALiens)
                        {
                            p2.Location = new Point(p2.Location.X, p2.Location.Y + 29);
                        }

                        aliensmove *= -1;
                        break;
                    }

                    else if (p.Location.X <= 1)
                    {

                        aliensmove *= -1;
                        p.Location = new Point(p.Location.X + aliensmove, p.Location.Y);
                        break;
                    }

                    if(p.Bounds.IntersectsWith(Players[0].Bounds)) 
                    {
                        Players[0].Image = SpaceInvad.Properties.Resources.ship2;
                        Players[0].Refresh();
                        axWindowsMediaPlayer1.URL = Application.StartupPath + @"\explosion.wav";

                        Stopwatch sw = new Stopwatch();
                        for (int i = 0; ; i++)
                        {
                            if (i % 100000 == 0) // if in 100000th iteration (could be any other large number
                            // depending on how often you want the time to be checked) 
                            {
                                sw.Stop(); // stop the time measurement
                                if (sw.ElapsedMilliseconds > 300) // check if desired period of time has elapsed
                                {
                                    break; // if more than 5000 milliseconds have passed, stop looping and return
                                    // to the existing code
                                }
                                else
                                {
                                    sw.Start(); // if less than 5000 milliseconds have elapsed, continue looping
                                    // and resume time measurement
                                }
                            }
                        }

                        if (lives <= 0)
                        {
                            timerALienBullets.Enabled = false;
                            Players[0].Hide();
                            score = 0;
                            ALiens = new List<PictureBox>();
                            Homes = new List<PictureBox>();
                            Players = new List<PictureBox>();
                            this.Controls.Clear();
                            CreateAliens();
                            CreatePlayer();
                            this.Refresh();
                            timerAnimateAlien.Interval = 600;
                            HomeStates[0] = 0;
                            HomeStates[1] = 0;
                            HomeStates[2] = 0;
                            Players[0].Show();
                            Players[0].Image = SpaceInvad.Properties.Resources.ship;
                            CreateHomes();
                            timerALienBullets.Enabled = true;
                            break;
                        }

                        else
                        {
                            timerALienBullets.Enabled = false;
                            Players[0].Hide();
                            Players = new List<PictureBox>();
                            CreatePlayer();
                            this.Refresh();
                            timerAnimateAlien.Interval = 600;
                            Players[0].Show();
                            Players[0].Image = SpaceInvad.Properties.Resources.ship;
                            timerALienBullets.Enabled = true;
                            lives--;
                            CreateHUD();
                            break;
                        }
                        

                    }


                }

            }
        }

        private void timerAnimateShipSpace_Tick(object sender, EventArgs e)
        {

            foreach (PictureBox p in SpaceShip)
            {
                if (p.Location.X > -14)
                {
                    p.Location = new Point(p.Location.X + 10, p.Location.Y);
                }

                else
                {
                    SpaceShip.RemoveAt(0);
                    timerAnimateShipSpace.Enabled = false;
                }
            }
        }

        private void timerALienBullets_Tick(object sender, EventArgs e)
        {
            int ran = GetRandomInt(0, ALiens.Count);
            PictureBox bullet = new PictureBox();
            bullet.Image = SpaceInvad.Properties.Resources.bullet;
            bullet.SizeMode = PictureBoxSizeMode.AutoSize;
            bullet.Location = new Point(ALiens[ran].Location.X + 9, ALiens[ran].Location.Y + 10);
            bullet.Name = "alienbullet";
            this.Controls.Add(bullet);


            while (bullet.Location.Y < this.Width + 40 && bullet.Visible == true)
            {
                int count =0;
                foreach (PictureBox p in Homes)
                {
                    if (bullet.Bounds.IntersectsWith(p.Bounds))
                    {
                        if (HomeStates[count] == 0)
                        {

                            p.Image = SpaceInvad.Properties.Resources.house1;
                            HomeStates[count]++;
                            bullet.Hide();
                            Application.DoEvents();
                            break;
                        }

                        else if (HomeStates[count] == 1)
                        {
                            p.Image = SpaceInvad.Properties.Resources.house2;
                            HomeStates[count]++;
                            bullet.Hide();
                            break;
                        }

                        else if (HomeStates[count] == 2)
                        {
                            p.Hide();
                            bullet.Hide();
                            break;
                        }
                        count++;
                    }
                }

                        
                
                bullet.Location = new Point(bullet.Location.X, bullet.Location.Y + 1);
                bullet.Refresh();
                foreach (PictureBox p in Players)
                {
                    if (bullet.Bounds.IntersectsWith(p.Bounds) && p.Visible == true)
                    {

                        Players[0].Image = SpaceInvad.Properties.Resources.ship2;
                        p.Refresh();
                        axWindowsMediaPlayer1.URL = Application.StartupPath + @"\explosion.wav";

                        Stopwatch sw = new Stopwatch();
                        for (int i = 0; ; i++)
                        {
                            if (i % 100000 == 0) // if in 100000th iteration (could be any other large number
                            // depending on how often you want the time to be checked) 
                            {
                                sw.Stop(); // stop the time measurement
                                if (sw.ElapsedMilliseconds > 500) // check if desired period of time has elapsed
                                {
                                    break; // if more than 5000 milliseconds have passed, stop looping and return
                                    // to the existing code
                                }
                                else
                                {
                                    sw.Start(); // if less than 5000 milliseconds have elapsed, continue looping
                                    // and resume time measurement
                                }
                            }
                        }
                        bullet.Hide();
                        if (lives <= 0)
                        {
                            timerALienBullets.Enabled = false;
                            Players[0].Hide();
                            score = 0;
                            ALiens = new List<PictureBox>();
                            Homes = new List<PictureBox>();
                            Players = new List<PictureBox>();
                            this.Controls.Clear();
                            CreateAliens();
                            CreatePlayer();
                            this.Refresh();
                            timerAnimateAlien.Interval = 600;
                            HomeStates[0] = 0;
                            HomeStates[1] = 0;
                            HomeStates[2] = 0;
                            Players[0].Show();
                            Players[0].Image = SpaceInvad.Properties.Resources.ship;
                            CreateHomes();
                            timerALienBullets.Enabled = true;
                            break;
                        }

                        else
                        {
                            timerALienBullets.Enabled = false;
                            Players[0].Hide();
                            Players = new List<PictureBox>();
                            CreatePlayer();
                            this.Refresh();
                            timerAnimateAlien.Interval = 600;
                            Players[0].Show();
                            Players[0].Image = SpaceInvad.Properties.Resources.ship;
                            timerALienBullets.Enabled = true;
                            lives--;
                            CreateHUD();
                            break;
                        }


                    }

                }
        }    }
        

        private void timerreDraw_Tick(object sender, EventArgs e)
        {
            /* Helps Speed Up GDI by redrawing all controls in a loop.
             */
            Application.DoEvents();
            foreach (PictureBox p in ALiens)
            {
                p.Refresh();
            }
        }

        

        private void txtcheats_TextChanged(object sender, EventArgs e)
        {
            if (txtcheats.Text == "ship red")
            {
                Players[0].Image = SpaceInvad.Properties.Resources.shipred;
            }

            else if (txtcheats.Text == "debug")
            {
                frmDebug de = new frmDebug();
                de.Show();
            }
        }

 
    }
}
    
