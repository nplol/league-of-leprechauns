using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    /*The class InputManager uses the singelton pattern.
     *  To use it, reference the Instance property */
    class PhysicsEngine
    {
        private Vector2 gravity;
        private Vector2 friction;

        public PhysicsEngine()
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
            foreach (Actor actor in ActorManager.getListOfAllActors())
            {
                friction = new Vector2(-actor.CurrentSpeed.X, 0);

                //Only apply gravity to Characters!
                if (actor is Character)
                    actor.AddForce(gravity);

                actor.AddForce(friction);
            }
        }
    }
}
