using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;



namespace E_Shooter
{
    public sealed class GameFlowManager : Microsoft.Xna.Framework.GameComponent
    {

        public static Game myGame;
        public static SpriteBatch mySpriteBatch;
        private static readonly GameFlowManager instance = new GameFlowManager(myGame,mySpriteBatch);

        public PlayerObject player1;
        public MainMenu mainMenu;
        public Level_1_1 level1;
        public Level_1_2 level2;
        public Level_1_3 level3;
        public Level_1_4 level4;
        public Level_1_5 level5;
        //simple levels end

        //targeted spawning levels begin


        List<ScreenAbstract> screenList;
        int currentScreenIndex;

        Random rand;

        private GameFlowManager(Game game, SpriteBatch mySpriteBatch): base(game)
        {
            screenList = new List<ScreenAbstract>();
            currentScreenIndex = 0;
            rand = new Random();
        }

        public static GameFlowManager sharedGameFlowManager
        {
            get
            {
                return instance;
            }

        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public void manualInit()
        {

            player1 = new PlayerObject(myGame, mySpriteBatch);
            player1.scale = 0.75f;
            myGame.Components.Add(player1);

            mainMenu = new MainMenu(myGame, mySpriteBatch);
            mainMenu.isActive = true;
            screenList.Add(mainMenu);
            myGame.Components.Add(mainMenu);

            level1 = new Level_1_1(myGame, mySpriteBatch);
            level1.isActive = false;
            screenList.Add(level1);

            level2 = new Level_1_2(myGame, mySpriteBatch);
            level2.isActive = false;
            screenList.Add(level2);

            level3 = new Level_1_3(myGame, mySpriteBatch);
            level3.isActive = false;
            screenList.Add(level3);

            level4 = new Level_1_4(myGame, mySpriteBatch);
            level4.isActive = false;
            screenList.Add(level4);

            level5 = new Level_1_5(myGame, mySpriteBatch);
            level5.isActive = false;
            screenList.Add(level5);
           

        }


        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            ScreenAbstract currentScreen = screenList[currentScreenIndex];
            if ( currentScreen.isComplete == true)
            {
                myGame.Components.Remove(currentScreen);
              //  currentScreen.Dispose();

                currentScreenIndex ++;

                if (currentScreenIndex < screenList.Count)
                {
                    ScreenAbstract newScreen = screenList[currentScreenIndex];
                    newScreen.isActive = true;
                    myGame.Components.Add(newScreen);
                }
                else
                {
                    currentScreenIndex --;
                }
                
            }

            base.Update(gameTime);
        }



        //Custom functions

        public ScreenAbstract getCurrentScreen()
        {
            return screenList[currentScreenIndex];
        }

        public Vector2 getRandomVector(int targetAngle, int coneArc)
        {
            int maxAngle = targetAngle + coneArc / 2;
            int minAngle = targetAngle - coneArc / 2;
            int randomAngle = rand.Next(minAngle, maxAngle);
            Vector2 randomVector = new Vector2(0, 1);
            randomVector = Vector2.Transform(randomVector, Matrix.CreateRotationZ(MathHelper.ToRadians((float)randomAngle)));
            return randomVector;
        }

    }
}
