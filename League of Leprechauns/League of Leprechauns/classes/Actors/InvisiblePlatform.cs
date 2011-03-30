using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class InvisiblePlatform : Platform
    {
        #region attributes
        private Button activationButton;
        private int activationBit;
        #endregion

        #region Properties

        /// <summary>
        /// Ovveriding the standard boundingrectangle, making it impossible for
        /// players to land on the platform until the platform's corresponding button
        /// has been pushed.
        /// </summary>
        public override Rectangle PotentialMoveRectangle
        {
            get
            {
                return new Rectangle((int)(CurrentPosition.X),
                    (int)(CurrentPosition.Y),
                    animation.CurrentRectangle.Width * activationBit,
                    animation.CurrentRectangle.Height * activationBit);
            }
        }
        #endregion

        /// <summary>
        /// Instanciates a new invisible platform. The platform will be made visible
        /// if a player stands on the the platform's corresponding button.
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="button"></param>
        public InvisiblePlatform(Vector2 startPosition)
            : base(startPosition)
        {
            activationBit = -1;
        }

        /// <summary>
        /// If the button is pushed, activate the platform.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (activationButton.Activated)
                activationBit = 1;
        }

    }
}
