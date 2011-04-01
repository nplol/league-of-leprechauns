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

        public static void ClearList()
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

            foreach (Actor actor in getListOfActiveActors().ToArray())
            {
                actor.Update(gametime);
            }

            CollisionDetector.DetectCollisions(ListOfActiveActors);

            //Updates the position of the actors based on the force applied on them
            foreach (Actor actor in getListOfActiveActors())
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
            foreach (Actor actor in getListOfActiveActors())
            {
                actor.Draw(spriteBatch, camera);
            }

            DrawDebug(spriteBatch);
        }

        public static FlufferNutter GetFlufferNutterInstance()
        {
            return ActorManager.flufferNutter;
        }

        public static CabbageLips GetCabbageLipsInstance()
        {
            return ActorManager.cabbageLips;
        }

        public static PlayerCharacter GetOtherPlayerCharacter(Character self)
        {
            return (self is CabbageLips) ? (PlayerCharacter)GetFlufferNutterInstance() : (PlayerCharacter)GetCabbageLipsInstance();
        }

        public static void RemoveActor(Actor actor)
        {
            if (actor is HostileNPC && ((Character)actor).IsDead() && getListOfAllActors().Contains(actor))
            {
                GetCabbageLipsInstance().addExperience(500);
                GetFlufferNutterInstance().addExperience(500);
            }

            // TODO: Fix so that the PlayerCharacters get experiencepoints when an enemy (HostileNPC) dies.
            ListOfActiveActors.Remove(actor);
            ListOfAllActors.Remove(actor);

            
        }

        public static List<Actor> GetActorsInRange(Rectangle area)
        {
            List<Actor> actorsInRange = new List<Actor>();

            //todo: ListofAllActors should be listOfActiveActors
            foreach (Actor actor in getListOfActiveActors())
            {
                if (actor.BoundingRectangle.Intersects(area))
                    actorsInRange.Add(actor);
            }

            return actorsInRange;
        }

        /// <summary>
        /// TEMPERARY METHOD
        /// </summary>
        private static void DrawDebug(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/MenuInfoFont"), "Active Actors: " + getListOfActiveActors().Count.ToString(), new Vector2(100, 0), Color.White);
            spriteBatch.DrawString(GlobalVariables.ContentManager.Load<SpriteFont>(@"Sprites/SpriteFonts/MenuInfoFont"), "All Actors: " + getListOfAllActors().Count.ToString(), new Vector2(100, 30), Color.White);
        }
    }
}
