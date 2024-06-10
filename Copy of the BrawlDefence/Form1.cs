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
        Rectangle fourthTurn = new Rectangle(120, 100, 30, 30);
        Rectangle fifthTurn = new Rectangle(145, 275, 30, 30);
        Rectangle sixthTurn = new Rectangle(250, 250, 30, 30);
        Rectangle seventhTurn = new Rectangle(225, 155, 30, 30);
        Rectangle eighthTurn = new Rectangle(350, 180, 30, 30);
        Rectangle ninethTurn = new Rectangle(325, 320, 30, 30);
        Rectangle tenthTurn = new Rectangle(550, 295, 30, 30);
        Rectangle eleventhTurn = new Rectangle(525, 220, 30, 30);
        Rectangle twelvethTurn = new Rectangle(740, 245, 30, 30);
        Rectangle thirteenthTurn = new Rectangle(715, 405, 30, 30);
        Rectangle fourteenthTurn = new Rectangle(225, 380, 30, 30);
        Rectangle fifteenthTurn = new Rectangle(250, 295, 30, 30);
        Rectangle sixteenthTurn = new Rectangle(120, 320, 30, 30);

        List<Rectangle> path = new List<Rectangle>();

        Point edgarOffset;
        Point crowOffset;
        Point jackyOffset;
        Point pocoOffset;
        Point nitaOffset;

        int screen = 2;
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
        List<Rectangle> crows = new List<Rectangle>();
        List<Rectangle> jackys = new List<Rectangle>();
        List<Rectangle> pocos = new List<Rectangle>();
        List<Rectangle> nitas = new List<Rectangle>();

        Random randGen = new Random();

        int randValue = 0;

        public Form1()
        {
            InitializeComponent();
            DrawMap();
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

                dragEdgar.Visible = false;
                dragCrow.Visible = false;
                dragJacky.Visible = false;
                dragPoco.Visible = false;
                dragNita.Visible = false;
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

                dragEdgar.Visible = false;
                dragCrow.Visible = false;
                dragJacky.Visible = false;
                dragPoco.Visible = false;
                dragNita.Visible = false;
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

                dragEdgar.Visible = true;
                dragCrow.Visible = true;
                dragJacky.Visible = true;
                dragPoco.Visible = true;
                dragNita.Visible = true;

                livesLabel.Text = $"Lives : {lives}";
                moneyLabel.Text = $"Money : {money}";

                //Draw Path
                for (int i = 0; i < path.Count; i ++)
                {
                    e.Graphics.FillRectangle(brownBrush, path[i]);
                }

                for (int i = 0; i < edgars.Count; i++)
                {
                    e.Graphics.FillRectangle(brownBrush, edgars[i]);

                    for (int j = 0; j < path.Count; j++)
                    {
                        if (edgars[i].IntersectsWith(path[j]))
                        {
                            edgars.RemoveAt(i);
                        }
                    }
                }

                e.Graphics.DrawRectangle(blackPen, firstTurn);
                e.Graphics.DrawRectangle(blackPen, secondTurn);
                e.Graphics.DrawRectangle(blackPen, thirdTurn);

                e.Graphics.DrawRectangle(blackPen, 0, 75, 100, 375);

                for (int i = 0; i < edgars.Count; i++)
                {
                    e.Graphics.DrawImage(edgarLogo, edgars[i]);
                    
                }

                for(int i = 0; i < crows.Count; i ++)
                {
                    e.Graphics.DrawImage(crowLogo, crows[i]);
                }

                for (int i = 0; i < jackys.Count; i++)
                {
                    e.Graphics.DrawImage(jackyLogo, jackys[i]);
                }

                for (int i = 0; i < pocos.Count; i++)
                {
                    e.Graphics.DrawImage(pocoLogo, pocos[i]);
                }

                for (int i = 0; i < nitas.Count; i++)
                {
                    e.Graphics.DrawImage(nitaLogo, nitas[i]);
                }

                e.Graphics.DrawRectangle(blackPen, firstTurn);
                e.Graphics.DrawRectangle(blackPen, secondTurn);
                e.Graphics.DrawRectangle(blackPen, thirdTurn);
                e.Graphics.DrawRectangle(blackPen, fourthTurn);
                e.Graphics.DrawRectangle(blackPen, fifthTurn);
                e.Graphics.DrawRectangle(blackPen, sixthTurn);
                e.Graphics.DrawRectangle(blackPen, seventhTurn);
                e.Graphics.DrawRectangle(blackPen, eighthTurn);
                e.Graphics.DrawRectangle(blackPen, ninethTurn);
                e.Graphics.DrawRectangle(blackPen, tenthTurn);
                e.Graphics.DrawRectangle(blackPen, eleventhTurn);
                e.Graphics.DrawRectangle(blackPen, twelvethTurn);
                e.Graphics.DrawRectangle(blackPen, thirteenthTurn);
                e.Graphics.DrawRectangle(blackPen, fourteenthTurn);
                e.Graphics.DrawRectangle(blackPen, fifteenthTurn);
                e.Graphics.DrawRectangle(blackPen, sixteenthTurn);
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

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        //All the process for Edgar
        private void dragEdgar_DragOver(object sender, DragEventArgs e)
        { 
        }

        private void dragEdgar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                edgarOffset = new Point (e.X, e.Y);
            }
        }

        private void dragEdgar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging) 
            {
                dragEdgar.Left += e.X - edgarOffset.X;
                dragEdgar.Top += e.Y - edgarOffset.Y;
            }
        }

        private void dragEdgar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                //Add a new button
                Button updateEdgar = new Button();
                updateEdgar.Location = dragEdgar.Location;
               
                //Customize the button
                updateEdgar.Size = dragEdgar.Size;
                updateEdgar.BackgroundImage = (Properties.Resources.edgar_logo);
                updateEdgar.BackgroundImageLayout = ImageLayout.Stretch;
                updateEdgar.FlatAppearance.BorderSize = 0;
                updateEdgar.FlatStyle = FlatStyle.Flat;

                //Add the updateEdgar to the form
                Controls.Add(updateEdgar);

                edgars.Add(new Rectangle(dragEdgar.Left, dragEdgar.Top, 45, 45));

                dragEdgar.Left = 23;
                dragEdgar.Top = 90;

            }
        }

        //All the process for Crow
       
        private void dragCrow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                crowOffset = new Point (e.X, e.Y);
            }
        }

        private void dragCrow_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragCrow.Left += e.X - crowOffset.X;
                dragCrow.Top += e.Y - crowOffset.Y;
            }
        }

        private void dragCrow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                //Add a new button
                Button updateCrow = new Button();
                updateCrow.Location = dragCrow.Location;

                //Customize the button
                updateCrow.Size = dragCrow.Size;
                updateCrow.BackgroundImage = (Properties.Resources.crow_logo);
                updateCrow.BackgroundImageLayout = ImageLayout.Stretch;
                updateCrow.FlatAppearance.BorderSize = 0;
                updateCrow.FlatStyle = FlatStyle.Flat;
                    
                //Add the updateEdgar to the form
                Controls.Add(updateCrow);

                crows.Add(new Rectangle(dragCrow.Left, dragCrow.Top, 45, 45));

                dragCrow.Left = 23;
                dragCrow.Top = 150;
            }
        }

        //All the process for Jacky
        private void dragJacky_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                jackyOffset = new Point(e.X, e.Y);
            }
        }

        private void dragJacky_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragJacky.Left += e.X - jackyOffset.X;
                dragJacky.Top += e.Y - jackyOffset.Y;
            }
        }

        private void dragJacky_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                //Add a new button
                Button updateJacky = new Button();
                updateJacky.Location = dragJacky.Location;

                //Customize the button
                updateJacky.Size = dragJacky.Size;
                updateJacky.BackgroundImage = (Properties.Resources.jacky_logo);
                updateJacky.BackgroundImageLayout = ImageLayout.Stretch;
                updateJacky.FlatAppearance.BorderSize = 0;
                updateJacky.FlatStyle = FlatStyle.Flat;

                //Add the updateEdgar to the form
                Controls.Add(updateJacky);

                jackys.Add(new Rectangle(dragJacky.Left, dragJacky.Top, 45, 45));

                dragJacky.Left = 23;
                dragJacky.Top = 220;

            }
        }

        //All the process for Poco
        private void dragPoco_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                pocoOffset = new Point(e.X, e.Y);
            }
        }

        private void dragPoco_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragPoco.Left += e.X - pocoOffset.X;
                dragPoco.Top += e.Y - pocoOffset.Y;
            }
        }

        private void dragPoco_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                //Add a new button
                Button updatePoco = new Button();
                updatePoco.Location = dragPoco.Location;

                //Customize the button
                updatePoco.Size = dragPoco.Size;
                updatePoco.BackgroundImage = (Properties.Resources.poco_logo);
                updatePoco.BackgroundImageLayout = ImageLayout.Stretch;
                updatePoco.FlatAppearance.BorderSize = 0;
                updatePoco.FlatStyle = FlatStyle.Flat;

                //Add the updateEdgar to the form
                Controls.Add(updatePoco);
                pocos.Add(new Rectangle(dragPoco.Left, dragPoco.Top, 45, 45));

                dragPoco.Left = 23;
                dragPoco.Top = 280;
            }
        }

        //All the process for Nita
        private void dragNita_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                nitaOffset = new Point(e.X, e.Y);
            }
        }

        private void dragNita_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragNita.Left += e.X - nitaOffset.X;
                dragNita.Top += e.Y - nitaOffset.Y;
            }
        }

        private void dragNita_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                //Add a new button
                Button updateNita = new Button();
                updateNita.Location = dragNita.Location;

                //Customize the button
                updateNita.Size = dragNita.Size;
                updateNita.BackgroundImage = (Properties.Resources.nita_logo);
                updateNita.BackgroundImageLayout = ImageLayout.Stretch;
                updateNita.FlatAppearance.BorderSize = 0;
                updateNita.FlatStyle = FlatStyle.Flat;

                //Add the updateEdgar to the form
                Controls.Add(updateNita);

                nitas.Add(new Rectangle(dragNita.Left, dragNita.Top, 45, 45));

                dragNita.Left = 23;
                dragNita.Top = 340;
            }
        }

        public void DrawMap()
        {
            Rectangle path1 = new Rectangle(675, 0, 30, 170);
            path.Add(path1);
            Rectangle path2 = new Rectangle(525, 170, 180, 30);
            path.Add(path2);
            Rectangle path3 = new Rectangle(525, 100, 30, 70);
            path.Add(path3);
            Rectangle path4 = new Rectangle(145, 100, 410, 30);
            path.Add(path4);
            Rectangle path5 = new Rectangle(145, 100, 30, 180);
            path.Add(path5);
            Rectangle path6 = new Rectangle(145, 250, 80, 30);
            path.Add(path6);
            Rectangle path7 = new Rectangle(225, 180, 30, 100);
            path.Add(path7);
            Rectangle path8 = new Rectangle(225, 180, 100, 30);
            path.Add(path8);
            Rectangle path9 = new Rectangle(325, 180, 30, 145);
            path.Add(path9);
            Rectangle path10 = new Rectangle(355, 295, 200, 30);
            path.Add(path10);
            Rectangle path11 = new Rectangle(525, 245, 30, 50);
            path.Add(path11);
            Rectangle path12 = new Rectangle(555, 245, 180, 30);
            path.Add(path12);
            Rectangle path13 = new Rectangle(715, 245, 30, 135);
            path.Add(path13);
            Rectangle path14 = new Rectangle(250, 380, 495, 30);
            path.Add(path14);
            Rectangle path15 = new Rectangle(250, 320, 30, 60);
            path.Add(path15);
            Rectangle path16 = new Rectangle(145, 320, 105, 30);
            path.Add(path16);
            Rectangle path17 = new Rectangle(145, 320, 30, 155);
            path.Add(path17);
        }
    }
}

