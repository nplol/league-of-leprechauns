using Microsoft.Xna.Framework;

namespace LoL
{
    class Tree : NonLivingObject
    {
        #region attributes
        private bool activated;
        #endregion

        /// <summary>
        /// Instanciates a new tree (used in the Highland-levels). This tree will
        /// fall over if hit with a fireball, creating a bridge for the players to
        /// traverse.
        /// </summary>
        /// <param name="startPosition"></param>
        public Tree(Vector2 startPosition)
            : base(startPosition)
        {
            activated = false;
        }

        /// <summary>
        /// If the tree collides with a fireball, make it fall.
        /// </summary>
        /// <param name="collision"></param>
        public override void HandleCollision(Collision collision)
        {
            if (collision.getCollidingActor() is AbilityObject) //fireball
                activated = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (activated)
            {
                //TODO: Fix animation for falling
            }
        }

    }
}
