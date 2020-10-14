using System;
using Xunit;

namespace EarnedValue
{
    public class Program
    {
        [Theory]
        [InlineData("SchedulePlan_ExampleData.json", "TaskPlan_ExampleData.json")]
        [InlineData("SchedulePlan_100Tasks.json", "TaskPlan_100Tasks.json")]
        public void Should_Calculate_Earned_Value_Plan(string schedulePlanPath, string taskPlanPath)
        {

        }

        [Theory]
        [InlineData("SchedulePlan_IllegalData.json", "TaskPlan_IllegalData.json")]
        public void Should_Throw_Exception_For_Illegal_Data(string schedulePlanPath, string taskPlanPath)
        {

        }
    }
}
