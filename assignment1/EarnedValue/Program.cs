using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace EarnedValue
{
    public class Program
    {
        private Validator Validator = new Validator();

        [Theory]
        [InlineData("SchedulePlan_ExampleData.json", "TaskPlan_ExampleData.json")]
        [InlineData("SchedulePlan_100Tasks.json", "TaskPlan_100Tasks.json")]
        public void Should_Calculate_Earned_Value_Plan(string schedulePlanPath, string taskPlanPath)
        {
            List<SchedulePlan> schedulePlans = ReadSchedulePlan(schedulePlanPath);
            List<TaskPlan> taskPlans = ReadTaskPlan(taskPlanPath);

            Validator.Validate(schedulePlans);
            Validator.Validate(taskPlans);


        }

        [Theory]
        [InlineData("SchedulePlan_IllegalData.json", "TaskPlan_IllegalData.json")]
        public void Should_Throw_Exception_For_Illegal_Data(string schedulePlanPath, string taskPlanPath)
        {
            List<SchedulePlan> schedulePlans = ReadSchedulePlan(schedulePlanPath);
            List<TaskPlan> taskPlans = ReadTaskPlan(taskPlanPath);

            Assert.Throws<InvalidDataException>(() => Validator.Validate(schedulePlans));
            Assert.Throws<InvalidDataException>(() => Validator.Validate(taskPlans));
        }

        private List<SchedulePlan> ReadSchedulePlan(string schedulePlanPath)
        {
            List<SchedulePlan> schedulePlans = new List<SchedulePlan>();
            try
            {
                using (StreamReader r = new StreamReader(ResolvePath(schedulePlanPath)))
                {
                    string schedulePlan = r.ReadToEnd();
                    schedulePlans = JsonConvert.DeserializeObject<List<SchedulePlan>>(schedulePlan);
                }
            }
            catch (Exception e)
            {
                throw new InvalidDataException($"Malformatted Schedule Plan: {schedulePlanPath}", e);
            }

            return schedulePlans;
        }

        private List<TaskPlan> ReadTaskPlan(string taskPlanPath)
        {
            List<TaskPlan> taskPlans = new List<TaskPlan>();
            try
            {
                using (StreamReader r = new StreamReader(ResolvePath(taskPlanPath)))
                {
                    string taskPlan = r.ReadToEnd();
                    taskPlans = JsonConvert.DeserializeObject<List<TaskPlan>>(taskPlan);
                }
            }
            catch (Exception e)
            {
                throw new InvalidDataException($"Malformatted Task Plan: {taskPlanPath}", e);
            }

            return taskPlans;
        }

        private string ResolvePath(string fileName)
        {
            string dllPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).Location);
            string slnPath = Path.Combine(dllPath, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..");
            return Path.GetFullPath(Path.Combine(slnPath, fileName));
        }
    }
}
