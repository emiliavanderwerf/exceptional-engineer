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
        #region Private Members
        private Validator Validator = new Validator();
        private Builder Builder = new Builder();
        #endregion

        #region Unit Test Methods
        [Theory]
        [InlineData("SchedulePlan_ExampleData.json", "TaskPlan_ExampleData.json", "SchedulePlan_ExampleData_Output.json", "TaskPlan_ExampleData_Output.json")]
        public void Should_Calculate_Earned_Value_Plan_And_Validate_Data(
            string schedulePlanPath,
            string taskPlanPath,
            string schedulePlanCorrectOutputPath,
            string taskPlanCorrectOutputPath)
        {
            // Read in the data from file
            List<SchedulePlan> schedulePlans = ReadSchedulePlan(schedulePlanPath);
            List<TaskPlan> taskPlans = ReadTaskPlan(taskPlanPath);

            // Validate the data, catching any illegal formatting
            Validator.Validate(schedulePlans);
            Validator.Validate(taskPlans);

            // Deserialize expected results
            List<SchedulePlanOutput> expectedSchedulePlanOutputs = ReadSchedulePlanOutputs(schedulePlanCorrectOutputPath);
            List<TaskPlanOutput> expectedTaskPlanOutputs = ReadTaskPlanOutputs(taskPlanCorrectOutputPath);

            // Generate & process the input data into the transformed output data
            List<SchedulePlanOutput> schedulePlanOutput = new List<SchedulePlanOutput>();
            for (int i = 0; i < schedulePlans.Count; i++)
            {
                SchedulePlanOutput result = Builder.Build(schedulePlans, i);
                SchedulePlanOutput expected = expectedSchedulePlanOutputs[i];

                Assert.True(result.Begin.Equals(expected.Begin));
                Assert.True(result.CumulativePlannedTaskHours.Equals(expected.CumulativePlannedTaskHours));
                Assert.True(result.CumulativePlannedValue.Equals(expected.CumulativePlannedValue));
                Assert.True(result.PlannedTaskHours.Equals(expected.PlannedTaskHours));
                Assert.True(result.Week.Equals(expected.Week));

                schedulePlanOutput.Add(result);
            }
            Assert.True(schedulePlanOutput.Count.Equals(expectedSchedulePlanOutputs.Count));

            List<TaskPlanOutput> taskPlanOutput = new List<TaskPlanOutput>();
            for (int i = 0; i < taskPlans.Count; i++)
            {
                TaskPlanOutput result = Builder.Build(taskPlans, i, schedulePlans);
                TaskPlanOutput expected = expectedTaskPlanOutputs[i];

                Assert.True(result.CumulativePlannedValue.Equals(expected.CumulativePlannedValue));
                Assert.True(result.CumulativeTaskHours.Equals(expected.CumulativeTaskHours));
                Assert.True(result.HoursToComplete.Equals(expected.HoursToComplete));
                Assert.True(result.PlannedValue.Equals(expected.PlannedValue));
                Assert.True(result.Task.Equals(expected.Task));
                Assert.True(result.WeekOfPlannedCompletion.Equals(expected.WeekOfPlannedCompletion));

                taskPlanOutput.Add(result);
            }
            Assert.True(taskPlanOutput.Count.Equals(expectedTaskPlanOutputs.Count));
        }

        [Theory]
        [InlineData("SchedulePlan_100Tasks.json", "TaskPlan_100Tasks.json")]
        public void Should_Calculate_Earned_Value_Plan(string schedulePlanPath, string taskPlanPath)
        {
            // Read in the data from file
            List<SchedulePlan> schedulePlans = ReadSchedulePlan(schedulePlanPath);
            List<TaskPlan> taskPlans = ReadTaskPlan(taskPlanPath);

            // Validate the data, catching any illegal formatting
            Validator.Validate(schedulePlans);
            Validator.Validate(taskPlans);

            // Generate & process the input data into the transformed output data
            List<SchedulePlanOutput> schedulePlanOutput = new List<SchedulePlanOutput>();
            for (int i = 0; i < schedulePlans.Count; i++)
            {
                schedulePlanOutput.Add(Builder.Build(schedulePlans, i));
            }

            List<TaskPlanOutput> taskPlanOutput = new List<TaskPlanOutput>();
            for (int i = 0; i < taskPlans.Count; i++)
            {
                taskPlanOutput.Add(Builder.Build(taskPlans, i, schedulePlans));
            }

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
        #endregion

        #region Private Helper Methods
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

        private List<SchedulePlanOutput> ReadSchedulePlanOutputs(string schedulePlanCorrectOutputPath)
        {
            using (StreamReader r = new StreamReader(ResolvePath(schedulePlanCorrectOutputPath)))
            {
                string schedulePlan = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<SchedulePlanOutput>>(schedulePlan);
            }
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

        private List<TaskPlanOutput> ReadTaskPlanOutputs(string taskPlanCorrectOutputPath)
        {
            using (StreamReader r = new StreamReader(ResolvePath(taskPlanCorrectOutputPath)))
            {
                string taskPlan = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<TaskPlanOutput>>(taskPlan);
            }
        }

        private string ResolvePath(string fileName)
        {
            string dllPath = Path.GetDirectoryName(Assembly.GetAssembly(typeof(Program)).Location);
            string slnPath = Path.Combine(dllPath, $"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..");
            return Path.GetFullPath(Path.Combine(slnPath, fileName));
        }
        #endregion
    }
}
