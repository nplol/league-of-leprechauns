using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class HitAbility : Ability
    {

        public HitAbility(Character owner, int cooldownTime, int damagePoints)
            : base(owner, cooldownTime, damagePoints)
        {
            
            abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/HitSlash");
            
        }

        protected override void InstanciateAbilityObject()
        {
            
                               
            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width,-abilityTexture.Height/2) , 
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
