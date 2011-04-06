using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    delegate void Attack(AbilityObject abilityObject, Collision collision);
    
    class AbilityObject : NonLivingObject, IIgnorable
    {
        #region attributes
        public event Attack CollisionOccurred;
        Timer timer;
        Direction direction;
        int damagePoints;
        #endregion

        #region properties
        public int DamagePoints
        {
            get { return damagePoints; }
        }
        #endregion


        /// <summary>
        /// Instanciates a new ability object.
        /// </summary>
        /// <param name="duration">Duration of the ability</param>
        /// <param name="texture">The texture of the ability</param>
        /// <param name="movementSpeed">the movement speed of the ability</param>
        /// <param name="direction">the direction of the ability</param>
        /// <param name="damagePoints">the damage points the ability causes</param>
        public AbilityObject(Vector2 startPosition, int duration, Texture2D texture, float movementSpeed, Direction direction, int damagePoints) : base(startPosition)
        {
            timer = new Timer(duration);
            timer.TimeEndedEvent += new TimerDelegate(Delete);
            timer.Start();
            animation.Initialize(texture.Width, texture.Height);

            this.movementSpeed = movementSpeed;
            this.direction = direction;
            if (this.direction == Direction.LEFT)
                FlipHorizontally(true);
            this.texture = texture;
            this.damagePoints = damagePoints;
            ActorManager.addActor(this);            
        }

        /// <summary>
        /// Ability specific collision handling. If it collides with a 
        /// </summary>
        /// <param name="collision"></param>
        public override void HandleCollision(Collision collision)
        {
            CollisionOccurred.Invoke(this, collision);
        }

        public override void Update(GameTime gameTime)
        {
            this.Move(direction);
            base.Update(gameTime);
        }


        public void Delete()
        {
            ActorManager.RemoveActor(this);
        }


        internal void AddAnimation(AnimationConstants animationType, int animationStartHeight, int animationWidth, int animationHeight, int numberOfFrames)
        {
            animation.AddAnimation(animationType, animationStartHeight, animationWidth, animationHeight, numberOfFrames);
            animation.SetCurrentAnimation(animationType);
        }


      

    }
}
