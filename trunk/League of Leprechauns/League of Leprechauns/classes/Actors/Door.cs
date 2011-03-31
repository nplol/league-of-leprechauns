using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    public enum DoorState
    {
        Open,
        Closed
    }

    class Door : NonLivingObject, IReciever
    {
        #region attributes
        private DoorState doorState;
        private Key key;
        private int activationBit;
        #endregion

        #region Properties
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
        /// Instanciates a new door.
        /// </summary>
        /// <param name="startPosition"></param>
        public Door(Vector2 startPosition)
            : base(startPosition)
        {
            this.doorState = DoorState.Closed;
            animation.AddAnimation(AnimationConstants.STILL, 3, 24, 150, 1);
            animation.AddAnimation(AnimationConstants.OPEN, 160, 107, 150, 1);
            animation.SetCurrentAnimation(AnimationConstants.STILL);
            activationBit = 1;
        }


        public void Recieve()
        {
            if (doorState == DoorState.Closed)
                Open();
            else
                Close();
        }

        /// <summary>
        /// Opens up the door.
        /// </summary>
        public void Open()
        {
            doorState = DoorState.Open;
            activationBit = -1;
            animation.SetCurrentAnimation(AnimationConstants.OPEN);
        }

        /// <summary>
        /// Closes the door.
        /// </summary>
        public void Close()
        {
            doorState = DoorState.Closed;
            activationBit = 1;
            animation.SetCurrentAnimation(AnimationConstants.STILL);
        }
    }
}
