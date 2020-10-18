using System;
using System.Collections.Generic;
using System.Text;

namespace Correlation
{
    public class TestData
    {
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
