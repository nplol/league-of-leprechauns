using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class used for detecting collisions. Called from ActorManager.
    /// </summary>
    static class CollisionDetector
    {
        public static void DetectCollisions(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                foreach (Actor actor2 in actors)
                {
                    if (actor != actor2)
                    {
                        if (actor.PotentialMoveRectangle.Intersects(actor2.BoundingRectangle) && actor is Character)
                        {
                            Vector2 translationVector = CalculateTranslationVector(actor, actor2);
                            Collision collision = new Collision(translationVector, actor2);
                            actor.HandleCollision(collision);
                        }
                    }
                }
                if (actor is HostileNPC && !actor.Collided)
                {
                    Collision emptyCollision = new Collision(Vector2.Zero, actor);
                    actor.HandleCollision(emptyCollision);
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

                //Beregne aksen for translasjonsvektoren.
                axis = new Vector2(-activeEdge.Y, activeEdge.X);
                axis.Normalize();

                //Finn projeksjonen av rektanglene på den gitte aksen
                float minA = 0; float minB = 0; float maxA = 0; float maxB = 0;
                ProjectRectangle(axis, actorBoundingRectangle, ref minA, ref maxA);
                ProjectRectangle(axis, staticBoundingRectangle, ref minB, ref maxB);
                float intervalDistance = IntervalDistance(minA, maxA, minB, maxB);

                //Finn minimum avstand actorRectangle må flyttes for at det ikke lenger
                //skal være kollisjon (translasjonsvektor).
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

            Vector2 translationVector = translationAxis * minIntervalDistance;

            //Hack for å fikse superfart for hopp på kanten.
            if (actorBoundingRectangle.Y < staticBoundingRectangle.Y && movingActor.PotentialSpeed.Y < 0)
                translationVector.Y = 0;

            return translationVector;
        }

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