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

        public void Start()
        {
            activated = true;
        }

        public static void Update(GameTime gameTime)
        {

            foreach (Timer timer in ActiveTimers)
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

        public static void RemoveInactiveTimers()
        {
            ActiveTimers.RemoveAll(item => !item.activated);
        }
    }
}
