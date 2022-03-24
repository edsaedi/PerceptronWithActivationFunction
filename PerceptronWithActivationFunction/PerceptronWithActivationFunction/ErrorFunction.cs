using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithActivationFunction
{
    public class ErrorFunction
    {
        Func<double, double, double> function;
        Func<double, double, double> derivative;
        public ErrorFunction(Func<double, double, double> function, Func<double, double, double> derivative) 
        {
            this.function = function;
            this.derivative = derivative;
        }

        public double Function(double output, double desiredOutput) 
        {
            return function.Invoke(output, desiredOutput);
        }
        public double Derivative(double output, double desiredOutput) 
        {
            return derivative.Invoke(output, desiredOutput);
        }

    }
}
