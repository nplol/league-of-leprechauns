using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Enumeration describing the animation.
    /// </summary>
    enum AnimationConstants { NONE, STILL, WALKING, JUMPING, DUCKING, ATTACKING, ACTIVATED, OPEN, STUNNED, HIDDEN}

    public delegate void AnimationDone();

    /// <summary>
    /// Method used to animate sprites
    /// </summary>
    class Animation
    {
        private Dictionary<AnimationConstants, Rectangle> animationRectangles;
        private Dictionary<AnimationConstants, int> numberOfFrames;
        private int currentFrame = 0;
        private int animationFrameLength = 100;
        private AnimationConstants currentAnimation;

        private int timeToNextFrame;

        public AnimationDone AnimationDone; 

        public Animation()
        {
            animationRectangles = new Dictionary<AnimationConstants, Rectangle>();
            numberOfFrames = new Dictionary<AnimationConstants, int>();
            currentAnimation = AnimationConstants.NONE;
        }

        /// <summary>
        /// Adds a animation
        /// </summary>
        /// <param name="animationType"></param>
        /// <param name="animationStartHeight">The start height coordinate in the spritesheet</param>
        /// <param name="animationWidth">The width of the animation frames</param>
        /// <param name="animationHeight">The height of the animation frames</param>
        /// <param name="numberOfFrames">Number of frames</param>
        public void AddAnimation(AnimationConstants animationType, int animationStartHeight, int animationWidth, int animationHeight, int numberOfFrames)
        {
            if (!animationRectangles.ContainsKey(animationType))
            {
                animationRectangles.Add(animationType, new Rectangle(0, animationStartHeight, animationWidth, animationHeight));
                this.numberOfFrames.Add(animationType, numberOfFrames);
            }
        }

        /// <summary>
        /// Sets the length of each 
        /// </summary>
        /// <param name="length"></param>
        public void SetAnimationFrameLength(int length)
        {
            if (length > 0)
                animationFrameLength = length;
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
            timeToNextFrame = animationFrameLength;

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
                timeToNextFrame = animationFrameLength;
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