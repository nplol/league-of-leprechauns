using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class CollapsableBridge : NonLivingObject
    {
        #region attributes
        private Timer timer;
        #endregion

        /// <summary>
        /// Instanciates a new collapsable bridge.
        /// </summary>
        /// <param name="startPosition"></param>
        public CollapsableBridge(Vector2 startPosition)
            : base(startPosition)
        {
            timer = new Timer(3000);
            timer.TimeEndedEvent += new TimerDelegate(Collapse);

            animation.AddAnimation(AnimationConstants.STILL, 0, 489, 11, 1);
            animation.AddAnimation(AnimationConstants.ACTIVATED, 21, 489, 11, 3);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            animation.SetAnimationLength(1000);
        }

        /// <summary>
        /// Activates the collapsing if Cabbagelips walks on the bridge.
        /// Called from Cabbagelips' HandleCollision method.
        /// </summary>
        public void ActivateCollapse()
        {
            if (!timer.Activated)
            {
                timer.Start();
                animation.SetCurrentAnimation(AnimationConstants.ACTIVATED);
            }
        }

        /// <summary>
        /// Collapses the bridge.
        /// </summary>
        public void Collapse()
        {
            AddForce(new Vector2(0, 5));
        }
    }
}
