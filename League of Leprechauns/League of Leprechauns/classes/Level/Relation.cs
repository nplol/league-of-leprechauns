namespace LoL
{
    /// <summary>
    /// Structure used represent a relation between two LevelEvents.
    /// </summary>
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
}