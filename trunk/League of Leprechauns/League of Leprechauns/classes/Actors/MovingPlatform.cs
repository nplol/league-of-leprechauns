using System;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of moving platforms.
    /// </summary>
    class MovingPlatform : Platform, IKeepActive
    {
        #region attributes
        private Vector2 speed;
        private float lapDistance;
        #endregion

        #region Properties
        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        #endregion

        /// <summary>
        /// Instanciates a new moving platform.
        /// </summary>
        /// <param name="StartPosition"></param>
        public MovingPlatform(Vector2 StartPosition) : base(StartPosition) 
        {
            Active = true;
            lapDistance = Settings.MOVING_PLATFORM_LAPDISTANCE;
            speed = new Vector2(0, Settings.MOVING_PLATFORM_SPEED);
        }

        /// <summary>
        /// Tests if the platform exceeds its bounds. If not, then it
        /// moves to the desired position.
        /// </summary>
        /// <param name="gametime"></param>
        public override void Update(GameTime gametime)
        {
            if (TestUpperBounds() || TestLowerBounds())
                speed *= -1;
            CurrentPosition += speed;
            base.Update(gametime);
        }

        /// <summary>
        /// Test for the platform's upper bounds.
        /// </summary>
        /// <returns>Returns false if the platform moves out of it's bounds, true otherwise</returns>
        private Boolean TestUpperBounds()
        {
            return (CurrentPosition.X + speed.X > StartPosition.X + lapDistance) || (CurrentPosition.Y + speed.Y < StartPosition.Y - lapDistance);
        }

        /// <summary>
        /// test for the platform's lower bounds;
        /// </summary>
        /// <returns>Returns false if the platform moves out of it's bounds, True otherwise</returns>
        private Boolean TestLowerBounds()
        {
            return (CurrentPosition.X + speed.X < StartPosition.X - lapDistance) || (CurrentPosition.Y + speed.Y > StartPosition.Y + lapDistance);
        }
    }
}
