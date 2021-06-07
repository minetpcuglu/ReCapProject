using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result  //this successresult base result
    {
        public SuccessResult(string message) : base(true, message)
        {

        }
        public SuccessResult():base(true)
        {

        }
       
    }
}
