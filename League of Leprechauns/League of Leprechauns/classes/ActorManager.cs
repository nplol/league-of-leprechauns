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


        public static void Update(GameTime gametime)
        {
            
            foreach(Actor actor in ListOfAllActors)
            {
                actor.Update(gametime);
            }
            CollisionDetector.DetectCollisions(ListOfAllActors);

            foreach (Actor actor in ListOfAllActors)
            {
                actor.UpdatePosition();
            }
        }

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
