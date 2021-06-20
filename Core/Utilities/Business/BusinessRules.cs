using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public class BusinessRules
    {
        public static IResult Run(params IResult[] locigs)  //iş motoru yazalım
        {
            foreach (var locig in locigs)
            {
                if (!locig.Success)
                {
                    return locig; //kurallara uyulmayan business iletildi 
                }
            }
            return null;
        }
    }
}
