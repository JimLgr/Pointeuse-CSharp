using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTime
{
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
}
