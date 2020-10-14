using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EarnedValue
{
    public class Validator
    {
        public void Validate(List<SchedulePlan> schedulePlans)
        {
            foreach (SchedulePlan plan in schedulePlans)
            {
                if (plan.PlannedTaskHours < 0)
                {
                    throw new InvalidDataException("Planned task hours must be zero or positive");
                }
                if (plan.Week <= 0)
                {
                    throw new InvalidDataException("Week number must be positive");
                }
            }
        }

        public void Validate(List<TaskPlan> taskPlans)
        {
            foreach (TaskPlan plan in taskPlans)
            {
                if (plan.HoursToComplete < 0)
                {
                    throw new InvalidDataException("Hours to complete must be zero or positive");
                }
                if (string.IsNullOrWhiteSpace(plan.Task))
                {
                    throw new InvalidDataException("Task must be a non-null, non-empty string");
                }
            }
        }
    }
}
