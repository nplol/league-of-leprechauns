using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL.classes
{
    class Collision
    {
        private CollisionType direction;
        private Actor collidingActor;

        public Collision(CollisionType direction, Actor collidingActor)
        {
            this.direction = direction;
            this.collidingActor = collidingActor;
        }

        public CollisionType getDirection()
        {
            return direction;
        }

        public Actor getCollidingActor()
        {
            return collidingActor;
        }

    }
}
