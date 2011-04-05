using Microsoft.Xna.Framework;

namespace LoL
{
    class BuildableBridge : NonLivingObject
    {

        #region attributes
        private Button activationButton1, activationButton2;
        private int currentWidth, blockWidth;
        #endregion

        #region Properties
        public virtual Rectangle PotentialMoveRectangle
        {
            get
            {
                return new Rectangle((int)(CurrentPosition.X),
                    (int)(CurrentPosition.Y),
                    currentWidth,
                    animation.CurrentRectangle.Height);
            }
        }
        #endregion

        /// <summary>
        /// Instanciates a new buildable bridge.
        /// </summary>
        /// <param name="startPosition"></param>
        public BuildableBridge(Vector2 startPosition)
            : base(startPosition)
        {
            currentWidth = 0;
            blockWidth = 100;
        }

        /// <summary>
        /// If both buttons are activated, start building the bridge.
        /// </summary>
        public void StartBuilding()
        {
            currentWidth += blockWidth;
        }

        public override void Update(GameTime gameTime)
        {
            if (activationButton1.Activated && activationButton2.Activated)
                StartBuilding();
            else if (currentWidth == 500)
            {
                return;
            }
            else
            {
                currentWidth = 0;
            }
        }


    }
}
