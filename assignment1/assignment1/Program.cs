using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
    /// <summary>
    /// This class reads in real number data from a file and calculates mean & standard deviation from the data.
    /// </summary>
    public class Calculator
    {
        public LinkedList LinkedList = new LinkedList();

        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("There must be exactly 1 argument: path to the file containing data");
            }

            string path = args[0];
            if (string.IsNullOrEmpty(args[0]))
            {
                throw new ArgumentNullException(nameof(path));
            }

            Calculator calculator = new Calculator();
            calculator.ReadData(path);
        }

        public void ReadData(string path)
        {
            string[] lines = File.ReadAllLines(path);

            if (lines.Length == 0)
            {
                throw new InvalidDataException("No data found");
            }

            foreach (string line in lines)
            {
                if (!decimal.TryParse(line, out decimal number))
                {
                    throw new InvalidDataException($"Failed to parse {line} as a decimal");
                }

                LinkedList.Insert(number);
            }
        }

        public decimal CalculateMean()
        {
            return 0;
        }

        public decimal CalculateStandardDeviation()
        {
            return 0;
        }
    }
}
