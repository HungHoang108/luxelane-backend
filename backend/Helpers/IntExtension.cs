using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luxelane.Helpers
{
    public static class IntExtension
    {
        public static bool IsOdd(this int num) => (num & 1) > 0;
        public static bool IsEven(this int num) => (num & 1) == 0;
    }
}