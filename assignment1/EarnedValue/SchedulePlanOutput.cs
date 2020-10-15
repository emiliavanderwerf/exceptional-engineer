using System;
using System.Collections.Generic;
using System.Text;

namespace EarnedValue
{
    public class SchedulePlanOutput : SchedulePlan
    {
        public double CumulativePlannedTaskHours { get; set; }

        public double CumulativePlannedValue { get; set; }
    }
}
