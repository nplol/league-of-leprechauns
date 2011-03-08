using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using LoL.Content;
using System.IO;

namespace LoL
{
    class LevelManager
    {
        private List<Level> levels;

        public LevelManager(ContentManager content)
        {
            levels = new List<Level>();

            String[] files = Directory.GetFiles(@"Content/Levels");


            for(int i = 0; i < files.Length; i++)
                AddLevel(content.Load<Level>(@"Levels/"+Path.GetFileNameWithoutExtension(files[i])));
        }

        public void AddLevel(Level level)
        {
            levels.Add(level);
        }
    }
}