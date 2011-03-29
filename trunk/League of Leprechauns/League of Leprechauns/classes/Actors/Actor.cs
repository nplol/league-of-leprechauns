﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    public abstract class Actor
    {
        public Boolean active;
        protected Texture2D texture;
        private SpriteEffects spriteEffect;
        protected float movementSpeed;
        private Vector2 currentForce;
        private Vector2 currentSpeed;
        private bool collided;
        private Vector2 transVector, collisionForce;

        internal Animation animation;

        public bool Collided { get { return collided; } }
        public float Depth { get; private set; }
        public Vector2 Scale { get; private set; }
        public float Rotation { get; private set; }
        public Vector2 Origin { get { return new Vector2(0,0); } }
        public Vector2 CurrentPosition { get; protected set; }
        public Vector2 CurrentSpeed { get { return currentSpeed; } }
        public Vector2 PotentialSpeed { get { return currentSpeed + currentForce; } }



        public Actor(Vector2 startPosition)
        {
            active = false;
            spriteEffect = SpriteEffects.None;
            Depth = 0.0f;
            Scale = new Vector2(1, 1);
            Rotation = 0.0f;
            CurrentPosition = startPosition;
            movementSpeed = Settings.PLAYER_INITIAL_SPEED;

            animation = new Animation();
        }
   
        /*
         * Property introdusert under kollisjonsdeteksjon. Returnerer
         * et rektangel som omslutter spriten.
         */
        public virtual Rectangle PotentialMoveRectangle
        {
            get { return new Rectangle( (int) (CurrentPosition.X + PotentialSpeed.X), 
                (int) (CurrentPosition.Y + PotentialSpeed.Y),
                animation.CurrentRectangle.Width, 
                animation.CurrentRectangle.Height); }
        }

        public Rectangle BoundingRectangle
        {
            get
            {
               return new Rectangle((int)CurrentPosition.X,
                                      (int)CurrentPosition.Y,
                                      animation.CurrentRectangle.Width,
                                      animation.CurrentRectangle.Height);
            }
        }

        public void FlipHorizontally(bool on)
        {
            if (on)
                spriteEffect = SpriteEffects.FlipHorizontally;
            else
                spriteEffect = SpriteEffects.None;
        }


        public virtual void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            texture = theContentManager.Load<Texture2D>(theAssetName);

            //add default animation
            animation.Initialize(texture.Width, texture.Height);
        }

        /// <summary>
        /// Applies a force to the actor
        /// </summary>
        /// <param name="force">The force</param>
        public void AddForce(Vector2 force)
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

        //public void AddCollisionForce(Vector2 force)
        //{
        //    collisionForce += force;
        //}

        /// <summary>
        /// Increases the current speed of the actor by the given direction * movementSpeed
        /// </summary>
        /// <param name="direction">The direction </param>
        public void Move(Direction direction)
        {
            AddForce(new Vector2((int)direction * movementSpeed, 0));
            CollisionDetector.DetectCollisions(ActorManager.getListOfAllActors(), this);
        }

        /// <summary>
        /// Updates the current speed according to the current forces affecting the Actor, and then resets the force vector
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            this.collided = false;
        }

        /// <summary>
        /// Is supposed to represent the effects of each possible collision
        /// </summary>
        /// <param name="collision"></param>
        public virtual void HandleCollision(Collision collision)
        {
            this.collided = true;
        }

        /// <summary>
        /// Draws the actor on the spriteBatch based on it's position and the camera's position
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to draw on</param>
        /// <param name="camera">The camera which controls the view of the game</param>
        public virtual void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(texture, CurrentPosition - camera.Position, animation.CurrentRectangle, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
            if (this is CabbageLips)
                spriteBatch.DrawString(GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/ButtonFont"), transVector.ToString(),
                                        new Vector2(0, 100), Color.White);
            if (this is FlufferNutter)
                spriteBatch.DrawString(GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/ButtonFont"), transVector.ToString(),
                                        new Vector2(0, 150), Color.White);
        }

        protected void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, CurrentPosition, animation.CurrentRectangle, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }

        /// <summary>
        /// Updates the position of the actor based on the forces applied to it.
        /// </summary>
        public void ApplyForcesToActor()
        {
            currentSpeed += currentForce;
            collisionForce = Vector2.Zero;
            currentForce = Vector2.Zero;

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