using Microsoft.Xna.Framework;

namespace LoL
{

    /// <summary>
    /// Struct containing collision details.
    /// </summary>
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
