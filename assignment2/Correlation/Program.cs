using Correlation.Calculators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Correlation
{
    /// <summary>
    /// This program correctly calculates the regression parameters B0 and B1, correlation coefficients r and r^2, and
    /// prediction. For definitions of each of the above, please see the README.md file.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Estimated proxy size of the new program to be written
        /// </summary>
        private const double E = 386.0;

        [Fact]
        public void Should_Calculate_Using_EstimatedProxySize_And_ActualAddedModifiedSize()
        {
            double B0 = -22.55;
            double B1 = 1.7279;
            double r = 0.9545;
            double rSquared = 0.9111;
            double P = 644.429;

            CalculateAndVerify(B0, B1, r, rSquared, P, E, TestData.EstimatedProxySize, TestData.ActualAddedModifiedSize);
        }

        [Fact]
        public void Should_Calculate_Using_EstimatedProxySize_And_ActualDevelopmentTime()
        {
            double B0 = -4.039;
            double B1 = 0.1681;
            double r = 0.9333;
            double rSquared = 0.8711;
            double P = 60.858;

            CalculateAndVerify(B0, B1, r, rSquared, P, E, TestData.EstimatedProxySize, TestData.ActualDevelopmentHours);
        }

        [Fact]
        public void Should_Calculate_Using_PlannedAddedModifiedSize_And_ActualAddedModifiedSize()
        {
            double B0 = -23.92;
            double B1 = 1.43097;
            double r = 0.9631;
            double rSquared = 0.9276;
            double P = 528.4294;

            CalculateAndVerify(B0, B1, r, rSquared, P, E, TestData.PlannedAddedModifiedSize, TestData.ActualAddedModifiedSize);
        }

        [Fact]
        public void Should_Calculate_Using_PlannedAddedModifiedSize_And_ActualDevelopmentTime()
        {
            double B0 = -4.604;
            double B1 = 0.140164;
            double r = 0.9480;
            double rSquared = 0.8988;
            double P = 49.4994;

            CalculateAndVerify(B0, B1, r, rSquared, P, E, TestData.PlannedAddedModifiedSize, TestData.ActualDevelopmentHours);
        }

        /// <summary>
        /// Calculates each of B0, B1, r, r^2, and P given input E, x, and y. Compares the calculated output with the
        /// expected output.
        /// </summary>
        /// <param name="B0">expected B0</param>
        /// <param name="B1">expected B1</param>
        /// <param name="r">expected r</param>
        /// <param name="rSquared">expected r^2</param>
        /// <param name="P">expected P</param>
        /// <param name="E">estimated proxy size</param>
        /// <param name="x">list of x axis <c>double</c> data</param>
        /// <param name="y">list of y axis <c>double</c> data</param>
        private void CalculateAndVerify(double B0, double B1, double r, double rSquared, double P, double E,
            List<double> x, List<double> y)
        {
            double calculatedB1 = B1Calculator.Calculate(x, y);
            double calculatedB0 = B0Calculator.Calculate(x, y, calculatedB1);
            double calculatedR = RCalculator.Calculate(x, y);
            double calculatedRSquared = RSquaredCalculator.Calculate(calculatedR);
            double calculatedP = PCalculator.Calculate(calculatedB0, calculatedB1, E);

            Assert.True(Math.Round(calculatedB0, 2).Equals(Math.Round(B0, 2)));
            Assert.True(Math.Round(calculatedB1, 2).Equals(Math.Round(B1, 2)));
            Assert.True(Math.Round(calculatedR, 2).Equals(Math.Round(r, 2)));
            Assert.True(Math.Round(calculatedRSquared, 2).Equals(Math.Round(rSquared, 2)));
            Assert.True(Math.Round(calculatedP, 2).Equals(Math.Round(P, 2)));
        }
    }
}
