using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace LoL
{
    abstract class PlayerCharacter : Character
    {
        private int lives;

        #region Properties

        public int Lives
        {
            get { return lives; }
        }

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

        public PlayerCharacter(Vector2 startPosition, int level, int totalHealth, int attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed) 
        {
            AbilityPoints = 0;
            ExperiencePoints = 0;
            movementSpeed = Settings.PLAYER_INITIAL_SPEED;
            lives = Settings.PLAYER_LIVES;
        }

        public override void Update(GameTime gameTime)
        {
            if (this.healthPoints <= 0)
            {
                Respawn();
            }
            base.Update(gameTime);
        }

        private void Respawn()
        {
            this.healthPoints = this.TotalHealthPoints;
            this.lives--;
            //TODO: logikk for å flytte player opp på brett igjen hvis den detter ned!
        }
    }
}
