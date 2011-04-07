﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class FlufferNutter : PlayerCharacter
    {
        #region attributes
        static FlufferNutter instance;
        #endregion

        /// <summary>
        /// Returns the Fluffernutter instance as per the Singelton pattern.
        /// </summary>
        public static FlufferNutter GetInstance()
        {
            if (instance == null)
            {
                instance = new FlufferNutter();
            }
            return instance;
        }

        /// <summary>
        /// Instanciates a new Fluffernutter instance.
        /// </summary>
        private FlufferNutter()
            : base(Vector2.Zero)
        {
            this.movementSpeed = Settings.FLUFFERNUTTER_INITIAL_SPEED;
            Abilities.Add(new RangedAbility(this, Settings.FLUFFERNUTTER_THROW_COOLDOWN, Settings.FLUFFERNUTTER_THROW_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/bucketThrow"), 43, 56, 57, 6));
            Abilities.Add(new RangedAbility(this, Settings.FLUFFERNUTTER_FIREBALL_COOLDOWN, Settings.FLUFFERNUTTER_FIREBALL_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/flameAnimation"), 45, 86, 55, 3));
        }

        /// <summary>
        /// Initialises the playable character instances with values from Settings.cs. These
        /// values ovveride the constructor given values in Character.cs.
        /// </summary>
        public override void Initialize(Vector2 startPosition)
        {
            this.CurrentPosition = startPosition;
            this.totalHealthPoints = Settings.FLUFFERNUTTER_HEALTH;
            this.healthPoints = Settings.FLUFFERNUTTER_HEALTH;
            this.jumpSpeed = Settings.FLUFFERNUTTER_JUMPFORCE;

            base.Initialize(startPosition);
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
    }
}