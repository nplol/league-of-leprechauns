using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class describing the (non existent) behaviour of platforms.
    /// </summary>
    abstract class Platform : NonLivingObject
    {
        protected Platform(Vector2 startPosition) : base(startPosition)
        {

        }
    }
}
