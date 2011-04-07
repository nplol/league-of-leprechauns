﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Enum describing each characters unique ability list.
    /// </summary>
    enum AbilityNumber { FIRST, SECOND, THIRD };

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

        protected Direction faceDirection;

        public const int RUNNING_ANIMATION_SPEED = 50;
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

        #endregion

        public Character(Vector2 startPosition) : base(startPosition) 
        {
            InitializeAnimation();

            experiencePoints = 0;
            isJumping = false;
            isAttacking = false;
            isAttacked = false;
            isDead = false;
            isSuspended = false;

            faceDirection = Direction.RIGHT;

            Abilities = new List<Ability>();
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

        protected abstract void InitializeAnimation();

        /// <summary>
        /// Updates the character.
        /// </summary>
        /// <param name="gameTime"></param>
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

            // Stunned is the state a character enters when hit by an attack.
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

        /// <summary>
        /// Adds experience points to the charcter.
        /// </summary>
        /// <param name="experiencePoints"></param>
        public void AddExperience(int experiencePoints)
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

        /// <summary>
        /// Initiates a new jump for the character if not already jumping.
        /// Collisiondetector is called to make sure this new move doesn't result in a collision.
        /// </summary>
        public void Jump()
        {
            if (isSuspended) return;
            if (!Jumping)
            {
                Jumping = true;
                AddForce(new Vector2(0, -jumpSpeed));
                CollisionDetector.DetectCollisions(ActorManager.GetListOfActiveActors(), this);
            }
        }

        /// <summary>
        /// Ensures the characters takes damage when hit by an attack, and updates 
        /// itself accordingly.
        /// </summary>
        /// <param name="damagePoints"></param>
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

        /// <summary>
        /// The main method for handling collisions for characters. If the character collides with
        /// an ignorable object, then no force is added to the actor. The method also detects whether
        /// the character is currently on the ground or not.
        /// </summary>
        /// <param name="collision"></param>
        public override void HandleCollision(Collision collision)
        {
            Actor collidingActor = collision.CollidingActor;
            Vector2 transVector = collision.TranslationVector;

            if (isDead) return;

            if (collidingActor is IIgnorable)
                return;

            AddForce(transVector);

            if (collision.LandedOnSomething())
                Jumping = false;

            base.HandleCollision(collision);
        }


        /// <summary>
        /// Performs the given ability based upon the ability list
        /// of the calling character.
        /// </summary>
        /// <param name="abilityNumber"></param>
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
                default:
                    break;
            }
        }

        /// <summary>
        /// Revives the character, called when changing levels in case
        /// either Fluffernutter or Cabbagelips are dead.
        /// </summary>
        public void Revive()
        {
            isDead = false;
            isSuspended = false;
        }

        /// <summary>
        /// Kills the invoking character.
        /// </summary>
        /// <param name="shouldAnimate"></param>
        public virtual void Kill(bool shouldAnimate = true)
        {
            isDead = true;
            isSuspended = true;
            healthPoints = 0;
            if (shouldAnimate)
            {
                animation.SetCurrentAnimation(AnimationConstants.STUNNED);
                Timer timer = new Timer(3000);
                timer.TimeEndedEvent += new TimerDelegate(RemoveActor);
                timer.Start();
            }
        }
      }
}