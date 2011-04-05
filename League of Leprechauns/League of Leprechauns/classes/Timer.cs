using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LoL
{
    public delegate void TimerDelegate();

    class Timer
    {
        private static List<Timer> ActiveTimers;
        private int durationLeft;
        private bool activated;
        private int totalDuration;

        public event TimerDelegate TimeEndedEvent;

        public bool Activated
        {
            get { return activated; }
        }

        static Timer()
        {
            ActiveTimers = new List<Timer>();
        }

        /// <summary>
        /// Creates a new timer
        /// </summary>
        /// <param name="duration">Duration of the timer, in milliseconds.</param>
        public Timer(int duration)
        {
            this.totalDuration = duration;
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            durationLeft = totalDuration;
            activated = true;
            ActiveTimers.Add(this);
        }

        /// <summary>
        /// Updates all the timers
        /// </summary>
        /// <param name="gameTime"></param>
        public static void Update(GameTime gameTime)
        {
            foreach (Timer timer in ActiveTimers.ToArray())
            {

                if (!timer.activated)
                    return;

                if (timer.durationLeft < 0)
                {
                    timer.activated = false;
                    timer.durationLeft = 0;
                    if (timer.TimeEndedEvent != null)
                        timer.TimeEndedEvent();

                    ActiveTimers.Remove(timer);
                }
                else
                    timer.durationLeft -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        /// <summary>
        /// Stops the timer
        /// </summary>
        public void Stop()
        {
            activated = false;
        }

        /// <summary>
        /// Removes all the timers.
        /// </summary>
        public static void RemoveAllTimers()
        {
            ActiveTimers.RemoveAll(item => item != null);
        }

        /// <summary>
        /// Removes all the inactive timers.
        /// </summary>
        public static void RemoveInactiveTimers()
        {
            ActiveTimers.RemoveAll(item => !item.activated);
        }
    }
}
