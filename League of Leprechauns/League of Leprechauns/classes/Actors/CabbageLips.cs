﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class CabbageLips : PlayerCharacter, IActivator
    {
        static CabbageLips instance;
        public event ActivatedEvent ActivatedEvent;

        public static CabbageLips GetInstance()
        {
            if (instance == null)
            {
                instance = new CabbageLips();
            }
            return instance;
        }

        private CabbageLips()
            : base(new Vector2(0, 0), 1, 0, 0)
        {
            InitializeAnimation();

            Abilities.Add(new HitAbility(this, Settings.HIT_COOLDOWN));
            Abilities.Add(new AoEAblity(this, 2000));
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);
        }

        private void InitializeAnimation()
        {
            animation.AddAnimation(AnimationConstants.WALKING, 15, 81, 135, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 180, 87, 137, 1);
            animation.AddAnimation(AnimationConstants.STILL, 15, 81, 135, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 340, 80, 136, 1);
            animation.AddAnimation(AnimationConstants.DUCKING, 500, 60, 50, 0);
            animation.AddAnimation(AnimationConstants.STUNNED, 180, 87, 137, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }

        public void Initialize(Vector2 startPosition, int level, int totalHealthPoints, int jumpSpeed)
        {
            this.CurrentPosition = startPosition;
            this.level = level;
            this.totalHealthPoints = totalHealthPoints;
            this.healthPoints = totalHealthPoints;
            this.jumpSpeed = jumpSpeed;
        }


        public override void Update(GameTime gameTime)
        {
            if (isSuspended) return;
            base.Update(gameTime);
        }

        public override void HandleCollision(Collision collision)
        {
            if (collision.getCollidingActor() is CollapsableBridge)
                ActivatedEvent();

            base.HandleCollision(collision);
        }
    }
}