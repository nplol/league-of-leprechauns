using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace LoL.Content
{
    /* Asset file which describes the elements of a level
     * Can be loaded from XML from the content pipeline. (Content.Load<Level>(@"Levels/LevelName");
     */
    public class Level
    {
        private string name;
        private string backgroundAsset;
        private string soundThemeAsset;

        public List<LevelEvent> events;

        public Level()
        {
            events = new List<LevelEvent>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string BackgroundAsset
        {
            get { return backgroundAsset; }
            set { backgroundAsset = value; }
        }

        public string SoundThemeAsset
        {
            get { return soundThemeAsset; }
            set { soundThemeAsset = value; }
        }

        public void addEvent(LevelEvent levelEvent)
        {
            events.Add(levelEvent);
        }
    }
}
