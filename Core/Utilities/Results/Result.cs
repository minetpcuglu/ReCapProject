using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // **** Getter lar readonly ve yalnızca getterlar ctor da set edilebilir ****///

        //onay + mesaj 
        public Result(bool success, string messsage):this(success)  //kendini tekrar etmemek için this kullanarak diger diğer ctordan success alınarak çalıştırıldı    
        {
            Message = messsage;
           
        }

        public Result(bool success)  //yanlızca onay 
        {
            Success = success; 
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
