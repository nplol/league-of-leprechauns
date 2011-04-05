using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    /// <summary>
    /// Class for drawing a hp-bar
    /// </summary>
    class Bar
    {
        private int barWidth, barHeight;
        Vector2 position;
        Texture2D fillTexture;

        /// <summary>
        /// Creates a new bar object.
        /// </summary>
        /// <param name="width">The width of the bar</param>
        /// <param name="height">The height of the bar</param>
        /// <param name="position">The position the screen the bar should be drawed</param>
        public Bar(int width, int height, Vector2 position)
        {
            barWidth = width;
            barHeight = height;
            this.position = position;
            fillTexture = new Texture2D(GlobalVariables.GraphicsDevice, barWidth, barHeight);

            Color[] color = new Color[barWidth * barHeight];
            for (int i = 0; i < color.Length; i++)
            {
                color[i] = new Color(255, 255, 255, 255);
            }

            fillTexture.SetData(color);
        }

        /// <summary>
        /// Draws the bar
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="fillPercentage">The percentage of the bar that should be filled</param>
        public void Draw(SpriteBatch spriteBatch, int fillPercentage = 100)
        {
            Rectangle fillRectangle = new Rectangle((int)position.X, (int)position.Y, fillPercentage, barHeight);
            spriteBatch.Draw(fillTexture, position, Color.White);
            spriteBatch.Draw(fillTexture, fillRectangle, Color.Red);
        }
    }
}
