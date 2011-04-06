using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of hostile gnomes.
    /// </summary>
    abstract class Gnome : HostileNPC
    {
        #region attributes
        private int playerDistance;
        #endregion

        #region Properties
        public int PlayerDistance
        {
            get { return playerDistance; }
            set { playerDistance = value; }
        }
        #endregion

        protected Gnome(Vector2 startPosition) :
            base(startPosition)
        {
                CharacterLevel = 1;
                movementSpeed = Settings.GNOME_INITIAL_SPEED;
                jumpSpeed = Settings.GNOME_JUMPFORCE;
        }

        /// <summary>
        /// Gnome specific logic for the update method. Attacks the player based upon
        /// values in Settings.cs. Also makes sure stationary gnomes stay put.
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            if (this is EnemyFireballGnomeStationary)
            {
                PerformAbility(AbilityNumber.FIRST);
            }
            else
            {
                if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) > playerDistance)
                {
                    base.Move(this.faceDirection);

                }
                else if ((nearestPlayer.CurrentPosition.X - this.CurrentPosition.X) < -playerDistance)
                {
                    base.Move(this.faceDirection);
                }
                else
                {
                    PerformAbility(AbilityNumber.FIRST);
                }
            }

            base.Update(gameTime);
        }


    }
}
