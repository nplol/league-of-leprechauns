using System.Collections.Generic;

namespace LoL
{
    struct Relation
    {
        LevelEvent event1;
        LevelEvent event2;

        public Relation(LevelEvent event1, LevelEvent event2)
        {
            this.event1 = event1;
            this.event2 = event2;
        }

        public LevelEvent Event1
        {
            get { return event1; }
        }

        public LevelEvent Event2
        {
            get { return event2; }
        }
    }
    public class Level
    {
        private string levelName;
        private string background;
        private string sound;

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

        public string Sound
        {
            get { return sound; }
            set { sound = value; }
        }

        public List<LevelEvent> events;
   
        public Level(string levelName, string background, string sound)
        {
            this.levelName = levelName;
            this.background = background;
            this.sound = sound;

            events = new List<LevelEvent>();
            relations = new List<Relation>();
        }

        public void AddEvent(LevelEvent levelEvent)
        {
            events.Add(levelEvent);
        }

        public void AddRelation(int actor1, int actor2)
        {
            LevelEvent levelEvent = events.Find(ev => ev.eventID == actor1);
            LevelEvent relationToEvent = events.Find(ev => ev.eventID == actor2);

            
            relations.Add(new Relation(levelEvent, relationToEvent));
        }

        public void AddRelations()
        {
            foreach (Relation relation in relations)
            {
                Actor actor1 = ActorManager.getListOfAllActors().Find(s => s.actorID == relation.Event1.EventID);
                Actor actor2 = ActorManager.getListOfAllActors().Find(s => s.actorID == relation.Event2.EventID);

                if(actor1 is IActivator && actor2 is IReciever)
                    ((IActivator)actor1).ActivatedEvent += new ActivatedEvent(((IReciever)actor2).Recieve);
            }
        }
    }
}
