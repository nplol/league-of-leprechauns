using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace LoL
{
    /// <summary>
    /// Base class for all actors
    /// </summary>
    public abstract class Actor
    {
        #region attributes
        private bool active;
        protected Texture2D texture;
        private SpriteEffects spriteEffect;
        protected float movementSpeed;
        protected Vector2 currentForce;
        protected Vector2 currentSpeed;
        internal Animation animation;

        /// <summary>
        /// actor ID (from the level file)
        /// </summary>
        public int actorID;

        #endregion

        #region Properties

        public bool Active { get { return active; } protected set { active = value; } }
        public float Depth { get; private set; }
        public Vector2 Scale { get; private set; }
        public float Rotation { get; private set; }
        public Vector2 Origin { get { return new Vector2(0,0); } }
        public Vector2 CurrentPosition { get; protected set; }
        public Vector2 CurrentSpeed { get { return currentSpeed; } }
        public Vector2 PotentialSpeed { get { return currentSpeed + currentForce; } }

        #endregion

        /// <summary>
        /// Instanciates a new actor.
        /// </summary>
        /// <param name="startPosition"></param>
        public Actor(Vector2 startPosition)
        {
            active = false;
            spriteEffect = SpriteEffects.None;
            Depth = 0.0f;
            Scale = new Vector2(1, 1);
            Rotation = 0.0f;
            CurrentPosition = startPosition;

            animation = new Animation();
        }
   
        /// <summary>
        /// Rectangle which contains the sprites next move.
        /// </summary>
        public virtual Rectangle PotentialMoveRectangle
        {
            get { return new Rectangle( (int) (CurrentPosition.X + PotentialSpeed.X), 
                (int) (CurrentPosition.Y + PotentialSpeed.Y),
                animation.CurrentRectangle.Width, 
                animation.CurrentRectangle.Height); }
        }

        /// <summary>
        /// Rectangle which contains the sprite.
        /// </summary>
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

        /// <summary>
        /// Flips the sprite horizontally if the parameter is true
        /// </summary>
        /// <param name="on"></param>
        public void FlipHorizontally(bool on)
        {
            if (on)
                spriteEffect = SpriteEffects.FlipHorizontally;
            else
                spriteEffect = SpriteEffects.None;
        }

        /// <summary>
        /// Loads the content associated with the actor.
        /// </summary>
        /// <param name="theContentManager"></param>
        /// <param name="theAssetName"></param>
        public virtual void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            texture = theContentManager.Load<Texture2D>(theAssetName);

            //add default animation
            animation.Initialize(texture.Width, texture.Height);
        }

        /// <summary>
        /// Applies a force to the actor, and then checks if the forces exceed the 
        /// predefined threshold.
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

        /// <summary>
        /// Increases the current speed of the actor by the given direction * movementSpeed.
        /// A call is then made to the collision detector to see if the new move results in a
        /// collision.
        /// </summary>
        /// <param name="direction">The direction </param>
        public virtual void Move(Direction direction)
        {
            AddForce(new Vector2((int)direction * movementSpeed, 0));
            CollisionDetector.DetectCollisions(ActorManager.GetListOfActiveActors(), this);
        }

        /// <summary>
        /// Updates the animation. Overridden by sub classes to perform class specific actions.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

        /// <summary>
        /// Overridden by each sub class needing its own unique response to collisions.
        /// </summary>
        /// <param name="collision"></param>
        public virtual void HandleCollision(Collision collision)
        {

        }

        /// <summary>
        /// Draws the actor on the spriteBatch based on its position and the camera's position
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to draw on</param>
        /// <param name="camera">The camera which controls the view of the game</param>
        public virtual void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(texture, CurrentPosition - camera.Position, animation.CurrentRectangle, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }

        /// <summary>
        /// Draws the actor on the spriteBatch unaware of the camera's position.
        /// </summary>
        /// <param name="spriteBatch"></param>
        protected void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, CurrentPosition, animation.CurrentRectangle, Color.White, Rotation, Origin, Scale, spriteEffect, Depth);
        }

        /// <summary>
        /// Updates the position of the actor based on the forces applied to it.
        /// </summary>
        public virtual void ApplyForcesToActor()
        {
            currentSpeed += currentForce;
            currentForce = Vector2.Zero;

            if(active)
                CurrentPosition += currentSpeed;
        }

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