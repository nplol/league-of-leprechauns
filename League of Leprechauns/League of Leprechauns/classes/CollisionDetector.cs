using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    /*
     * Klasse for å oppdage potensielle kollisjoner     
     */ 
    static class CollisionDetector
    {
        public static void DetectCollisions(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                foreach (Actor actor2 in actors)
                {
                    //Først generer en liste over alle actors vi potensielt kommer til å kollidere med. 
                    //Så må vi avgjøre hvor stor kraft vi må apply'e for å unngå kollisjonen. 
                    //Potensielt problem: hvis actor beveger seg mot actor2, og actor2 beveger seg mot actor så vil begge
                    //detecte en collision, og applye en force i motsatt retning for å unngå kollisjonen.
                    if (actor != actor2)
                    {
                        if (actor.PotentialMoveRectangle.Intersects(actor2.PotentialMoveRectangle) && actor is PlayerCharacter)
                        {
                            CollisionType direction = checkDirection(actor, actor2);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Is supposed to return the object that the moving actor is colliding with,
        /// and the collision vector which tells the actor the maximum possible movement
        /// in the current direction.
        /// </summary>
        /// <param name="movingActor"></param>
        /// <param name="staticActor"></param>
        /// <returns></returns>
        private static CollisionType checkDirection(Actor movingActor, Actor staticActor)
        {

            Vector2 movementSpeed = movingActor.PotentialSpeed;
            Rectangle movingActorRectangle = movingActor.BoundingRectangle;
            Rectangle collisionActorRectangle = staticActor.BoundingRectangle;

            #region Collision test points
            //Point centerPoint = new Point(movingActorRectangle.Center.X, movingActorRectangle.Center.Y);
            //Point collisionTestPoint = new Point(0, 0);
            //Vector2 collisionLine = new Vector2(0, 0);
            
            // Points for moving actor
            Point movingActivePointRight = new Point(0, 0);
            Point movingActivePointLeft = new Point(0, 0);
            Point movingCollisionPoint = new Point(0, 0);

            // Points for static actor
            Point staticActivePointRight = new Point(0, 0);
            Point staticActivePointLeft = new Point(0, 0);
            Point staticCollisionPoint = new Point(0, 0);
            
            #endregion

            /*
             * 1. Finn ut om kollisjonsvektoren fra "moving collision point" og i fartsretningen 
             * passerer over eller under "static collision point"
             * 2. Velg deretter riktig aktivt punkt for både moving og static actor
             * 3. Finn ut om "moving active point" passerer "static active point" på samme side av punktet som "static collision point"
             *  - Hvis IKKE : Avbryt - ingen kollisjon
             * 4. Regn ut hvor langt det er fra "moving collision point" til linjen mellom "static collision point" og "static active point"
             * dersom man følger fartsvektoren fra "moving collision point"
             * 5. Returner denne avstanden som en vektor
             */

            if (movementSpeed.X > 0)
            {
                if (movementSpeed.Y > 0)
                {
                    /*
                     * Ned mot høyre.
                     */
                    movingActivePointRight = new Point( movingActorRectangle.X, 
                                                        movingActorRectangle.Y + movingActorRectangle.Height);
                    movingActivePointLeft = new Point(  movingActorRectangle.X + movingActorRectangle.Width, 
                                                        movingActorRectangle.Y);
                }
                else if (movementSpeed.Y == 0)
                {
                    /*
                     * Horisontalt mot høyre.
                     */
                    movingActivePointRight = new Point( movingActorRectangle.X + movingActorRectangle.Width, 
                                                        movingActorRectangle.Y + movingActorRectangle.Height);
                    movingActivePointLeft = new Point(  movingActorRectangle.X + movingActorRectangle.Width,
                                                        movingActorRectangle.Y);
                }
                else
                {
                    /*
                     * Opp mot høyre.
                     */
                    movingActivePointRight = new Point( movingActorRectangle.X + movingActorRectangle.Width,
                                                        movingActorRectangle.Y + movingActorRectangle.Height);
                    movingActivePointLeft = new Point(  movingActorRectangle.X, 
                                                        movingActorRectangle.Y);
                }
            }
            else if (movementSpeed.X == 0)
            {
                if (movementSpeed.Y > 0)
                {
                    /*
                     * Rett ned.
                     */
                    movingActivePointRight = new Point( movingActorRectangle.X,
                                                        movingActorRectangle.Y + movingActorRectangle.Height);
                    movingActivePointLeft = new Point(  movingActorRectangle.X + movingActorRectangle.Width, 
                                                        movingActorRectangle.Y + movingActorRectangle.Height);

                }
                else
                {
                    /*
                     * Rett opp.
                     */
                    movingActivePointRight = new Point( movingActorRectangle.X + movingActorRectangle.Width,
                                                        movingActorRectangle.Y);
                    movingActivePointLeft = new Point(  movingActorRectangle.X,
                                                        movingActorRectangle.Y);
                }
            }
            else if (movementSpeed.X < 0)
            {
                if (movementSpeed.Y > 0)
                {
                    /*
                     * Ned mot venstre.
                     */
                    movingActivePointRight = new Point( movingActorRectangle.X, 
                                                        movingActorRectangle.Y);
                    movingActivePointLeft = new Point(  movingActorRectangle.X + movingActorRectangle.Width,
                                                        movingActorRectangle.Y + movingActorRectangle.Height);
                }
                else if (movementSpeed.Y == 0)
                {
                    /*
                     * Horisontalt mot venstre.
                     */
                    movingActivePointRight = new Point( movingActorRectangle.X, 
                                                        movingActorRectangle.Y);
                    movingActivePointLeft = new Point(  movingActorRectangle.X, 
                                                        movingActorRectangle.Y + movingActorRectangle.Height);
                }
                else
                {
                    /*
                     * Opp mot venstre.
                     */
                    movingActivePointRight = new Point( movingActorRectangle.X + movingActorRectangle.Width, 
                                                        movingActorRectangle.Y);
                    movingActivePointLeft = new Point(  movingActorRectangle.X, 
                                                        movingActorRectangle.Y + movingActorRectangle.Height);
                }
            }

            return new CollisionType();
        }
    }
}
