using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace LevelEditor
{
    class LoLClassObjects
    {
        internal ArrayList ListBoxSpriteData;
        internal List<Texture2D> Textures;
        internal List<System.Drawing.Image> DisplayImages;
        internal List<String> DirectoryPaths;
        internal List<String> ClassType;

        internal int SelectedIndex
        {
            get;
            set;
        }

        internal LoLClassObjects()
        {
            ListBoxSpriteData = new ArrayList();
            Textures = new List<Texture2D>();
            DisplayImages = new List<System.Drawing.Image>();
            DirectoryPaths = new List<string>();
            ClassType = new List<string>();
        }

        internal void AddClassObjects(GraphicsDevice graphicsDevice, string[] files, string directory, string classType)
        {
            foreach (string item in files)
            {
                Stream stream = File.OpenRead(item);
                Texture2D texture = Texture2D.FromStream(graphicsDevice, stream);
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                AddClassObject(Path.GetFileNameWithoutExtension(item), texture, image, directory);
                ClassType.Add(GetClassType(Path.GetFileNameWithoutExtension(item)));
                stream.Close();
            }
        }

        private string GetClassType(string textureName)
        {
            switch (textureName)
            {
                case "characterCabbagelips":
                    return "CabbageLips";
                case "characterFluffernutter":
                    return "FlufferNutter";
                case "enemy1":
                case "enemy2":
                    return "HostileNPC";
                case "groundSpriteHighlands":
                case "groundSpriteHighlandsUnder":
                case "groundSpriteMountain":
                case "groundSpriteMountainUnder":
                case "groundSpriteWoods":
                case "groundSpriteWoodsUnder":
                    return "StaticPlatform";
                case "bridgeAnimated":
                    return "CollapsableBridge";
                case "buttonAnimated":
                case "squareBox1":
                    return "StaticPlatform";
                case "tree1":
                case "tree2":
                    return "BackgroundObject";
            }

            return "Actor";
        }

        internal void AddClassObject(string displayText, Texture2D texture, System.Drawing.Image displayImage, string directory)
        {
            ListBoxSpriteData.Add(displayText);
            Textures.Add(texture);
            DisplayImages.Add(displayImage);
            DirectoryPaths.Add(directory);
        }

        internal void SetClassType(int index, string classType)
        {
            if (index < 0 || index >= ClassType.Count)
                throw new IndexOutOfRangeException("SetClassType index out of range");

            ClassType[index] = classType;
        }

        internal string ActorType
        {
            get { return ClassType[SelectedIndex]; }
            set { ClassType[SelectedIndex] = value; }
        }

        internal Texture2D GetTexture(int index)
        {
            if (index < 0 || index >= Textures.Count)
                throw new IndexOutOfRangeException("GetTexture index out of range");
            
            return Textures[index];
        }

        internal Texture2D GetTexture(string textureName)
        {
            int indexOfLastSlash = textureName.LastIndexOf('/');
            string textureFileName = textureName.Substring(indexOfLastSlash + 1);

            return Textures[ListBoxSpriteData.IndexOf(textureFileName)];
        }

        internal System.Drawing.Image GetDisplayImage(int index)
        {
            if (index < 0 || index >= DisplayImages.Count)
                throw new IndexOutOfRangeException("GetDisplayImage index out of range");

            return DisplayImages[index];
        }

        internal string GetFileNameWithoutExtension(int index)
        {
            if (index < 0 || index >= DisplayImages.Count)
                throw new IndexOutOfRangeException("GetFileNameWithoutExtension index out of range");

            return DirectoryPaths[index] + ListBoxSpriteData[index];
        }
    }
}