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
        private Vector2 currentForce;
        private Vector2 currentSpeed;

        protected float movementSpeed;

        public float Depth { get; set; }

        public Vector2 Origin
        {
            get { return new Vector2(texture.Width / 2, texture.Height / 2); }
        }

        public Vector2 CurrentSpeed 
        {
            get { return currentSpeed; }
        }

        public Vector2 Position { get; protected set; }

        public float Rotation { get; private set; }

        public Vector2 Scale { get; private set; }

        /*
         * Metode introdusert under kollisjonsdeteksjon. Returnerer
         * et rektangel som omslutter spriten.
         */
        public Rectangle BoundingRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height); }
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
            movementSpeed = Settings.PLAYER_INITIAL_SPEED;
        }

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            texture = theContentManager.Load<Texture2D>(theAssetName);
            frame = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        //TODO: add speed threshold to Settings
        public void ApplyForce(Vector2 force)
        {
            currentForce += force;
            if (currentForce.X > 20)
                currentForce.X = 20;
            if (currentForce.X < -20)
                currentForce.X = -20;
            if (currentForce.Y > 20)
                currentForce.Y = 20;
            if (currentForce.Y < -20)
                currentForce.Y = -20;
        }

        public void Move(Direction direction)
        {
            currentSpeed.X += (int)direction * movementSpeed;
        }

        public virtual void Update(GameTime gameTime)
        {
            currentSpeed += currentForce;
            currentForce = Vector2.Zero;
        }

        public abstract void HandleCollision(Collision collision);

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(texture, Position - camera.Position, frame, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }

        public void UpdatePosition()
        {
            Position += currentSpeed;
        }
    }
}