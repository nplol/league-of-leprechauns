using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    /// <summary>
    /// A Nonliving object which doesn't collide with other actors.
    /// </summary>
    class BackgroundObject : NonLivingObject, IIgnorable
    {
        private bool fixedPosition;
        /// <summary>
        /// Instanciates a new BackgroundObject
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="fixedPosition">If true, the object should now follow the camera movement.</param>
        public BackgroundObject(Vector2 startPosition, bool fixedPosition) : base(startPosition) 
        {
            this.fixedPosition = fixedPosition;
        }

        public override void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            if (fixedPosition)
                base.Draw(spriteBatch);
            else
                base.Draw(spriteBatch, camera);
        }
    }
}
