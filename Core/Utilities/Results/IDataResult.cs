using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public interface IDataResult<T>:IResult  //hem mesaj hem işlem sonucu hemde data içersin bunun için ıresult impelemnte al diğerleri IResultdan gelioyo datayı burda tanımlıcaz   <T> Data 
    {
        T Data { get; }
    }
}
