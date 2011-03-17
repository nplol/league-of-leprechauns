using System;
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
        List<Texture2D> spritesTexture;
        List<System.Drawing.Image> spriteImages;
        List<String> spriteFolders;

        List<Texture2D> backgroundsTexture;
        List<System.Drawing.Image> backgroundImages;

        GameItem selectedItem;
        Texture2D selectedRectangle;

        Texture2D backgroundTexture;

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
            if (backgroundTexture != null)
                spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);

            foreach (GameItem item in level.events)
            {
                item.Draw(spriteBatch, camera);
            }

            if (selectedItem != null)
            {
                selectedRectangle = CreateRectangle(selectedItem.Width, selectedItem.Height);
                spriteBatch.Draw(selectedRectangle, selectedItem.Position - camera.Position, Color.White);
            }
            spriteBatch.End();
        }

        private void LoadFiles()
        {
            string[] characterFiles = Directory.GetFiles("Sprites\\Characters");
            string[] groundFiles = Directory.GetFiles("Sprites\\Ground");
            string[] objectFiles = Directory.GetFiles("Sprites\\Objects");
            string[] platformFiles = Directory.GetFiles("Sprites\\Platforms");
            string[] backgroundFiles = Directory.GetFiles("Sprites\\Backgrounds");

            spriteFolders = new List<string>();
            spritesTexture = new List<Texture2D>();
            spriteImages = new List<System.Drawing.Image>();

            for (int i = 0; i < characterFiles.Length; i++)
            {
                spriteFolders.Add("Characters/");
                listBoxSprites.Items.Add(Path.GetFileName(characterFiles[i]));
                Stream stream = File.OpenRead(@"Sprites/Characters/" + Path.GetFileName(characterFiles[i]));
                spritesTexture.Add(Texture2D.FromStream(GraphicsDevice, stream));
                spriteImages.Add(System.Drawing.Image.FromFile(@"Sprites/Characters/" + Path.GetFileName(characterFiles[i])));
                stream.Close();
            }

            for (int i = 0; i < groundFiles.Length; i++)
            {
                spriteFolders.Add("Ground/");
                listBoxSprites.Items.Add(Path.GetFileName(groundFiles[i]));
                Stream stream = File.OpenRead(@"Sprites/Ground/" + Path.GetFileName(groundFiles[i]));
                spritesTexture.Add(Texture2D.FromStream(GraphicsDevice, stream));
                spriteImages.Add(System.Drawing.Image.FromFile(@"Sprites/Ground/" + Path.GetFileName(groundFiles[i])));
                stream.Close();
            }

            for (int i = 0; i < objectFiles.Length; i++)
            {
                spriteFolders.Add("Objects/");
                listBoxSprites.Items.Add(Path.GetFileName(objectFiles[i]));
                Stream stream = File.OpenRead(@"Sprites/Objects/" + Path.GetFileName(objectFiles[i]));
                spritesTexture.Add(Texture2D.FromStream(GraphicsDevice, stream));
                spriteImages.Add(System.Drawing.Image.FromFile(@"Sprites/Objects/" + Path.GetFileName(objectFiles[i])));
                stream.Close();
            }

            for (int i = 0; i < platformFiles.Length; i++)
            {
                spriteFolders.Add("Platforms/");
                listBoxSprites.Items.Add(Path.GetFileName(platformFiles[i]));
                Stream stream = File.OpenRead(@"Sprites/Platforms/" + Path.GetFileName(platformFiles[i]));
                spritesTexture.Add(Texture2D.FromStream(GraphicsDevice, stream));
                spriteImages.Add(System.Drawing.Image.FromFile(@"Sprites/Platforms/" + Path.GetFileName(platformFiles[i])));
                stream.Close();
            }

            backgroundsTexture = new List<Texture2D>();
            backgroundImages = new List<System.Drawing.Image>();

            for (int i = 0; i < backgroundFiles.Length; i++)
            {
                listBoxBackgrounds.Items.Add(Path.GetFileName(backgroundFiles[i]));
                Stream stream = File.OpenRead(@"Backgrounds\" + Path.GetFileName(backgroundFiles[i]));
                backgroundsTexture.Add(Texture2D.FromStream(GraphicsDevice, stream));
                backgroundImages.Add(System.Drawing.Image.FromFile(@"Backgrounds\" + Path.GetFileName(backgroundFiles[i])));
                stream.Close();
            }

        }

        private void listBoxSprites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedSpriteIndex < 0 || SelectedSpriteIndex >= spriteImages.Count)
                return;
            imageBoxSprite.Image = spriteImages[SelectedSpriteIndex];
        }

        private void listBoxBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedBackgroundIndex < 0 || SelectedBackgroundIndex >= backgroundImages.Count)
                return;
            imageBoxBackground.Image = backgroundImages[SelectedBackgroundIndex];
            backgroundTexture = backgroundsTexture[SelectedBackgroundIndex];
        }

        //TODO: Check if new sprite collides with old sprite
        private void display1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = display1;
            selectedItem = GetSelectedGameItem(e.X, e.Y);
            
              //check if we should mark an existing sprite
            if (selectedItem != null)
            {
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


            //Check if we should place a new sprite
            if (!checkMoveSelected.Checked && selectedItem == null && SelectedSpriteIndex >= 0 && checkCreateActor.Checked)
            {
                Vector2 newPos = GetCenterVector(e.X, e.Y);


                level.addItem(new GameItem(spritesTexture[SelectedSpriteIndex], newPos, SelectedSpritePath()));
                txtPosX.Enabled = false;
                txtPosY.Enabled = false;
                txtScaleX.Enabled = false;
                txtScaleY.Enabled = false;
            }
            display1.Invalidate();
        }

        private Vector2 GetCenterVector(int x, int y)
        {
            return new Vector2(x - spritesTexture[SelectedSpriteIndex].Width / 2 + camera.X,
                               y - spritesTexture[SelectedSpriteIndex].Height / 2 + camera.Y);
        }

        private GameItem GetSelectedGameItem(int X, int Y)
        {
            Rectangle rect = new Rectangle(X, Y, 1, 1);

            foreach(GameItem item in level.events)
            {
                Rectangle currentRect = new Rectangle((int)(item.Position.X - camera.Position.X), (int)(item.Position.Y - camera.Position.Y), item.Width, item.Height);
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
                    level.addItem(new GameItem(texture, pos, SelectedSpritePath()));
                    
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

        private string SelectedSpritePath()
        {
            return spriteFolders[SelectedSpriteIndex] + Path.GetFileNameWithoutExtension(listBoxSprites.Items[SelectedSpriteIndex].ToString());
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

        private void display1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!checkCreateActor.Checked && selectedItem != null)
                checkMoveSelected.Checked = !checkMoveSelected.Checked;

        }

        private void display1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedItem != null && checkMoveSelected.Checked)
            {
                selectedItem.Position = GetCenterVector(e.X, e.Y);
                display1.Invalidate();
            }
        }
    }
}
