using System;
using System.Collections.Generic;
using System.Text;

namespace PerceptronWithActivationFunction
{
    public class Perceptron
    {
        public double[] weights;
        public double bias;
        double mutationAmount;
        Random random;
        Func<double, double, double> errorFunc;
        ActivationFunction activationFunction;

        public Perceptron(double[] initialWeightValues, double initialBiasValue, double mutationAmount, Random random, Func<double, double, double> errorFunc, Func<double, double> function, ActivationFunction activationFunction)
        {
            /*initializes the perceptron*/
            weights = initialWeightValues;
            bias = initialBiasValue;
            this.mutationAmount = mutationAmount;
            this.random = random;
            this.errorFunc = errorFunc;
            this.activationFunction = activationFunction;
        }

        public Perceptron(int amountOfInputs, double mutationAmount, Random random, Func<double, double, double> errorFunc, ActivationFunction activationFunction)
        {
            /*Initializes the weights array given the amount of inputs*/
            this.mutationAmount = mutationAmount;
            this.random = random;
            this.errorFunc = errorFunc;
            this.activationFunction = activationFunction;

            weights = new double[amountOfInputs];

        }

        public void Randomize(Random random, double min, double max)
        {
            /*Randomly generates values for every weight including the bias*/

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = random.NextDouble(min, max);
            }

            bias = random.NextDouble(min, max);
        }

        public double Compute(double[] inputs)
        {
            double result = bias;
            /*computes the output with given input*/

            for (int i = 0; i <= inputs.Length - 1; i++)
            {
                result += (weights[i] * inputs[i]);
            }

            return activationFunction.Function(result);
        }

        public double[] Compute(double[][] inputs)
        {
            double[] result = new double[inputs.Length];
            /*computes the output for each row of inputs*/

            for (int i = 0; i <= result.Length - 1; i++)
            {
                result[i] = activationFunction.Function(Compute(inputs[i]));
            }

            return result;
        }

        public double GetError(double[][] inputs, double[] desiredOutputs)
        {
            double error = 0;
            var outputs = Compute(inputs);

            for (int i = 0; i < outputs.Length; i++)
            {
                error += errorFunc.Invoke(desiredOutputs[i], outputs[i]);
            }

            error /= outputs.Length;
            return error;
            /*computes the output using the inputs returns the average error between each output row and each desired output row using errorFunc*/
        }

        // error = sum of (desired = actual)^2/n
        //This is the code for MSE
        //var top = Math.Pow((desiredOutputs[i] - outputs[i]), 2);
        //result += (top / inputs.Length);



        public double TrainWithHillClimbing(double[][] inputs, double[] desiredOutputs, double currentError)
        {
            // Randomly Mutate one weight
            ///Random mutation begins:

            double mutation = random.NextDouble(-mutationAmount, mutationAmount);
            int index = random.Next(-1, weights.Length);
            if (index == -1)
            {
                bias += mutation; //bias weight;
            }
            else
            {
                weights[index] += mutation;
            }

            ///Random mutation ends

            // Calculate the new error of the data(just use "GetError" function explained below)

            double newError = GetError(inputs, desiredOutputs);

            // If the new error is better than the current error, update the current error, else undo the mutation.

            if (newError <= currentError)
            {
                return newError;
            }

            else
            {
                if (index == -1)
                {
                    bias -= mutation;
                }
                else
                {
                    weights[index] -= mutation;
                }

                return currentError;
            }
        }
    }
}
