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
        protected int healthPoints;
        private int totalHealthPoints;
        private Vector2 attackSpeed;
        private int jumpSpeed;
        private Boolean jumping;

        #endregion

        #region Properties

        public int HealthPoints
        {
            get { return healthPoints; }
        }

        public int TotalHealthPoints
        {
            get { return totalHealthPoints; }
        }

        #endregion

        public Character(Vector2 startPosition, int level, int totalHealth, Vector2 attackSpeed, int jumpSpeed) : base(startPosition) 
        {
            this.level = level;
            totalHealthPoints = totalHealth;
            this.healthPoints = totalHealth;
            this.attackSpeed = attackSpeed;
            this.jumpSpeed = jumpSpeed;
            jumping = false;
        }

        //public void Update(GameTime gameTime)
        //{
        //    move(MovementSpeed, Position);
        //}

        public virtual void move()
        {

        }

        public void Jump()
        {
            setJumping(true);
            AddForce(new Vector2(0, -jumpSpeed));
        }


        public Boolean isJumping()
        {
            return this.jumping;
        }

        public void setJumping(Boolean jumping)
        {
            this.jumping = jumping;
        }


        public override void HandleCollision(Collision collision)
        {
            base.HandleCollision(collision);
            Vector2 transVector = collision.getTranslationVector();
            if (transVector.Y < 0)
                setJumping(false);
        }





    }
}
