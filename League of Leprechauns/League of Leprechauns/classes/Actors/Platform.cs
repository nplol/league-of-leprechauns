using Microsoft.Xna.Framework;

namespace LoL
{
    abstract class Platform : NonLivingObject
    {
        private Microsoft.Xna.Framework.Vector2 startPosition;

        public Platform(Vector2 startPosition) : base(startPosition)
        {
            this.startPosition = startPosition;
        }
    }
}
