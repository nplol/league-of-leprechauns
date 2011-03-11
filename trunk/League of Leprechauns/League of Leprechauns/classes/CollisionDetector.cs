using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using LoL.classes;

namespace LoL
{
    public enum CollisionType
    {
        collideLeft,
        collideRight,
        collideTop,
        collideBottom
    }
    /*
     * Klasse for å oppdage potensielle kollisjoner     
     */ 
    static class CollisionDetector
    {
        private ActorManager actorManager;

        public static CollisionDetector()
        {

        }

        public static List<Collision> detectCollision(Actor movingActor)
        {
            List<Collision> collisionList = new List<Collision>();
            Rectangle movingActorRectangle = movingActor.generateBoundingRectangle();
            foreach (Actor actor1 in ActorManager.getListOfActiveActors())
            {
                if (actor1 != movingActor)
                {
                    Rectangle collisionRectangle = actor1.generateBoundingRectangle();
                    if (movingActorRectangle.Intersects(collisionRectangle))
                    {
                        CollisionType direction = checkDirection(movingActorRectangle, collisionRectangle);
                        collisionList.Add(new Collision(direction, actor1));
                    }
                }
            }

            return collisionList;
        }

        private static CollisionType checkDirection(Rectangle rect1, Rectangle rect2)
        {
                if (rect1.Bottom >= rect2.Top)
                {
                    /* TODO:
                     * actor1 står på actor2.
                     */
                    return CollisionType.collideBottom;
                }
                else if (rect1.Top >= rect2.Bottom)
                {
                    /* TODO:
                     * actor1 skaller i actor2. 
                     */
                    return CollisionType.collideTop;
                }
                else if (rect1.Right >= rect2.Left)
                {
                    /*
                     * actor1 treffer actor2 fra venstre.
                     */
                    return CollisionType.collideLeft;
                }
                else
                {
                    /*
                     * actir1 treffer actor2 fra høyre.
                     */
                    return CollisionType.collideRight;
                }
        }

    }
}
