using System;
using System.Collections.Generic;
using System.Text;

namespace EarnedValue
{
    public class TaskPlanOutput : TaskPlan
    {
        public double CumulativeTaskHours { get; set; }

        public double PlannedValue { get; set; }

        public double CumulativePlannedValue { get; set; }

        public uint WeekOfPlannedCompletion { get; set; }
    }
}
