using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LevelEditor
{
    class Level
    {
        public string Name;
        public string BackgroundAsset;
        public string SoundThemeAsset;
        public Vector2 LevelSize;

        public List<GameItem> events;

        public Level()
        {
            events = new List<GameItem>();
            Name = "LevelName";
            BackgroundAsset = "Background";
            SoundThemeAsset = "SoundTheme";
        }

        public void addItem(GameItem gameItem)
        {
            events.Add(gameItem);
        }
    }
}
