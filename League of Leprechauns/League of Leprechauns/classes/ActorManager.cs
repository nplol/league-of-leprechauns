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

        private List<Actor> ListOfAllActors;
        private List<Actor> ListOfActiveActors;
        private Rectangle actor1Rect, actor2Rect;
        private CollisionDetector collisionDetector;
        private CollisionHandler collisionHandler;

        public ActorManager()
        {
            ListOfAllActors = new List<Actor>();
            ListOfActiveActors = new List<Actor>();
            collisionDetector = new CollisionDetector(this);
        }

        public void addActor(Actor actor)
        {
            ListOfAllActors.Add(actor);
        }

        public void clearList()
        {
            ListOfAllActors.Clear();
        }

        public List<Actor> getListOfActiveActors()
        {
            return ListOfActiveActors;
        }

        public List<Actor> getListOfAllActors()
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
