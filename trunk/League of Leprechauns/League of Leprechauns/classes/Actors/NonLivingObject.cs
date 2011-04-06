using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class describing the (non existent) behaviour of non living objects.
    /// </summary>
    class NonLivingObject : Actor
    {
        /// <summary>
        /// Instanciates a new non living object.
        /// </summary>
        /// <param name="startPosition"></param>
        public NonLivingObject(Vector2 startPosition) : base(startPosition) { }
    }
}