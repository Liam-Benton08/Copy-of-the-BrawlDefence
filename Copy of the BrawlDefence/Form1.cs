
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
using System.Diagnostics;

//Brawl Defence
//Liam Benton & Heet Patel
//This game is a tower defence merged with characters from brawlStars
namespace Copy_of_the_BrawlDefence
{
    public partial class BrawlDefence : Form
    {
        //Turns of the robots
        Rectangle firstTurn = new Rectangle(675, 185, 30, 30);
        Rectangle secondTurn = new Rectangle(510, 170, 30, 30);
        Rectangle thirdTurn = new Rectangle(525, 85, 30, 30);
        Rectangle fourthTurn = new Rectangle(130, 100, 30, 30);
        Rectangle fifthTurn = new Rectangle(145, 265, 30, 30);
        Rectangle sixthTurn = new Rectangle(240, 250, 30, 30);
        Rectangle seventhTurn = new Rectangle(225, 165, 30, 30);
        Rectangle eighthTurn = new Rectangle(340, 180, 30, 30);
        Rectangle ninethTurn = new Rectangle(325, 310, 30, 30);
        Rectangle tenthTurn = new Rectangle(540, 295, 30, 30);
        Rectangle eleventhTurn = new Rectangle(525, 230, 30, 30);
        Rectangle twelvethTurn = new Rectangle(730, 245, 30, 30);
        Rectangle thirteenthTurn = new Rectangle(715, 395, 30, 30);
        Rectangle fourteenthTurn = new Rectangle(235, 380, 30, 30);
        Rectangle fifteenthTurn = new Rectangle(250, 305, 30, 30);
        Rectangle sixteenthTurn = new Rectangle(130, 320, 30, 30);
        Rectangle end = new Rectangle(100, 475, 100, 20);

        Rectangle logo = new Rectangle(250, 10, 300, 375);
        Rectangle brawlStars = new Rectangle(150, 50, 500, 300);

        //List for the path for the robot
        List<Rectangle> path = new List<Rectangle>();

        //List and string for the robots
        List<String> mRD = new List<string>();
        List<String> sRD = new List<string>();
        List<String> fSRD = new List<string>();
        List<String> bMRD = new List<string>();
        List<String> bRD = new List<string>();
        List<String> fBRD = new List<string>();

        List<int> mRH = new List<int>();
        List<int> sRH = new List<int>();
        List<int> fSRH = new List<int>();
        List<int> bMRH = new List<int>();
        List<int> bRH = new List<int>();
        List<int> fBRH = new List<int>();

        //Robot lists
        List<Rectangle> miniRobots = new List<Rectangle>();
        List<Rectangle> sniperRobots = new List<Rectangle>();
        List<Rectangle> finalSniperRobots = new List<Rectangle>();
        List<Rectangle> bigMeleeRobots = new List<Rectangle>();
        List<Rectangle> bossRobots = new List<Rectangle>();
        List<Rectangle> finalBossRobots = new List<Rectangle>();

        //Brawler lists
        List<Rectangle> edgars = new List<Rectangle>();
        List<Rectangle> crows = new List<Rectangle>();
        List<Rectangle> jackys = new List<Rectangle>();
        List<Rectangle> pocos = new List<Rectangle>();
        List<Rectangle> nitas = new List<Rectangle>();

        //Squares
        List<Rectangle> placeBrawlers = new List<Rectangle>();

        //Point for brawlers and the Lists
        Point edgarOffset;
        Point crowOffset;
        Point jackyOffset;
        Point pocoOffset;
        Point nitaOffset;

        //Creating speeds and rectangle for bears
        Rectangle bearRect = new Rectangle();
        int bearYSpeed = 6;
        int bearXSpeed = 6;

        int closestBotX;
        int closestBotY;

        int closestBotDistance = 99999;
        bool isDropped = false;

        //Bots speeds and size
        int miniBots = 10;
        int miniBotspeedX = 7;
        int miniBotspeedY = 7;

        int sniperBots = 10;
        int sniperBotspeedX = 4;
        int sniperBotspeedY = 4;

        int finalSniperBots = 10;
        int finalSniperBotspeedX = 6;
        int finalSniperBotspeedY = 6;

        int bigMeleeBots = 10;
        int bigMeleeBotspeedX = 5;
        int bigMeleeBotspeedY = 5;

        int bossBots = 10;
        int bossBotspeedX = 6;
        int bossBotspeedY = 6;

        int finalBossBots = 10;
        int finalBossBotspeedX = 5;
        int finalBossBotspeedY = 5;

        //Cooldowns
        int edgarCooldown;
        int crowCooldown;
        int jackyCooldown;
        int pocoCooldown;


        //Sets the basic tools
        int screen = 0;
        int time = 600;
        int loadingBar;
        int wave = 1;
        int waveBehind = 1;
        int lives = 1;
        int money;
        int counter = 0;

        //Bools for the code
        bool waveSpawned = false;
        bool isDragging = false;
        bool showingRanges = false;
        bool nitaPlaced = false;

        //This is where we get the sidebar images
        Image edgarLogo = (Properties.Resources.edgar_logo);
        Image crowLogo = (Properties.Resources.crow_logo);
        Image jackyLogo = (Properties.Resources.jacky_logo);
        Image pocoLogo = (Properties.Resources.poco_logo);
        Image nitaLogo = (Properties.Resources.nita_logo);

        //Stating the Colors
        Pen blackPen = new Pen(Color.Black, 3);
        Pen purplePen = new Pen(Color.Purple, 3);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush brownBrush = new SolidBrush(Color.Peru);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);

        //Setting up a random Generator
        Random randGen = new Random();
        int randValue = 0;

        public BrawlDefence()
        {
            InitializeComponent();
            DrawMap();
            brawlersPlacement();
        }

        private void NewGame()
        {
            //This Code Resets the waves after a round
            wave = 1;
            waveBehind = 0;

            //This code resets the brawlers and robots after a round
            for (int i = 0; i < miniRobots.Count; i++) 
            {
                mRD.RemoveAt(i);
                miniRobots.RemoveAt(i);
                mRH.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < sniperRobots.Count; i++)
            {
                sRD.RemoveAt(i);
                sniperRobots.RemoveAt(i);
                sRH.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < finalSniperRobots.Count; i++)
            {
                fSRD.RemoveAt(i);
                finalSniperRobots.RemoveAt(i);
                fSRH.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < bigMeleeRobots.Count; i++)
            {
                bMRD.RemoveAt(i);
                bigMeleeRobots.RemoveAt(i);
                bMRH.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < bossRobots.Count; i++)
            {
                bRD.RemoveAt(i);
                bossRobots.RemoveAt(i);
                bRH.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < finalBossRobots.Count; i++)
            {
                fBRD.RemoveAt(i);
                finalBossRobots.RemoveAt(i);
                fBRH.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < edgars.Count; i++)
            {
                edgars.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < crows.Count; i++)
            {
                crows.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < jackys.Count; i++)
            {
                jackys.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < pocos.Count; i++)
            {
                pocos.RemoveAt(i);
                i--;
            }
            for (int i = 0; i < nitas.Count; i++)
            {
                nitas.RemoveAt(i);
                i--;
            }

            brawlersPlacement();
        }

