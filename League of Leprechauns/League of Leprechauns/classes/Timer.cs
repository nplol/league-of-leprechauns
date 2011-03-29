using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LoL
{
    public delegate void TimerDelegate();
    class Timer
    {
        public static List<Timer> ActiveTimers;

        public int durationLeft;
        public event TimerDelegate TimeEndedEvent;
        private bool activated;
        private int totalDuration;

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

        public void Start()
        {
            durationLeft = totalDuration;
            activated = true;
            ActiveTimers.Add(this);
        }

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
