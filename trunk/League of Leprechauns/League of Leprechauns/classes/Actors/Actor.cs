﻿using System;
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
        public Boolean active;
        private Texture2D texture;
        private SpriteEffects spriteEffect;
        protected float movementSpeed;
        private Rectangle frame;
        private Vector2 currentForce;
        private Vector2 currentSpeed;
        
        public float Depth { get; set; }
        public Vector2 Scale { get; private set; }
        public Vector2 CurrentPosition { get; protected set; }

        public Vector2 Origin
        {
            get { return new Vector2(texture.Width / 2, texture.Height / 2); }
        }

        public Vector2 CurrentSpeed 
        {
            get { return currentSpeed; }
        }

        

        public float Rotation { get; private set; }

        

        /*
         * Property introdusert under kollisjonsdeteksjon. Returnerer
         * et rektangel som omslutter spriten.
         */
        public virtual Rectangle BoundingRectangle
        {
            get { return new Rectangle((int)CurrentPosition.X, (int)CurrentPosition.Y, texture.Width, texture.Height); }
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
            active = false;
            spriteEffect = SpriteEffects.None;
            Depth = 0.0f;
            Scale = new Vector2(1, 1);
            Rotation = 0.0f;
            CurrentPosition = startPosition;
            movementSpeed = Settings.PLAYER_INITIAL_SPEED;
        }

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            texture = theContentManager.Load<Texture2D>(theAssetName);
            frame = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        /// <summary>
        /// Applies a force to the actor
        /// </summary>
        /// <param name="force">The force</param>
        public void ApplyForce(Vector2 force)
        {
            currentForce += force;
            if (currentForce.X > Settings.FORCE_THRESHOLD)
                currentForce.X = Settings.FORCE_THRESHOLD;
            if (currentForce.X < -Settings.FORCE_THRESHOLD)
                currentForce.X = -Settings.FORCE_THRESHOLD;
            if (currentForce.Y > Settings.FORCE_THRESHOLD)
                currentForce.Y = Settings.FORCE_THRESHOLD;
            if (currentForce.Y < -Settings.FORCE_THRESHOLD)
                currentForce.Y = -Settings.FORCE_THRESHOLD;
        }

        /// <summary>
        /// Increases the current speed of the actor by the given direction * movementSpeed
        /// </summary>
        /// <param name="direction">The direction </param>
        public void Move(Direction direction)
        {
            ApplyForce(new Vector2((int)direction * movementSpeed, 0));
        }

        /// <summary>
        /// Updates the current speed according to the current forces affecting the Actor, and then resets the force vector
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            currentSpeed += currentForce;
            currentForce = Vector2.Zero;
        }

        /// <summary>
        /// Is supposed to represent the effects of each possible collision
        /// </summary>
        /// <param name="collision"></param>
        public abstract void HandleCollision(Collision collision);

        /// <summary>
        /// Draws the actor on the spriteBatch based on it's position and the camera's position
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to draw on</param>
        /// <param name="camera">The camera which controls the view of the game</param>
        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(texture, CurrentPosition - camera.Position, frame, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }
        /// <summary>
        /// Updates the position of the actor based on the forces applied to it.
        /// </summary>
        /// <summary>
        /// Updates the position according to the current speed (makes a move)
        /// </summary>
        public void UpdatePosition()
        {
            if(active)
                CurrentPosition += currentSpeed;
        }

        /// <summary>
        /// 
        /// </summary>
        #region activation & deactivation
        public void Activate()
        {
            active = true;
        }
        public void Deactivate()
        {
            active = false;
        }
        #endregion

    }
}