        public void shootBullet()
        {
            #region edgarRanges
            for (int i = 0; i < edgars.Count; i++)
            {
                //This Code makes an attack rectangle
                Rectangle attacRec = new Rectangle(edgars[i].X - 75, edgars[i].Y - 75, edgars[i].Width + 150, edgars[i].Height + 150);

                //Makes it shoot mini robots
                for (int r = 0; r < miniRobots.Count; r++)
                {
                    if (miniRobots[r].IntersectsWith(attacRec) && edgarCooldown > 6)
                    {
                        mRH[r] -= 1;
                        if (mRH[r] <= 0)
                        {
                            mRD.RemoveAt(r);
                            mRH.RemoveAt(r);
                            miniRobots.RemoveAt(r);
                            money = money + 50;
                        }
                        edgarCooldown = 0;
                    }

                }
                //Makes it shoot sniper robots
                for (int r = 0; r < sniperRobots.Count; r++)
                {
                    if (sniperRobots[r].IntersectsWith(attacRec) && edgarCooldown > 6)
                    {
                        sRH[r] -= 1;
                        if (sRH[r] <= 0)
                        {
                            sRD.RemoveAt(r);
                            sRH.RemoveAt(r);
                            sniperRobots.RemoveAt(r);
                            money = money + 100;
                        }
                        edgarCooldown = 0;
                    }
                }
                //makes it shoot final sniper robots
                for (int r = 0; r < finalSniperRobots.Count; r++)
                {
                    if (finalSniperRobots[r].IntersectsWith(attacRec) && edgarCooldown > 6)
                    {
                        fSRH[r] -= 1;
                        if (fSRH[r] <= 0)
                        {
                            fSRD.RemoveAt(r);
                            fSRH.RemoveAt(r);
                            finalSniperRobots.RemoveAt(r);
                            money = money + 150;
                        }
                        edgarCooldown = 0;
                    }
                }
                //makes it shoot big melee robots
                for (int r = 0; r < bigMeleeRobots.Count; r++)
                {
                    if (bigMeleeRobots[r].IntersectsWith(attacRec) && edgarCooldown > 6)
                    {
                        bMRH[r] -= 1;
                        if (bMRH[r] <= 0)
                        {
                            bMRD.RemoveAt(r);
                            bMRH.RemoveAt(r);
                            bigMeleeRobots.RemoveAt(r);
                            money = money + 250;
                        }
                        edgarCooldown = 0;
                    }
                }
                //makes it shoot boss robots
                for (int r = 0; r < bossRobots.Count; r++)
                {
                    if (bossRobots[r].IntersectsWith(attacRec) && edgarCooldown > 6)
                    {
                        bRH[r] -= 1;
                        if (bRH[r] <= 0)
                        {
                            bRD.RemoveAt(r);
                            bRH.RemoveAt(r);
                            bossRobots.RemoveAt(r);
                            money = money + 350;
                        }
                        edgarCooldown = 0;
                    }
                }
                //makes it shoot final boss robot
                for (int r = 0; r < finalBossRobots.Count; r++)
                {
                    if (finalBossRobots[r].IntersectsWith(attacRec) && edgarCooldown > 6)
                    {
                        fBRH[r] -= 1;
                        if (fBRH[r] <= 0)
                        {
                            fBRD.RemoveAt(r);
                            fBRH.RemoveAt(r);
                            finalBossRobots.RemoveAt(r);
                            money = money + 700;
                        }
                        edgarCooldown = 0;
                    }
                }
            }

            #endregion

            #region crowRanges
            for (int i = 0; i < crows.Count; i++)
            {
                //Makes an attack rectangle
                Rectangle crowAttacRec = new Rectangle(crows[i].X - 125, crows[i].Y - 125, crows[i].Width + 250, crows[i].Height + 250);

                //shoot mini robots
                for (int r = 0; r < miniRobots.Count; r++)
                {
                    if (miniRobots[r].IntersectsWith(crowAttacRec) && crowCooldown > 8)
                    {
                        mRH[r] -= 2;
                        if (mRH[r] <= 0)
                        {
                            mRD.RemoveAt(r);
                            mRH.RemoveAt(r);
                            miniRobots.RemoveAt(r);
                            money = money + 50;

                        }
                        crowCooldown = 0;
                    }
                }
                //shoot sniper robots
                for (int r = 0; r < sniperRobots.Count; r++)
                {
                    if (sniperRobots[r].IntersectsWith(crowAttacRec) && crowCooldown > 8)
                    {
                        sRH[r] -= 3;
                        if (sRH[r] <= 0)
                        {
                            sRD.RemoveAt(r);
                            sRH.RemoveAt(r);
                            sniperRobots.RemoveAt(r);
                            money = money + 100;
                        }
                        crowCooldown = 0;

                    }
                }
                //shoots final sniper robots
                for (int r = 0; r < finalSniperRobots.Count; r++)
                {
                    if (finalSniperRobots[r].IntersectsWith(crowAttacRec) && crowCooldown > 8)
                    {
                        fSRH[r] -= 3;
                        if (fSRH[r] <= 0)
                        {
                            fSRD.RemoveAt(r);
                            fSRH.RemoveAt(r);
                            finalSniperRobots.RemoveAt(r);
                            money = money + 150;
                        }
                        crowCooldown = 0;
                    }
                }
                //shoots melee robots
                for (int r = 0; r < bigMeleeRobots.Count; r++)
                {
                    if (bigMeleeRobots[r].IntersectsWith(crowAttacRec) && crowCooldown > 8)
                    {
                        bMRH[r] -= 3;
                        if (bMRH[r] <= 0)
                        {
                            bMRD.RemoveAt(r);
                            bMRH.RemoveAt(r);
                            bigMeleeRobots.RemoveAt(r);
                            money = money + 250;
                        }
                        crowCooldown = 0;
                    }
                }
                //shoots boss robots
                for (int r = 0; r < bossRobots.Count; r++)
                {
                    if (bossRobots[r].IntersectsWith(crowAttacRec) && crowCooldown > 8)
                    {
                        bRH[r] -= 3;
                        if (bRH[r] <= 0)
                        {
                            bRD.RemoveAt(r);
                            bRH.RemoveAt(r);
                            bossRobots.RemoveAt(r);
                            money = money + 350;
                        }
                        crowCooldown = 0;
                    }
                }
                //shoots final boss robots
                for (int r = 0; r < finalBossRobots.Count; r++)
                {
                    if (finalBossRobots[r].IntersectsWith(crowAttacRec) && crowCooldown > 8)
                    {
                        fBRH[r] -= 3;
                        if (fBRH[r] <= 0)
                        {
                            fBRD.RemoveAt(r);
                            fBRH.RemoveAt(r);
                            finalBossRobots.RemoveAt(r);
                            money = money + 700;
                        }
                        crowCooldown = 0;
                    }
                }
            }
            #endregion

            #region JackyRanges
            for (int i = 0; i < jackys.Count; i++)
            {

                //makes an attack rectangle
                Rectangle jackyAttacRec = new Rectangle(jackys[i].X - 75, jackys[i].Y - 75, jackys[i].Width + 150, jackys[i].Height + 150);

                //makes it shoot all the robots once reloaded
                if (jackyCooldown > 28)
                {
                    #region MiniRobots

                    for (int r = 0; r < miniRobots.Count; r++)
                    {
                        if (miniRobots[r].IntersectsWith(jackyAttacRec))
                        {
                            mRH[r] -= 2;

                            if (mRH[r] <= 0)
                            {
                                mRD.RemoveAt(r);
                                mRH.RemoveAt(r);
                                miniRobots.RemoveAt(r);
                                money = money + 50;
                                r--;
                            }
                        }
                    }
                    jackyCooldown = 0;
                    #endregion

                    #region SniperRobots
                    for (int r = 0; r < sniperRobots.Count; r++)
                    {
                        if (sniperRobots[r].IntersectsWith(jackyAttacRec))
                        {
                            sRH[r] -= 4;
                            if (sRH[r] <= 0)
                            {
                                sRD.RemoveAt(r);
                                sRH.RemoveAt(r);
                                sniperRobots.RemoveAt(r);
                                money = money + 100;
                                r--;
                            }
                        }
                    }
                    jackyCooldown = 0;

                    #endregion

                    #region FinalSniperRobots 
                    for (int r = 0; r < finalSniperRobots.Count; r++)
                    {
                        if (finalSniperRobots[i].IntersectsWith(jackyAttacRec))
                        {
                            fSRH[r] -= 5;
                            if (fSRH[r] <= 0)
                            {
                                fSRD.RemoveAt(r);
                                fSRH.RemoveAt(r);
                                finalSniperRobots.RemoveAt(r);
                                money = money + 150;
                                r--;
                            }
                        }
                        jackyCooldown = 0;
                    }

                    #endregion

                    #region BigMeleeRobots
                    for (int r = 0; r < bigMeleeRobots.Count; r++)
                    {
                        if (bigMeleeRobots[r].IntersectsWith(jackyAttacRec))
                        {
                            bMRH[r] -= 5;

                            if (bMRH[r] <= 0)
                            {
                                bMRH.RemoveAt(r);
                                bMRD.RemoveAt(r);
                                bigMeleeRobots.RemoveAt(r);
                                money = money + 250;

                            }
                        }
                        jackyCooldown = 0;
                    }

                    #endregion

                    #region BossRobots
                    for (int r = 0; r < bossRobots.Count; r++)
                    {
                        if (bossRobots[r].IntersectsWith(jackyAttacRec))
                        {
                            bRH[r] -= 5;

                            if (bRH[r] <= 0)
                            {
                                bRH.RemoveAt(r);
                                bRD.RemoveAt(r);
                                bossRobots.RemoveAt(r);
                                money = money + 350;
                            }
                        }

                        jackyCooldown = 0;
                    }

                    #endregion

                    #region FinalBossRobots
                    for (int r = 0; r < finalBossRobots.Count; r++)
                    {
                        if (jackyAttacRec.IntersectsWith(finalBossRobots[i]))
                        {
                            fBRH[r] -= 5;

                            if (fBRH[r] <= 0)
                            {
                                fBRH.RemoveAt(r);
                                fBRD.RemoveAt(r);
                                finalBossRobots.RemoveAt(r);
                                money = money + 700;
                            }
                        }
                        jackyCooldown = 0;
                    }

                    #endregion
                }
            }
            #endregion

            #region PocoRanges
            for (int i = 0; i < pocos.Count; i++)
            {
                //creates attack rectangle
                Rectangle pocoAttacRec = new Rectangle(pocos[i].X - 50, pocos[i].Y - 50, pocos[i].Width + 100, pocos[i].Height + 100);

                //shoots mini robots
                for (int r = 0; r < miniRobots.Count; r++)
                {
                    if (miniRobots[r].IntersectsWith(pocoAttacRec) && pocoCooldown > 3)
                    {
                        mRH[r] -= 3;
                        if (mRH[r] <= 0)
                        {
                            mRD.RemoveAt(r);
                            mRH.RemoveAt(r);
                            miniRobots.RemoveAt(r);
                            money = money + 50;

                        }
                        pocoCooldown = 0;
                        money += 20;
                    }
                }
                //shoots sniper robots
                for (int r = 0; r < sniperRobots.Count; r++)
                {
                    if (sniperRobots[r].IntersectsWith(pocoAttacRec) && pocoCooldown > 3)
                    {
                        sRH[r] -= 3;
                        if (sRH[r] <= 0)
                        {
                            sRD.RemoveAt(r);
                            sRH.RemoveAt(r);
                            sniperRobots.RemoveAt(r);
                            money = money + 100;
                        }
                        pocoCooldown = 0;
                        money += 20;

                    }
                }
                //shoots final sniper robots
                for (int r = 0; r < finalSniperRobots.Count; r++)
                {
                    if (finalSniperRobots[r].IntersectsWith(pocoAttacRec) && pocoCooldown > 3)
                    {
                        fSRH[r] -= 3;
                        if (fSRH[r] <= 0)
                        {
                            fSRD.RemoveAt(r);
                            fSRH.RemoveAt(r);
                            finalSniperRobots.RemoveAt(r);
                            money = money + 150;
                        }
                        pocoCooldown = 0;
                        money += 20;
                    }
                }
                //shoots melee robots
                for (int r = 0; r < bigMeleeRobots.Count; r++)
                {
                    if (bigMeleeRobots[r].IntersectsWith(pocoAttacRec) && pocoCooldown > 3)
                    {
                        bMRH[r] -= 3;
                        if (bMRH[r] <= 0)
                        {
                            bMRD.RemoveAt(r);
                            bMRH.RemoveAt(r);
                            bigMeleeRobots.RemoveAt(r);
                            money = money + 250;
                        }
                        pocoCooldown = 0;
                        money += 20;
                    }
                }
                //shoots boss robots
                for (int r = 0; r < bossRobots.Count; r++)
                {
                    if (bossRobots[r].IntersectsWith(pocoAttacRec) && pocoCooldown > 3)
                    {
                        bRH[r] -= 3;
                        if (bRH[r] <= 0)
                        {
                            bRD.RemoveAt(r);
                            bRH.RemoveAt(r);
                            bossRobots.RemoveAt(r);
                            money = money + 350;
                        }
                        pocoCooldown = 0;
                        money += 20;
                    }
                }
                //shoots final boss robots
                for (int r = 0; r < finalBossRobots.Count; r++)
                {
                    if (finalBossRobots[r].IntersectsWith(pocoAttacRec) && pocoCooldown > 3)
                    {
                        fBRH[r] -= 3;
                        if (fBRH[r] <= 0)
                        {
                            fBRD.RemoveAt(r);
                            fBRH.RemoveAt(r);
                            finalBossRobots.RemoveAt(r);
                            money = money + 700;
                        }
                        pocoCooldown = 0;
                        money += 20;
                    }
                }

            }
            #endregion

            //adds to the cooldown every tick
            edgarCooldown++;
            crowCooldown++;
            jackyCooldown++;
            pocoCooldown++;
        }

