using System.Collections.Generic;
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

        /// <summary>
        /// Adds a actor to the game
        /// </summary>
        /// <param name="actor">The actor to add</param>
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

        public static void ClearActorList()
        {
            ListOfAllActors.Clear();
        }

        public static List<Actor> GetListOfActiveActors()
        {
            return ListOfActiveActors;
        }

        public static List<Actor> GetListOfAllActors()
        {
            return ListOfAllActors;
        }

        /// <summary>
        /// Updates all the active actors and checks for collisions.
        /// </summary>
        /// <param name="gametime"></param>
        public static void Update(GameTime gametime)
        {

            foreach (Actor actor in GetListOfActiveActors().ToArray())
            {
                actor.Update(gametime);
            }

            CollisionDetector.DetectCollisions(GetListOfActiveActors());

            //Updates the position of the actors based on the force applied on them
            foreach (Actor actor in GetListOfActiveActors())
            {
                actor.ApplyForcesToActor();
            }
        }

        /// <summary>
        /// Draws all the Active actors
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to draw on</param>
        /// <param name="camera">The camera which controls the view of the game</param>
        public static void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (Actor actor in GetListOfActiveActors())
            {
                actor.Draw(spriteBatch, camera);
            }
        }

        public static FlufferNutter GetFlufferNutterInstance
        {
            get { return ActorManager.flufferNutter; }
        }

        public static CabbageLips GetCabbageLipsInstance
        {
            get { return ActorManager.cabbageLips; }
        }

        public static PlayerCharacter GetOtherPlayerCharacter(Character self)
        {
            return (self is CabbageLips) ? (PlayerCharacter)GetFlufferNutterInstance : (PlayerCharacter)GetCabbageLipsInstance;
        }

        public static void RemoveActor(Actor actor)
        {
            if (actor is HostileNPC && ((Character)actor).IsDead())
            {
                GetCabbageLipsInstance.AddExperience(500);
                GetFlufferNutterInstance.AddExperience (500);
            }

            ListOfActiveActors.Remove(actor);
            ListOfAllActors.Remove(actor);
        }

        /// <summary>
        /// Returns a list of all active actors in a given range
        /// </summary>
        /// <param name="area">Rectangle describing the area</param>
        /// <returns></returns>
        public static List<Actor> GetActorsInRange(Rectangle area)
        {
            List<Actor> actorsInRange = new List<Actor>();

            foreach (Actor actor in GetListOfActiveActors())
            {
                if (actor.BoundingRectangle.Intersects(area))
                    actorsInRange.Add(actor);
            }

            return actorsInRange;
        }
    }
}
