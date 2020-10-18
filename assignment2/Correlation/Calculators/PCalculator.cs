namespace Correlation.Calculators
{
    /// <summary>
    /// Calculates the prediction given an estimate E, the results of <see cref="B0Calculator"/> and
    /// <see cref="B1Calculator"/>.
    /// Formula:
    /// P = B0 + B1 * E
    /// </summary>
    public static class PCalculator
    {
        public static double Calculate(double B0, double B1, double E)
        {
            return B0 + B1 * E;
        }
    }
}
