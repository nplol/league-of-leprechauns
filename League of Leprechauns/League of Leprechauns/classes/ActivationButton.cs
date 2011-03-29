using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class ActivationButton : Button
    {
        public ActivationButton(Vector2 startPosition)
            : base(startPosition)
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (!this.Collided)
            {
                DeactivateButton();
            }
            base.Update(gameTime);
        }

        private void DeactivateButton()
        {
            activated = false;
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            // Samme hack som i superklassen Button.
            CurrentPosition += new Vector2(0, -26);
        }

    }
}
