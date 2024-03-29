﻿using Microsoft.Xna.Framework;

namespace LoL
{
    class Button : NonLivingObject, IActivator
    {
        #region attributes
        protected bool activated;
        #endregion

        #region Properties
        public bool Activated
        {
            get { return activated; }
        }
        #endregion

        /// <summary>
        /// Instanciates a new button.
        /// </summary>
        /// <param name="startPosition"></param>
        public Button(Vector2 startPosition)
            : base(startPosition)
        {
            activated = false;
            animation.AddAnimation(AnimationConstants.STILL, 47, 51, 35, 1);
            animation.AddAnimation(AnimationConstants.ACTIVATED, 73, 51, 9, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }

        /// <summary>
        /// If a playable character stands on a button, activate it.
        /// </summary>
        /// <param name="collision"></param>
        public void ActivateButton()
        {
            if (!activated)
            {
                activated = true;
                //Hack for å flytte på knappen.
                CurrentPosition += new Vector2(0, 26);
                animation.SetCurrentAnimation(AnimationConstants.ACTIVATED);

                ActivatedEvent();
            }
        }

        public event ActivatedEvent ActivatedEvent;
    }
}
