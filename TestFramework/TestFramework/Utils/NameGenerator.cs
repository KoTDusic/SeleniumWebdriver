using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{
    public class NameGenerator
    {
        public static string GenerateUnicName()
        {
            return "test_" + DateTimeOffset.UtcNow.UtcTicks.ToString();
        }
    }
}
