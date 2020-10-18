using System.Collections.Generic;
using System.Linq;

namespace Correlation.Calculators
{
    /// <summary>
    /// Calculates the linear regression parameter B0, also known as the y-intercept.
    /// Formula:
    /// B0 = yAverage - B1 * xAverage
    /// </summary>
    public static class B0Calculator
    {
        public static double Calculate(List<double> x, List<double> y, double B1)
        {
            return y.Average() - B1 * x.Average();
        }
    }
}
