using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T> //sen bir resultsın ve o sınıfın ctorları oldugu için onları tanımla
    {
        public DataResult(T data,bool success,string message):base(success,message)  //base=result
        {
            Data = data;
        }
        public DataResult(T data , bool success):base(success)
        {
            Data = data;  
        }
        public T Data  { get; }
    }
}
