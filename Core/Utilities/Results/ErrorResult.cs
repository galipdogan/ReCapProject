using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  public  class ErrorResult:Result
    {
        public ErrorResult(string message) : base(true, message)//İstersekde mesaj döndürebiliriz
        {

        }

        public ErrorResult() : base(true)//Default olarak getirebiliriz.
        {
        }
    }
}
