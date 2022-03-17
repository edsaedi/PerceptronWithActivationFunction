using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithActivationFunction
{
    public static class Extensions
    {
        public static double NextDouble(this Random @this, double min, double max)
        {
            return @this.NextDouble() * (max - min) + min;
        }
    }
}
