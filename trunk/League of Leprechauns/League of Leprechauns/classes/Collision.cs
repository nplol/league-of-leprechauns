using Microsoft.Xna.Framework;

namespace LoL
{

    /// <summary>
    /// Struct containing collision details.
    /// </summary>
    public struct Collision
    {
        #region attributes
        private Vector2 translationVector;
        private Actor collidingActor;
        #endregion

        public Vector2 TranslationVector
        {
            get { return translationVector; }
            set { translationVector = value;}
        }

        public Actor CollidingActor
        {
            get { return collidingActor; }
        }

        /// <summary>
        /// Instanciates a new collision object.
        /// </summary>
        /// <param name="translationVector"></param>
        /// <param name="collidingActor"></param>
        public Collision(Vector2 translationVector, Actor collidingActor)
        {
            this.translationVector = translationVector;
            this.collidingActor = collidingActor;
        }

        /// <summary>
        /// Returns true if the character has landed on another actor (such as a platform).
        /// </summary>
        /// <returns></returns>
        public bool LandedOnSomething()
        {
            return translationVector.Y < 0;
        }
    }
}
