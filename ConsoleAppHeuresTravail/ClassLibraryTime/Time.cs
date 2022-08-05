using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTime
{
    public class Time : Object , IComparable<Time> , IComparable
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
        public static bool operator<(Time pLeft, Time pRight)
        {
            return pLeft.TotalMinutes < pRight.TotalMinutes;
        }
        public static bool operator>(Time pLeft, Time pRight)
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

        public int CompareTo(Time? other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.TotalMinutes - other.TotalMinutes;
        }

        public int CompareTo(object? obj)
        {
            Time time = obj as Time;
            if (time == null) throw new ArgumentNullException("Error l'objet n'est pas convertible en minutes ");
            return this.TotalMinutes - time.TotalMinutes;
        }
    }
}
