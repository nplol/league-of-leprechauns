﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace LoL
{
    /// <summary>
    /// Class containing level information.
    /// </summary>
    public class Level
    {
        private string levelName;
        private string background;
        private string backgroundSong;
        private bool finished;

        /// <summary>
        /// A list of all the relations between events in the level.
        /// </summary>
        List<Relation> relations;

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

        public string BackgroundSong
        {
            get { return backgroundSong; }
            set { backgroundSong = value; }
        }

        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }

        public List<LevelEvent> events;
   
        public Level(string levelName, string background, string song)
        {
            this.levelName = levelName;
            this.background = background;
            this.backgroundSong = song;
            this.finished = false;

            events = new List<LevelEvent>();
            relations = new List<Relation>();
        }

        public void AddEvent(LevelEvent levelEvent)
        {
            events.Add(levelEvent);
        }

        /// <summary>
        /// Adds a relation between two actors to the relation list
        /// </summary>
        /// <param name="actor1">The id of actor 1</param>
        /// <param name="actor2">The id of actor 2</param>
        public void AddRelation(int actor1, int actor2)
        {
            LevelEvent levelEvent = events.Find(ev => ev.eventID == actor1);
            LevelEvent relationToEvent = events.Find(ev => ev.eventID == actor2);
            
            relations.Add(new Relation(levelEvent, relationToEvent));
        }

        /// <summary>
        /// Adds all relations in the relation list to actors.
        /// </summary>
        public void AddRelations()
        {
            foreach (Relation relation in relations)
            {
                Actor actor1 = ActorManager.GetListOfAllActors().Find(s => s.actorID == relation.Event1.EventID);
                Actor actor2 = ActorManager.GetListOfAllActors().Find(s => s.actorID == relation.Event2.EventID);

                if(actor1 is IActivator && actor2 is IReciever)
                    ((IActivator)actor1).ActivatedEvent += new ActivatedEvent(((IReciever)actor2).Recieve);
            }
        }
    }
}
