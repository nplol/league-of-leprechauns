using Microsoft.Xna.Framework;

namespace LoL
{
    class InvisiblePlatform : Platform, IReciever
    {
        #region attributes
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
                return new Rectangle((int)(CurrentPosition.X * activationBit),
                    (int)(CurrentPosition.Y * activationBit),
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
            activationBit = 0;
            animation.AddAnimation(AnimationConstants.HIDDEN, 0, 0, 0, 1);
            animation.AddAnimation(AnimationConstants.STILL, 0, 128, 72, 1);
            animation.SetCurrentAnimation(AnimationConstants.HIDDEN);
        }

        /// <summary>
        /// When the associated button is pushed, activate the platform.
        /// </summary>
        public void Recieve()
        {
            activationBit = 1;
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }

    }
}
