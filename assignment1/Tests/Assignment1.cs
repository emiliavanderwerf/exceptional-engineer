using System;
using Xunit;
using Assignment1;
using System.IO;

namespace Tests
{
    public class Assignment1
    {
        Calculator calculator = new Calculator();
        string myPath = "C:\\Users\\Emilia Vanderwerf\\source\\repos\\exceptional-engineer\\assignment1\\Tests";

        #region Success Cases: Mean Calculations
        [Fact]
        public void CalculatingMean_EstimatedProxySize()
        {
            calculator.ReadData($"{myPath}/EstimatedProxySize.txt");
            Assert.True(Equals(Math.Round(calculator.CalculateMean(), 1), 550.6));
        }

        [Fact]
        public void CalculatingMean_DevelopmentHours()
        {
            calculator.ReadData($"{myPath}/DevelopmentHours.txt");
            Assert.True(Equals(Math.Round(calculator.CalculateMean(), 2), 60.32));
        }

        [Fact]
        public void CalculatingMean_MaxValueMinValue()
        {
            calculator.ReadData($"{myPath}/MaxValueMinValue.txt");
            Assert.True(Equals(Math.Round(calculator.CalculateMean()), (double)0));
        }
        #endregion

        #region Success Cases: Standard Deviation Calculations
        [Fact]
        public void CalculatingStandardDeviation_EstimatedProxySize()
        {
            calculator.ReadData($"{myPath}/EstimatedProxySize.txt");
            Assert.True(Equals(Math.Round(calculator.CalculateStandardDeviation(), 2), 572.03));
        }

        [Fact]
        public void CalculatingStandardDeviation_DevelopmentHours()
        {
            calculator.ReadData($"{myPath}/DevelopmentHours.txt");
            Assert.True(Equals(Math.Round(calculator.CalculateStandardDeviation(), 2), 62.26));
        }
        #endregion

        #region Error Cases: Standard Deviation Calculations
        [Fact]
        public void CalculatingStandardDeviation_OneItemOnly_ThrowsInvalidOperationException()
        {
            calculator.ReadData($"{myPath}/OneValueOnly.txt");
            Assert.Throws<InvalidOperationException>(() => calculator.CalculateStandardDeviation());
        }

        [Fact]
        public void CalculatingStandardDeviation_MaxValuePlusZero_ThrowsOverflowException()
        {
            calculator.ReadData($"{myPath}/MaxValuePlusZero.txt");
            Assert.Throws<OverflowException>(() => calculator.CalculateStandardDeviation());
        }
        #endregion

        #region Error Cases: Mean Calculations
        [Fact]
        public void CalculatingMean_MaxValuePlusMaxValue_ThrowsOverflowException()
        {
            calculator.ReadData($"{myPath}/MaxValuePlusMaxValue.txt");
            Assert.Throws<OverflowException>(() => calculator.CalculateMean());
        }
        #endregion

        #region Success Cases: Linked List Implementation
        [Fact]
        public void InsertingToLinkedList_ThreeItems()
        {
            calculator.ReadData($"{myPath}/LinkedListThreeItems.txt");
            Node head = calculator.LinkedList.GetLinkedList();

            Assert.True(Equals(head.Value, 3));
            Assert.True(Equals(head.Next.Value, 2));
            Assert.True(Equals(head.Next.Next.Value, 1));
        }
        #endregion

        #region Failure Cases: File Lookup
        [Fact]
        public void CallingCalculator_InvalidFilePath_ThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => calculator.ReadData($"{myPath}/InvalidFilePath.txt"));
        }
        #endregion

        #region Failure Cases: Data Parsing
        [Fact]
        public void CallingCalculator_NoDataInFile_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => calculator.ReadData($"{myPath}/EmptyFile.txt"));
        }

        [Fact]
        public void CallingCalculator_InvalidDataInFile_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => calculator.ReadData($"{myPath}/InvalidData.txt"));
        }

        [Fact]
        public void CallingCalculator_DataTooLarge_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => calculator.ReadData($"{myPath}/DataTooLarge.txt"));
        }
        #endregion
    }
}
