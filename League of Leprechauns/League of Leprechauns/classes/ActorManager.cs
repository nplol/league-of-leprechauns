using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LoL.classes;

namespace LoL
{
    class ActorManager
    {

        private static List<Actor> ListOfAllActors;
        private static List<Actor> ListOfActiveActors;

        static ActorManager()
        {
            ListOfAllActors = new List<Actor>();
            ListOfActiveActors = new List<Actor>();
        }

        public void addActor(Actor actor)
        {
            ListOfAllActors.Add(actor);
        }

        public void clearList()
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


        public void Update(GameTime gametime)
        {
            /*
             * Hver aktive actor forsøker å bevege seg,
             * og kaller CollisionDetector fra sine egne metoder.
             */ 
            foreach(Actor actor in ListOfActiveActors)
            {
                actor.Update(gametime);
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {

        }

    }
}
