using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        //işlem sonucu ve kullanıcı bilgilendirme yönlendirme mesajları
        bool Success { get; }   //set etmeye gerek yok 
        string Message { get; }

    }
}
