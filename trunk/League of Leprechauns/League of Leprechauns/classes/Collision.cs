using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    public enum CollisionType
    {
        COLLIDE_LEFT,
        COLLIDE_RIGHT,
        COLLIDE_UP,
        COLLIDE_DOWN
    }

    public struct Collision
    {
        private Vector2 translationVector;
        private Actor collidingActor;

        public Vector2 getTranslationVector()
        {
            return translationVector;
        }

        public void setTranslationVector(Vector2 vector)
        {
            translationVector = vector;
        }

        public Actor getCollidingActor()
        {
            return collidingActor;
        }

        public Collision(Vector2 translationVector, Actor collidingActor)
        {
            this.translationVector = translationVector;
            this.collidingActor = collidingActor;
        }

        public bool IsOnGround()
        {
            return translationVector.Y < 0;
        }
    }
}
