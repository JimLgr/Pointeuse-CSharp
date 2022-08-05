using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibraryTime
{
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
}
