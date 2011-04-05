using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class Bar
    {
        private int barWidth, barHeight;
        Vector2 position;
        Texture2D fillTexture;

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

        public void Draw(SpriteBatch spriteBatch, int width)
        {
            Rectangle fillRectangle = new Rectangle((int)position.X, (int)position.Y, width, barHeight);
            spriteBatch.Draw(fillTexture, position, Color.White);
            spriteBatch.Draw(fillTexture, fillRectangle, Color.Red);
        }
    }
}
