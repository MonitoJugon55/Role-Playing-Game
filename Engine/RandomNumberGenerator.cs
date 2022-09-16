using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class RandomNumberGenerator
    {
        private static Random _randomNumber = new Random();

        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            return _randomNumber.Next(minimumValue, maximumValue + 1);
        }
    }
}
