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
                        if (actor.PotentialMoveRectangle.Intersects(actor2.BoundingRectangle) && actor is PlayerCharacter)
                        {
                            Vector2 translationVector = CalculateTranslationVector(actor, actor2);
                            Collision collision = new Collision(translationVector, actor2);
                            actor.HandleCollision(collision);
                        }
                    }
                }
            }
        }

        private static Vector2 CalculateTranslationVector(Actor movingActor, Actor staticActor)
        {
            Rectangle actorBoundingRectangle = movingActor.PotentialMoveRectangle;
            Rectangle staticBoundingRectangle = staticActor.BoundingRectangle;
            float minIntervalDistance = float.PositiveInfinity;
            Vector2 translationAxis = new Vector2();
            Vector2 activeEdge = new Vector2();
            Vector2 axis;

            List<Vector2> actorEdges = getRectangleEdges(actorBoundingRectangle);
            List<Vector2> collisionEdges = getRectangleEdges(staticBoundingRectangle);

            for (int i = 0; i < 8; i++)
            {
                if (i < 4)
                {
                    activeEdge = actorEdges[i];
                }
                else
                {
                    activeEdge = collisionEdges[i-4];
                }

                //Sjekke ut om de kolliderer
                axis = new Vector2(-activeEdge.Y, activeEdge.X);
                float magnitude = (float) Math.Sqrt(axis.X * axis.X + axis.Y * axis.Y);
                axis.X = axis.X / magnitude;
                axis.Y = axis.Y / magnitude;

                //Finn projeksjonen av rektangelet på den gitte aksen
                float minA = 0; float minB = 0; float maxA = 0; float maxB = 0;
                ProjectRectangle(axis, actorBoundingRectangle, ref minA, ref maxA);
                ProjectRectangle(axis, staticBoundingRectangle, ref minB, ref maxB);
                float intervalDistance = IntervalDistance(minA, maxA, minB, maxB);

                //Finn minimum avstand actorRectangle må flyttes for at det ikke lenger
                //skal være kollisjon. (translation vector)
                intervalDistance = Math.Abs(intervalDistance);
                if (intervalDistance < minIntervalDistance)
                {
                    minIntervalDistance = intervalDistance;
                    translationAxis = axis;

                    Vector2 difference = new Vector2(actorBoundingRectangle.Center.X - staticBoundingRectangle.Center.X,
                                                     actorBoundingRectangle.Center.Y - staticBoundingRectangle.Center.Y);
                    if (calculateDotProduct(difference, axis) < 0)
                        translationAxis = -translationAxis;
                }
            }
            return translationAxis * minIntervalDistance;
        }

        //private static void Normalize(Vector2 vector)
        //{
        //    float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        //    vector.X = vector.X / magnitude;
        //    vector.Y =  vector.Y / magnitude;
        //}

        private static void ProjectRectangle(Vector2 axis, Rectangle boundingRectangle,
                            ref float min, ref float max)
        {
            //Bruker prikkprodukt for å projektere et punkt på en akse.
            List<Vector2> points = getRectanglePoints(boundingRectangle);
            float dotProduct = calculateDotProduct(axis, points[0]);
            min = dotProduct;
            max = dotProduct;

            for (int i = 0; i < points.Count; i++)
            {
                dotProduct = calculateDotProduct(axis, points[i]);
                if (dotProduct < min)
                {
                    min = dotProduct;
                }
                else
                {
                    if (dotProduct > max)
                    {
                        max = dotProduct;
                    }
                }
            }
        }

        private static float calculateDotProduct(Vector2 vector1, Vector2 vector2)
        {
            return vector1.X * vector2.X + vector1.Y * vector2.Y;
        }

        private static List<Vector2> getRectangleEdges(Rectangle rectangle)
        {
            List<Vector2> returnList = new List<Vector2>();

            returnList.Add(new Vector2(0, (rectangle.Y + rectangle.Height) - rectangle.Y));
            returnList.Add(new Vector2((rectangle.X + rectangle.Width) - rectangle.X, 0));
            returnList.Add(new Vector2(0, rectangle.Y - (rectangle.Y + rectangle.Height)));
            returnList.Add(new Vector2(rectangle.X - (rectangle.X + rectangle.Width), 0));

            return returnList;
        }

        private static List<Vector2> getRectanglePoints(Rectangle rectangle)
        {
            List<Vector2> returnList = new List<Vector2>();

            returnList.Add(new Vector2(rectangle.X, rectangle.Y));
            returnList.Add(new Vector2(rectangle.X, (rectangle.Y + rectangle.Height)));
            returnList.Add(new Vector2((rectangle.X + rectangle.Width), (rectangle.Y + rectangle.Height)));
            returnList.Add(new Vector2((rectangle.X + rectangle.Width), rectangle.Y));

            return returnList;
        }

        private static float IntervalDistance(float minA, float maxA, float minB, float maxB)
        {
            if (minA < minB)
            {
                return minB - maxA;
            }
            else
            {
                return minA - maxB;
            }
        }
    }
}




    //    /// <summary>
    //    /// Is supposed to return the object that the moving actor is colliding with,
    //    /// and the collision vector which tells the actor the maximum possible movement
    //    /// in the current direction.
    //    /// </summary>
    //    /// <param name="movingActor"></param>
    //    /// <param name="staticActor"></param>
    //    /// <returns></returns>
    //    private static CollisionType checkDirection(Actor movingActor, Actor collidingActor)
    //    {

    //        Vector2 movementSpeed = movingActor.PotentialSpeed;
    //        Rectangle movingActorRectangle = movingActor.BoundingRectangle;
    //        Rectangle collidingActorRectangle = collidingActor.BoundingRectangle;

    //        #region Collision test points
    //        //Point centerPoint = new Point(movingActorRectangle.Center.X, movingActorRectangle.Center.Y);
    //        //Point collisionTestPoint = new Point(0, 0);
    //        //Vector2 collisionLine = new Vector2(0, 0);
            
    //        // Points for moving actor
    //        Point movingActivePointRight = new Point(0, 0);
    //        Point movingActivePointLeft = new Point(0, 0);
    //        Point movingActivePoint = new Point(0, 0);
    //        Point movingCollisionPoint = new Point(0, 0);

    //        // Points for colliding actor
    //        Point collidingActivePointRight = new Point(0, 0);
    //        Point collidingActivePointLeft = new Point(0, 0);
    //        Point collidingAvtivePoint = new Point(0, 0);
    //        Point collidingCollisionPoint = new Point(0, 0);
            
    //        #endregion

    //        /*
    //         * 1. Finn ut om kollisjonsvektoren fra "moving collision point" og i fartsretningen 
    //         * passerer over eller under "static collision point"
    //         * 2. Velg deretter riktig aktivt punkt for både moving og static actor
    //         * 3. Finn ut om "moving active point" passerer "static active point" på samme side av punktet som "static collision point"
    //         *  - Hvis IKKE : Avbryt - ingen kollisjon
    //         * 4. Regn ut hvor langt det er fra "moving collision point" til linjen mellom "static collision point" og "static active point"
    //         * dersom man følger fartsvektoren fra "moving collision point"
    //         * 5. Returner denne avstanden som en vektor
    //         */

    //        if (movementSpeed.X > 0)
    //        {
    //            if (movementSpeed.Y > 0)
    //            {
    //                /*
    //                 * Ned mot høyre.
    //                 */
    //                movingActivePoint = new Point(  movingActorRectangle.X + movingActorRectangle.Width,
    //                                                movingActorRectangle.Y + movingActorRectangle.Height);
    //                movingActivePointRight = new Point( movingActorRectangle.X, 
    //                                                    movingActorRectangle.Y + movingActorRectangle.Height);
    //                movingActivePointLeft = new Point(  movingActorRectangle.X + movingActorRectangle.Width, 
    //                                                    movingActorRectangle.Y);
    //                collidingAvtivePoint = new Point(   collidingActorRectangle.X, collidingActorRectangle.Y);
    //                collidingActivePointLeft = new Point(   collidingActorRectangle.X, 
    //                                                        collidingActorRectangle.Y + collidingActorRectangle.Height);
    //                collidingActivePointRight = new Point(  collidingActorRectangle.X + collidingActorRectangle.Width,
    //                                                        collidingActorRectangle.Y);

    //                if(new Point((int) (movingActivePoint.X + movingActor.PotentialSpeed.X), 
    //                             (int) (movingActivePoint.Y + movingActor.PotentialSpeed.Y))
    //                    //Sjekke om kollisjonsvektoren fra movingActivePoint går over CollisionPoint
    //                {

    //                }

    //            }
    //            else if (movementSpeed.Y == 0)
    //            {
    //                /*
    //                 * Horisontalt mot høyre.
    //                 */
    //                movingActivePointRight = new Point( movingActorRectangle.X + movingActorRectangle.Width, 
    //                                                    movingActorRectangle.Y + movingActorRectangle.Height);
    //                movingActivePointLeft = new Point(  movingActorRectangle.X + movingActorRectangle.Width,
    //                                                    movingActorRectangle.Y);
    //            }
    //            else
    //            {
    //                /*
    //                 * Opp mot høyre.
    //                 */
    //                movingActivePointRight = new Point( movingActorRectangle.X + movingActorRectangle.Width,
    //                                                    movingActorRectangle.Y + movingActorRectangle.Height);
    //                movingActivePointLeft = new Point(  movingActorRectangle.X, 
    //                                                    movingActorRectangle.Y);
    //            }
    //        }
    //        else if (movementSpeed.X == 0)
    //        {
    //            if (movementSpeed.Y > 0)
    //            {
    //                /*
    //                 * Rett ned.
    //                 */
    //                movingActivePointRight = new Point( movingActorRectangle.X,
    //                                                    movingActorRectangle.Y + movingActorRectangle.Height);
    //                movingActivePointLeft = new Point(  movingActorRectangle.X + movingActorRectangle.Width, 
    //                                                    movingActorRectangle.Y + movingActorRectangle.Height);

    //            }
    //            else
    //            {
    //                /*
    //                 * Rett opp.
    //                 */
    //                movingActivePointRight = new Point( movingActorRectangle.X + movingActorRectangle.Width,
    //                                                    movingActorRectangle.Y);
    //                movingActivePointLeft = new Point(  movingActorRectangle.X,
    //                                                    movingActorRectangle.Y);
    //            }
    //        }
    //        else if (movementSpeed.X < 0)
    //        {
    //            if (movementSpeed.Y > 0)
    //            {
    //                /*
    //                 * Ned mot venstre.
    //                 */
    //                movingActivePointRight = new Point( movingActorRectangle.X, 
    //                                                    movingActorRectangle.Y);
    //                movingActivePointLeft = new Point(  movingActorRectangle.X + movingActorRectangle.Width,
    //                                                    movingActorRectangle.Y + movingActorRectangle.Height);
    //            }
    //            else if (movementSpeed.Y == 0)
    //            {
    //                /*
    //                 * Horisontalt mot venstre.
    //                 */
    //                movingActivePointRight = new Point( movingActorRectangle.X, 
    //                                                    movingActorRectangle.Y);
    //                movingActivePointLeft = new Point(  movingActorRectangle.X, 
    //                                                    movingActorRectangle.Y + movingActorRectangle.Height);
    //            }
    //            else
    //            {
    //                /*
    //                 * Opp mot venstre.
    //                 */
    //                movingActivePointRight = new Point( movingActorRectangle.X + movingActorRectangle.Width, 
    //                                                    movingActorRectangle.Y);
    //                movingActivePointLeft = new Point(  movingActorRectangle.X, 
    //                                                    movingActorRectangle.Y + movingActorRectangle.Height);
    //            }
    //        }

    //        return new CollisionType();
    //    }
    //}
//}
