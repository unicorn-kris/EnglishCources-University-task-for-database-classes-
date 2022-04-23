using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCources.Repository.Exceptions
{
    internal class IncorrectIdException: Exception
    {
        public override string Message => "Incorrect id";
    }
}
