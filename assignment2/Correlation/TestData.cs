using System.Collections.Generic;

namespace Correlation
{
    /// <summary>
    /// This model class with statically initialized data describes the estimated proxy size, planned added and
    /// modified size, actual added and modified size, and actual development hours for 10 sample software
    /// programs. See remarks.
    /// </summary>
    public class TestData
    {
        /// <summary>
        /// The estimated LOC size of each program before the program was written.
        /// </summary>
        public static readonly List<int> EstimatedProxySize = new List<int>
        {
            130,
            650,
            99,
            150,
            128,
            302,
            95,
            945,
            368,
            961
        };

        /// <summary>
        /// The planned/estimated LOC which will be added or modified in each program before the program was written.
        /// </summary>
        public static readonly List<int> PlannedAddedModifiedSize = new List<int>
        {
            163,
            765,
            141,
            166,
            137,
            355,
            136,
            1206,
            433,
            1130
        };

        /// <summary>
        /// The actual LOC which were added or modified, counted after the program was written.
        /// </summary>
        public static readonly List<int> ActualAddedModifiedSize = new List<int>
        {
            186,
            699,
            132,
            272,
            291,
            331,
            199,
            1890,
            788,
            1601
        };

        /// <summary>
        /// The actual number of hours it took to complete the program.
        /// </summary>
        public static readonly List<double> ActualDevelopmentHours = new List<double>
        {
            15.0,
            69.9,
            6.5,
            22.4,
            28.4,
            65.9,
            19.4,
            198.7,
            38.8,
            138.2
        };
    }
}
