namespace Correlation.Calculators
{
    /// <summary>
    /// Calculates the correlation coefficient r^2.
    /// </summary>
    public static class RSquaredCalculator
    {
        public static double Calculate(double r)
        {
            return r * r;
        }
    }
}
