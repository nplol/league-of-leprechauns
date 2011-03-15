using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace LoL
{
    class PlayerCharacter : Character
    {
        #region Properties

        public int AbilityPoints
        {
            get;
            set;
        }

        public int ExperiencePoints
        {
            get;
            set;
        }

        #endregion

        public PlayerCharacter(Vector2 startPosition, int level, Vector2 startSpeed, int totalHealth, Vector2 attackSpeed, int jumping)
            : base(startPosition, level, startSpeed, totalHealth, attackSpeed, jumping) 
        {
            AbilityPoints = 0;
            ExperiencePoints = 0;
            MovementSpeedX = Settings.PLAYER_SPEED;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Move(Direction directionX, Direction directionY)
        {
        }

    }
}
