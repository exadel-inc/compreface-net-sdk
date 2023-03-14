using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;

namespace Exadel.Compreface.UnitTests.Helpers
{
    public static class GetRandomStringHelper
    {
        public static string GetRandomString()
        {
            return new Filler<string>().Create();
        }
    }
}
