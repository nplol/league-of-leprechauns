using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class describing the (non existent) behaviour of static platforms.
    /// </summary>
    class StaticPlatform : Platform
    {
        /// <summary>
        /// instanciates a new static platform.
        /// </summary>
        /// <param name="startPosition"></param>
        public StaticPlatform(Vector2 startPosition) : base(startPosition) { }
    }



}
