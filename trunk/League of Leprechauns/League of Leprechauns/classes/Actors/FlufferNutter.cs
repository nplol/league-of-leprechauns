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
            InitializeAnimation();

            //TEMP CODE. TODO: Decide where to add abilites

            Abilities.Add(new ShootAbility(this, Settings.THROW_COOLDOWN, Settings.THROW_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/bucketThrow"), 43, 56, 57, 6));

            animation.AnimationDone += new AnimationDone(HandleAnimationDone);

            //TODO: want to change inputhandler a bit. Preffered behavior:
            //Abilites.Add(new HitAbility(this, 1000));
            //InputManager.Bind(PlayerIndex.One, Buttons.Y, Attack);
        }

        private void InitializeAnimation()
        {
            animation.AddAnimation(AnimationConstants.WALKING, 30, 64, 145, 3);
            animation.AddAnimation(AnimationConstants.JUMPING, 215, 67, 145, 1);
            animation.AddAnimation(AnimationConstants.STILL, 30, 64, 145, 1);
            animation.AddAnimation(AnimationConstants.ATTACKING, 400, 67, 145, 1);
            animation.AddAnimation(AnimationConstants.STUNNED, 700, 67, 145, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }

        public override void Update(GameTime gameTime)
        {
            if (isSuspended) return;
            base.Update(gameTime);
            
           
        }
    }
}