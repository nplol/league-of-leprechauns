using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LevelEditor
{
    class OldLevel
    {
        public string Name;
        public string BackgroundAsset;
        public string SoundThemeAsset;
        public Vector2 LevelSize;

        public List<GameItemOld> events;

        public OldLevel()
        {
            events = new List<GameItemOld>();
            Name = "LevelName";
            BackgroundAsset = "bg";
            SoundThemeAsset = "SoundTheme";
        }

        public void addItem(GameItemOld gameItem)
        {
            events.Add(gameItem);
        }
    }
}
