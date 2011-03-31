using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    /// <summary>
    /// Animation state. None draws the entire spritesheet.
    /// </summary>
    enum AnimationConstants { NONE, STILL, WALKING, JUMPING, DUCKING, ATTACKING, ACTIVATED, OPEN, STUNNED}

    public delegate void AnimationDone();

    class Animation
    {
        private Dictionary<AnimationConstants, Rectangle> animationRectangles;
        private Dictionary<AnimationConstants, int> numberOfFrames;
        private int currentFrame = 0;
        private int animationLength = 100;
        private AnimationConstants currentAnimation;

        private int timeToNextFrame;

        public AnimationDone AnimationDone; 

        public Animation()
        {
            animationRectangles = new Dictionary<AnimationConstants, Rectangle>();
            numberOfFrames = new Dictionary<AnimationConstants, int>();
            currentAnimation = AnimationConstants.NONE;
        }

        public void AddAnimation(AnimationConstants animationType, int animationStartHeight, int animationWidth, int animationHeight, int numberOfFrames)
        {
            if (animationRectangles.ContainsKey(animationType))
            {
                animationRectangles.Add(animationType, new Rectangle(0, animationStartHeight, animationWidth, animationHeight));
                this.numberOfFrames.Add(animationType, numberOfFrames);
            }
        }

        public void SetAnimationLength(int length)
        {
            if (length > 0)
                animationLength = length;
        }

        public AnimationConstants AnimationState
        {
            get { return currentAnimation; }
        }

        /// <summary>
        /// Sets the current animation sequence. If the actor doesn't use the specified animation, AnimationConstants.NONE is used
        /// </summary>
        /// <param name="animation">The Animation</param>
        public void SetCurrentAnimation(AnimationConstants animation)
        {
            if (animation == currentAnimation)
                return;

            currentAnimation = animation;
            currentFrame = 0;
            timeToNextFrame = animationLength;

        }

        public Rectangle CurrentRectangle
        {
            get
            {
                return new Rectangle(currentFrame * animationRectangles[currentAnimation].Width,
                                     animationRectangles[currentAnimation].Y,
                                     animationRectangles[currentAnimation].Width,
                                     animationRectangles[currentAnimation].Height);
            }
        }

        public void Update(GameTime gameTime)
        {
            timeToNextFrame -= gameTime.ElapsedGameTime.Milliseconds;
            if (timeToNextFrame < 0)
            {
                timeToNextFrame = animationLength;
                currentFrame++;
                currentFrame %= numberOfFrames[currentAnimation];
                if(currentFrame == 0 && AnimationDone != null)
                {
                    AnimationDone();
                }
            }
        }

        public void Initialize(int width, int height)
        {
            this.AddAnimation(AnimationConstants.NONE, 0, width, height, 1);
        }
    }
}