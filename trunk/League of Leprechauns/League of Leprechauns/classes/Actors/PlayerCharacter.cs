using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


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

        public PlayerCharacter(Vector2 startPosition, int level, int totalHealth, Vector2 attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed) 
        {
            AbilityPoints = 0;
            ExperiencePoints = 0;
            movementSpeed = Settings.PLAYER_INITIAL_SPEED;
        }

        public override void Update(GameTime gameTime)
        {
            healthPoints = 0;
            base.Update(gameTime);
        }

    }
}
