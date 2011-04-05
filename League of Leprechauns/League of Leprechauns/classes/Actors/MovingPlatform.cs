using System;
using Microsoft.Xna.Framework;

namespace LoL
{
    class MovingPlatform : Platform, IKeepActive
    {
        #region attributes
        private Vector2 speed, startPosition;
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
        /// <param name="startPosition"></param>
        public MovingPlatform(Vector2 startPosition) : base(startPosition) 
        {
            this.startPosition = startPosition;
        }

        /// <summary>
        /// Initializes the lapdistance and speed of the platform.
        /// </summary>
        /// <param name="lapDistance"></param>
        /// <param name="speed"></param>
        public void Initialize(float lapDistance, Vector2 speed)
        {
            this.lapDistance = lapDistance;
            this.speed = speed;
            this.Active = true;
        }

        /// <summary>
        /// Tests if the platform exceeds its bounds. If not, then it
        /// moves to the desired position.
        /// </summary>
        /// <param name="gametime"></param>
        public override void Update(GameTime gametime)
        {
            if (testUpperBounds() || testLowerBounds())
                speed *= -1;
            CurrentPosition += speed;
            base.Update(gametime);
        }

        /// <summary>
        /// Test for the platform's upper bounds.
        /// </summary>
        /// <returns>Returns false if the platform moves out of it's bounds, true otherwise</returns>
        private Boolean testUpperBounds()
        {
            return (CurrentPosition.X + speed.X > startPosition.X + lapDistance) || (CurrentPosition.Y + speed.Y < startPosition.Y - lapDistance);
        }

        /// <summary>
        /// test for the platform's lower bounds;
        /// </summary>
        /// <returns>Returns false if the platform moves out of it's bounds, True otherwise</returns>
        private Boolean testLowerBounds()
        {
            return (CurrentPosition.X + speed.X < startPosition.X - lapDistance) || (CurrentPosition.Y + speed.Y > startPosition.Y + lapDistance);
        }

    }
}
