using System;
using System.Collections.Generic;
using System.Linq;

namespace Correlation.Calculators
{
    /// <summary>
    /// Calculates the correlation coefficient r.
    /// Formula is too complex to represent in this format.
    /// </summary>
    public static class RCalculator
    {
        public static double Calculate(List<double> x, List<double> y)
        {
            // Assumes that the count of x and y is equal
            double sumXY = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sumXY += x[i] * y[i];
            }

            double divisor = x.Count * sumXY - x.Sum() * y.Sum();
            double dividend = Math.Sqrt(
                (x.Count * x.Select(item => item * item).Sum() - x.Sum() * x.Sum()) *
                (y.Count * y.Select(item => item * item).Sum() - y.Sum() * y.Sum())
                );

            return divisor / dividend;
        }
    }
}
