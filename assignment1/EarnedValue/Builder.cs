using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EarnedValue
{
    public class Builder
    {
        public SchedulePlanOutput Build(List<SchedulePlan> schedulePlans, int index)
        {
            SchedulePlan schedulePlan = schedulePlans[index];

            SchedulePlanOutput output = new SchedulePlanOutput();

            // Assign duplicated data from the original SchedulePlan object
            output.Week = schedulePlan.Week;
            output.Begin = schedulePlan.Begin;
            output.PlannedTaskHours = schedulePlan.PlannedTaskHours;

            // Cumulative planned task hours is the total number of hours that will be spent up to this week
            output.CumulativePlannedTaskHours = schedulePlans
                .Take(index + 1)
                .Select(s => s.PlannedTaskHours)
                .Sum();

            // Cumulate planned value is the total percentage value that should be earned up to this week
            output.CumulativePlannedValue = Math.Round(output.CumulativePlannedTaskHours /
                schedulePlans
                .Select(s => s.PlannedTaskHours)
                .Sum(), 2);

            return output;
        }

        public TaskPlanOutput Build(List<TaskPlan> taskPlans, int index, List<SchedulePlan> schedulePlans)
        {
            TaskPlan taskPlan = taskPlans[index];

            TaskPlanOutput output = new TaskPlanOutput();
            
            // Assign duplicated data from the original TaskPlan object
            output.Task = taskPlan.Task;
            output.HoursToComplete = taskPlan.HoursToComplete;

            // Cumulative task hours is the total number of hours spent on this project up through completing this task
            output.CumulativeTaskHours = taskPlans
                .Take(index + 1)
                .Select(t => t.HoursToComplete)
                .Sum();

            // Planned value is the percentage of time this task will take out of all time allocated for this project
            output.PlannedValue = Math.Round(taskPlan.HoursToComplete /
                taskPlans
                .Select(t => t.HoursToComplete)
                .Sum(), 2);

            // Cumulative planned value is the value earned from the start of this project to the end of the current
            // task
            output.CumulativePlannedValue = Math.Round(output.CumulativeTaskHours /
                taskPlans
                .Select(t => t.HoursToComplete)
                .Sum(), 2);

            // The week in which this task is planned to be completed
            double sum = 0; // Sum of scheduled hours up to the current week
            output.WeekOfPlannedCompletion = schedulePlans
                .TakeWhile(s => {
                    if (sum >= output.CumulativeTaskHours)
                    {
                        // Stop taking SchedulePlan objects if we have exceeded the hours necessary to complete this
                        // task
                        return false;
                    }
                    else
                    {
                        // We need more planned hours to completed this task. Keep iterating over the weeks.
                        sum += s.PlannedTaskHours;
                        return true;
                    }
                })
                // TODO: Will throw an exception if the first SchedulePlan's planned task hours is zero
                .Last().Week;

            return output;
        }
    }
}
