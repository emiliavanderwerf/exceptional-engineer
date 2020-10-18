using Correlation.Calculators;
using System;
using System.Collections.Generic;
using Xunit;

namespace Correlation
{
    public class Program
    {
        [Fact]
        public void Should_Calculate_Using_EstimatedProxySize_And_ActualAddedModifiedSize()
        {
            double B0 = -22.55;
            double B1 = 1.7279;
            double r = 0.9545;
            double rSquared = 0.9111;
            double P = 644.429;

            CalculateAndVerify(B0, B1, r, rSquared, P, TestData.EstimatedProxySize, TestData.ActualAddedModifiedSize);
        }

        [Fact]
        public void Should_Calculate_Using_EstimatedProxySize_And_ActualDevelopmentTime()
        {
            double B0 = -4.039;
            double B1 = 0.1681;
            double r = 0.9333;
            double rSquared = 0.8711;
            double P = 60.858;

            CalculateAndVerify(B0, B1, r, rSquared, P, TestData.EstimatedProxySize, TestData.ActualDevelopmentHours);
        }

        [Fact]
        public void Should_Calculate_Using_PlannedAddedModifiedSize_And_ActualAddedModifiedSize()
        {
            double B0 = -23.92;
            double B1 = 1.43097;
            double r = 0.9631;
            double rSquared = 0.9276;
            double P = 528.4294;

            CalculateAndVerify(B0, B1, r, rSquared, P, TestData.PlannedAddedModifiedSize, TestData.ActualAddedModifiedSize);
        }

        [Fact]
        public void Should_Calculate_Using_PlannedAddedModifiedSize_And_ActualDevelopmentTime()
        {
            double B0 = -4.604;
            double B1 = 0.140164;
            double r = 0.9480;
            double rSquared = 0.8988;
            double P = 49.4994;

            CalculateAndVerify(B0, B1, r, rSquared, P, TestData.PlannedAddedModifiedSize, TestData.ActualDevelopmentHours);
        }

        private void CalculateAndVerify(double B0, double B1, double r, double rSquared, double P, List<double> x, List<double> y)
        {
            double calculatedB1 = B1Calculator.Calculate(x, y);
            double calculatedB0 = B0Calculator.Calculate(x, y, calculatedB1);
            double calculatedR = RCalculator.Calculate(x, y);

            Assert.True(Math.Round(calculatedB0, 2).Equals(Math.Round(B0, 2)));
            Assert.True(Math.Round(calculatedB1, 2).Equals(Math.Round(B1, 2)));
            Assert.True(Math.Round(calculatedR, 2).Equals(Math.Round(r, 2)));
        }
    }
}
