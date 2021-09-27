using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo4EmpDisplay.Services
{
    //34.  Reference Interface
    public class FormatNumber : IFormatNumber
    {
        //35.  Create a method
        public string GetFormattedNumber(int number)
        {
            //36.  Return commas between numbers
            return string.Format("{0:n0}", number);
            //n0 is use to display comma's in between numbers


            //37.  Go to startup
        }
    }
}
