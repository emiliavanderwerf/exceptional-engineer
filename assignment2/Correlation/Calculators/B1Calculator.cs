using System.Collections.Generic;
using System.Linq;

namespace Correlation.Calculators
{
    /// <summary>
    /// Calculates the linear regression parameter B1, also known as the slope (rise over run).
    /// Formula:
    /// B1 = [sum(xi * yi) - n * xAvg * yAvg] / [sum(xi^2) - n * xAvg^2]
    /// </summary>
    public static class B1Calculator
    {
        public static double Calculate(List<double> x, List<double> y)
        {
            // Assumes that the count of x and y is equal
            double sumXY = 0;
            for (int i = 0; i < x.Count; i++)
            {
                sumXY += x[i] * y[i];
            }

            double divisor = sumXY - x.Count * x.Average() * y.Average();
            double dividend = x.Select(item => item * item).Sum() - x.Count * x.Average() * x.Average();

            return divisor / dividend;
        }
    }
}
