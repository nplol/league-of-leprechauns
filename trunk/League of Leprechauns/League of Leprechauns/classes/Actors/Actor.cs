using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace League_of_Leprechauns
{
    class Actor
    {
        static List<Actor> Actors;
        private SpriteEffects spriteEffect;
        private Texture2D texture;

        public float Depth
        {
            set;
            get;
        }

        public Vector2 Origin
        {
            get { return new Vector2(texture.Width / 2, texture.Height / 2); }

        }

        public Vector2 Position
        {
            get;
            set;
        }

        public float Rotation
        {
            get;
            set;
        }

        public float Scale
        {
            get;
            set;
        }

        public void flipHorizontally()
        {
            if (spriteEffect == SpriteEffects.FlipHorizontally)
                spriteEffect = SpriteEffects.None;
            else
                spriteEffect = SpriteEffects.FlipHorizontally;
        }

       
        static Actor()
        {
            Actors = new List<Actor>();
        }

        public Actor()
        {
            Actors.Add(this);
            spriteEffect = SpriteEffects.None;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }
    }
}