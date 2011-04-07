using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class describing the behaviour of a melee ability
    /// </summary>
    class MeleeAbility : Ability
    {
        /// <summary>
        /// Instanciates a new melee ability.
        /// </summary>
        public MeleeAbility(Character owner, int cooldownTime, int damagePoints)
            : base(owner, cooldownTime, damagePoints)
        {
            
            abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/HitSlash");
        }

        /// <summary>
        /// Instanciates the associated ability object.
        /// </summary>
        protected override void InstanciateAbilityObject()
        {
            abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width,-abilityTexture.Height/2) , 
                                                            abilityLifeTime, 
                                                            abilityTexture, 
                                                            Settings.HIT_SPEED, 
                                                            owner.FaceDirection, 
                                                            damagePoints
                                                            );
            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }
    }
}