        private void Form1_Paint(object sender, PaintEventArgs e) 
        {
            //Make animation
            if (screen == 0)
            {
                if (time > 0 && loadingBar < 300)
                {
                    this.BackColor = (Color.White);
                    e.Graphics.FillRectangle(redBrush, 215, 400, loadingBar, 50);
                    e.Graphics.DrawRectangle(blackPen, 215, 400, 375, 50);
                    e.Graphics.DrawImage(Properties.Resources.logo, logo);

                    loadingBar = loadingBar + 40;
                    time--;
                }
                else if (time > 0 && loadingBar < 353)
                {
                    this.BackColor = (Color.White);
                    e.Graphics.FillRectangle(redBrush, 215, 400, loadingBar, 50);
                    e.Graphics.DrawRectangle(blackPen, 215, 400, 375, 50);
                    e.Graphics.DrawImage(Properties.Resources.logo, logo);

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
                    e.Graphics.FillRectangle(redBrush, 215, 400, loadingBar, 50);
                    e.Graphics.DrawRectangle(blackPen, 215, 400, 375, 50);
                    e.Graphics.DrawImage(Properties.Resources.logo, logo);

                    loadingBar = loadingBar + 10;
                    time--;
                }
                else
                {
                    Thread.Sleep(500);
                    e.Graphics.Clear(Color.White);
                    screen = 1;
                }

                //Set all of the buttons to visible/invisible
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
                //Set all of the buttons to visible/invisible
                this.BackColor = Color.White;
                easyButton.Visible = true;
                mediumButton.Visible = true;
                hardButton.Visible = true;
                insaneButton.Visible = true;
                exitButton.Visible = true;
                playAgainButton.Visible = false;
                titleLabel.Visible = true;
                moneyLabel.Visible = false;
                livesLabel.Visible = false;
                waveLabel.Visible = false;
                showingRanges = false;

                dragEdgar.Visible = false;
                dragCrow.Visible = false;
                dragJacky.Visible = false;
                dragPoco.Visible = false;
                dragNita.Visible = false;

                gameOverLabel.Visible = false;
                gameOver2Label.Visible = false;
                exitButton2.Visible = false;
                areasButton.Visible = false;

                edgarPriceLabel.Visible = false;
                crowPriceLabel.Visible = false;
                jackyPriceLabel.Visible = false;
                pocoPriceLabel.Visible = false;
                nitaPriceLabel.Visible = false;

                e.Graphics.DrawImage(Properties.Resources.brawlStars, brawlStars);
            }
            else if (screen == 2)
            {
                //Set all of the buttons to visible/invisible
                this.BackColor = Color.White;
                easyButton.Visible = false;
                mediumButton.Visible = false;
                hardButton.Visible = false;
                insaneButton.Visible = false;
                exitButton.Visible = false;
                titleLabel.Visible = false;
                livesLabel.Visible = true;
                moneyLabel.Visible = true;
                waveLabel.Visible = true;

                dragEdgar.Visible = true;
                dragCrow.Visible = true;
                dragJacky.Visible = true;
                dragPoco.Visible = true;
                dragNita.Visible = true;

                edgarPriceLabel.Visible = true;
                crowPriceLabel.Visible = true;
                jackyPriceLabel.Visible = true;
                pocoPriceLabel.Visible = true;
                nitaPriceLabel.Visible = true;

                areasButton.Visible = true;

                //Draw Path
                for (int i = 0; i < path.Count; i++)
                {
                    e.Graphics.FillRectangle(brownBrush, path[i]);
                }
                e.Graphics.DrawRectangle(blackPen, 0, 75, 100, 375);

                //Draw brawlers
                for (int i = 0; i < edgars.Count; i++)
                {
                    e.Graphics.DrawImage(edgarLogo, edgars[i]);
                }
                for (int i = 0; i < crows.Count; i++)
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

                //draw robots
                for (int i = 0; i < miniRobots.Count(); i++)
                {
                    e.Graphics.FillRectangle(blackBrush, miniRobots[i]);
                }
                for (int i = 0; i < sniperRobots.Count(); i++)
                {
                    e.Graphics.FillRectangle(blueBrush, sniperRobots[i]);
                }
                for (int i = 0; i < finalSniperRobots.Count(); i++)
                {
                    e.Graphics.FillRectangle(greenBrush, finalSniperRobots[i]);
                }
                for (int i = 0; i < bigMeleeRobots.Count(); i++)
                {
                    e.Graphics.FillRectangle(purpleBrush, bigMeleeRobots[i]);
                }
                for (int i = 0; i < bossRobots.Count(); i++)
                {
                    e.Graphics.FillRectangle(redBrush, bossRobots[i]);
                }
                for (int i = 0; i < finalBossRobots.Count(); i++)
                {
                    e.Graphics.FillRectangle(orangeBrush, finalBossRobots[i]);
                }
                e.Graphics.DrawRectangle(blackPen, 0, 75, 100, 375);

                #region Draw Ranges
                //Draw ranges
                if (showingRanges == true)
                {
                    foreach (Rectangle r in edgars)
                    {
                        Rectangle attackRec = new Rectangle(r.X - 75, r.Y - 75, r.Width + 150, r.Height + 150);
                        e.Graphics.DrawRectangle(blackPen, attackRec);
                    }
                    foreach (Rectangle r in jackys)
                    {
                        Rectangle attackRec = new Rectangle(r.X - 75, r.Y - 75, r.Width + 150, r.Height + 150);
                        e.Graphics.DrawRectangle(blackPen, attackRec);
                    }
                    foreach (Rectangle r in crows)
                    {
                        Rectangle attackRec = new Rectangle(r.X - 125, r.Y - 125, r.Width + 250, r.Height + 250);
                        e.Graphics.DrawRectangle(blackPen, attackRec);
                    }
                    foreach (Rectangle r in pocos)
                    {
                        Rectangle attackRec = new Rectangle(r.X - 50, r.Y - 50, r.Width + 100, r.Height + 100);
                        e.Graphics.DrawRectangle(blackPen, attackRec);
                    }

                }
                #endregion

                //draw placements if being dragged
                if (isDragging == true)
                {
                    for (int i = 0; i < placeBrawlers.Count; i++)
                    {
                        e.Graphics.DrawRectangle(purplePen, placeBrawlers[i]);
                    }
                }

                //Draw the bear
                e.Graphics.DrawImage(Properties.Resources.download, bearRect);
            }
        }

