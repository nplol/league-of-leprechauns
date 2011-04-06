using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of the actor manager. This class is responsible for
    /// maintaining a list of active actors, as well as updating each of these. 
    /// </summary>
    class ActorManager
    {
        #region attributes
        private static List<Actor> ListOfAllActors;
        private static List<Actor> ListOfActiveActors;
        
        private static FlufferNutter flufferNutter;
        private static CabbageLips cabbageLips;
        #endregion

        /// <summary>
        /// Instanciates the actor manager.
        /// </summary>
        static ActorManager()
        {
            ListOfAllActors = new List<Actor>();
            ListOfActiveActors = new List<Actor>();
        }

        /// <summary>
        /// Adds a new actor to the list of all actors. If the actor
        /// to add is either Cabbagelips or Fluffernutter, it's saved to the
        /// local instances, which are used by other classes to have quick access to
        /// the Fluffernutter and Cabbagelips instances.
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

        /// <summary>
        /// Removes all actors.
        /// </summary>
        public static void ClearActorList()
        {
            ListOfAllActors.Clear();
        }

        /// <summary>
        /// Returns the list of active actors.
        /// </summary>
        /// <returns></returns>
        public static List<Actor> GetListOfActiveActors()
        {
            return ListOfActiveActors;
        }

        /// <summary>
        /// Returns the list of ALL actors.
        /// </summary>
        /// <returns></returns>
        public static List<Actor> GetListOfAllActors()
        {
            return ListOfAllActors;
        }

        /// <summary>
        /// Updates all active actors, then calcuates collisions based upon the actors' potential moves. After 
        /// this has been done, all active actors have their respective forces applied to them (such as gravity,
        /// or movement based on input from the user).
        /// </summary>
        /// <param name="gametime"></param>
        public static void Update(GameTime gametime)
        {
            foreach (Actor actor in GetListOfActiveActors().ToArray())
            {
                actor.Update(gametime);
            }

            CollisionDetector.DetectCollisions(GetListOfActiveActors());

            foreach (Actor actor in GetListOfActiveActors())
            {
                actor.ApplyForcesToActor();
            }
        }

        /// <summary>
        /// Draws all the active actors.
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

        /// <summary>
        /// Removes the actor from the actor lists. If the actor to be removed is
        /// a hostile NPC, Cabbagelips and Fluffernutter are awarded experience points.
        /// </summary>
        /// <param name="actor"></param>
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
    }
}
