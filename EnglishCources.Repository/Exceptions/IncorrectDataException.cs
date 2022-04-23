using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCources.Repository.Exceptions
{
    internal class IncorrectDataException: Exception
    {
        public override string Message => "Incorrect data for saving in database";
    }
}
