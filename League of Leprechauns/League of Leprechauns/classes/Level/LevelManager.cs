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
        private int currentLevel;
        private ContentManager contentManager;
        private ActorManager actorManager;
        private ActorFactory actorFactory;

        public int CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        public ActorManager getActorManager()
        {
            return actorManager;
        }

        public LevelManager(ContentManager content)
        {
            contentManager = content;
            actorManager = new ActorManager();
            actorFactory = new ActorFactory(actorManager);
            levels = new List<Level>();

            String[] files = Directory.GetFiles(@"Content/Levels");


            for(int i = 0; i < files.Length; i++)
                AddLevel(contentManager.Load<Level>(@"Levels/"+Path.GetFileNameWithoutExtension(files[i])));
        }

        public void AddLevel(Level level)
        {
            levels.Add(level);
        }

        /*
         * ChangeLevel loads inn every event in the level. 
         * TODO: make it load only nearby events
         */
        public void ChangeLevel(int levelIndex)
        {
            ActorManager.clearList();
            foreach(LevelEvent e in levels[levelIndex].events)
            {
                actorFactory.createActor(e.ActorType, e.Position, contentManager);
            }   
        }
    }
}