using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class _Clock
    {
        int Second;
        int Minute;
        int Hour;
        public int _Second
        {
            get
            {
                return Second;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    Second = value;
                }
            }
        }
        public int _Minute
        {
            get
            {
                return Minute;
            }
            set
            {
                if (value >= 0 && value <= 59)
                {
                    Minute = value;
                }
            }
        }
        public int _Hour
        {
            get
            {
                return Hour;
            }
            set
            {
                if (value >= 0 && value <= 24)
                {
                    Hour = value;
                }
            }
        }
        public int AddSecond()
        {
            Second++;
            if (Second > 59)
            {
                Second = 0;
                AddMinute();
            }
            return Second;
        }

        public int AddMinute()
        {
            Minute++;
            if (Minute > 59)
            {
                Minute = 0;
                AddHour();
            }
            return Minute;
        }

        public int AddHour()
        {
            Hour++;
            if (Hour == 24)
            {
                Hour = 0;
            }
            return Hour;
        }
        public int DecsSecond()
        {
            Second--;
            if (Second < 0)
            {
                Second = 59;
                DecsMinute();
            }
            return Second;
        }

        public int DecsMinute()
        {
            Minute--;
            if (Minute < 0)
            {
                Minute = 59;
                DecsHour();
            }
            return Minute;
        }

        public int DecsHour()
        {
            Hour--;
            if (Hour < 0)
            {
                Hour = 23;
            }
            return Hour;
        }
        public string GetCurrentTime()
        {
            string format = String.Format("{0:D2}:{1:D2}:{2:D2}", _Hour,_Minute,_Second);
            return format;
        }
    }
}
