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

        public List<Actor> ListOfAllActors;
        private Rectangle actor1Rect, actor2Rect;

        public ActorManager()
        {
            ListOfAllActors = new List<Actor>();
        }

        public void addActor(Actor actor)
        {
            ListOfAllActors.Add(actor);
        }

        public void clearList()
        {
            ListOfAllActors.Clear();
        }

        public List<Actor> getListOfAllActors()
        {
            return ListOfAllActors;
        }

        public void Update(GameTime gametime)
        {
            /*
             * Hovedmetoden for kollisjonsdeteksjon.
             */
            foreach (Actor actor1 in ListOfAllActors)
            {
                actor1Rect = actor1.generateBoundingRectangle();
                foreach (Actor actor2 in ListOfAllActors)
                {
                    if (actor1 != actor2)
                    {
                        actor2Rect = actor2.generateBoundingRectangle();
                        collisionDetection(actor1Rect, actor2Rect, actor1, actor2);
                    }
                }
            }

        }

        private void collisionDetection(Rectangle actor1Rect, Rectangle actor2Rect, Actor actor1, Actor actor2)
        {
            if (actor1Rect.Intersects(actor2Rect))
            {
                if (actor1Rect.Bottom >= actor2Rect.Top)
                {
                    /* TODO:
                     * actor1 står på actor2.
                     */
                    actor1.collisionUnder(actor2);
                }
                else if (actor1Rect.Top >= actor2Rect.Bottom)
                {
                    /* TODO:
                     * actor1 skaller i actor2. 
                     */
                    actor1.collisionOver(actor2);
                }
                else if (actor1Rect.Right >= actor2Rect.Left || actor1Rect.Left <= actor2Rect.Right)
                {
                    /*
                     * actor1 treffer actor2 fra venstre eller høyre.
                     */
                    actor1.collisionSide(actor2);
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {

        }

    }
}
