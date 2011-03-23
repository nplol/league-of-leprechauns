using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
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
