using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    class LevelManager
    {
        private List<Level> levels;
        private int currentLevel;
        private ContentManager contentManager;
        private ActorFactory actorFactory;

        private Texture2D currentBackground;

        private static LevelManager instance;

        public int CurrentLevel
        {
            get { return currentLevel; }
        }

        public int LastLevel
        {
            get { return levels.Count; }
        }

        public Texture2D CurrentBackground
        {
            get { return currentBackground; }
        }

        

        private LevelManager(ContentManager content)
        {
            currentLevel = 0;
            contentManager = content;;
            actorFactory = new ActorFactory();
            GlobalVariables.ActorFactory = actorFactory;
            levels = new List<Level>();

            //String[] files = Directory.GetFiles(@"Content/Levels");

            //for(int i = 0; i < files.Length; i++)
            //    AddLevel(contentManager.Load<Level>(@"Levels/"+Path.GetFileNameWithoutExtension(files[i])));

            //AddLevel(LevelXMLOperations.ReadLevelFromXML(@"Content/Levels/FileFromEditor.xml"));
            AddLevel(LevelXMLOperations.ReadLevelFromXML(@"Content/Levels/woodlands1-1.xml"));
            AddLevel(LevelXMLOperations.ReadLevelFromXML(@"Content/Levels/highlands1-1.xml"));
        }

        public static LevelManager GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LevelManager(GlobalVariables.ContentManager);
                }
                return instance;
            }
        }

        public void AddLevel(Level level)
        {
            levels.Add(level);
        }

        /*
         * ChangeLevel loads inn every event in the level. 
         * TODO: make it load only nearby events
         */
        /// <summary>
        /// Change the level. Removes all existing actors and creates new actors based on the given level.
        /// </summary>
        /// <param name="levelIndex">Index of the level</param>
        public void ChangeLevel(int levelIndex)
        {
            currentLevel = levelIndex;
            if (currentLevel >= levels.Count)
            {
                LeagueOfLeprechauns.GetInstance.GameWon();
            }
            else
            {
                currentBackground = contentManager.Load<Texture2D>(@"Sprites/Backgrounds/" + levels[levelIndex].Background);
                ActorManager.ClearList();

                foreach (LevelEvent le in levels[currentLevel].events)
                {
                    le.Execute();
                }

                levels[currentLevel].AddRelations();
            }
        }

        /// <summary>
        /// Changes to the next level.
        /// </summary>
        public void ChangeLevel()
        {
            ChangeLevel(CurrentLevel + 1);
        }
    }
}