using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithActivationFunction
{
    class ActivationFunction
    {
        Func<double, double> function;
        Func<double, double> derivative;
        public ActivationFunction(Func<double, double> function, Func<double, double> derivative)
        {

        }

        public double Function(double input)
        {
            return 0;
        }

        public double Derivative(double input)
        {
            return 0;
        }
    }
}
