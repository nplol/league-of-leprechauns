using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LoL
{

    abstract class Actor
    {
        private SpriteEffects spriteEffect;
        private Texture2D texture;
        private Rectangle frame;

        public float Depth { get; set; }

        public Vector2 Origin
        {
            get { return new Vector2(texture.Width / 2, texture.Height / 2); }

        }

        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        public Vector2 Scale { get; set; }

        /*
         * Metode introdusert under kollisjonsdeteksjon. Returnerer
         * et rektangel som omslutter spriten.
         */
        public Rectangle generateBoundingRectangle()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
        }


        public void flipHorizontally()
        {
            if (spriteEffect == SpriteEffects.FlipHorizontally)
                spriteEffect = SpriteEffects.None;
            else
                spriteEffect = SpriteEffects.FlipHorizontally;
        }

        public Actor(Vector2 startPosition)
        {
            spriteEffect = SpriteEffects.None;
            Depth = 0.0f;
            Scale = new Vector2(1, 1);
            Rotation = 0.0f;
            Position = startPosition;
        }

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            texture = theContentManager.Load<Texture2D>(theAssetName);
            frame = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }


        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(texture, Position - camera.Position, frame, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }
    }
}