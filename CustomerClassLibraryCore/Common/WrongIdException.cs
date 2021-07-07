using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerClassLibraryCore.Common
{
    class WrongIdException : Exception
    {
        public WrongIdException(string message) : base(message)
        {
        }
    }
}
