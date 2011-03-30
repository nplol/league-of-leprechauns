﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class CabbageLips : PlayerCharacter
    {
        public CabbageLips(Vector2 startPosition, int level, int totalHealth, int attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, jumpSpeed)
        {
            animation.AddAnimation(AnimationConstants.WALKING, 15, 81, 135, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 180, 87, 137, 1);
            animation.AddAnimation(AnimationConstants.STILL, 15, 81, 135, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 340, 80, 136, 1);
            animation.AddAnimation(AnimationConstants.DUCKING, 500, 60, 50, 0);
            animation.AddAnimation(AnimationConstants.STUNNED, 180, 87, 137, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);

            Abilities.Add(new HitAbility(this, Settings.HIT_COOLDOWN));
            Abilities.Add(new AoEAblity(this, 2000));
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);
        }

        public override void Update(GameTime gameTime)
        {
            if (isSuspended) return;
            base.Update(gameTime);
        }

        public override void HandleCollision(Collision collision)
        {
            if (collision.getCollidingActor() is Button)
                ((Button)collision.getCollidingActor()).ActivateButton();

            base.HandleCollision(collision);
        }

           
    }
}