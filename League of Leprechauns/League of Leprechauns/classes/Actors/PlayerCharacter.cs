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

        public PlayerCharacter(Vector2 startPosition, Vector2 startSpeed, int totalHealth, Vector2 attackSpeed, int jumping)
            : base(startPosition, startSpeed, totalHealth, attackSpeed, jumping) 
        {
            AbilityPoints = 0;
            ExperiencePoints = 0;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void move(Vector2 movementSpeed, Vector2 position)
        {

        }

    }
}
