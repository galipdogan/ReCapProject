using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message)//İstersekde mesaj döndürebiliriz
        {

        }

        public SuccessResult() : base(true)//Default olarak getirebiliriz.
        {
        }
    }
}
