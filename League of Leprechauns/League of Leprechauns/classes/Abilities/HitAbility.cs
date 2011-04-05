using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class HitAbility : Ability
    {

        public HitAbility(Character owner, int cooldownTime)
            : base(owner, cooldownTime)
        {
            this.damagePoints = Settings.HIT_DAMAGE;
            abilityTexture = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Objects/HitSlash");
            
        }

        protected override void InstanciateAbilityObject()
        {
            
            float abilitySpeed = 8f;
                   
            AbilityObject abilityObject = new AbilityObject(GetAbilityPosition(abilityTexture.Width,-abilityTexture.Height/2) , 
                                                            abilityLifeTime, 
                                                            abilityTexture, 
                                                            abilitySpeed, 
                                                            owner.FaceDirection, 
                                                            damagePoints
                                                            );


            abilityObject.CollisionOccurred += new Attack(HandleCollision);
        }

      

        
    }
}
