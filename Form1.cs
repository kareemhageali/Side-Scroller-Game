
/*Kareem Hage-ali
 *June 17, 2014
 *Culminating Assignment
 **/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Culminating_Assignment
{
    public partial class Form1 : Form
    {
        //Controls whether or not the program is running 
        bool keepRunning = false;
        //Constants to store animation from rate and frame time
        const int FRAME_RATE = 60; //60 frames per second
        const int FRAME_TIME = 1000 / FRAME_RATE; //The length of the time needed for each frame
        //Constant number of platforms
        const int NUMBER_OF_PLATFORMS = 17;
        //Constant number of enemies
        const int NUMBER_OF_ENEMIES = 10;
        //Keeps track of time of the program
        int currentTime;
        int previousTime;
        //Controls the time that the program has been running for
        int programTime = 0;

        //Size
        Size platformSize;
        //Point Arrays
        Point[] platformsXY = new Point[NUMBER_OF_PLATFORMS];
        //Bounding Box arrays
        Rectangle[] platformsBoundingBox = new Rectangle[NUMBER_OF_PLATFORMS];

        //Size for user guy
        Size userSize;
        //Point for the user guy
        Point userXY;
        //Rectangle
        Rectangle userBoundingBox;

        //Size for enemy
        Size enemySize;
        //Point array for enemys
        Point[] enemysXY = new Point[NUMBER_OF_ENEMIES];
        //Bounding box arrays for enemys
        Rectangle[] enemysBoundingBox = new Rectangle[NUMBER_OF_ENEMIES];




        //Size for the bullet
        Size bulletSize;
        //Point for the bullet
        Point bulletXY;
        //Making a rectangle variable for the bullet
        Rectangle bulletBoundingBox;

        //Size for all background images
        Size backgroundSize;
        //Point for all background images
        Point backgroundXY;
        //Bounding box for background
        Rectangle gameOverBoundingBox;

        //Bool variable to determine if image does appear
        bool[] appearEnemy = new bool[NUMBER_OF_ENEMIES];
        bool appearBullet = false;
        bool appearGameOver = false;
        bool appearBackgroundGameOver = false;
        bool appearInstructions = true;
        bool appearYouWin = false;

        //The veritcal speed for the user
        int masterCheifYSpeed = 0;
        //The gravity for the user
        int gravity = 4;
        //Bool variable to determine if user jumps
        bool userJump = false;
        //Determines if user moves right
        bool userMoveRight = false;
        //Determines if user moves left
        bool userMoveLeft = false;
        //Determines if user is shooting
        bool isShooting = false;
        //Constant horizontal speed for the user
        const int MASTER_CHEIF_X_SPEED = 12;

        //Making a constant speed for the bullet
        const int BULLET_X_SPEED = 50;

        //Constant for sidescroll speed
        const int SIDE_SCROLL_X_SPEED = 15;
            

        //Time variables to time the user 
        DateTime start;
        //Used to restart program after amount of seconds on game over screen
        DateTime gameOverTime;
        TimeSpan secondsLasted;
        double timeTillRestart;

        public Form1()
        {
            InitializeComponent();
            //Intialize timer variables
            currentTime = Environment.TickCount;
            previousTime = currentTime;
            
            //Calling the subprogram "Initialize Images"
            InitializeImages();
            
        }

        void InitializeImages()
        {
            //Set the starting size for the platform
            platformSize = new Size(100, 20);
            //Set the starting point of the image
            platformsXY[0] = new Point(100, 400);
            //Set the image bounding box
            platformsBoundingBox[0] = new Rectangle(platformsXY[0], platformSize);
            //Starting point
            platformsXY[1] = new Point(400, 300); 
            //Set bounding box
            platformsBoundingBox[1] = new Rectangle(platformsXY[1], platformSize);
            //Starting point
            platformsXY[2] = new Point(700, 200); 
            //Set bounding box
            platformsBoundingBox[2] = new Rectangle(platformsXY[2], platformSize);
            //Point
            platformsXY[3] = new Point(1000, 400);
            //Bounding Box
            platformsBoundingBox[3] = new Rectangle(platformsXY[3], platformSize);
            //Point
            platformsXY[4] = new Point(1300, 300);
            //Bounding box
            platformsBoundingBox[4] = new Rectangle(platformsXY[4], platformSize);
            //Point
            platformsXY[5] = new Point(1600, 300);
            //Bounding box
            platformsBoundingBox[5] = new Rectangle(platformsXY[5], platformSize);
            //Point
            platformsXY[6] = new Point(1900, 200);
            //Bounding box
            platformsBoundingBox[6] = new Rectangle(platformsXY[6], platformSize);
            //Point
            platformsXY[7] = new Point(2150, 400);
            //Bounding box
            platformsBoundingBox[7] = new Rectangle(platformsXY[7], platformSize);
            //Point
            platformsXY[8] = new Point(2450, 300);
            //Bounding box
            platformsBoundingBox[8] = new Rectangle(platformsXY[8], platformSize);
            //Point
            platformsXY[9] = new Point(2750, 300);
            //Bounding box
            platformsBoundingBox[9] = new Rectangle(platformsXY[9], platformSize);
            //Point
            platformsXY[10] = new Point(2950, 200);
            //Bounding box
            platformsBoundingBox[10] = new Rectangle(platformsXY[10], platformSize);
            //Point
            platformsXY[11] = new Point(3150, 100);
            //Bounding box
            platformsBoundingBox[11] = new Rectangle(platformsXY[11], platformSize);
            //Point
            platformsXY[12] = new Point(3350, 400);
            //Bounding box
            platformsBoundingBox[12] = new Rectangle(platformsXY[12], platformSize);
            //Point
            platformsXY[13] = new Point(3550, 300);
            //Bounding box
            platformsBoundingBox[13] = new Rectangle(platformsXY[13], platformSize);
            //Point
            platformsXY[14] = new Point(3750, 400);
            //Bounding box
            platformsBoundingBox[14] = new Rectangle(platformsXY[14], platformSize);
            //Point
            platformsXY[15] = new Point(3950, 300);
            //Bounding box
            platformsBoundingBox[15] = new Rectangle(platformsXY[15], platformSize);
            //Point
            platformsXY[16] = new Point(4150, 200);
            //Bounding box
            platformsBoundingBox[16] = new Rectangle(platformsXY[16], platformSize);
            //Size for the user guy
            userSize = new Size(70, 80);
            //Point for the user
            userXY = new Point(115, 320);
            //Bounding box for the user guy
            userBoundingBox = new Rectangle(userXY, userSize);
            //Size for the enemy
            enemySize = new Size(50, 50);
            //Point for the enemy
            enemysXY[0] = new Point(platformsXY[2].X, 150);
            //Bounding box for the enemy
            enemysBoundingBox[0] = new Rectangle(enemysXY[0], enemySize);
            //Point
            enemysXY[1] = new Point(platformsXY[5].X, 250);
            //Bounding box for enemy
            enemysBoundingBox[1] = new Rectangle(enemysXY[1], enemySize);
            //Point
            enemysXY[2] = new Point(platformsXY[6].X, 150);
            //Bounding box for enemy
            enemysBoundingBox[2] = new Rectangle(enemysXY[2], enemySize);
            //Point
            enemysXY[3] = new Point(platformsXY[8].X, 250);
            //Bounding box for enemy
            enemysBoundingBox[3] = new Rectangle(enemysXY[3], enemySize);
            //Point
            enemysXY[4] = new Point(platformsXY[9].X, 250);
            //Bounding box for enemy
            enemysBoundingBox[4] = new Rectangle(enemysXY[4], enemySize);
            //Point
            enemysXY[5] = new Point(platformsXY[10].X, 150);
            //Bounding box for enemy
            enemysBoundingBox[5] = new Rectangle(enemysXY[5], enemySize);
            //Point
            enemysXY[6] = new Point(platformsXY[11].X, 50);
            //Bounding box for enemy
            enemysBoundingBox[6] = new Rectangle(enemysXY[6], enemySize);
            //Point
            enemysXY[7] = new Point(platformsXY[13].X, 250);
            //Bounding box for enemy
            enemysBoundingBox[7] = new Rectangle(enemysXY[7], enemySize);
            enemysXY[8] = new Point(platformsXY[15].X, 250);
            //Bounding box for enemy
            enemysBoundingBox[8] = new Rectangle(enemysXY[8], enemySize);
            enemysXY[9] = new Point(platformsXY[16].X, 150);
            //Bounding box for enemy
            enemysBoundingBox[9] = new Rectangle(enemysXY[9], enemySize);

            //Size for bullet
            bulletSize = new Size(20, 20);
            //Making the point for the bullet later on 
            bulletXY = new Point(0, 0);
            //Rectangle for the bullet
            bulletBoundingBox = new Rectangle(bulletXY, bulletSize);


            //Size for background
            backgroundSize = new Size(ClientSize.Width, ClientSize.Height);
            //Point for the background
            backgroundXY = new Point(0, 0);
            //Bounding box for the background
            gameOverBoundingBox = new Rectangle(backgroundXY, backgroundSize);
            //For loop for the bool "appear Enemy" in order to reduce amount of code
            for (int count = 0; count < appearEnemy.Length; count++)
            {
                appearEnemy[count] = true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Drawing the image for the user
            e.Graphics.DrawImage(Properties.Resources._1337_copy, userBoundingBox);
            //Drawing all platforms that are in an array
            for (int i = 0; i < platformsBoundingBox.Length; i++)
            {
                if (ClientRectangle.IntersectsWith(platformsBoundingBox[i]))
                {
                    e.Graphics.DrawImage(Properties.Resources.wood, platformsBoundingBox[i]);
                }
            }

            /*Drawing collison rectangle around user
            e.Graphics.DrawLine(Pens.Red, new Point(userXY.X, userXY.Y), new Point(userXY.X + userSize.Width, userXY.Y));
            e.Graphics.DrawLine(Pens.Red, new Point(userXY.X, userXY.Y), new Point(userXY.X, userXY.Y + userSize.Height));
            e.Graphics.DrawLine(Pens.Red, new Point(userXY.X + userSize.Width, userXY.Y), new Point(userXY.X + userSize.Width, userXY.Y + userSize.Height));
            e.Graphics.DrawLine(Pens.Red, new Point(userXY.X, userXY.Y + userSize.Height), new Point(userXY.X + userSize.Width, userXY.Y + userSize.Height));*/

            //Drawing all enemies that are in the array
            for (int i = 0; i < appearEnemy.Length; i++)
            {
                if (appearEnemy[i] == true && ClientRectangle.IntersectsWith(enemysBoundingBox[i]))
                {
                    e.Graphics.DrawImage(Properties.Resources.scarab_copy, enemysBoundingBox[i]);
                }
            }
            //Drawing the bullet if user wants to shoot
            if (appearBullet == true)
            {
                e.Graphics.FillEllipse(Brushes.Red, bulletBoundingBox);
            }
            //If the player dies, the game over screen will appear
            if (appearBackgroundGameOver == true)
            {
                e.Graphics.DrawImage(Properties.Resources.black, gameOverBoundingBox);
            }
            //Draws the game over text
            if (appearGameOver == true)
            {
                e.Graphics.DrawString("GAME OVER", new Font(FontFamily.GenericMonospace, 35), Brushes.Red, new PointF(230, 225));
                e.Graphics.DrawString("You lasted " + secondsLasted.TotalSeconds.ToString("0.0") + " seconds" ,new Font(FontFamily.GenericMonospace, 35), Brushes.White, new PointF(40, 260));
                e.Graphics.DrawString("Time until restart: " + (2.0-timeTillRestart).ToString("0.0"), new Font(FontFamily.GenericMonospace, 18), Brushes.White, new PointF(180, 350));
            }
            //Drawing Instructions for the game 
            if (appearInstructions == true)
            {
                e.Graphics.DrawString("Arrows Keys = Left/Right Spacebar = Jump Z = Shoot", new Font(FontFamily.GenericMonospace, 12), Brushes.White, new PointF(0, 50));
                e.Graphics.DrawString("Dont fall OR hit the side of the screen or else you lose!", new Font(FontFamily.GenericMonospace, 12), Brushes.White, new PointF(0, 75));
                e.Graphics.DrawString("Kill the enemies while lasting as long as possible", new Font(FontFamily.GenericMonospace, 12), Brushes.White, new PointF(0, 100));
                e.Graphics.DrawString("Press Enter to begin", new Font(FontFamily.GenericMonospace, 12), Brushes.White, new PointF(0, 125));
            }
            //Drawing the winn screen
            if (appearYouWin == true)
            {
                e.Graphics.DrawString("You Win!", new Font(FontFamily.GenericMonospace, 35), Brushes.Green, new PointF(230, 225));

            }
        }

        //Subprogram that makes player jump 
        void MovePlayer()
        {
            //New temperary point for the future position of player
            Point tempUserXY = new Point(userXY.X, userXY.Y);
            //Adding veritcal speed to the new point
            tempUserXY.Y = userXY.Y + masterCheifYSpeed;
            //Making a temperary future speed of player
            int tempSpeed = masterCheifYSpeed;
            tempSpeed = masterCheifYSpeed + gravity;
            //Making bounding box for temperary user
            Rectangle tempUser = new Rectangle(tempUserXY, userSize);
            //Determines if user is colliding with platform
            Rectangle collison = CollidePlatform(tempUser);
            //If the use doesnt collide with anything, the user can continue to move
            if (collison == Rectangle.Empty)
            {
                //Update user's location and speed
                userXY = tempUserXY;
                userBoundingBox.Location = userXY;
                masterCheifYSpeed = tempSpeed;
            }
            else
            {
                //If the person collides with a platform, the user is brought to the platform
                Rectangle intersect = Rectangle.Intersect(collison,tempUser);
                if (intersect.Y > tempUserXY.Y)
                {
                    tempUserXY.Y -= intersect.Height;
                }
                else
                {
                    tempUserXY.Y += intersect.Height;
                }
                tempUser.Location = tempUserXY;
                userXY = tempUserXY;
                userBoundingBox = tempUser;
                masterCheifYSpeed = 0;
                userJump = false;
            }
            //If user hits the bottom of the screen, the game over screen subprogram is called
            if (userXY.Y >= ClientSize.Height && appearGameOver == false)
            {
                GameOver();
            }
            //If the user hits the right side of the screen, the game over subprogram is called
            if (userXY.X >= ClientSize.Width && appearGameOver == false)
            {
                GameOver();
            }
            //If the user hits the left side of the screen, the game over subprogram is called
            if (userXY.X <= 0 && appearGameOver == false)
            {
                GameOver();
            }
            //If user hits the enemy, the game over subprogram is called
            for (int i = 0; i < appearEnemy.Length; i++)
            {
                if (userBoundingBox.IntersectsWith(enemysBoundingBox[i]) && appearEnemy[i] == true && appearGameOver == false)
                {
                    GameOver();
                }
            }
        }

        void GameOver()
        {
            //Makes the game over screen appear
            appearGameOver = true;
            appearBackgroundGameOver = true;
            //Calculates time that user was alive
            secondsLasted = DateTime.Now.Subtract(start);
            gameOverTime = DateTime.Now;

        }

        void YouWin()
        {
            //When user wins, it wil say You Win!
            appearYouWin = true;
            appearBackgroundGameOver = true;
            keepRunning = false;
            appearGameOver = false;
            

            
            Refresh();
        }

        void MoveRight()
        {
            //Moving the user right
            Point tempXY = new Point(userXY.X + MASTER_CHEIF_X_SPEED, userXY.Y);
            Rectangle tempBoundingBox = new Rectangle(tempXY, userSize);
            Rectangle collision = CollidePlatform(tempBoundingBox);
            //If user doesnt hit anything, the user keeps his speed
            if (collision == Rectangle.Empty)
            {
                userXY.X = userXY.X + MASTER_CHEIF_X_SPEED;
                //Update location
                userBoundingBox.Location = userXY;
            }
            else
            {
                //If the person collides with a platform, the user is brought to the platform
                Rectangle intersect = Rectangle.Intersect(collision, tempBoundingBox);
                if (intersect.X > tempXY.X)
                {
                    //tempXY.X = intersect.Location.X - userSize.Width;
                }
                else
                { 
                    //tempXY.X = intersect.Location.X - userSize.Width;
                }
                //Updating location
                tempBoundingBox.Location = tempXY;
                userXY = tempXY;
                userBoundingBox = tempBoundingBox;
            }
        }

        void MoveLeft()
        {
            //Moving the user right
            Point tempXY = new Point(userXY.X - MASTER_CHEIF_X_SPEED, userXY.Y);
            Rectangle tempBoundingBox = new Rectangle(tempXY, userSize);
            Rectangle collision = CollidePlatform(tempBoundingBox);
            //If user doesnt hit anything, the user keeps his speed
            if (collision == Rectangle.Empty)
            {
                userXY.X = userXY.X - MASTER_CHEIF_X_SPEED;
                //Update location
                userBoundingBox.Location = userXY;
            }
            else
            {
                //If the person collides with a platform, the user is brought to the platform
                Rectangle intersect = Rectangle.Intersect(collision, tempBoundingBox);
                if (intersect.X < tempXY.X)
                {
                    //tempXY.X -= intersect.Width;
                }
                else
                {
                    //tempXY.X += intersect.Width;
                }
                //Updating location
                tempBoundingBox.Location = tempXY;
                userXY = tempXY;
                userBoundingBox = tempBoundingBox;
            }
        }

        void Shooting()
        {
            //Making the bullet move forward
            bulletXY.X = bulletXY.X + BULLET_X_SPEED;
            bulletBoundingBox.Location = bulletXY;
            //Check if the bullet is still within the client
            if (bulletBoundingBox.IntersectsWith(ClientRectangle) == false)
            {
                //If the user doesnt shoot, the bullet wont appear
                if (isShooting == false)
                {
                    appearBullet = false;
                }
                //Resets position back to player
                bulletXY = userXY;
            }
            //If the bullet hits the enemy, the enemy will disappear
            for (int i = 0; i < appearEnemy.Length; i++)
            {
                if (appearBullet == true && bulletBoundingBox.IntersectsWith(enemysBoundingBox[i]) && appearEnemy[i] == true)
                {
                    appearEnemy[i] = false;
                    appearBullet = false;
                }
            }
        }
        void SideScrolling()
        {

            //Update location and make all platforms side scroll
            for (int i = 0; i < platformsBoundingBox.Length; i++)
            {
                //Making the platforms go left to create side scroll
                platformsXY[i].X -= SIDE_SCROLL_X_SPEED;
                platformsBoundingBox[i].Location = platformsXY[i];
            }

            //Making enemies side scroll with the platforms
            for (int i = 0; i < enemysXY.Length; i++)
            {
                enemysXY[i].X -= SIDE_SCROLL_X_SPEED;
                //Update the enemy location
                enemysBoundingBox[i].Location = enemysXY[i];
            }
        }

        Rectangle CollidePlatform(Rectangle otherRect)
        {
            //If the user hits the platform, it will return as hitting the platform bounding box otherwise will return hitting nothing
            for (int i = 0; i < platformsBoundingBox.Length; i++)
            {

                if (platformsBoundingBox[platformsBoundingBox.Length - 1].IntersectsWith(otherRect))            
                {
                    YouWin();
                    return platformsBoundingBox[platformsBoundingBox.Length - 1];
                }
                if (platformsBoundingBox[i].IntersectsWith(otherRect) == true)
                {
                    return platformsBoundingBox[i];
                }
            }
            return Rectangle.Empty;
        }
        
        //Subprogram that creates the time in my program
        void CustomTimer()
        {
            //Loops until the escape key is pressed
            do
            {
                //Get the current time
                currentTime = Environment.TickCount;
                //Calculates how much time has passed since the last program update
                int timePassed = currentTime - previousTime;
                //Only update program if enough time has passed
                if (timePassed >= FRAME_TIME)
                {
                    //Update the timer variable
                    previousTime = currentTime;
                    programTime++;
                    MovePlayer();
                    if (userMoveRight == true)
                    {
                        //Calls the subprogam to move user right
                        
                        MoveRight();
                    }
                    if (userMoveLeft == true)
                    {
                        //Calls the subprogram to move user left
                        MoveLeft();
                    }
                    //RESTART APPLICATION AFTER 2 SECONDS OF GAME OVER SCREEN
                    if (appearGameOver == true && DateTime.Now.Subtract(gameOverTime).TotalSeconds >= 2)
                    {
                        Application.Restart();
                        keepRunning = false; //this is here due to a weird bug where the application never exits so it opens 10000+ windows until out of memory
                    }
                    else
                    {
                        //Counts the time it takes to restart program
                        timeTillRestart = DateTime.Now.Subtract(gameOverTime).TotalSeconds;
                    }
                    //Calls the shooting subprogram
                    Shooting();
                    //Calls the side scrolling subprogram
                    SideScrolling();
                    //Update the paint
                    Refresh();

                }
                //Prevents the program from freezing
                Application.DoEvents();

            }
            while (keepRunning == true);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //When the escape key is pressed, close the program
            if (e.KeyCode == Keys.Escape)
            {
                //Stops program
                keepRunning = false;
                //Exits program
                Application.Exit();
            }
            //Starts program when enter is pressed
            if (e.KeyCode == Keys.Enter)
            {
                keepRunning = true;
                appearInstructions = false;
                start = DateTime.Now;
                //Calls the custom timer subprogram
                CustomTimer();
            }
            if (keepRunning)
            {
                if (e.KeyCode == Keys.Space && !userJump)
                {
                    masterCheifYSpeed = -30;
                    //Makes the jump variable true in order to jump
                    userJump = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    //Makes the move right variable true if user presses right arrow key
                    userMoveRight = true;

                }
                //When the user presses the left key, the user moves left
                if (e.KeyCode == Keys.Left)
                {
                    userMoveLeft = true;
                }
                //Makes user shoot when Z is pressed
                if (e.KeyCode == Keys.Z && !isShooting && !appearBullet)
                {
                    bulletXY = new Point(userXY.X, userXY.Y + (userSize.Height / 2));
                    appearBullet = true;
                    isShooting = true;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //User can hold the key in order to move left/right
            if (keepRunning == true)
            {
                if (e.KeyCode == Keys.Right)
                {
                    userMoveRight = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    userMoveLeft = false;
                }
                if (e.KeyCode == Keys.Z)
                {
                    isShooting = false;
                }
            }
        }

    }
}
