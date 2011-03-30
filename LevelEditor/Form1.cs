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
using LoL;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        LoLClassObjects lolClassObjects;

        List<Texture2D> backgroundsTexture;
        List<System.Drawing.Image> backgroundImages;

        ActorSpawnEvent selectedEventType;
        Texture2D selectedRectangle;

        Texture2D backgroundTexture;

        SpriteBatch spriteBatch;

        int levelSizeX = 1000;
        int levelSizeY = 720;

        internal static Camera camera;

        LoL.Level level;

        private bool moveSelected;

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
            level = new Level("Level", "bg", "none");

            vScrollBar1.Maximum = levelSizeY;
            hScrollBar1.Maximum = levelSizeX;

            display1.OnInitialize += new EventHandler(display1_OnInitialize);
            display1.OnDraw += new EventHandler(display1_OnDraw);

            lolClassObjects = new LoLClassObjects();

            txtClassName.DataBindings.Add("Text", lolClassObjects, "ActorType");
        }

        void display1_OnInitialize(object sender, EventArgs e)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dialogSprites.Description = "Select content directory";
            dialogSprites.RootFolder = Environment.SpecialFolder.Desktop;
            dialogSprites.ShowDialog();
            LoadFiles(dialogSprites.SelectedPath);
        }

        void display1_OnDraw(object sender, EventArgs e)
        {
            Logic();
            Render();
        }

        private void Logic()
        {

        }

        private void Draw(ActorSpawnEvent actorSpawnEvent, SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(lolClassObjects.GetTexture(actorSpawnEvent.Texture), actorSpawnEvent.Position - camera.Position, Color.White);
        }

        private void Render()
        {
            spriteBatch.Begin();
            if (backgroundTexture != null)
            {
                Vector2 scale = new Vector2(display1.Size.Width / (float)backgroundTexture.Width, display1.Size.Height / (float)backgroundTexture.Height);
                spriteBatch.Draw(backgroundTexture, Vector2.Zero, null, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
            }

            foreach (ActorSpawnEvent item in level.events)
            {
                Draw(item, spriteBatch, camera);
            }

            if (selectedEventType != null)
            {
                selectedRectangle = CreateRectangle(lolClassObjects.GetTexture(selectedEventType.Texture).Width, lolClassObjects.GetTexture(selectedEventType.Texture).Height);
                spriteBatch.Draw(selectedRectangle, selectedEventType.Position - camera.Position, Color.White);
            }
            spriteBatch.End();
        }

        private void LoadFiles(string path)
        {
            string dir = path + @"/Sprites/Characters";
            string[] characterFiles = Directory.GetFiles(path + @"\Sprites\Characters");
            string[] groundFiles = Directory.GetFiles(path + @"\Sprites\Ground");
            string[] objectFiles = Directory.GetFiles(path + @"\Sprites\Objects");
            string[] platformFiles = Directory.GetFiles(path + @"\Sprites\Platforms");
            string[] backgroundFiles = Directory.GetFiles(path + @"\Sprites\Backgrounds");
            string[] enemyFiles = Directory.GetFiles(path + @"\Sprites\Enemies");
            
            lolClassObjects.AddClassObjects(GraphicsDevice, characterFiles, "Characters/", "Actor");
            lolClassObjects.AddClassObjects(GraphicsDevice, groundFiles, "Ground/", "Actor");
            lolClassObjects.AddClassObjects(GraphicsDevice, objectFiles, "Objects/", "Actor");
            lolClassObjects.AddClassObjects(GraphicsDevice, platformFiles, "Platforms/", "Actor");
            lolClassObjects.AddClassObjects(GraphicsDevice, enemyFiles, "Enemies", "Actor");


            listBoxSprites.DataSource = lolClassObjects.ListBoxSpriteData;


            backgroundsTexture = new List<Texture2D>();
            backgroundImages = new List<System.Drawing.Image>();

            for (int i = 0; i < backgroundFiles.Length; i++)
            {
                listBoxBackgrounds.Items.Add(Path.GetFileName(backgroundFiles[i]));
                Stream stream = File.OpenRead(path + @"/Sprites/Backgrounds/" + Path.GetFileName(backgroundFiles[i]));
                backgroundsTexture.Add(Texture2D.FromStream(GraphicsDevice, stream));
                backgroundImages.Add(System.Drawing.Image.FromFile(path + @"/Sprites/Backgrounds/" + Path.GetFileName(backgroundFiles[i])));
                stream.Close();
            }
        }

        private void listBoxSprites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedSpriteIndex < 0 || SelectedSpriteIndex >= lolClassObjects.DisplayImages.Count)
                return;

            lolClassObjects.SelectedIndex = listBoxSprites.SelectedIndex;
            imageBoxSprite.Image = lolClassObjects.DisplayImages[SelectedSpriteIndex];
            txtClassName.Text = lolClassObjects.ActorType;
        }

        private void listBoxBackground_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedBackgroundIndex < 0 || SelectedBackgroundIndex >= backgroundImages.Count)
                return;
            imageBoxBackground.Image = backgroundImages[SelectedBackgroundIndex];
            backgroundTexture = backgroundsTexture[SelectedBackgroundIndex];
            level.Background = SelectedBackgroundPath();
            display1.Invalidate();
        }

        //TODO: Check if new sprite collides with old sprite
        private void display1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = display1;
            selectedEventType = GetSelectedGameItem(e.X, e.Y);
            
              //check if we should mark an existing sprite
            if (selectedEventType != null)
            {
                txtPosX.Enabled = true;
                txtPosX.Text = selectedEventType.Position.X.ToString();
                txtPosY.Enabled = true;
                txtPosY.Text = selectedEventType.Position.Y.ToString();
            }

            //Check if we should place a new sprite
            if (!moveSelected && selectedEventType == null && SelectedSpriteIndex >= 0 && checkCreateActor.Checked)
            {
                Vector2 newPos = GetCenterVector(lolClassObjects.Textures[SelectedSpriteIndex], e.X, e.Y);

                level.AddEvent(new ActorSpawnEvent(lolClassObjects.ActorType, lolClassObjects.GetFileNameWithoutExtension(SelectedSpriteIndex), newPos));

                txtPosX.Enabled = false;
                txtPosY.Enabled = false;
            }
            display1.Invalidate();
        }

        private Vector2 GetCenterVector(Texture2D item, int x, int y)
        {
            return new Vector2(x - item.Width / 2 + camera.X,
                               y - item.Height / 2 + camera.Y);
        }

        private ActorSpawnEvent GetSelectedGameItem(int X, int Y)
        {
            Rectangle rect = new Rectangle(X, Y, 1, 1);

            foreach(ActorSpawnEvent item in level.events)
            {
                Rectangle currentRect = new Rectangle((int)(item.Position.X - camera.Position.X), (int)(item.Position.Y - camera.Position.Y), lolClassObjects.GetTexture(item.Texture).Width, lolClassObjects.GetTexture(item.Texture).Height);
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

            if (selectedEventType == null)
                return;

            int posX, posY;

            try
            {
                int.TryParse(txtPosX.Text, out posX);
                int.TryParse(txtPosY.Text, out posY);
          
                selectedEventType.Position = new Vector2(posX, posY);

                display1.Invalidate();
            }
            catch (ArgumentException e)
            {
                Console.Write(e);
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
                Console.Write(ex);
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
            if (selectedEventType != null)
            {
                level.events.Remove(selectedEventType);
                selectedEventType = null;
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

            LevelXMLOperations.WriteLevelToXML(level, url);
        }

        //Load from XML
        private void loadLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Xml Files | *.xml";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Cancel)
                return;
            string url = openFileDialog1.FileName;

           
            //TODO: Load level
            this.level = LoL.LevelXMLOperations.ReadLevelFromXML(url);

            display1.Invalidate();

        }

        private string SelectedBackgroundPath()
        {
            return Path.GetFileNameWithoutExtension(listBoxBackgrounds.Items[SelectedBackgroundIndex].ToString());
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void display1_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle rect = new Rectangle(e.X, e.Y, 1, 1);
            if (!checkCreateActor.Checked && selectedEventType != null && GetSelectedGameItem(e.X, e.Y) == selectedEventType)
                moveSelected = !moveSelected;

        }

        private void display1_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedEventType != null && moveSelected)
            {
                selectedEventType.Position = GetCenterVector(lolClassObjects.GetTexture(selectedEventType.Texture), e.X, e.Y);
                display1.Invalidate();
            }
        }

        private void addAbove_Click(object sender, EventArgs e)
        {
            if (selectedEventType != null)
            {
                Vector2 position = new Vector2(selectedEventType.Position.X, selectedEventType.Position.Y - lolClassObjects.Textures[SelectedSpriteIndex].Height);
                selectedEventType = AddSelectedItem(position);
                
                display1.Invalidate();
            }
        }

        private void addRight_Click(object sender, EventArgs e)
        {
            if (selectedEventType != null)
            {
                Vector2 position = new Vector2(selectedEventType.Position.X + lolClassObjects.Textures[SelectedSpriteIndex].Width, selectedEventType.Position.Y);
                selectedEventType = AddSelectedItem(position);

                display1.Invalidate();
            }
        }

        private void addUnder_Click(object sender, EventArgs e)
        {
            if (selectedEventType != null)
            {
                Vector2 position = new Vector2(selectedEventType.Position.X, selectedEventType.Position.Y + lolClassObjects.Textures[SelectedSpriteIndex].Height);
                selectedEventType = AddSelectedItem(position);

                display1.Invalidate();
            }
        }

        private void addLeft_Click(object sender, EventArgs e)
        {
            if (selectedEventType != null)
            {
                Vector2 position = new Vector2(selectedEventType.Position.X - lolClassObjects.Textures[SelectedSpriteIndex].Width, selectedEventType.Position.Y);
                selectedEventType = AddSelectedItem(position);

                display1.Invalidate();
            }
        }

        private ActorSpawnEvent AddSelectedItem(Vector2 position)
        {
            ActorSpawnEvent item = new ActorSpawnEvent(lolClassObjects.ActorType, lolClassObjects.GetFileNameWithoutExtension(SelectedSpriteIndex), position);
            level.AddEvent(item);
            return item;
        }

        private void txtClassName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13)
                return;

            lolClassObjects.ActorType = txtClassName.Text;
        }
    }
}