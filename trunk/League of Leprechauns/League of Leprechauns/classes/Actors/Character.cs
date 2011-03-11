using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class Character : Actor
    {
        #region Attributes

        private int level;
        private int healthPoints;
        private int totalHealthPoints;
        private Vector2 attackSpeed;
        private int jumping;

        #endregion

        #region Properties

        private Vector2 MovementSpeed
        {
            get;
            set;
        }

        #endregion

        public Character(Vector2 startPosition, Vector2 startSpeed, int totalHealth, Vector2 attackSpeed, int jumping) : base(startPosition) 
        {
            MovementSpeed = startSpeed;
            totalHealthPoints = totalHealth;
            this.attackSpeed = attackSpeed;
            this.jumping = jumping;
        }

        public void Update(GameTime gameTime)
        {
            move(MovementSpeed, Position);
        }

        public virtual void move(Vector2 MovementSpeed, Vector2 Position)
        {

        }



    }
}
