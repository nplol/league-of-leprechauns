﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class FlufferNutter : PlayerCharacter
    {
        static FlufferNutter instance;

        public static FlufferNutter GetInstance()
        {
            if (instance == null)
            {
                instance = new FlufferNutter();
            }
            return instance;
        }

        private FlufferNutter()
            : base(new Vector2(0, 0), 0, 0, 0)
        {
            this.movementSpeed = Settings.FLUFFERNUTTER_INITIAL_SPEED;
            Abilities.Add(new ShootAbility(this, Settings.FLUFFERNUTTER_THROW_COOLDOWN, Settings.FLUFFERNUTTER_THROW_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/bucketThrow"), 43, 56, 57, 6));
        }

        protected override void InitializeAnimation()
        {
            animation.AddAnimation(AnimationConstants.WALKING, 30, 64, 145, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 215, 67, 145, 1);
            animation.AddAnimation(AnimationConstants.STILL, 30, 64, 145, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 400, 67, 145, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 700, 67, 145, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);

        }

        public override void Update(GameTime gameTime)
        {
            if (isSuspended) return;
            base.Update(gameTime);
        }
    }
}