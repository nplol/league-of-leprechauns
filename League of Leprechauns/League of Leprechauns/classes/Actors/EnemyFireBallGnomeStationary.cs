using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LoL
{

    /// <summary>
    /// Class describing the behaviour of a stationary fireball gnome.
    /// </summary>
    class EnemyFireballGnomeStationary : EnemyFireballGnome
    {
        /// <summary>
        /// Instanciates a new stationary fireball gnome.
        /// </summary>
        /// <param name="startPosition"></param>
        public EnemyFireballGnomeStationary(Vector2 startPosition)
            : base(startPosition)
        {
            Abilities.Add(new RangedAbility(this, Settings.GNOME_FIREBALL_COOLDOWN, Settings.GNOME_FIREBALL_DAMAGE, GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/flameAnimation"), 45, 86, 55, 3));
        }
    }
}
