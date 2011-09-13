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


    public abstract class BulletObjectAbstract : GameObjectAbstract
    {

        public static int fireCooldown;
        public static float speed;
        public static float fireRateCounter;

        public int damagePoints;

        public BulletObjectAbstract(Game game, SpriteBatch givenSpriteBatch):base(game, givenSpriteBatch)
        {
            fireCooldown = 100;
            speed = 1;
            fireRateCounter = 1;
            damagePoints = 10;

        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

  


    }



}
