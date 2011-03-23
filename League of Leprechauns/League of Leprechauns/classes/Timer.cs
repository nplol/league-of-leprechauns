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

        /// <summary>
        /// Creates a new timer
        /// </summary>
        /// <param name="duration">Duration of the timer, in milliseconds.</param>
        public Timer(int duration)
        {
            this.duration = duration;
        }

        public void Start()
        {
            activated = true;
            ActiveTimers.Add(this);
        }

        public static void Update(GameTime gameTime)
        {
            foreach (Timer timer in ActiveTimers.ToArray())
            {

                if (!timer.activated)
                    return;

                if (timer.duration < 0)
                {
                    timer.activated = false;
                    if (timer.TimeEndedEvent != null)
                        timer.TimeEndedEvent();
                }
                else
                    timer.duration -= gameTime.ElapsedGameTime.Milliseconds;

            }
        }

        public void Stop()
        {
            activated = false;
        }

        public static void RemoveInactiveTimers()
        {
            ActiveTimers.RemoveAll(item => !item.activated);
        }
    }
}
