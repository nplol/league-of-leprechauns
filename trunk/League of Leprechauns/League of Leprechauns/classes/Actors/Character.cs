using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    abstract class Character : Actor
    {
        #region Attributes

        private int level;
        private int healthPoints;
        private int totalHealthPoints;
        private Vector2 attackSpeed;
        private int jumpSpeed;
        private Vector2 movementSpeed;

        #endregion

        #region Properties

        public float MovementSpeedX
        {
            get
            {
                return movementSpeed.X;
            }
            set
            {
                movementSpeed.X = value;
            }
        }

        public float MovementSpeedY
        {
            get
            {
                return movementSpeed.Y;
            }
            set
            {
                movementSpeed.Y = value;
            }
        }

        #endregion

        public Character(Vector2 startPosition, int level, int totalHealth, Vector2 attackSpeed, int jumpSpeed) : base(startPosition) 
        {
            this.level = level;
            totalHealthPoints = totalHealth;
            this.healthPoints = totalHealth;
            this.attackSpeed = attackSpeed;
            this.jumpSpeed = jumpSpeed;
        }

        //public void Update(GameTime gameTime)
        //{
        //    move(MovementSpeed, Position);
        //}

        public virtual void move()
        {

        }



    }
}
