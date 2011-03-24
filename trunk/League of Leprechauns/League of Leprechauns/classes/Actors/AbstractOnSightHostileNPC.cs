using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    abstract class AbstractOnSightHostileNPC : AbstractAwareHostileNPC
    {
        private int _sightDistance;
        private Rectangle _sightRectangle;

         public AbstractOnSightHostileNPC(Vector2 startPosition, int level, int totalHealth, int attackSpeed, 
            int jumpSpeed, int sightDistance) 
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed)
        {
            _sightDistance = sightDistance;
            _sightRectangle = createSightRectangle();
        }

         internal abstract void OnInSight();

         public override void Update(GameTime gameTime)
         {
             base.Update(gameTime);
             _sightRectangle = createSightRectangle();

             if (aPlayerCharacterIsInSight())
                 OnInSight();

         }

         private Boolean aPlayerCharacterIsInSight()
         {
             Boolean isInSight = false;
             foreach (PlayerCharacter playerCharacter in GetObserveablePlayerCharacters())
             {
                 isInSight = playerCharacter.BoundingRectangle.Intersects(_sightRectangle);
                 if (isInSight)
                     break;
             }
             return isInSight;
         }

         private Rectangle createSightRectangle()
         {
             int xPosition = 0;
             int yPosition = _sightDistance / 2 + (int)CurrentPosition.Y;

             if (faceDirection == Direction.LEFT)
                 xPosition = (int) CurrentPosition.X - _sightDistance;
             else
                 xPosition = (int) CurrentPosition.X;

            

             Rectangle sightRectangle = new Rectangle(xPosition, yPosition, _sightDistance, _sightDistance);
             return sightRectangle;
         }

 
    }
}
