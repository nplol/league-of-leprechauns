using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoL
{
    public class Level
    {
        private string levelName;
        private string background;
        private string sound;

        public string LevelName
        {
            get { return levelName; }
            set { levelName = value; }
        }

        public string Background
        {
            get { return background; }
            set { background = value; }
        }

        public string Sound
        {
            get { return sound; }
            set { sound = value; }
        }

        public List<LevelEvent> events;
        private Dictionary<int, int> relations;

        public Level(string levelName, string background, string sound)
        {
            this.levelName = levelName;
            this.background = background;
            this.sound = sound;

            events = new List<LevelEvent>();
            relations = new Dictionary<int, int>();
        }

        public void AddEvent(LevelEvent levelEvent)
        {
            events.Add(levelEvent);
        }
    }
}
