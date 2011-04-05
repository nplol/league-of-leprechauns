﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LoL
{
    enum AbilityNumber { FIRST, SECOND, THIRD, FOURTH };

    abstract class Character : Actor
    {
        #region Attributes

        private int characterLevel;
        private int experiencePoints;
        protected int healthPoints;
        protected int totalHealthPoints;
        protected int jumpSpeed;

        private bool isJumping;
        private bool isAttacking;
        private bool isAttacked;
        internal bool isDead;
        internal bool isSuspended;
        internal bool isDucking;

        protected Direction faceDirection;

        public const int RUNNING_ANIMATION_SPEED = 50;

        //TODO: Make private
        public List<Ability> Abilities;

        #endregion

        #region Properties

        public int CharacterLevel
        {
            get { return characterLevel; }
            protected set { characterLevel = value; }
        }

        public int ExperiencePoints
        {
            get { return experiencePoints; }
            protected set { experiencePoints = value; }
        }
        
        public Direction FaceDirection
        {
            get { return faceDirection; }
        }

        public bool Jumping 
        { 
            get { return isJumping; }
            set { isJumping = value; }
        }

        public bool Stunned
        {
            get { return isAttacked; }
            set { isAttacked = value; }
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

        public bool Ducking
        {
            get { return isDucking; }
            protected set { isDucking = value; }
        }

        #endregion

        public Character(Vector2 startPosition, int characterLevel, int totalHealthPoints, int jumpSpeed) : base(startPosition) 

        {
            this.characterLevel = characterLevel;
            this.totalHealthPoints = totalHealthPoints;
            this.healthPoints = totalHealthPoints;
            this.jumpSpeed = jumpSpeed;
            this.ExperiencePoints = 0;

            isJumping = false;
            isAttacking = false;
            isAttacked = false;
            isDead = false;
            isSuspended = false;
            isDucking = false;
            

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

            if (Stunned)
            {
                animation.SetCurrentAnimation(AnimationConstants.STUNNED);
            }
            else if (Attacking)
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

            if (healthPoints <= 0 && !IsDead())
                Kill();

            base.Update(gameTime);
        }

        public void addExperience(int experiencePoints)
        {
            ExperiencePoints += experiencePoints;
            try
            {
                if (ExperiencePoints >= Settings.LEVEL_XP_CONSTANTS[characterLevel])
                {
                    CharacterLevelUp();
                }
            }
            catch (IndexOutOfRangeException e)
            {
                // This happens if the character reaches higher than level 5
            }

        }

        private void CharacterLevelUp()
        {
            characterLevel++;
        }

        public override void Move(Direction direction)
        {
            
            if (isSuspended) return;
            faceDirection = direction;
            base.Move(direction);
        }

        public void Jump()
        {
            if (isSuspended) return;
            if (!Jumping)
            {
                Jumping = true;
                AddForce(new Vector2(0, -jumpSpeed));
                CollisionDetector.DetectCollisions(ActorManager.getListOfActiveActors(), this);
            }
        }

        public void TakeDamage(int damagePoints)
        {
            this.healthPoints -= damagePoints;
            if (this.healthPoints < 0)
                this.healthPoints = 0;
            
            this.isAttacked = true;
            Timer timer = new Timer(200);
            timer.TimeEndedEvent += new TimerDelegate(StopAttackedAnimation);
            timer.Start();
        }

        public override void HandleCollision(Collision collision)
        {
            Actor collidingActor = collision.getCollidingActor();
            Vector2 transVector = collision.getTranslationVector();

            if (isDead) return;

            if (collidingActor is IIgnorable)
                return;

            AddForce(transVector);

            if (collision.IsOnGround())
                Jumping = false;

            base.HandleCollision(collision);
        }

        public void PerformAbility(AbilityNumber abilityNumber)
        {
            if (isSuspended) return;
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

        public bool IsDead()
        {
            return isDead;
        }

        public void HandleAnimationDone()
        {
                        
            isAttacking = false;
        }

        public void StopAttackedAnimation()
        {
            isAttacked = false;
        }

        public void Kill()
        {
            isDead = true;
            isSuspended = true;
            healthPoints = 0;
            animation.SetCurrentAnimation(AnimationConstants.STUNNED);
            Timer timer = new Timer(3000);
            timer.TimeEndedEvent += new TimerDelegate(RemoveActor);
            timer.Start();

        }

        public void Suspend()
        {
            this.isSuspended = true;
        }
        public void UnSuspend()
        {
            this.isSuspended = false;
        }


        public void RemoveActor()
        {
            ActorManager.RemoveActor(this);
        }
      }
}