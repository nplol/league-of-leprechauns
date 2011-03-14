﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

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

        int levelSizeX = 1000;
        int levelSizeY = 720;

        Camera camera;

        Level level;

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
            txtLevelSizeX.Text = levelSizeX.ToString();
            txtLevelSizeY.Text = levelSizeY.ToString();

            camera = new Camera();
            level = new Level();

            vScrollBar1.Maximum = levelSizeY;
            hScrollBar1.Maximum = levelSizeX;

            display1.OnInitialize += new EventHandler(display1_OnInitialize);
            display1.OnDraw += new EventHandler(display1_OnDraw);
        }

        void display1_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadFiles();
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
            foreach (GameItem item in level.events)
            {
                item.Draw(spriteBatch, camera);
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

        //TODO: Check if new sprite collides with old sprite
        private void display1_MouseClick(object sender, MouseEventArgs e)
        {
            selectedItem = GetSelectedGameItem(e.X, e.Y);
            selectedRectangle = null;

            //Check if we should place a new sprite
            if (selectedItem == null && SelectedSpriteIndex >= 0)
            {
                Vector2 newPos = new Vector2(e.X - spritesTexture[SelectedSpriteIndex].Width / 2 + camera.X,
                                              e.Y - spritesTexture[SelectedSpriteIndex].Height / 2 + camera.Y);
                level.addItem(new GameItem(spritesTexture[SelectedSpriteIndex], newPos));
                txtPosX.Enabled = false;
                txtPosY.Enabled = false;
                txtScaleX.Enabled = false;
                txtScaleY.Enabled = false;
            }
              //check if we should mark an existing sprite
            if (selectedItem != null)
            {
                selectedRectangle = CreateRectangle(selectedItem.Width, selectedItem.Height);

                txtPosX.Enabled = true;
                txtPosX.Text = selectedItem.Position.X.ToString();
                txtPosY.Enabled = true;
                txtPosY.Text = selectedItem.Position.Y.ToString();
                txtScaleX.Enabled = true;
                txtScaleX.Text = selectedItem.Scale.X.ToString();
                txtScaleY.Enabled = true;
                txtScaleY.Text = selectedItem.Scale.Y.ToString();

                //move it to the next mouse click
                //need to save the currently selected sprite. Deselect if we click another place
            }
            display1.Invalidate();
        }


        private GameItem GetSelectedGameItem(int X, int Y)
        {
            Rectangle rect = new Rectangle(X, Y, 1, 1);

            foreach(GameItem item in level.events)
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


        private void updateSelectedSprite(object sender, KeyPressEventArgs ev)
        {
            //only do something if the key pressed == enter
            if (ev.KeyChar != 13)
                return;

            if (selectedItem == null)
                return;

            int posX, posY, scaleX, scaleY;

            try
            {
                int.TryParse(txtPosX.Text, out posX);
                int.TryParse(txtPosY.Text, out posY);
                int.TryParse(txtScaleX.Text, out scaleX);
                int.TryParse(txtScaleY.Text, out scaleY);

                selectedItem.Position = new Vector2(posX, posY);
                selectedItem.Scale = new Vector2(scaleX, scaleY);

                display1.Invalidate();
            }
            catch (ArgumentException e)
            {
                label4.Text = "ERROR";
            }
        }

        private void updateLevelSize()
        {
            vScrollBar1.Maximum = levelSizeY;
            hScrollBar1.Maximum = levelSizeX;
            txtLevelSizeX.Text = levelSizeX.ToString();
            txtLevelSizeY.Text = levelSizeY.ToString();
        }

        private void updateLevelSize(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;

            try
            {
                int.TryParse(txtLevelSizeX.Text, out levelSizeX);
                int.TryParse(txtLevelSizeY.Text, out levelSizeY);
                vScrollBar1.Maximum = levelSizeY;
                hScrollBar1.Maximum = levelSizeX;
            }
            catch(ArgumentException ex)
            {
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            camera.X = e.NewValue;
            display1.Invalidate();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            camera.Y = e.NewValue;
            display1.Invalidate();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                level.events.Remove(selectedItem);
                selectedItem = null;
                selectedRectangle = null;
                display1.Invalidate();
            }
        }

        //Save to XML
        private void saveLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Xml Files | *.xml";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel)
                return;
            string url = saveFileDialog1.FileName;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create(url, settings);
            
            IntermediateSerializer.Serialize(writer, level, null);
            writer.Close();
        }

        //Load from XML
        private void loadLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Xml Files | *.xml";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel)
                return;
            string url = openFileDialog1.FileName;

            XmlReader reader = new XmlTextReader(url);

            level = new Level();

            reader.ReadStartElement("XnaContent");
            reader.ReadStartElement("Asset");
            reader.ReadStartElement("Name");
            level.Name = reader.Value;
            reader.Read();
            reader.ReadEndElement();
            reader.ReadStartElement("BackgroundAsset");
            level.BackgroundAsset = reader.Value;
            reader.Read();
            reader.ReadEndElement();
            reader.ReadStartElement("SoundThemeAsset");
            level.SoundThemeAsset = reader.Value;
            reader.Read();
            reader.ReadEndElement();
            reader.ReadStartElement("LevelSize");
            string levelSize = reader.Value;
            levelSizeX = int.Parse(levelSize.Substring(0, levelSize.IndexOf(' ')));
            levelSizeY = int.Parse(levelSize.Substring(levelSize.IndexOf(' ') + 1));
            level.LevelSize = new Vector2(levelSizeX, levelSizeY);
            updateLevelSize();
            reader.Read();
            reader.ReadEndElement();

            reader.ReadStartElement("events");
            while (true)
            {
                try
                {
                    reader.ReadStartElement("Item");
                    reader.ReadStartElement("ActorType");
                    Texture2D texture = getTexture(reader.Value);
                    reader.Read();
                    reader.ReadEndElement();
                    reader.ReadStartElement("Position");
                    
                    string position = reader.Value;
                    int x = int.Parse(position.Substring(0, position.IndexOf(' ')));
                    int y = int.Parse(position.Substring(position.IndexOf(' ') + 1));
                    Vector2 pos = new Vector2(x, y);
                    level.addItem(new GameItem(texture, pos));
                    
                    reader.Read();
                    reader.ReadEndElement();
                    reader.ReadEndElement();
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            reader.Close();
            display1.Invalidate();

        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Texture2D getTexture(string actorType)
        {
            switch (actorType)
            {
                case "CabbageLips":
                   
                    break;
            }

            return spritesTexture[0]; 
        }
    }
}
