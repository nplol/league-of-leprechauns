using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    delegate void Attack(AbilityObject abilityObject, Collision collision);
    
    class AbilityObject : NonLivingObject, IIgnorable
    {
        public event Attack CollisionOccurred;
        Timer timer;
        Direction direction;
        int damagePoints;
        Vector2 hitbox;
       

        #region properties
        public int DamagePoints
        {
            get { return damagePoints; }
        }
        #endregion
        public AbilityObject(Vector2 startPosition, int duration, Texture2D texture, float movementSpeed, Direction direction, int damagePoints, Vector2 hitbox) : base(startPosition)
        {
            timer = new Timer(duration);
            timer.TimeEndedEvent += new TimerDelegate(Delete);
            timer.Start();
            animation.Initialize(texture.Width, texture.Height);

            this.hitbox = hitbox;
            this.movementSpeed = movementSpeed;
            this.direction = direction;
            if (this.direction == Direction.LEFT)
                FlipHorizontally(true);
            this.texture = texture;
            this.damagePoints = damagePoints;
            ActorManager.addActor(this);
            
        }

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


       ////  Overrides PotentialMoveRectangle so the hitbox can be specified
       // public override Rectangle PotentialMoveRectangle
       // {
       //     get
       //     {
       //         return new Rectangle((int)(CurrentPosition.X + PotentialSpeed.X),
       //             (int)(CurrentPosition.Y - (int)hitbox.Y/2  + PotentialSpeed.Y),
       //             (int)hitbox.X,
       //             (int)hitbox.Y);
       //     }
       // }

    }
}
