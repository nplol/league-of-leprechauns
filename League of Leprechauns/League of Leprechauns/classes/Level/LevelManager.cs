﻿using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    /// <summary>
    /// Singelton class. Responsible for loading levels and changing levels.
    /// </summary>
    class LevelManager
    {
        private List<Level> levels;
        private int currentLevel;
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
            actorFactory = new ActorFactory();
            GlobalVariables.ActorFactory = actorFactory;
            levels = new List<Level>();

            AddLevel(LevelXMLOperations.ReadLevelFromXML(@"Content/Levels/woodlands1-1.xml"));
            AddLevel(LevelXMLOperations.ReadLevelFromXML(@"Content/Levels/highlands1-1.xml"));
            AddLevel(LevelXMLOperations.ReadLevelFromXML(@"Content/Levels/lastBoss.xml"));
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
                currentBackground = GlobalVariables.ContentManager.Load<Texture2D>(@"Sprites/Backgrounds/" + levels[levelIndex].Background);
                ActorManager.ClearActorList();

                foreach (LevelEvent levelEvent in levels[currentLevel].events)
                {
                    levelEvent.Execute();
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