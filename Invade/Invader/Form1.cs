using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invader
{
    public partial class Form1 : Form
    {
        bool goleft;
        bool goright;
        int speed = 5;
        int score = 0;
        bool isPressed;
        int totalEnemies = 12;
        int playerSpeed = 6;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (isPressed)
            {
                isPressed = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Space && !isPressed)
            {
                isPressed = true;
                makebullet();
            }
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(goleft && player.Left > 1)
            {
                player.Left -= playerSpeed;
            }
            else if(goright && player.Right <680)
            {
                player.Left += playerSpeed;
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "invader")
                {
                    if(((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        gameOver();
                    }

                    ((PictureBox)x).Left += speed;

                    if(((PictureBox)x).Left >720)
                    {
                        ((PictureBox)x).Top += ((PictureBox)x).Height + 10;
                        ((PictureBox)x).Left = -50;
                    }
                }
            }
            
            foreach (Control y in this.Controls)
            {
                if(y is PictureBox && y.Tag == "bullet")
                {
                    y.Top -= 10; //speed of bullet
                    if(((PictureBox)y).Top < this.Height - 490)
                    {
                        this.Controls.Remove(y);
                    }
                }
            }

            foreach(Control a in this.Controls)
            {
                foreach(Control b in this.Controls)
                {
                    if(a is PictureBox && a.Tag == "invader")
                    {
                        if(b is PictureBox && b.Tag == "bullet")
                        {
                            if(a.Bounds.IntersectsWith(b.Bounds))
                            {
                                score++;
                                this.Controls.Remove(a);
                                this.Controls.Remove(b);
                            }
                        }
                    }
                }
            }
            label1.Text = "Score: " + score; 
            if(score > totalEnemies -1)
            {
                gameOver();
                MessageBox.Show("You win");
            }
        }

        private void makebullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.Image = Properties.Resources.bullet;
            bullet.Size = new Size(5, 20);
            bullet.Tag = "bullet";
            bullet.Left = player.Left + player.Width / 2;
            bullet.Top = player.Top - 20;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        private void gameOver()
        {
            timer1.Stop();
            label1.Text += "Game over";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