        private void gameTimer_Tick_1(object sender, EventArgs e)
        {
            shootBullet();

            nitaAbility();

            //Checks if there are any lives left
            if (lives <= 0)
            {
                livesLabel.Text = "lives = 0";
                gameOverLabel.Visible = true;
                gameOver2Label.Visible = true;
                gameOverLabel.Text = $"Game Over";
                gameOver2Label.Text = "Out of Lives";
                playAgainButton.Visible = true;
                exitButton2.Visible = true;
                robotTimer.Enabled = false;
                gameTimer.Enabled = false;
                lives++;
            }

            //Check to see if the wave is completed
            if (counter > 100 && waveSpawned == true && miniRobots.Count() == 0 && sniperRobots.Count() == 0 && finalSniperRobots.Count() == 0 && bigMeleeRobots.Count() == 0 && bossRobots.Count() == 0 && finalBossRobots.Count() == 0)
            {
                waveSpawned = false;
                counter = 0;
                waveBehind++;
            }

            //Show the player information
            if (lives > 0)
            {
                waveLabel.Text = $"Wave : {waveBehind}";
                livesLabel.Text = $"Lives : {lives}";
                moneyLabel.Text = $"Money : {money}";

                //Showing if the player can afford the money 
                if (money < 600)
                {
                    edgarPriceLabel.ForeColor = Color.Red;
                    crowPriceLabel.ForeColor = Color.Red;
                    jackyPriceLabel.ForeColor = Color.Red;
                    pocoPriceLabel.ForeColor = Color.Red;
                    nitaPriceLabel.ForeColor = Color.Red;
                }
                else if (money >= 600 && money < 1400)
                {
                    edgarPriceLabel.ForeColor = Color.Black;
                    crowPriceLabel.ForeColor = Color.Red;
                    jackyPriceLabel.ForeColor = Color.Red;
                    pocoPriceLabel.ForeColor = Color.Red;
                    nitaPriceLabel.ForeColor = Color.Red;
                }
                else if (money >= 1400 && money < 4000)
                {
                    edgarPriceLabel.ForeColor = Color.Black;
                    crowPriceLabel.ForeColor = Color.Black;
                    jackyPriceLabel.ForeColor = Color.Red;
                    pocoPriceLabel.ForeColor = Color.Red;
                    nitaPriceLabel.ForeColor = Color.Red;
                }
                else if (money >= 4000 && money < 8000)
                {
                    edgarPriceLabel.ForeColor = Color.Black;
                    crowPriceLabel.ForeColor = Color.Black;
                    jackyPriceLabel.ForeColor = Color.Black;
                    pocoPriceLabel.ForeColor = Color.Red;
                    nitaPriceLabel.ForeColor = Color.Red;
                }
                else if (money >= 8000 && money < 20000)
                {
                    edgarPriceLabel.ForeColor = Color.Black;
                    crowPriceLabel.ForeColor = Color.Black;
                    jackyPriceLabel.ForeColor = Color.Black;
                    pocoPriceLabel.ForeColor = Color.Black;
                    nitaPriceLabel.ForeColor = Color.Red;
                }
                else
                {
                    edgarPriceLabel.ForeColor = Color.Black;
                    crowPriceLabel.ForeColor = Color.Black;
                    jackyPriceLabel.ForeColor = Color.Black;
                    pocoPriceLabel.ForeColor = Color.Black;
                    nitaPriceLabel.ForeColor = Color.Black;
                }
            }

            //Check to see if all the waves have been completed
            if (waveBehind == 16)
            {
                gameOverLabel.Text = $"You Won ";
                gameOver2Label.Text = "Waves Cleared";
                playAgainButton.Visible = true;
                exitButton2.Visible = true;
                gameOverLabel.Visible = true;
                gameOver2Label.Visible = true;

            }
        }

