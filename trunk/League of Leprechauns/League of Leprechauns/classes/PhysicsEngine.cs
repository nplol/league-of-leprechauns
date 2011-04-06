using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// The physics engine for the game application. Applies friction and gravity
    /// to active characters. Implements the Singleton pattern.
    /// </summary>
    class PhysicsEngine
    {
        #region attributes
        private Vector2 gravity;
        private Vector2 friction;
        #endregion

        private PhysicsEngine()
        {
            gravity = new Vector2(0, Settings.GRAVITY);
        }

        private static PhysicsEngine instance;

        /// <summary>
        /// GetInstance returns the Singelton instance.
        /// </summary>
        public static PhysicsEngine GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PhysicsEngine();
                }
                return instance;
            }
        }

        /// <summary>
        /// Applies physical forces to the actors.
        /// </summary>
        public void ApplyForces()
        {
            foreach (Actor actor in ActorManager.GetListOfActiveActors())
            {
                friction = new Vector2(-actor.CurrentSpeed.X, 0);

                //Only apply gravity to Characters!
                if (actor is Character && actor.CurrentSpeed.Y < Settings.MAX_FALL_SPEED)
                        actor.AddForce(gravity);
                actor.AddForce(friction);
            }
        }
    }
}
