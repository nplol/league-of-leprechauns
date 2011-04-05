using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LoL
{
    class MenuText
    {

        private List<string> textList;
        private SpriteFont spriteFont;
        private Vector2 position;
        private Color color;
        private int lineSpacing;
        

        public MenuText(string text, Vector2 position, int width, int lineSpacing, SpriteFont spriteFont, Color color)
        {
            textList = BuildTextList(text, width);         
            this.lineSpacing = lineSpacing;
            this.position = position;
            this.spriteFont = spriteFont;
            this.color = color;
        }

        
        
        private List<string> BuildTextList(string text, int width)
        {
            List<string> tList = new List<string>();
            int counter = 0;
            string temp = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (counter < width || !(text.Substring(i, 1) == " "))
                {
                    temp += text.Substring(i, 1);
                    counter++;
                }
                else
                {
                    counter = 0;
                    tList.Add(temp);
                    temp = "";
                }
            }
            tList.Add(temp);
            foreach (string texxt in tList)
            {
                Console.WriteLine(texxt);
            }
            return tList;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (string line in textList)
            {
                spriteBatch.DrawString(spriteFont, line, new Vector2(position.X, position.Y+lineSpacing*textList.IndexOf(line)), color);
            }
           
        }
    }
}
