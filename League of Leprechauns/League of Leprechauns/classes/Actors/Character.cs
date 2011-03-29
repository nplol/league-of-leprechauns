﻿using System;
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
        private int jumpSpeed;
        
        private bool isJumping;
        private bool isAttacking;

        protected Direction faceDirection;

        public const int RUNNING_ANIMATION_SPEED = 50;

        //TODO: Make private
        public List<Ability> Abilities;

        #endregion

        #region Properties

        public Direction FaceDirection
        {
            get { return faceDirection; }
        }


        public bool Jumping 
        { 
            get { return isJumping; }
            set { isJumping = value; }
        }

        public bool Attacking
        {
            get { return isAttacking; }
            set { isAttacking = value; }
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

        public Character(Vector2 startPosition, int level, int totalHealth, int jumpSpeed) : base(startPosition) 

        {
            this.level = level;
            totalHealthPoints = totalHealth;
            this.healthPoints = totalHealth;
            this.jumpSpeed = jumpSpeed;

            isJumping = false;
            isAttacking = false;

            faceDirection = Direction.RIGHT;

            Abilities = new List<Ability>();
        }

        public override void Update(GameTime gameTime)
        {
           
            if (faceDirection == Direction.RIGHT)
            {
                FlipHorizontally(false);
            }
            else if (faceDirection == Direction.LEFT)
            {
                FlipHorizontally(true);
            }

            if (Attacking)
            {
                animation.SetCurrentAnimation(AnimationConstants.ATTACKING);
            }
            else if (Jumping)
            {
                animation.SetCurrentAnimation(AnimationConstants.JUMPING);
            }
            else if (CurrentSpeed.X != 0)
            {
                animation.SetCurrentAnimation(AnimationConstants.WALKING);
            }
            else
            {
                animation.SetCurrentAnimation(AnimationConstants.STILL);
            }

            base.Update(gameTime);
        }

        public virtual void Move()
        {

        }

        public override void Move(Direction direction)
        {
            faceDirection = direction;
            base.Move(direction);
        }

        public void Jump()
        {
            if (!Jumping)
            {
                Jumping = true;
                AddForce(new Vector2(0, -jumpSpeed));
                CollisionDetector.DetectCollisions(ActorManager.getListOfAllActors(), this);
            }
        }

        public void TakeDamage(int damagePoints)
        {
            this.healthPoints -= damagePoints;
            if (this.healthPoints < 0)
                this.healthPoints = 0;
        }

        public override void HandleCollision(Collision collision)
        {
            Actor collidingActor = collision.getCollidingActor();
            Vector2 transVector = collision.getTranslationVector();

            if (collidingActor is IIgnorable)
                return;

            AddForce(transVector);

            if (collision.IsOnGround())
                Jumping = false;

            base.HandleCollision(collision);
        }

        public void PerformAbility(AbilityNumber abilityNumber)
        {
            switch (abilityNumber)
            {
                case AbilityNumber.FIRST:
                    this.Abilities[0].PerformAttack();
                    break;
                case AbilityNumber.SECOND:
                    this.Abilities[1].PerformAttack();
                    break;
                case AbilityNumber.THIRD:
                    this.Abilities[2].PerformAttack();
                    break;
                case AbilityNumber.FOURTH:
                    this.Abilities[3].PerformAttack();
                    break;
                default:
                    break;
            }
        }
    }
}