using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Copy_of_the_BrawlDefence
{
    public partial class Form1 : Form
    {
        Rectangle firstTurn = new Rectangle(675, 195, 30, 30);
        Rectangle secondTurn = new Rectangle(500, 170, 30, 30);
        Rectangle thirdTurn = new Rectangle(525, 75, 30, 30);
        Rectangle fourthTurn = new Rectangle(145, 100, 410, 30);

        Point edgaroffset;

        int screen = 0;
        int time = 600;
        int loadingBar;

        int lives;
        int money;

        bool isDragging = false;

        Pen blackPen = new Pen(Color.Black, 3);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush brownBrush = new SolidBrush(Color.Peru);

        List<int> robots = new List<int>();
        List<string> robotsColour = new List<string>();
        List<int> robotsSize = new List<int>();
        List<int> robotsSpeed = new List<int>();

        Image edgarLogo = (Properties.Resources.edgar_logo);
        Image crowLogo = (Properties.Resources.crow_logo);
        Image jackyLogo = (Properties.Resources.jacky_logo);
        Image pocoLogo = (Properties.Resources.poco_logo);
        Image nitaLogo = (Properties.Resources.nita_logo);

        Rectangle edgarSquare = new Rectangle(23, 90, 50, 50);
        Rectangle crowSquare = new Rectangle(23, 150, 50, 50);
        Rectangle jackySquare = new Rectangle(23, 220, 50, 50);
        Rectangle pocoSquare = new Rectangle(23, 280, 50, 50);
        Rectangle nitaSquare = new Rectangle(23, 340, 50, 50);

        List<Rectangle> edgars = new List<Rectangle>();

        Random randGen = new Random();

        int randValue = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void menuTimer_Tick(object sender, EventArgs e)
        {
            //Show Menu Screen

            //Check to see if easy button has been pressed

            //Check to see if medium button has been pressed

            //Check to see if hard button has been pressed

            //Check to see if insane button has been pressed

            //Check to see if exit button has been pressed

            Refresh();
        }
        public void towerGrabbed()
        {

        }
        public void towerUpgraded()
        {

        }
        public void towerSold()
        {

        }
        public void shootBullet()
        {

        }
        public void moveBullet()
        {

        }
        public void removeBullet()
        {

        }
        public void bulletHitRobot()
        {

        }
        public void robotKill()
        {

        }
        public void loseLives()
        {

        }
        public void outOfLives()
        {

        }
        public void waveCompleted()
        {

        }
        public void gameCompleted()
        {

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
            //Make animation
            if (screen == 0)
            {
                if (time > 0 && loadingBar < 300)
                {
                    this.BackColor = (Color.White);
                    e.Graphics.FillRectangle(redBrush, 200, 300, loadingBar, 50);
                    e.Graphics.DrawRectangle(blackPen, 200, 300, 375, 50);

                    loadingBar = loadingBar + 40;
                    time--;
                }
                else if (time > 0 && loadingBar < 353)
                {
                    this.BackColor = (Color.White);
                    e.Graphics.FillRectangle(redBrush, 200, 300, loadingBar, 50);
                    e.Graphics.DrawRectangle(blackPen, 200, 300, 375, 50);

                    randValue = randGen.Next(0, 101);

                    if (randValue > 95)
                    {
                        loadingBar = loadingBar + 40;
                    }
                    time--;
                }
                else if (time > 0 && loadingBar < 375)
                {
                    this.BackColor = (Color.White);
                    e.Graphics.FillRectangle(redBrush, 200, 300, loadingBar, 50);
                    e.Graphics.DrawRectangle(blackPen, 200, 300, 375, 50);

                    loadingBar = loadingBar + 10;
                    time--;
                    screen = 1;
                }
                else
                {
                    Thread.Sleep(500);
                    e.Graphics.Clear(Color.White);
                }
                easyButton.Visible = false;
                mediumButton.Visible = false;
                hardButton.Visible = false;
                insaneButton.Visible = false;
                exitButton.Visible = false;
                titleLabel.Visible = false;
                moneyLabel.Visible = false;
                livesLabel.Visible = false;
            }
            else if (screen == 1)
            {
               this.BackColor = Color.White;
                easyButton.Visible = true;
                mediumButton.Visible = true;
                hardButton.Visible = true;
                insaneButton.Visible = true;
                exitButton.Visible = true;
                titleLabel.Visible = true;
                moneyLabel.Visible= true;
                livesLabel.Visible = true;
            }
            else if (screen == 2)
            {
                this.BackColor = Color.White;
                easyButton.Visible = false;
                mediumButton.Visible = false;
                hardButton.Visible = false;
                insaneButton.Visible = false;
                exitButton.Visible = false;
                titleLabel.Visible = false;
                livesLabel.Visible = true;
                moneyLabel.Visible = true;

                livesLabel.Text = $"Lives : {lives}";
                moneyLabel.Text = $"Money : {money}";

                //Draw Path
                e.Graphics.FillRectangle(brownBrush, 675, 0, 30, 170);
                e.Graphics.FillRectangle(brownBrush, 525, 170, 180, 30);
                e.Graphics.FillRectangle(brownBrush, 525, 100, 30, 70);
                e.Graphics.FillRectangle(brownBrush, 145, 100, 410, 30);
                e.Graphics.FillRectangle(brownBrush, 145, 100, 30, 180);
                e.Graphics.FillRectangle(brownBrush, 145, 250, 80, 30);
                e.Graphics.FillRectangle(brownBrush, 225, 180, 30, 100);
                e.Graphics.FillRectangle(brownBrush, 225, 180, 100, 30);
                e.Graphics.FillRectangle(brownBrush, 325, 180, 30, 145);
                e.Graphics.FillRectangle(brownBrush, 355, 295, 200, 30);
                e.Graphics.FillRectangle(brownBrush, 525, 245, 30, 50);
                e.Graphics.FillRectangle(brownBrush, 555, 245, 180, 30);
                e.Graphics.FillRectangle(brownBrush, 715, 245, 30, 135);
                e.Graphics.FillRectangle(brownBrush, 250, 380, 495, 30);
                e.Graphics.FillRectangle(brownBrush, 250, 320, 30, 60);
                e.Graphics.FillRectangle(brownBrush, 145, 320, 105, 30);
                e.Graphics.FillRectangle(brownBrush, 145, 320, 30, 155);

                //Draw the square where the brawlers can be placed
                e.Graphics.DrawRectangle(blackPen, firstTurn);
                e.Graphics.DrawRectangle(blackPen, secondTurn);
                e.Graphics.DrawRectangle(blackPen, thirdTurn);

                e.Graphics.DrawRectangle(blackPen, 0, 75, 100, 375);

                e.Graphics.DrawImage(edgarLogo, edgarSquare);
                e.Graphics.DrawImage(crowLogo, crowSquare);
                e.Graphics.DrawImage(jackyLogo, jackySquare);
                e.Graphics.DrawImage(pocoLogo, pocoSquare);
                e.Graphics.DrawImage(nitaLogo, nitaSquare);

                for (int i = 0; i < edgars.Count; i++)
                {
                    e.Graphics.DrawImage(edgarLogo, edgars[i]);
                }
            }
        }

        private void easyButton_MouseHover(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.Lime;
        }

        private void easyButton_MouseLeave(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.White;
        }

        private void mediumButton_MouseHover(object sender, EventArgs e)
        {
            mediumButton.BackColor = Color.Yellow;
        }

        private void mediumButton_MouseLeave(object sender, EventArgs e)
        {
            mediumButton.BackColor = Color.White;
        }

        private void hardButton_MouseHover(object sender, EventArgs e)
        {
            hardButton.BackColor = Color.Orange;
        }

        private void hardButton_MouseLeave(object sender, EventArgs e)
        {
            hardButton.BackColor = Color.White;
        }

        private void insaneButton_MouseHover(object sender, EventArgs e)
        {
            insaneButton.BackColor = Color.Red;
        }

        private void insaneButton_MouseLeave(object sender, EventArgs e)
        {
            insaneButton.BackColor = Color.White;
        }

        private void exitButton_MouseHover(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Red;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.White;
        }

        private void gameTimer_Tick_1(object sender, EventArgs e)
        {
            //Check to see if user has grabbed tower
            

            //check to see if the tower is placed on the arena

            //Check to see if any towers have been upgraded

            //Check to see if any towers have been sold

            //Check to see if it is time to shoot

            //Check to see if there is a bullet on the screen

            //Check to see if there are any bullets off the screen

            //Check to see if the robots have been shot

            //Check to see if the robots have been killed

            //Check to see if any robots made it to the end of the path

            //Are there any lives left

            //Check to see if the wave is completed

            //Check to see if all the waves have been completed



            Refresh();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void easyButton_Click_1(object sender, EventArgs e)
        {
            screen = 2;

            lives = 200;
            money = 1200;
            screen = 2;
        }

        private void mediumButton_Click_1(object sender, EventArgs e)
        {
            screen = 2;

            lives = 150;
            money = 1000;
            screen = 2;
        }

        private void hardButton_Click_1(object sender, EventArgs e)
        {
            screen = 2;

            lives = 100;
            money = 800;
            screen = 2;
        }

        private void insaneButton_Click_1(object sender, EventArgs e)
        {
            screen = 2;

            lives = 1;
            money = 600;
            screen = 2;
        }

        private void dragEdgar_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void dragEdgar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                edgaroffset = new Point (e.X, e.Y);
            }
        }

        private void dragEdgar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) 
            {
                dragEdgar.Left += e.X - edgaroffset.X;
                dragEdgar.Top += e.Y - edgaroffset.Y;
            }
        }

        private void dragEdgar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                edgars.Add(new Rectangle(dragEdgar.Left, dragEdgar.Top, 50, 50));

                dragEdgar.Left = 23;
                dragEdgar.Top = 90;

            }
        }
    }
}

