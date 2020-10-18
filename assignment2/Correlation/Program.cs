using Correlation.Calculators;
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

            double calculatedB1 = B1Calculator.Calculate(TestData.EstimatedProxySize, TestData.ActualAddedModifiedSize);
            double calculatedB0 = B0Calculator.Calculate(TestData.EstimatedProxySize, TestData.ActualAddedModifiedSize, calculatedB1);
        }

        [Fact]
        public void Should_Calculate_Using_EstimatedProxySize_And_ActualDevelopmentTime()
        {
            List<double> estimatedProxySize = TestData.EstimatedProxySize;
            List<double> actualDevelopmentHours = TestData.ActualDevelopmentHours;
            double B0 = -4.039;
            double B1 = 0.1681;
            double r = 0.9333;
            double rSquared = 0.8711;
            double P = 60.858;
        }

        [Fact]
        public void Should_Calculate_Using_PlannedAddedModifiedSize_And_ActualAddedModifiedSize()
        {
            List<double> plannedAddedModifiedSize = TestData.PlannedAddedModifiedSize;
            List<double> actualAddedModifiedSize = TestData.ActualAddedModifiedSize;
            double B0 = -23.92;
            double B1 = 1.43097;
            double r = 0.9631;
            double rSquared = 0.9276;
            double P = 528.4294;       
        }

        [Fact]
        public void Should_Calculate_Using_PlannedAddedModifiedSize_And_ActualDevelopmentTime()
        {
            List<double> plannedAddedModifiedSize = TestData.PlannedAddedModifiedSize;
            List<double> actualDevelopmentHours = TestData.ActualDevelopmentHours;
            double B0 = -4.604;
            double B1 = 0.140164;
            double r = 0.9480;
            double rSquared = 0.8988;
            double P = 49.4994;        
        }
    }
}
