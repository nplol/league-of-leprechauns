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
        private int baseDamagePoints;
        private int attackSpeed;
        private int jumpSpeed;
        private Boolean isJumping;

        protected Direction faceDirection;

        protected int timeSinceLastFrame = 0;
        public const int RUNNING_ANIMATION_SPEED = 50;

        #endregion

        #region Properties

        public Direction FaceDirection
        {
            get { return faceDirection; }
        }

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
            isJumping = false;
            faceDirection = Direction.RIGHT;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (CurrentSpeed.X < 0 && faceDirection == Direction.RIGHT)
            {
                faceDirection = Direction.LEFT;
                FlipHorizontally(true);
            }
            else if (CurrentSpeed.X > 0 && faceDirection == Direction.LEFT)
            {
                faceDirection = Direction.RIGHT;
                FlipHorizontally(false);
            }
        }

        public bool TimeForNextFrame()
        {
            return timeSinceLastFrame > RUNNING_ANIMATION_SPEED;
        }

        public virtual void Move()
        {

        }

        public void Jump()
        {
            if (!IsJumping())
            {
                SetJumping(true);
                AddForce(new Vector2(0, -jumpSpeed));
            }
        }


        public Boolean IsJumping()
        {
            return this.isJumping;
        }

        public void SetJumping(Boolean jumping)
        {
            this.isJumping = jumping;
        }

        public void TakeDamage(int damagePoints)
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
                SetJumping(false);
        }

        public abstract void PerformAbility(AbilityNumber abilityNumber);


    }
}