        #region Edgar
        //All the process for Edgar
        private void dragEdgar_MouseDown(object sender, MouseEventArgs e)
        {
            //Check to see if the user grabbed edgar
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                edgarOffset = new Point(e.X, e.Y);
            }
        }

        private void dragEdgar_MouseMove(object sender, MouseEventArgs e)
        {
            //Check to see if the user moves edgar
            if (isDragging)
            {
                dragEdgar.Left += e.X - edgarOffset.X;
                dragEdgar.Top += e.Y - edgarOffset.Y;
            }
        }

        private void dragEdgar_MouseUp(object sender, MouseEventArgs e)
        {
            //Check to see if the user drops edgar
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                for (int i = 0; i < placeBrawlers.Count; i++)
                {
                    Rectangle currentRect = placeBrawlers[i]; // Get the current rectangle

                    //Is it intersecting with a placement and do they have enough?
                    if (currentRect.IntersectsWith(new Rectangle(dragEdgar.Location, dragEdgar.Size)) && money >= 600)
                    {
                        //remove the money when palced
                        money -= 600;

                        //Makes a new rectangle added to crows list
                        Rectangle edgarRect = new Rectangle(currentRect.Left + currentRect.Width / 2 - dragEdgar.Width / 2, currentRect.Top + currentRect.Height / 2 - dragEdgar.Height / 2, 45, 45);
                        edgars.Add(edgarRect);
                        isDropped = true;
                        placeBrawlers.Remove(currentRect);

                    }
                }
                //clones it and puts it back to orignal spot
                dragEdgar.Left = 20;
                dragEdgar.Top = 90;
            }
        }
        #endregion

        #region Crow
        //All the process for Crow
        private void dragCrow_MouseDown(object sender, MouseEventArgs e)
        {
            //Check to see if the user grabbed crow
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                crowOffset = new Point(e.X, e.Y);
            }
        }

        private void dragCrow_MouseMove(object sender, MouseEventArgs e)
        {
            //Check to see if the user moves crow
            if (isDragging)
            {
                dragCrow.Left += e.X - crowOffset.X;
                dragCrow.Top += e.Y - crowOffset.Y;
            }
        }

        private void dragCrow_MouseUp(object sender, MouseEventArgs e)
        {
            //Check to see if the user drops crow
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                for (int i = 0; i < placeBrawlers.Count; i++)
                {
                    Rectangle currentRect = placeBrawlers[i]; 
                    
                    //Is it intersecting with a placement and do they have enough?
                    if (currentRect.IntersectsWith(new Rectangle(dragCrow.Location, dragCrow.Size)) && money >= 1400)
                    {
                        //remove money
                        money -= 1400;

                        //Makes a new rectangle added to crows list
                        Rectangle crowRect = new Rectangle(currentRect.Left + currentRect.Width / 2 - dragCrow.Width / 2, currentRect.Top + currentRect.Height / 2 - dragCrow.Height / 2, 45, 45);
                        crows.Add(crowRect);
                        isDropped = true;
                        placeBrawlers.Remove(currentRect);
                    }
                }
                //clones it and puts it back to orignal spot
                dragCrow.Left = 20;
                dragCrow.Top = 160;
            }
        }
        #endregion

        #region Jacky
        //All the process for Jacky
        private void dragJacky_MouseDown(object sender, MouseEventArgs e)
        {
            //Check to see if the user grabbed jacky
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                jackyOffset = new Point(e.X, e.Y);
            }
        }

        private void dragJacky_MouseMove(object sender, MouseEventArgs e)
        {
            //Check to see if the user moves jacky
            if (isDragging)
            {
                dragJacky.Left += e.X - jackyOffset.X;
                dragJacky.Top += e.Y - jackyOffset.Y;
            }
        }

        private void dragJacky_MouseUp(object sender, MouseEventArgs e)
        {
            //Check to see if the user drops jacky
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                for (int i = 0; i < placeBrawlers.Count; i++)
                {
                    Rectangle currentRect = placeBrawlers[i]; // Get the current rectangle

                    //Is it intersecting with a placement and do they have enough?
                    if (currentRect.IntersectsWith(new Rectangle(dragJacky.Location, dragJacky.Size)) && money >= 4000)
                    {
                        //remove money
                        money -= 4000;

                        //Makes a new rectangle added to jacky list
                        Rectangle jackyRect = new Rectangle(currentRect.Left + currentRect.Width / 2 - dragJacky.Width / 2, currentRect.Top + currentRect.Height / 2 - dragJacky.Height / 2, 45, 45);
                        jackys.Add(jackyRect);
                        isDropped = true;
                        placeBrawlers.Remove(currentRect);
                    }
                }

                //clones it and puts it back to orignal spot
                dragJacky.Left = 20;
                dragJacky.Top = 230;
            }
        }
        #endregion

        #region Poco
        //All the process for Poco
        private void dragPoco_MouseDown(object sender, MouseEventArgs e)
        {
            //Check to see if the user grabbed poco
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                pocoOffset = new Point(e.X, e.Y);
            }
        }
        private void dragPoco_MouseMove(object sender, MouseEventArgs e)
        {
            //Check to see if the user moves poco
            if (isDragging)
            {
                dragPoco.Left += e.X - pocoOffset.X;
                dragPoco.Top += e.Y - pocoOffset.Y;
            }
        }
        private void dragPoco_MouseUp(object sender, MouseEventArgs e) // it works for the mini robots good job
        {
            //Check to see if the user drops poco
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;

                for (int i = 0; i < placeBrawlers.Count; i++)
                {
                    Rectangle currentRect = placeBrawlers[i]; // Get the current rectangle

                    if (currentRect.IntersectsWith(new Rectangle(dragPoco.Location, dragPoco.Size)) && money >= 8000)
                    {
                        money -= 8000;
                        Rectangle pocoRect = new Rectangle(currentRect.Left + currentRect.Width / 2 - dragEdgar.Width / 2, currentRect.Top + currentRect.Height / 2 - dragEdgar.Height / 2, 45, 45);
                        pocos.Add(pocoRect);
                        isDropped = true;
                        placeBrawlers.Remove(currentRect);
                    }
                }

                //clones it and puts it back to orignal spot
                dragPoco.Left = 20;
                dragPoco.Top = 300;
            }
        }
        #endregion

        #region Nita
        //All the process for Nita
        private void dragNita_MouseDown(object sender, MouseEventArgs e)
        {
            //Check to see if the user grabbed Nita
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                nitaOffset = new Point(e.X, e.Y);
            }
        }

        private void dragNita_MouseMove(object sender, MouseEventArgs e)
        {
            //Check to see if the user moves Nita
            if (isDragging)
            {
                dragNita.Left += e.X - nitaOffset.X;
                dragNita.Top += e.Y - nitaOffset.Y;
            }
        }

        private void dragNita_MouseUp(object sender, MouseEventArgs e)
        {
            //Check to see if the user drops nita
            
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = false;

                    for (int i = 0; i < placeBrawlers.Count; i++)
                    {
                        Rectangle currentRect = placeBrawlers[i];

                        //Is it intersecting with a placement and do they have enough and has nita already been grabbed?
                        if (currentRect.IntersectsWith(new Rectangle(dragNita.Location, dragNita.Size)) && nitaPlaced == false && money >= 20000)
                        {
                            //remove money
                            money -= 20000;

                            //Makes a new rectangle added to jacky list
                            Rectangle nitaRect = new Rectangle(currentRect.Left + currentRect.Width / 2 - dragNita.Width / 2, currentRect.Top + currentRect.Height / 2 - dragNita.Height / 2, 45, 45);
                            nitas.Add(nitaRect);
                            bearRect = new Rectangle(placeBrawlers[i].X, placeBrawlers[i].Y, 25, 25);
                            isDropped = true;
                            nitaPlaced = true;
                            placeBrawlers.Remove(currentRect); 
                        }
                    }

                    //clones it and puts it back to orignal spot
                    dragNita.Left = 20;
                    dragNita.Top = 370;
                }
        }

        public void nitaAbility()
        {
            if (isDropped == true )  
            {
                #region Tracking Closest Robot
                //Track the closest robot
                for (int i = 0; i < miniRobots.Count; i++)
                {
                    int xComponent = Math.Abs(miniRobots[i].X - bearRect.X);
                    int yComponent = Math.Abs(miniRobots[i].Y - bearRect.Y);

                    int distanceAway = (int)Math.Abs(Math.Sqrt(Math.Pow(yComponent, 2) + Math.Pow(xComponent, 2)));

                    if (distanceAway < closestBotDistance)
                    {
                        distanceAway = closestBotDistance;
                        closestBotX = miniRobots[i].X;
                        closestBotY = miniRobots[i].Y;
                    }
                }
                for (int i = 0; i < sniperRobots.Count; i++)
                {
                    int xComponent = Math.Abs(sniperRobots[i].X - bearRect.X);
                    int yComponent = Math.Abs(sniperRobots[i].Y - bearRect.Y);

                    int distanceAway = (int)Math.Abs(Math.Sqrt(Math.Pow(yComponent, 2) + Math.Pow(xComponent, 2)));

                    if (distanceAway < closestBotDistance)
                    {
                        distanceAway = closestBotDistance;
                        closestBotX = sniperRobots[i].X;
                        closestBotY = sniperRobots[i].Y;
                    }
                }
                for (int i = 0; i < finalSniperRobots.Count; i++)
                {
                    int xComponent = Math.Abs(finalSniperRobots[i].X - bearRect.X);
                    int yComponent = Math.Abs(finalSniperRobots[i].Y - bearRect.Y);

                    int distanceAway = (int)Math.Abs(Math.Sqrt(Math.Pow(yComponent, 2) + Math.Pow(xComponent, 2)));

                    if (distanceAway < closestBotDistance)
                    {
                        distanceAway = closestBotDistance;
                        closestBotX = finalSniperRobots[i].X;
                        closestBotY = finalSniperRobots[i].Y;
                    }
                }
                for (int i = 0; i < bigMeleeRobots.Count; i++)
                {
                    int xComponent = Math.Abs(bigMeleeRobots[i].X - bearRect.X);
                    int yComponent = Math.Abs(bigMeleeRobots[i].Y - bearRect.Y);

                    int distanceAway = (int)Math.Abs(Math.Sqrt(Math.Pow(yComponent, 2) + Math.Pow(xComponent, 2)));

                    if (distanceAway < closestBotDistance)
                    {
                        distanceAway = closestBotDistance;
                        closestBotX = bigMeleeRobots[i].X;
                        closestBotY = bigMeleeRobots[i].Y;
                    }
                }
                for (int i = 0; i < bossRobots.Count; i++)
                {
                    int xComponent = Math.Abs(bossRobots[i].X - bearRect.X);
                    int yComponent = Math.Abs(bossRobots[i].Y - bearRect.Y);

                    int distanceAway = (int)Math.Abs(Math.Sqrt(Math.Pow(yComponent, 2) + Math.Pow(xComponent, 2)));

                    if (distanceAway < closestBotDistance)
                    {
                        distanceAway = closestBotDistance;
                        closestBotX = bossRobots[i].X;
                        closestBotY = bossRobots[i].Y;
                    }
                }
                for (int i = 0; i < finalBossRobots.Count; i++)
                {
                    int xComponent = Math.Abs(finalBossRobots[i].X - bearRect.X);
                    int yComponent = Math.Abs(finalBossRobots[i].Y - bearRect.Y);

                    int distanceAway = (int)Math.Abs(Math.Sqrt(Math.Pow(yComponent, 2) + Math.Pow(xComponent, 2)));

                    if (distanceAway < closestBotDistance)
                    {
                        distanceAway = closestBotDistance;
                        closestBotX = finalBossRobots[i].X;
                        closestBotY = finalBossRobots[i].Y;
                    }
                }
                #endregion

                //Chase the closest Robot
                if (closestBotX > bearRect.X)
                {
                    if (closestBotY < bearRect.Y)
                    {
                        bearRect.X += bearXSpeed;
                        bearRect.Y -= bearYSpeed;
                    }
                    if (closestBotY > bearRect.Y)
                    {
                        bearRect.X += bearXSpeed;
                        bearRect.Y += bearYSpeed;
                    }
                }
                if (closestBotX < bearRect.X)
                {
                    if (closestBotY < bearRect.Y)
                    {
                        bearRect.X -= bearXSpeed;
                        bearRect.Y -= bearYSpeed;
                    }
                    if (closestBotY > bearRect.Y)
                    {
                        bearRect.X -= bearXSpeed;
                        bearRect.Y += bearYSpeed;
                    }
                }

                #region Destroy Robots
                //Destroy minirobots
                for (int i = 0; i < miniRobots.Count; i++)
                {
                    Rectangle tempRectangle = new Rectangle(miniRobots[i].X, miniRobots[i].Y, miniRobots[i].Width, miniRobots[i].Height);
                    if (tempRectangle.IntersectsWith(bearRect))
                    {
                        mRH[i] -= 3; 
                        if (mRH[i] <= 0)
                        {
                            miniRobots.RemoveAt(i);
                            mRD.RemoveAt(i);
                            mRH.RemoveAt(i);
                            break;
                        }
                    }
                }
                //Destroy sniperRobots
                for (int i = 0; i < sniperRobots.Count; i++)
                {
                    Rectangle tempRectangle = new Rectangle(sniperRobots[i].X, sniperRobots[i].Y, sniperRobots[i].Width, sniperRobots[i].Height);
                    if (tempRectangle.IntersectsWith(bearRect))
                    {
                        sRH[i] -= 3; 
                        if (sRH[i] <= 0)
                        {
                            sniperRobots.RemoveAt(i);
                            sRD.RemoveAt(i);
                            sRH.RemoveAt(i);
                            break;
                        }
                    }
                }
                //Destroy finalSniperRobots
                for (int i = 0; i < finalSniperRobots.Count; i++)
                {
                    Rectangle tempRectangle = new Rectangle(finalSniperRobots[i].X, finalSniperRobots[i].Y, finalSniperRobots[i].Width, finalSniperRobots[i].Height);
                    if (tempRectangle.IntersectsWith(bearRect))
                    {
                        fSRH[i] -= 3; 
                        if (fSRH[i] <= 0)
                        {
                            finalSniperRobots.RemoveAt(i);
                            fSRD.RemoveAt(i);
                            fSRH.RemoveAt(i);
                            break;
                        }
                    }
                }
                //Destroy biMeleeRobots
                for (int i = 0; i < bigMeleeRobots.Count; i++)
                {
                    Rectangle tempRectangle = new Rectangle(bigMeleeRobots[i].X, bigMeleeRobots[i].Y, bigMeleeRobots[i].Width, bigMeleeRobots[i].Height);
                    if (tempRectangle.IntersectsWith(bearRect))
                    {
                        bMRH[i] -= 3; 
                        if (bMRH[i] <= 0)
                        {
                            bigMeleeRobots.RemoveAt(i);
                            bMRD.RemoveAt(i);
                            bMRH.RemoveAt(i);
                            break;
                        }
                    }
                }
                //Destroy bossRobots
                for (int i = 0; i < bossRobots.Count; i++)
                {
                    Rectangle tempRectangle = new Rectangle(bossRobots[i].X, bossRobots[i].Y, bossRobots[i].Width, bossRobots[i].Height);
                    if (tempRectangle.IntersectsWith(bearRect))
                    {
                        bRH[i] -= 3;
                        if (bRH[i] <= 0)
                        {
                            bossRobots.RemoveAt(i);
                            bRD.RemoveAt(i);
                            bRH.RemoveAt(i);
                            break;
                        }
                    }
                }
                //Destroy finalBossRobots
                for (int i = 0; i < finalBossRobots.Count; i++)
                {
                    Rectangle tempRectangle = new Rectangle(finalBossRobots[i].X, finalBossRobots[i].Y, finalBossRobots[i].Width, finalBossRobots[i].Height);
                    if (tempRectangle.IntersectsWith(bearRect))
                    {
                        fBRH[i] -= 3;
                        if (fBRH[i] <= 0)
                        {
                            finalBossRobots.RemoveAt(i);
                            fBRD.RemoveAt(i);
                            fBRH.RemoveAt(i);
                            break;
                        } 
                    }
                }
            }
        }

        #endregion
        #endregion

        public void DrawMap()
        {
            //Draws Path
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

        public void brawlersPlacement()
        {
            //List of the places where brawlers can be placed 
            Rectangle brawlplace1 = new Rectangle(675, 212, 20, 20);
            placeBrawlers.Add(brawlplace1);
            Rectangle brawlplace2 = new Rectangle(480, 170, 20, 20);
            placeBrawlers.Add(brawlplace2);
            Rectangle brawlplace3 = new Rectangle(520, 68, 20, 20);
            placeBrawlers.Add(brawlplace3);
            Rectangle brawlplace4 = new Rectangle(113, 100, 20, 20);
            placeBrawlers.Add(brawlplace4);
            Rectangle brawlplace5 = new Rectangle(175, 287, 20, 20);
            placeBrawlers.Add(brawlplace5);
            Rectangle brawlplace6 = new Rectangle(270, 255, 20, 20);
            placeBrawlers.Add(brawlplace6);
            Rectangle brawlplace7 = new Rectangle(225, 150, 20, 20);
            placeBrawlers.Add(brawlplace7);
            Rectangle brawlplace8 = new Rectangle(370, 180, 20, 20);
            placeBrawlers.Add(brawlplace8);
            Rectangle brawlplace9 = new Rectangle(325, 335, 20, 20);
            placeBrawlers.Add(brawlplace9);
            Rectangle brawlplace10 = new Rectangle(565, 300, 20, 20);
            placeBrawlers.Add(brawlplace10);
            Rectangle brawlplace11 = new Rectangle(550, 210, 20, 20);
            placeBrawlers.Add(brawlplace11);
            Rectangle brawlplace12 = new Rectangle(760, 245, 20, 20);
            placeBrawlers.Add(brawlplace12);
            Rectangle brawlplace13 = new Rectangle(715, 425, 20, 20);
            placeBrawlers.Add(brawlplace13);
            Rectangle brawlplace14 = new Rectangle(220, 380, 20, 20);
            placeBrawlers.Add(brawlplace14);
            Rectangle brawlplace15 = new Rectangle(110, 320, 20, 20);
            placeBrawlers.Add(brawlplace15);
        }

        #region button colors

        //When hovering over a button change colour / reverse it after leaving
        private void easyButton_MouseHover(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.Lime;
        }

        private void easyButton_MouseLeave(object sender, EventArgs e)
        {
            easyButton.BackColor = Color.Black;
        }
        private void mediumButton_MouseHover(object sender, EventArgs e)
        {
            mediumButton.BackColor = Color.Yellow;
        }

        private void mediumButton_MouseLeave(object sender, EventArgs e)
        {
            mediumButton.BackColor = Color.Black;
        }

        private void hardButton_MouseHover(object sender, EventArgs e)
        {
            hardButton.BackColor = Color.Orange;
        }

        private void hardButton_MouseLeave(object sender, EventArgs e)
        {
            hardButton.BackColor = Color.Black;
        }

        private void insaneButton_MouseHover(object sender, EventArgs e)
        {
            insaneButton.BackColor = Color.Red;
        }

        private void insaneButton_MouseLeave(object sender, EventArgs e)
        {
            insaneButton.BackColor = Color.Black;
        }

        private void exitButton_MouseHover(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Red;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.BackColor = Color.Black;
        }

        private void exitButton2_MouseHover(object sender, EventArgs e)
        {
            exitButton2.BackColor = Color.Red;
        }

        private void exitButton2_MouseLeave(object sender, EventArgs e)
        {
            exitButton2.BackColor = Color.Black;
        }

        private void playAgainButton_MouseHover(object sender, EventArgs e)
        {
            playAgainButton.BackColor = Color.Green;
        }

        private void playAgainButton_MouseLeave(object sender, EventArgs e)
        {
            playAgainButton.BackColor = Color.Black;
        }
        #endregion

        #region button clicks

        //When button is clicked has a specific funtion

        //Exits game
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Different modes according to buttons
        private void easyButton_Click(object sender, EventArgs e)
        {
            lives = 200;
            money = 1200;
            screen = 2;

            gameTimer.Enabled = true;
            robotTimer.Enabled = true;
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            lives = 150;
            money = 1000;
            screen = 2;

            gameTimer.Enabled = true;
            robotTimer.Enabled = true;
        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            lives = 100;
            money = 800;
            screen = 2;

            gameTimer.Enabled = true;
            robotTimer.Enabled = true;
        }

        private void insaneButton_Click(object sender, EventArgs e)
        {
            lives = 1;
            money = 600;
            screen = 2;

            gameTimer.Enabled = true;
            robotTimer.Enabled = true;
        }

        //resets game for user
        private void playAgain_Click(object sender, EventArgs e)
        {
            lives++;
            NewGame();
            if (screen == 2)
            {
                screen = 1;
            }

        }

        //Exits game
        private void exitButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void areasButton_Click(object sender, EventArgs e)
        {
            //If it isn't showing area show it / vise versa
            if (showingRanges == true)
            {
                showingRanges = false;
            }
            else
            {
                showingRanges = true;
            }
        }
        #endregion
        
        private void robotTimer_Tick(object sender, EventArgs e)
        {
            if (screen == 2)
            {
                #region move robots
                //Move Mini Robots
                for (int i = 0; i < miniRobots.Count(); i++)
                {
                    //Checks what direction its supposed to go
                    if (mRD[i] == "down")
                    {
                        int x = miniRobots[i].X;
                        int y = miniRobots[i].Y + miniBotspeedY;
                        miniRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (mRD[i] == "left")
                    {
                        int y = miniRobots[i].Y;
                        int x = miniRobots[i].X - miniBotspeedX;
                        miniRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (mRD[i] == "up")
                    {
                        int x = miniRobots[i].X;
                        int y = miniRobots[i].Y - miniBotspeedY;
                        miniRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (mRD[i] == "right")
                    {
                        int x = miniRobots[i].X + miniBotspeedX;
                        int y = miniRobots[i].Y;
                        miniRobots[i] = new Rectangle(x, y, 10, 10);
                    }

                    //What direction robot is supposed to go
                    if (miniRobots[i].IntersectsWith(firstTurn))
                    {
                        mRD[i] = "left";
                    }
                    if (miniRobots[i].IntersectsWith(secondTurn))
                    {
                        mRD[i] = "up";
                    }
                    if (miniRobots[i].IntersectsWith(thirdTurn))
                    {
                        mRD[i] = "left";
                    }
                    if (miniRobots[i].IntersectsWith(fourthTurn))
                    {
                        mRD[i] = "down";
                    }
                    if (miniRobots[i].IntersectsWith(fifthTurn))
                    {
                        mRD[i] = "right";
                    }
                    if (miniRobots[i].IntersectsWith(sixthTurn))
                    {
                        mRD[i] = "up";
                    }
                    if (miniRobots[i].IntersectsWith(seventhTurn))
                    {
                        mRD[i] = "right";
                    }
                    if (miniRobots[i].IntersectsWith(eighthTurn))
                    {
                        mRD[i] = "down";
                    }
                    if (miniRobots[i].IntersectsWith(ninethTurn))
                    {
                        mRD[i] = "right";
                    }
                    if (miniRobots[i].IntersectsWith(tenthTurn))
                    {
                        mRD[i] = "up";
                    }
                    if (miniRobots[i].IntersectsWith(eleventhTurn))
                    {
                        mRD[i] = "right";
                    }
                    if (miniRobots[i].IntersectsWith(twelvethTurn))
                    {
                        mRD[i] = "down";
                    }
                    if (miniRobots[i].IntersectsWith(thirteenthTurn))
                    {
                        mRD[i] = "left";
                    }
                    if (miniRobots[i].IntersectsWith(fourteenthTurn))
                    {
                        mRD[i] = "up";
                    }
                    if (miniRobots[i].IntersectsWith(fifteenthTurn))
                    {
                        mRD[i] = "left";
                    }
                    if (miniRobots[i].IntersectsWith(sixteenthTurn))
                    {
                        mRD[i] = "down";
                    }
                    if (miniRobots[i].IntersectsWith(end))
                    {
                        //At end of path remove
                        lives = lives - 2;
                        livesLabel.Text = $"{lives}";
                        miniRobots.RemoveAt(i);
                        mRD.RemoveAt(i);
                        mRH.RemoveAt(i);
                    }
                }
                //Move sniper Robots
                for (int i = 0; i < sniperRobots.Count(); i++)
                {
                    if (sRD[i] == "down")
                    {
                        int x = sniperRobots[i].X;
                        int y = sniperRobots[i].Y + sniperBotspeedY;
                        sniperRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (sRD[i] == "left")
                    {
                        int y = sniperRobots[i].Y;
                        int x = sniperRobots[i].X - sniperBotspeedX;
                        sniperRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (sRD[i] == "up")
                    {
                        int x = sniperRobots[i].X;
                        int y = sniperRobots[i].Y - sniperBotspeedY;
                        sniperRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (sRD[i] == "right")
                    {
                        int x = sniperRobots[i].X + sniperBotspeedX;
                        int y = sniperRobots[i].Y;
                        sniperRobots[i] = new Rectangle(x, y, 10, 10);
                    }

                    if (sniperRobots[i].IntersectsWith(firstTurn))
                    {
                        sRD[i] = "left";
                    }
                    if (sniperRobots[i].IntersectsWith(secondTurn))
                    {
                        sRD[i] = "up";
                    }
                    if (sniperRobots[i].IntersectsWith(thirdTurn))
                    {
                        sRD[i] = "left";
                    }
                    if (sniperRobots[i].IntersectsWith(fourthTurn))
                    {
                        sRD[i] = "down";
                    }
                    if (sniperRobots[i].IntersectsWith(fifthTurn))
                    {
                        sRD[i] = "right";
                    }
                    if (sniperRobots[i].IntersectsWith(sixthTurn))
                    {
                        sRD[i] = "up";
                    }
                    if (sniperRobots[i].IntersectsWith(seventhTurn))
                    {
                        sRD[i] = "right";
                    }
                    if (sniperRobots[i].IntersectsWith(eighthTurn))
                    {
                        sRD[i] = "down";
                    }
                    if (sniperRobots[i].IntersectsWith(ninethTurn))
                    {
                        sRD[i] = "right";
                    }
                    if (sniperRobots[i].IntersectsWith(tenthTurn))
                    {
                        sRD[i] = "up";
                    }
                    if (sniperRobots[i].IntersectsWith(eleventhTurn))
                    {
                        sRD[i] = "right";
                    }
                    if (sniperRobots[i].IntersectsWith(twelvethTurn))
                    {
                        sRD[i] = "down";
                    }
                    if (sniperRobots[i].IntersectsWith(thirteenthTurn))
                    {
                        sRD[i] = "left";
                    }
                    if (sniperRobots[i].IntersectsWith(fourteenthTurn))
                    {
                        sRD[i] = "up";
                    }
                    if (sniperRobots[i].IntersectsWith(fifteenthTurn))
                    {
                        sRD[i] = "left";
                    }
                    if (sniperRobots[i].IntersectsWith(sixteenthTurn))
                    {
                        sRD[i] = "down";
                    }
                    if (sniperRobots[i].IntersectsWith(end))
                    {
                        lives = lives - 3;
                        livesLabel.Text = $"{lives}";
                        sniperRobots.RemoveAt(i);
                        sRD.RemoveAt(i);
                        sRH.RemoveAt(i);
                    }
                }
                //Move Final Sniper Robots
                for (int i = 0; i < finalSniperRobots.Count(); i++)
                {
                    if (fSRD[i] == "down")
                    {
                        int x = finalSniperRobots[i].X;
                        int y = finalSniperRobots[i].Y + finalSniperBotspeedY;
                        finalSniperRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (fSRD[i] == "left")
                    {
                        int y = finalSniperRobots[i].Y;
                        int x = finalSniperRobots[i].X - finalSniperBotspeedX;
                        finalSniperRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (fSRD[i] == "up")
                    {
                        int x = finalSniperRobots[i].X;
                        int y = finalSniperRobots[i].Y - finalSniperBotspeedY;
                        finalSniperRobots[i] = new Rectangle(x, y, 10, 10);
                    }
                    if (fSRD[i] == "right")
                    {
                        int x = finalSniperRobots[i].X + finalSniperBotspeedX;
                        int y = finalSniperRobots[i].Y;
                        finalSniperRobots[i] = new Rectangle(x, y, 10, 10);
                    }

                    if (finalSniperRobots[i].IntersectsWith(firstTurn))
                    {
                        fSRD[i] = "left";
                    }
                    if (finalSniperRobots[i].IntersectsWith(secondTurn))
                    {
                        fSRD[i] = "up";
                    }
                    if (finalSniperRobots[i].IntersectsWith(thirdTurn))
                    {
                        fSRD[i] = "left";
                    }
                    if (finalSniperRobots[i].IntersectsWith(fourthTurn))
                    {
                        fSRD[i] = "down";
                    }
                    if (finalSniperRobots[i].IntersectsWith(fifthTurn))
                    {
                        fSRD[i] = "right";
                    }
                    if (finalSniperRobots[i].IntersectsWith(sixthTurn))
                    {
                        fSRD[i] = "up";
                    }
                    if (finalSniperRobots[i].IntersectsWith(seventhTurn))
                    {
                        fSRD[i] = "right";
                    }
                    if (finalSniperRobots[i].IntersectsWith(eighthTurn))
                    {
                        fSRD[i] = "down";
                    }
                    if (finalSniperRobots[i].IntersectsWith(ninethTurn))
                    {
                        fSRD[i] = "right";
                    }
                    if (finalSniperRobots[i].IntersectsWith(tenthTurn))
                    {
                        fSRD[i] = "up";
                    }
                    if (finalSniperRobots[i].IntersectsWith(eleventhTurn))
                    {
                        fSRD[i] = "right";
                    }
                    if (finalSniperRobots[i].IntersectsWith(twelvethTurn))
                    {
                        fSRD[i] = "down";
                    }
                    if (finalSniperRobots[i].IntersectsWith(thirteenthTurn))
                    {
                        fSRD[i] = "left";
                    }
                    if (finalSniperRobots[i].IntersectsWith(fourteenthTurn))
                    {
                        fSRD[i] = "up";
                    }
                    if (finalSniperRobots[i].IntersectsWith(fifteenthTurn))
                    {
                        fSRD[i] = "left";
                    }
                    if (finalSniperRobots[i].IntersectsWith(sixteenthTurn))
                    {
                        fSRD[i] = "down";
                    }
                    if (finalSniperRobots[i].IntersectsWith(end))
                    {
                        lives = lives - 5;
                        livesLabel.Text = $"{lives}";
                        finalSniperRobots.RemoveAt(i);
                        fSRD.RemoveAt(i);
                        fSRH.RemoveAt(i);
                    }
                }
                //Move big Melee Robots
                for (int i = 0; i < bigMeleeRobots.Count(); i++)
                {
                    if (bMRD[i] == "down")
                    {
                        int x = bigMeleeRobots[i].X;
                        int y = bigMeleeRobots[i].Y + bigMeleeBotspeedY;
                        bigMeleeRobots[i] = new Rectangle(x, y, 11, 11);
                    }
                    if (bMRD[i] == "left")
                    {
                        int y = bigMeleeRobots[i].Y;
                        int x = bigMeleeRobots[i].X - bigMeleeBotspeedX;
                        bigMeleeRobots[i] = new Rectangle(x, y, 11, 11);
                    }
                    if (bMRD[i] == "up")
                    {
                        int x = bigMeleeRobots[i].X;
                        int y = bigMeleeRobots[i].Y - bigMeleeBotspeedY;
                        bigMeleeRobots[i] = new Rectangle(x, y, 11, 11);
                    }
                    if (bMRD[i] == "right")
                    {
                        int x = bigMeleeRobots[i].X + bigMeleeBotspeedX;
                        int y = bigMeleeRobots[i].Y;
                        bigMeleeRobots[i] = new Rectangle(x, y, 11, 11);
                    }

                    if (bigMeleeRobots[i].IntersectsWith(firstTurn))
                    {
                        bMRD[i] = "left";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(secondTurn))
                    {
                        bMRD[i] = "up";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(thirdTurn))
                    {
                        bMRD[i] = "left";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(fourthTurn))
                    {
                        bMRD[i] = "down";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(fifthTurn))
                    {
                        bMRD[i] = "right";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(sixthTurn))
                    {
                        bMRD[i] = "up";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(seventhTurn))
                    {
                        bMRD[i] = "right";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(eighthTurn))
                    {
                        bMRD[i] = "down";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(ninethTurn))
                    {
                        bMRD[i] = "right";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(tenthTurn))
                    {
                        bMRD[i] = "up";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(eleventhTurn))
                    {
                        bMRD[i] = "right";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(twelvethTurn))
                    {
                        bMRD[i] = "down";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(thirteenthTurn))
                    {
                        bMRD[i] = "left";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(fourteenthTurn))
                    {
                        bMRD[i] = "up";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(fifteenthTurn))
                    {
                        bMRD[i] = "left";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(sixteenthTurn))
                    {
                        bMRD[i] = "down";
                    }
                    if (bigMeleeRobots[i].IntersectsWith(end))
                    {
                        lives = lives - 8;
                        livesLabel.Text = $"{lives}";
                        bigMeleeRobots.RemoveAt(i);
                        bMRD.RemoveAt(i);
                        bMRH.RemoveAt(i);
                    }
                }
                //Move boss Robots
                for (int i = 0; i < bossRobots.Count(); i++)
                {
                    if (bRD[i] == "down")
                    {
                        int x = bossRobots[i].X;
                        int y = bossRobots[i].Y + bossBotspeedY;
                        bossRobots[i] = new Rectangle(x, y, 12, 12);
                    }
                    if (bRD[i] == "left")
                    {
                        int y = bossRobots[i].Y;
                        int x = bossRobots[i].X - bossBotspeedX;
                        bossRobots[i] = new Rectangle(x, y, 12, 12);
                    }
                    if (bRD[i] == "up")
                    {
                        int x = bossRobots[i].X;
                        int y = bossRobots[i].Y - bossBotspeedY;
                        bossRobots[i] = new Rectangle(x, y, 12, 12);
                    }
                    if (bRD[i] == "right")
                    {
                        int x = bossRobots[i].X + bossBotspeedX;
                        int y = bossRobots[i].Y;
                        bossRobots[i] = new Rectangle(x, y, 12, 12);
                    }

                    if (bossRobots[i].IntersectsWith(firstTurn))
                    {
                        bRD[i] = "left";
                    }
                    if (bossRobots[i].IntersectsWith(secondTurn))
                    {
                        bRD[i] = "up";
                    }
                    if (bossRobots[i].IntersectsWith(thirdTurn))
                    {
                        bRD[i] = "left";
                    }
                    if (bossRobots[i].IntersectsWith(fourthTurn))
                    {
                        bRD[i] = "down";
                    }
                    if (bossRobots[i].IntersectsWith(fifthTurn))
                    {
                        bRD[i] = "right";
                    }
                    if (bossRobots[i].IntersectsWith(sixthTurn))
                    {
                        bRD[i] = "up";
                    }
                    if (bossRobots[i].IntersectsWith(seventhTurn))
                    {
                        bRD[i] = "right";
                    }
                    if (bossRobots[i].IntersectsWith(eighthTurn))
                    {
                        bRD[i] = "down";
                    }
                    if (bossRobots[i].IntersectsWith(ninethTurn))
                    {
                        bRD[i] = "right";
                    }
                    if (bossRobots[i].IntersectsWith(tenthTurn))
                    {
                        bRD[i] = "up";
                    }
                    if (bossRobots[i].IntersectsWith(eleventhTurn))
                    {
                        bRD[i] = "right";
                    }
                    if (bossRobots[i].IntersectsWith(twelvethTurn))
                    {
                        bRD[i] = "down";
                    }
                    if (bossRobots[i].IntersectsWith(thirteenthTurn))
                    {
                        bRD[i] = "left";
                    }
                    if (bossRobots[i].IntersectsWith(fourteenthTurn))
                    {
                        bRD[i] = "up";
                    }
                    if (bossRobots[i].IntersectsWith(fifteenthTurn))
                    {
                        bRD[i] = "left";
                    }
                    if (bossRobots[i].IntersectsWith(sixteenthTurn))
                    {
                        bRD[i] = "down";
                    }
                    if (bossRobots[i].IntersectsWith(end))
                    {
                        lives = lives - 25;
                        livesLabel.Text = $"{lives}";
                        bossRobots.RemoveAt(i);
                        bRD.RemoveAt(i);
                        bRH.RemoveAt(i);
                    }
                }
                //Move final Boss Robots
                for (int i = 0; i < finalBossRobots.Count(); i++)
                {
                    if (fBRD[i] == "down")
                    {
                        int x = finalBossRobots[i].X;
                        int y = finalBossRobots[i].Y + finalBossBotspeedY;
                        finalBossRobots[i] = new Rectangle(x, y, 12, 12);
                    }
                    if (fBRD[i] == "left")
                    {
                        int y = finalBossRobots[i].Y;
                        int x = finalBossRobots[i].X - finalBossBotspeedX;
                        finalBossRobots[i] = new Rectangle(x, y, 12, 12);
                    }
                    if (fBRD[i] == "up")
                    {
                        int x = finalBossRobots[i].X;
                        int y = finalBossRobots[i].Y - finalBossBotspeedY;
                        finalBossRobots[i] = new Rectangle(x, y, 12, 12);
                    }
                    if (fBRD[i] == "right")
                    {
                        int x = finalBossRobots[i].X + finalBossBotspeedX;
                        int y = finalBossRobots[i].Y;
                        finalBossRobots[i] = new Rectangle(x, y, 12, 12);
                    }

                    if (finalBossRobots[i].IntersectsWith(firstTurn))
                    {
                        fBRD[i] = "left";
                    }
                    if (finalBossRobots[i].IntersectsWith(secondTurn))
                    {
                        fBRD[i] = "up";
                    }
                    if (finalBossRobots[i].IntersectsWith(thirdTurn))
                    {
                        fBRD[i] = "left";
                    }
                    if (finalBossRobots[i].IntersectsWith(fourthTurn))
                    {
                        fBRD[i] = "down";
                    }
                    if (finalBossRobots[i].IntersectsWith(fifthTurn))
                    {
                        fBRD[i] = "right";
                    }
                    if (finalBossRobots[i].IntersectsWith(sixthTurn))
                    {
                        fBRD[i] = "up";
                    }
                    if (finalBossRobots[i].IntersectsWith(seventhTurn))
                    {
                        fBRD[i] = "right";
                    }
                    if (finalBossRobots[i].IntersectsWith(eighthTurn))
                    {
                        fBRD[i] = "down";
                    }
                    if (finalBossRobots[i].IntersectsWith(ninethTurn))
                    {
                        fBRD[i] = "right";
                    }
                    if (finalBossRobots[i].IntersectsWith(tenthTurn))
                    {
                        fBRD[i] = "up";
                    }
                    if (finalBossRobots[i].IntersectsWith(eleventhTurn))
                    {
                        fBRD[i] = "right";
                    }
                    if (finalBossRobots[i].IntersectsWith(twelvethTurn))
                    {
                        fBRD[i] = "down";
                    }
                    if (finalBossRobots[i].IntersectsWith(thirteenthTurn))
                    {
                        fBRD[i] = "left";
                    }
                    if (finalBossRobots[i].IntersectsWith(fourteenthTurn))
                    {
                        fBRD[i] = "up";
                    }
                    if (finalBossRobots[i].IntersectsWith(fifteenthTurn))
                    {
                        fBRD[i] = "left";
                    }
                    if (finalBossRobots[i].IntersectsWith(sixteenthTurn))
                    {
                        fBRD[i] = "down";
                    }
                    if (finalBossRobots[i].IntersectsWith(end))
                    {
                        lives = lives - 50;
                        livesLabel.Text = $"{lives}";
                        finalBossRobots.RemoveAt(i);
                        fBRD.RemoveAt(i);
                        fBRH.RemoveAt(i);
                    }
                }
                #endregion

                #region Waves
                //Creats each wave, changes bot numbers inside of each wave
                if (wave == 1 && waveSpawned == false)
                {
                    miniBots = 6;
                    sniperBots = 0;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 2 && waveSpawned == false)
                {
                    miniBots = 10;
                    sniperBots = 0;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 3 && waveSpawned == false)
                {
                    miniBots = 13;
                    sniperBots = 2;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 4 && waveSpawned == false)
                {
                    miniBots = 10;
                    sniperBots = 6;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 5 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 14;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 6 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 16;
                    finalSniperBots = 2;
                    bigMeleeBots = 0;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 7 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 8;
                    finalSniperBots = 8;
                    bigMeleeBots = 1;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 8 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 0;
                    finalSniperBots = 10;
                    bigMeleeBots = 4;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 9 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 0;
                    finalSniperBots = 0;
                    bigMeleeBots = 10;
                    bossBots = 0;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 10 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 0;
                    finalSniperBots = 0;
                    bigMeleeBots = 10;
                    bossBots = 4;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 11 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 0;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 12;
                    finalBossBots = 0;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 12 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 0;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 8;
                    finalBossBots = 2;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 13 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 0;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 8;
                    finalBossBots = 6;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 14 && waveSpawned == false)
                {
                    miniBots = 0;
                    sniperBots = 00;
                    finalSniperBots = 0;
                    bigMeleeBots = 0;
                    bossBots = 0;
                    finalBossBots = 12;
                    waveSpawned = true;
                    wave++;
                }
                else if (wave == 15 && waveSpawned == false)
                {
                    miniBots = 15;
                    sniperBots = 15;
                    finalSniperBots = 15;
                    bigMeleeBots = 15;
                    bossBots = 15;
                    finalBossBots = 15;
                    waveSpawned = true;
                    wave++;
                }
                #endregion

                #region Create Robots
                //Create Robots
                if (miniBots > 0 && counter > 4)
                {
                    //Makes new robot
                    Rectangle miniB = new Rectangle(685, 0, 10, 10);
                    miniRobots.Add(miniB);

                    //Adds properties
                    mRD.Add("down");
                    mRH.Add(2);

                    //Makes it finish spawning
                    miniBots--;
                    counter = 0;
                }
                if (sniperBots > 0 && miniBots == 0 && counter > 6)
                {
                    Rectangle sniperB = new Rectangle(685, 0, 10, 10);
                    sniperRobots.Add(sniperB);
                    sRD.Add("down");
                    sRH.Add(4);
                    sniperBots--;
                    counter = 0;
                }
                if (finalSniperBots > 0 && miniBots == 0 && sniperBots == 0 && counter > 9)
                {
                    Rectangle finalSniperB = new Rectangle(685, 0, 10, 10);  //?
                    finalSniperRobots.Add(finalSniperB);
                    fSRD.Add("down");
                    fSRH.Add(8);
                    finalSniperBots--;
                    counter = 0;
                }
                if (bigMeleeBots > 0 && finalSniperBots == 0 && miniBots == 0 && sniperBots == 0 && counter > 10)
                {
                    Rectangle bigMeleeB = new Rectangle(685, 0, 11, 11);
                    bigMeleeRobots.Add(bigMeleeB);
                    bMRD.Add("down");
                    bMRH.Add(16);
                    bigMeleeBots--;
                    counter = 0;
                }
                if (bossBots > 0 && bigMeleeBots == 0 && finalSniperBots == 0 && miniBots == 0 && sniperBots == 0 && counter > 10)
                {
                    Rectangle bossB = new Rectangle(685, 0, 13, 13);
                    bossRobots.Add(bossB);
                    bRD.Add("down");
                    bRH.Add(25);
                    bossBots--;
                    counter = 0;
                }
                if (finalBossBots > 0 && bossBots == 0 && bigMeleeBots == 0 && finalSniperBots == 0 && miniBots == 0 && sniperBots == 0 && counter > 10)
                {
                    Rectangle finalBossB = new Rectangle(685, 0, 12, 12);
                    finalBossRobots.Add(finalBossB);
                    fBRD.Add("down");
                    fBRH.Add(50);
                    finalBossBots--;
                    counter = 0;
                }
                #endregion

                counter++;
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
