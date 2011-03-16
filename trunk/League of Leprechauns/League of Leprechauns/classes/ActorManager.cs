using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class ActorManager
    {
        private static List<Actor> ListOfAllActors;
        private static List<Actor> ListOfActiveActors;
        private static FlufferNutter flufferNutter;
        private static CabbageLips cabbageLips;

        static ActorManager()
        {
            ListOfAllActors = new List<Actor>();
            ListOfActiveActors = new List<Actor>();
        }

        public static void addActor(Actor actor)
        {
            if (actor is FlufferNutter)
            {
                flufferNutter = (FlufferNutter)actor;
            }
            if (actor is CabbageLips)
            {
                cabbageLips = (CabbageLips)actor;
            }
            ListOfAllActors.Add(actor);
        }

        public static void clearList()
        {
            ListOfAllActors.Clear();
        }

        public static List<Actor> getListOfActiveActors()
        {
            return ListOfActiveActors;
        }

        public static List<Actor> getListOfAllActors()
        {
            return ListOfAllActors;
        }

        /// <summary>
        /// Updates all the active actors.
        /// </summary>
        /// <param name="gametime"></param>
        public static void Update(GameTime gametime)
        {
            
            foreach(Actor actor in ListOfAllActors)
            {
                actor.Update(gametime);
            }

            CollisionDetector.DetectCollisions(ListOfAllActors);

            //Updates the position of the actors based on the force applied on them
            foreach (Actor actor in ListOfAllActors)
            {
                actor.UpdatePosition();
            }
        }

        /// <summary>
        /// Draws all the Active actors
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to draw on</param>
        /// <param name="camera">The camera which controls the view of the game</param>
        public static void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (Actor actor in ListOfAllActors)
            {
                actor.Draw(spriteBatch, camera);
            }
        }

        public static FlufferNutter GetFlufferNutterInstance()
        {
            return ActorManager.flufferNutter;
        }

        public static CabbageLips GetCabbageLipsInstance()
        {
            return ActorManager.cabbageLips;
        }
    }
}
