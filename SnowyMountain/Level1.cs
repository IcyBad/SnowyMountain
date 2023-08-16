namespace SnowyMountain
{
    public partial class Level1 : Form
    {

        bool goLeft, goRight, jumping, isGameOver;
        int jumpSpeed;
        int force;
        int score = 0;
        int timer;
        int timer50 = 1;
        int timerSec = 0;
        int playerSpeed = 10;
        int horizontalSpeed = 2;
        int verticalSpeed = 3;
        int enemyOneSpeed = 3;
        int enemyTwoSpeed = 3;

        public Level1()
        {
            InitializeComponent();
        }

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
                textScore.Text = "Snowballs:" + score;
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

                            if ((string)x.Name == "horizontalPlatform" && goLeft == false || (string)x.Name == "horizontalPlatform" && goRight == false)
                            {
                                player.Left -= horizontalSpeed;
                            }
                        }
                    }

                    if ((string)x.Tag == "snowball")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && x.Visible == true)
                        {
                            x.Visible = false;
                            score++;
                        }
                    }

                    if ((string)x.Tag == "enemy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            gameTimer.Stop();
                            isGameOver = true;
                            textScore.Text = "Snowballs:" + score + Environment.NewLine + "you were killed in your journey!!!";
                        }
                    }

                }
            }

            horizontalPlatform.Left -= horizontalSpeed;

            if (horizontalPlatform.Left < 0 || horizontalPlatform.Left + horizontalPlatform.Width > this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }

            verticalPlatform.Top += verticalSpeed;

            if (verticalPlatform.Top < 407 || verticalPlatform.Top > 609)
            {
                verticalSpeed = -verticalSpeed;
            }

            enemyOne.Left -= enemyOneSpeed;

            if (enemyOne.Left < pictureBox7.Left || enemyOne.Left + enemyOne.Width > pictureBox7.Left + pictureBox7.Width)
            {
                enemyOneSpeed = -enemyOneSpeed;
            }

            enemyTwo.Left += enemyTwoSpeed;

            if (enemyTwo.Left < pictureBox4.Left || enemyTwo.Left + enemyTwo.Width > pictureBox4.Left + pictureBox4.Width)
            {
                enemyTwoSpeed = -enemyTwoSpeed;
            }

            if (player.Top + player.Height > this.ClientSize.Height + 50)
            {
                gameTimer.Stop();
                isGameOver = true;
                textScore.Text = "Snowballs:" + score + Environment.NewLine + " You feel to your death!";
            }

            if (player.Bounds.IntersectsWith(door.Bounds) && score == 21)
            {
                gameTimer.Stop();
                isGameOver = true;
                textScore.Text = "Snowballs: " + score + Environment.NewLine + " You finished Level 1";
            }
            else
            {
                textScore.Text = "Snowballs: " + score;
            }

            if (door.Bounds.IntersectsWith(player.Bounds) && score == 21)
            {
                Level2 newLevel = new Level2();
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

            textScore.Text = "Snowballs: " + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }

            //reset the position of player, platform and enemies
            player.Left = 33;
            player.Top = 665;

            enemyOne.Left = 423;
            enemyTwo.Left = 423;

            horizontalPlatform.Left = 302;
            verticalPlatform.Top = 609;

            gameTimer.Start();
        }

        private void textScore_Click(object sender, EventArgs e)
        {

        }
    }
}