using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    class CabbageLips : PlayerCharacter
    {
        public CabbageLips(Vector2 startPosition, int level, int totalHealth, Vector2 attackSpeed, int jumpSpeed)
            : base(startPosition, level, totalHealth, attackSpeed, jumpSpeed) 
        {
 
        }

        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            

            if (isJumping())
            {
                jumpingFrame();
            }
            else if (CurrentSpeed.X != 0)
            {
                nextRunningFrame();
            }
            else
            {
                Rectangle stillFrame = new Rectangle(0, 0, 100, 140);
                setFrame(stillFrame);
            }
        }

        private void nextRunningFrame(){
            if (timeForNextFrame())
            {
                timeSinceLastFrame = 0;
                Rectangle oldFrame = getFrame();
                Rectangle nextFrame = new Rectangle((oldFrame.Left + 100) % 300, 0, 100, 140);
                setFrame(nextFrame);
            }
        }

        private void jumpingFrame()
        {
            Rectangle jumpFrame = new Rectangle(300, 0, 100, 140);
            setFrame(jumpFrame);
        }

        public override void move()
        {

        }


        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager theContentManager, string theAssetName)
        {
            base.LoadContent(theContentManager, theAssetName);
            Rectangle newFrame = new Rectangle(0,0, 100, 140);
            setFrame(newFrame);

        }
    }
}
