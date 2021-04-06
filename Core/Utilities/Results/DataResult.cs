using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        public T Data { get; }//Datayı T tipinde istiyoruz. 

        //İstersek message gösteririz
        public DataResult(T data,bool success, string message) : base(success, message)
        {
            Data = data;
        }
        //İstersek message göstermeyiz
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
    }

        
    
}
