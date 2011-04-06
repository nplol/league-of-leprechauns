﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    /// <summary>
    /// The player character Cabbagelips.
    /// </summary>
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
            this.movementSpeed = Settings.CABBAGELIPS_INITIAL_SPEED;

            Abilities.Add(new HitAbility(this, Settings.CABBAGELIPS_HIT_COOLDOWN, Settings.CABBAGELIPS_HIT_DAMAGE));
            Abilities.Add(new AoEAblity(this, Settings.CABBAGELIPS_AOE_COOLDOWN, Settings.CABBAGELIPS_AOE_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/AOEAbility")));
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);
        }


        protected override void InitializeAnimation()
        {
            animation.AddAnimation(AnimationConstants.WALKING, 15, 81, 135, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 181, 86, 137, 1);
            animation.AddAnimation(AnimationConstants.STILL, 15, 81, 135, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 340, 80, 136, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 600, 75, 137, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }

        public override void Update(GameTime gameTime)
        {
       //     if (isSuspended) return;
            base.Update(gameTime);
        }

        public override void HandleCollision(Collision collision)
        {
            if (collision.CollidingActor is CollapsableBridge)
                ActivatedEvent();

            base.HandleCollision(collision);
        }
    }
}