using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnowyMountain
{
    public partial class Level2 : Form
    {
        public Level2()
        {
            InitializeComponent();
        }

        private void Level2_Load(object sender, EventArgs e)
        {

        }

        bool goLeft, goRight, jumping, isGameOver;

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 10;

        int verticalSpeed = 3;

        int enemyOneSpeed = 2;
        int enemyTwoSpeed = 2;
        int enemyThreeSpeed = 2;
        int enemyFourSpeed = 2;
        int timer;
        int timer50 = 1;
        int timerSec = 0;
        private int verticalSpeedPlatform1 = 4;
        private int verticalSpeedPlatform2 = 4;
        private int verticalSpeedPlatform3 = 4;
        private int verticalSpeedEnemy1 = 2;
        private int verticalSpeedEnemy2 = 2;
        private int verticalSpeedEnemy3 = 2;
        private int verticalSpeedEnemy4 = 2;
        private int verticalSpeedEnemy5 = 2;
        private int verticalSpeedEnemy6 = 2;

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            timer++;

            if (timer50 < 50)
            {
                timer50++;
            }
            else
            {
                timer50 = 1;
                timerSec++;
                textSnowballs.Text = "Snowballs: " + score;
                textTimer.Text = "Timer: " + timerSec + "s";
            }

            player.Top += jumpSpeed;

            if (goLeft == true)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true)
            {
                player.Left += playerSpeed;
            }

            if (jumping == true && force < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                jumpSpeed = -8;
                force -= 1;
            }
            else
            {
                jumpSpeed = 10;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                        }

                        // x.BringToFront();
                    }

                    if ((string)x.Tag == "snowball")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }

                    if ((string)x.Tag == "start")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            x.Visible = false;
                        }
                    }

                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            textSnowballs.Text = "Score: " + score + Environment.NewLine + "you were killed in your journey!!!";
                        }
                    }
                }
            }

            verticalPlatform1.Top += verticalSpeedPlatform1;

            if (verticalPlatform1.Top < 522 || verticalPlatform1.Top > 719)
            {
                verticalSpeedPlatform1 = -verticalSpeedPlatform1;
            }

            verticalPlatform2.Top += verticalSpeedPlatform2;

            if (verticalPlatform2.Top < 361 || verticalPlatform2.Top > 507)
            {
                verticalSpeedPlatform2 = -verticalSpeedPlatform2;
            }

            verticalPlatform3.Top += verticalSpeedPlatform3;

            if (verticalPlatform3.Top < 138 || verticalPlatform3.Top > 407)
            {
                verticalSpeedPlatform3 = -verticalSpeedPlatform3;
            }

            verticalEnemy1.Top += verticalSpeedEnemy1;

            if (verticalEnemy1.Top < 548 || verticalEnemy1.Top > 693)
            {
                verticalSpeedEnemy1 = -verticalSpeedEnemy1;
            }

            verticalEnemy2.Top += verticalSpeedEnemy2;

            if (verticalEnemy2.Top < 548 || verticalEnemy2.Top > 693)
            {
                verticalSpeedEnemy2 = -verticalSpeedEnemy2;
            }

            verticalEnemy3.Top += verticalSpeedEnemy3;

            if (verticalEnemy3.Top < 360 || verticalEnemy3.Top > 482)
            {
                verticalSpeedEnemy3 = -verticalSpeedEnemy3;
            }

            verticalEnemy4.Top += verticalSpeedEnemy4;

            if (verticalEnemy4.Top < 400 || verticalEnemy4.Top > 547)
            {
                verticalSpeedEnemy4 = -verticalSpeedEnemy4;
            }

            verticalEnemy5.Top += verticalSpeedEnemy5;

            if (verticalEnemy5.Top < 400 || verticalEnemy5.Top > 547)
            {
                verticalSpeedEnemy5 = -verticalSpeedEnemy5;
            }

            verticalEnemy6.Top += verticalSpeedEnemy6;

            if (verticalEnemy6.Top < 180 || verticalEnemy6.Top > 277)
            {
                verticalSpeedEnemy6 = -verticalSpeedEnemy6;
            }

            enemyOne.Left -= enemyOneSpeed;

            if (enemyOne.Left < pictureBox62.Left || enemyOne.Left + enemyOne.Width > pictureBox62.Left + pictureBox62.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            enemyTwo.Left += enemyTwoSpeed;

            if (enemyTwo.Left < pictureBox36.Left || enemyTwo.Left + enemyTwo.Width > pictureBox36.Left + pictureBox36.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }

            enemyThree.Left -= enemyThreeSpeed;

            if (enemyThree.Left < pictureBox25.Left || enemyThree.Left + enemyThree.Width > pictureBox25.Left + pictureBox25.Width)
            {
                enemyThreeSpeed = -enemyThreeSpeed;
            }

            enemyFour.Left -= enemyFourSpeed;

            if (enemyFour.Left < pictureBox25.Left || enemyFour.Left + enemyFour.Width > pictureBox25.Left + pictureBox25.Width)
            {
                enemyFourSpeed = -enemyFourSpeed;
            }


            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                isGameOver = true;
                textSnowballs.Text = "Snowballs: " + score + Environment.NewLine + "You feel to your death!";
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && score == 20)
            {
                gameTimer.Stop();
                isGameOver = true;
                textSnowballs.Text = "Snowballs: " + score + Environment.NewLine + "You won Level 2";
            }
            else
            {
                textSnowballs.Text = "Snowballs: " + score + Environment.NewLine + "Collect all the snowballs";
            }

            if (door.Bounds.IntersectsWith(player.Bounds) && score == 20)
            {
                EndScreen newLevel = new EndScreen();
                this.Hide();
                gameTimer.Stop();
                newLevel.Show();
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }

            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;

            textSnowballs.Text = "Snowballs: " + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            //reser the position of player, platform and enemies
            player.Left = 20;
            player.Top = 675;

            enemyOne.Left = 474;
            enemyTwo.Left = 108;
            enemyThree.Left = 508;
            enemyFour.Left = 302;

            verticalPlatform1.Top = 719;
            verticalPlatform2.Top = 507;
            verticalPlatform3.Top = 407;


            gameTimer.Start();

        }

        private void textTimer_Click(object sender, EventArgs e)
        {

        }
    }
}
