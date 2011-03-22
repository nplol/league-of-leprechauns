using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    enum AbilityNumber { FIRST, SECOND, THIRD, FOURTH };

    abstract class Character : Actor
    {
        #region Attributes

        private int level;
        protected int healthPoints;
        private int totalHealthPoints;
        private int attackSpeed;
        private int jumpSpeed;
        private Boolean jumping;
        private int baseDamagePoints;

        protected int timeSinceLastFrame = 0;
        public const int RUNNING_ANIMATION_SPEED = 50;

        #endregion

        #region Properties

        public int HealthPoints
        {
            get { return healthPoints; }
        }

        public int TotalHealthPoints
        {
            get { return totalHealthPoints; }
        }

        #endregion

        public Character(Vector2 startPosition, int level, int totalHealth, int attackSpeed, int jumpSpeed) : base(startPosition) 
        {
            this.level = level;
            totalHealthPoints = totalHealth;
            this.healthPoints = totalHealth;
            this.attackSpeed = attackSpeed;
            this.jumpSpeed = jumpSpeed;
            jumping = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (CurrentSpeed.X < 0)
            {
                flipHorizontally(true);
            }
            else if (CurrentSpeed.X > 0)
            {
                flipHorizontally(false);
            }
        }

        public bool timeForNextFrame()
        {
            return timeSinceLastFrame > RUNNING_ANIMATION_SPEED;
        }

        public virtual void move()
        {

        }

        public void Jump()
        {
            if (!isJumping())
            {
                setJumping(true);
                AddForce(new Vector2(0, -jumpSpeed));
            }
        }


        public Boolean isJumping()
        {
            return this.jumping;
        }

        public void setJumping(Boolean jumping)
        {
            this.jumping = jumping;
        }

        public void takeDamage(int damagePoints)
        {
            this.healthPoints -= damagePoints;
            if (this.healthPoints < 0)
                this.healthPoints = 0;
        }

        public override void HandleCollision(Collision collision)
        {
            if (collision.getCollidingActor() is BackgroundObject)
                return;

            base.HandleCollision(collision);
            if (collision.IsOnGround())
                setJumping(false);
        }

        public abstract void PerformAbility(AbilityNumber abilityNumber);


    }
}
