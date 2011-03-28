using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public AbilityObject(Vector2 startPosition, int duration, Texture2D texture, float movementSpeed, Direction direction) : base(startPosition)
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

        internal void AddAnimation(AnimationDefiniton animationDefinition)
        {
            animation.AddAnimation(animationDefinition);
            animation.SetCurrentAnimation(animationDefinition.animationType);
        }
    }
}
