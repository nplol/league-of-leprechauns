using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        Texture2D[] spritesTexture;
        System.Drawing.Image[] spriteImages;

        Texture2D[] backgroundsTexture;
        System.Drawing.Image[] backgroundImages;

        GameItem selectedItem;
        Texture2D selectedRectangle;

        SpriteBatch spriteBatch;

        List<GameItem> gameItems;

        public GraphicsDevice GraphicsDevice
        {
            get { return display1.GraphicsDevice; }
        }

        public int SelectedSpriteIndex
        {
            get { return listBoxSprites.SelectedIndex; }
        }

        public int SelectedBackgroundIndex
        {
            get { return listBoxBackgrounds.SelectedIndex; }
        }

        public Form1()
        {
            InitializeComponent();

            display1.OnInitialize += new EventHandler(display1_OnInitialize);
            display1.OnDraw += new EventHandler(display1_OnDraw);
        }

        void display1_OnInitialize(object sender, EventArgs e)
        {
            gameItems = new List<GameItem>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadFiles();

            gameItems.Add(new GameItem(spritesTexture[0], new Vector2(100, 100)));
        }

        void display1_OnDraw(object sender, EventArgs e)
        {
            Logic();
            Render();
        }

        private void Logic()
        {

        }

        private void Render()
        {
            spriteBatch.Begin();
            foreach (GameItem item in gameItems)
            {
                item.Draw(spriteBatch);
            }

            if (selectedRectangle != null)
                spriteBatch.Draw(selectedRectangle, selectedItem.Position, Color.White);
            spriteBatch.End();
        }

        private void LoadFiles()
        {
            string[] spriteFiles = Directory.GetFiles("Contents");
            spritesTexture = new Texture2D[spriteFiles.Length];
            spriteImages = new System.Drawing.Image[spriteFiles.Length];

            for (int i = 0; i < spriteFiles.Length; i++)
            {
                listBoxSprites.Items.Add(Path.GetFileName(spriteFiles[i]));
                Stream stream = File.OpenRead(@"Contents\" + Path.GetFileName(spriteFiles[i]));
                spritesTexture[i] = Texture2D.FromStream(GraphicsDevice, stream);
                spriteImages[i] = System.Drawing.Image.FromFile(@"Contents\" + Path.GetFileName(spriteFiles[i]));
            }

            string[] backgroundFiles = Directory.GetFiles("Backgrounds");
            backgroundsTexture = new Texture2D[backgroundFiles.Length];
            backgroundImages = new System.Drawing.Image[backgroundFiles.Length];

            for (int i = 0; i < backgroundFiles.Length; i++)
            {
                listBoxBackgrounds.Items.Add(Path.GetFileName(backgroundFiles[i]));
                Stream stream = File.OpenRead(@"Backgrounds\" + Path.GetFileName(backgroundFiles[i]));
                backgroundsTexture[i] = Texture2D.FromStream(GraphicsDevice, stream);
                backgroundImages[i] = System.Drawing.Image.FromFile(@"Backgrounds\" + Path.GetFileName(backgroundFiles[i]));
            }


        }

        private void listBoxSprites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedSpriteIndex < 0 || SelectedSpriteIndex >= spriteImages.Length)
                return;
            imageBoxSprite.Image = spriteImages[SelectedSpriteIndex];
        }

        private void listBoxBackground_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (SelectedBackgroundIndex < 0 || SelectedBackgroundIndex >= backgroundImages.Length)
                return;
            imageBoxBackground.Image = backgroundImages[SelectedBackgroundIndex];
        }

        private void display1_MouseClick(object sender, MouseEventArgs e)
        {
            selectedItem = GetSelectedGameItem(e.X, e.Y);
            selectedRectangle = null;
            
            if (selectedItem == null && SelectedSpriteIndex >=0)
            {
                gameItems.Add(new GameItem(spritesTexture[SelectedSpriteIndex], new Vector2(e.X, e.Y)));
                
                //Invalidate causes control to repaint. Move it somewhere else?
            }
            if (selectedItem != null)
            {
                selectedRectangle = CreateRectangle(selectedItem.Width, selectedItem.Height);

               //highlight sprite
                //move it to the next mouse click
                //need to save the currently selected sprite. Deselect if we click another place
            }
            display1.Invalidate();
        }

        private GameItem GetSelectedGameItem(int X, int Y)
        {
            Rectangle rect = new Rectangle(X, Y, 1, 1);

            foreach(GameItem item in gameItems)
            {
                Rectangle currentRect = new Rectangle((int)item.Position.X, (int)item.Position.Y, item.Width, item.Height);
                if (currentRect.Intersects(rect))
                {
                    return item;
                }
            }

            return null;
        }

        private Texture2D CreateRectangle(int width, int height)
        {
            Texture2D rectangleTexture = new Texture2D(GraphicsDevice, width, height, false, SurfaceFormat.Color);
            Color[] color = new Color[width * height];
            for (int i = 0; i < color.Length; i++)
            {
                color[i] = new Color(0, 0, 0, 150);
            }

            rectangleTexture.SetData(color);
            return rectangleTexture;
        }
    }
}
