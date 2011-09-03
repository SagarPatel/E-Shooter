using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;


namespace E_Shooter
{

    public class SimpleStraight_BulletObject : BulletObjectAbstract
    {

        public SimpleStraight_BulletObject(Game game, SpriteBatch givenSpriteBatch):base(game,givenSpriteBatch)
        {
            
        }


        protected override void LoadContent()
        {
            texture = TextureManager.sharedTextureManager.getTexture("Player1Sprite");
            scale = 0.2f;
            color = Color.LawnGreen;

            fireCooldown = 100;
            speed = 1;

            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {

            if (isAlive)
            {
                updatePV(gameTime);
                //Handle leaving screen
                Rectangle myRect = getRect();
                if (!isInsideScreen() && !isIntersectingScreen())
                    isAlive = false;

                if (isAlive)
                {
                    List<GameObjectAbstract> collList = GameFlowManager.sharedGameFlowManager.getCurrentScreen().collisionList;

                    foreach (GameObjectAbstract collObj in collList)
                    {
                        if (collObj.isAlive)
                        {
                            if (collObj.isCollidingOtherObject(myRect))
                            {
                                collObj.isAlive = false;
                                this.isAlive = false;
                            }
                        }
                    }
                }

            }

            
           
          

            base.Update(gameTime);
        }


        private void updatePV(GameTime gameTime)
        {
            velocity = speed * facing;
            position += velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }



    }



}