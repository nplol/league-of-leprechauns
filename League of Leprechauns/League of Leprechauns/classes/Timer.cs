using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace LoL
{
    public delegate void TimerDelegate();
    class Timer
    {
        public static List<Timer> ActiveTimers;

        private int duration;
        public event TimerDelegate TimeEndedEvent;
        bool activated;

        static Timer()
        {
            ActiveTimers = new List<Timer>();
        }

        public Timer(int duration)
        {
            this.duration = duration;

            ActiveTimers.Add(this);
        }

        /// <summary>
        /// Activates the timer
        /// </summary>
        public void Start()
        {
            activated = true;
        }

        /// <summary>
        /// Updates the current timer, and fires the TimerDelegate event if the time is up. 
        /// </summary>
        /// <param name="gameTime"></param>
        private void Update(GameTime gameTime)
        {
            if (!activated)
                return;

            if (duration < 0)
            {
                activated = false;
                if(TimeEndedEvent != null)
                    TimeEndedEvent();
            }
            else
                duration -= gameTime.ElapsedGameTime.Milliseconds;
        }

        /// <summary>
        /// Updates all the active timers.
        /// </summary>
        /// <param name="gameTime"></param>
        public static void UpdateTimers(GameTime gameTime)
        {
            foreach (Timer timer in ActiveTimers)
                timer.Update(gameTime);
        }

        /// <summary>
        /// Removes all the inactive timers. Should be called after all the timers have been updated.
        /// </summary>
        public static void RemoveInactiveTimers()
        {
            ActiveTimers.RemoveAll(item => !item.activated);
        }
    }
}
