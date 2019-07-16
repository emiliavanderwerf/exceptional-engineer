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
                if (!double.TryParse(line, out double number))
                {
                    throw new InvalidDataException($"Failed to parse {line} as a double");
                }

                if (double.IsInfinity(number))
                {
                    throw new OverflowException($"Input is too large");
                }

                LinkedList.Insert(number);
            }
        }

        public double CalculateMean()
        {
            double total = 0;
            int count = 0;

            Node head = LinkedList.GetLinkedList();
            Node current = head;
            while (current != null)
            {
                total += current.Value;
                count++;
                current = current.Next;
            }

            if (double.IsInfinity(total))
            {
                throw new OverflowException("Mean cannot be calculated: too large");
            }

            return total / count;
        }

        public double CalculateStandardDeviation()
        {
            double standardDeviation = 0;
            double mean = this.CalculateMean();
            double numerator = 0;
            int count = 0;

            Node head = LinkedList.GetLinkedList();
            Node current = head;
            while (current != null)
            {
                numerator += Math.Pow(current.Value - mean, 2);
                current = current.Next;
                count++;
            }

            if (double.IsInfinity(numerator))
            {
                throw new OverflowException("Standard deviation cannot be calculated: too large");
            }

            if (count <= 1)
            {
                throw new InvalidOperationException("Cannot calculate standard deviation: only 1 value supplied");
            }

            double denominator = count - 1;
            standardDeviation = Math.Sqrt(numerator / denominator);
            return standardDeviation;
        }
    }
}
