﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of Cabbagelips.
    /// </summary>
    class CabbageLips : PlayerCharacter, IActivator
    {
        #region attributes
        static CabbageLips instance;
        public event ActivatedEvent ActivatedEvent;
        #endregion

        /// <summary>
        /// Returns the Cabbagelips instance as per the Singelton pattern.
        /// </summary>
        public static CabbageLips GetInstance()
        {
            if (instance == null)
            {
                instance = new CabbageLips();
            }
            return instance;
        }

        /// <summary>
        /// Instanciates a new Cabbagelips instance.
        /// </summary>
        private CabbageLips()
            : base(Vector2.Zero)
        {
            this.movementSpeed = Settings.CABBAGELIPS_INITIAL_SPEED;

            Abilities.Add(new HitAbility(this, Settings.CABBAGELIPS_HIT_COOLDOWN, Settings.CABBAGELIPS_HIT_DAMAGE));
            Abilities.Add(new AoEAblity(this, Settings.CABBAGELIPS_AOE_COOLDOWN, Settings.CABBAGELIPS_AOE_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/AOEAbility")));
            animation.AnimationDone += new AnimationDone(HandleAnimationDone);
        }

        /// <summary>
        /// Initialises the playable character instances with values from Settings.cs. These
        /// values ovveride the constructor given values in Character.cs.
        /// </summary>
        public override void Initialize(Vector2 startPosition)
        {
            this.CurrentPosition = startPosition;
            this.totalHealthPoints = Settings.CABBAGELIPS_HEALTH;
            this.healthPoints = Settings.CABBAGELIPS_HEALTH;
            this.jumpSpeed = Settings.CABBAGELIPS_JUMPFORCE;

            base.Initialize(startPosition);
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

        /// <summary>
        /// If Cabbagelips collides with a collapseable bridge, then fire off an event.
        /// </summary>
        public override void HandleCollision(Collision collision)
        {
            if (collision.CollidingActor is CollapsableBridge)
                ActivatedEvent();

            base.HandleCollision(collision);
        }
    }
}