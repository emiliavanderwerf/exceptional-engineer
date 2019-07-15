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
            Assert.True(calculator.CalculateMean() == (decimal)550.6);
        }

        [Fact]
        public void CalculatingMean_DevelopmentHours()
        {
            calculator.ReadData($"{myPath}/DevelopmentHours.txt");
            Assert.True(calculator.CalculateMean() == (decimal)60.32);
        }

        [Fact]
        public void CalculatingMean_MaxValueMinValue()
        {
            calculator.ReadData($"{myPath}/Mean_MaxValueMinValue.txt");
            Assert.True(calculator.CalculateMean() == 0);
        }
        #endregion

        #region Error Cases: Mean Calculations
        [Fact]
        public void CalculatingMean_MaxValuePlusOne_ThrowsOverflowException()
        {
            calculator.ReadData($"{myPath}/Mean_MaxValuePlusOne.txt");
            Assert.Throws<OverflowException>(() => calculator.CalculateMean());
        }
        #endregion

        #region Success Cases: Linked List Implementation
        [Fact]
        public void InsertingToLinkedList_ThreeItems()
        {
            calculator.ReadData($"{myPath}/LinkedListThreeItems.txt");
            Node head = calculator.LinkedList.GetLinkedList();

            Assert.True(head.Value == 3);
            Assert.True(head.Next.Value == 2);
            Assert.True(head.Next.Next.Value == 1);
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
