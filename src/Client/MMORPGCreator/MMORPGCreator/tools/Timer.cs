using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MmorpgEngine
{
    class Timer
    {
        private int _max_time;
        private int _time;
        bool _actif;
        bool loop;
        public Timer(int max_time, bool loop)
        {
            this.max_time = max_time;
            this.time = max_time;
            this.loop = loop;
        }

        public bool Istime()
        {
            if (time >= max_time)
            {
                this.reset();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void plus()
        {
            if (actif == true)
            {
                time++;
            }
        }

        public void reset()
        {
            time = 0;
        }

        public bool actif
        {
            get
            {
                return _actif;
            }

            set
            {
                _actif = value;
            }
        }
        public int time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
            }
        }
        public int max_time
        {
            get
            {
                return _max_time;
            }

            set
            {
                _max_time = value;
            }
        }
    }
}
