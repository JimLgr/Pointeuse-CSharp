using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTime
{
    public class ClassTimeAndCo
    {
        public class Time
        {
            private const int MINUTES_IN_HOUR = 60;
            private int m_Hours;
            public int Hours { get => m_Hours; }

            private int m_Minutes;
            public int Minutes { get => m_Minutes; }


            public Time()
            {

            }
            public Time(int pHours, int pMinutes)
            {

                m_Hours = pHours;
                m_Minutes = pMinutes;
            }


            //public int GetMinutes() => m_Minutes;


            public int TotalMinutes { get => (m_Hours * MINUTES_IN_HOUR) + m_Minutes; }

            #region Surcharges d'opérateur de conversion
            public static explicit operator Time(int pMinutes)
            {

                Time myTime = new Time();
                myTime.m_Hours = pMinutes / MINUTES_IN_HOUR;
                myTime.m_Minutes = pMinutes % MINUTES_IN_HOUR;
                return myTime;
            }

            #endregion

            #region Surcharges d'opérateur de comparaison
            public static bool operator <(Time pLeft, Time pRight)
            {
                return pLeft.TotalMinutes < pRight.TotalMinutes;
            }
            public static bool operator >(Time pLeft, Time pRight)
            {
                return pLeft.TotalMinutes > pRight.TotalMinutes;
            }
            //public static int operator-(Time pLeft, Time pRight)
            //{
            //    pLeft.GetTotalMinutes() - pRight.GetTotalMinutes();
            //}
            #endregion

            #region Surcharges d'opérateur arithmetiques
            public static Time operator -(Time pLeft, Time pRight)
            {
                if (pLeft < pRight)
                    throw new ArgumentException("Le Time ne peux finir pas finir en négatif");

                return (Time)(pLeft.TotalMinutes - pRight.TotalMinutes);
            }
            public static Time operator +(Time pLeft, Time pRight)
            {
                return (Time)(pLeft.TotalMinutes + pRight.TotalMinutes);
            }

            #endregion


            public override string ToString()
            {
                string str = $"{Hours:00}:{Minutes:00}";
                return str;
            }
        }
        public class StartEnd
        {
            private readonly Time m_Start;
            private readonly Time _End;

            public Time Start { get => m_Start; }
            public Time End { get => _End; }


            public StartEnd(Time pStart, Time pEnd)
            {
                if (pEnd < pStart)
                {
                    throw new ArgumentException("L'heure de fin doit être supérieur à l'heure de début");
                }
                m_Start = pStart;
                _End = pEnd;

            }

            public Time Duration
            {
                get
                {
                    Time duration = _End - m_Start;
                    return duration;
                }

            }
        }
        public class TimeHelper
        {
            public static Time ExtractTime(string pTexte)
            {
                string[] HourEndSplit = pTexte.Split(":");
                bool EndHPArsed = int.TryParse(HourEndSplit[0], out int hours);
                bool EndMPArsed = int.TryParse(HourEndSplit[1], out int minutes);
                Time mytime = new(hours, minutes);
                return mytime;
            }

        }
        public enum Jour
        {
            lundi = 1,
            mardi,
            mercredi,
            jeudi,
            vendredi,
            samedi,
            dimanche

        }
    }
}
