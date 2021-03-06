# Exceptional Engineer Assignment 1: Calculate an Earned Value Plan

## Purpose
The purpose of this assignment is to:
1. Dive deeply into how the Process Dashboard correctly calculates Earned Value for improved understanding
2. Understand my performance in developing a software product
3. Gather data on myself as I follow the Personal Software Process to develop software
4. Gain experience using the Process Dashboard

## Modules & Classes
- Program.cs: The unit test program that drives the main logic. It takes input Schedule and Task Plan data and outputs
  the Earned Value plans
- Validator.cs: Validates the input data
- Builder.cs: Builds the output data
- Models Directory: Contains the input and output models for Schedule and Task Plans
- Input Directory: Contains user-input Schedule and Task Plans, similar to the data a user would input into the Process
  Dashboard
- ExpectedOutput Directory: Contains expected output of the Schedule and Task Plans enriched with additional data. This
  is used for unit testing purposes, and only contains expected output for the sample data in the assignment due to
  time constraints.
- GeneratedOutput Directory: Contains the Schedule and Task Plans enriched with additional data generated by this
  program
- Images Directory: Contains images embedded in this README.md

## Software Design

### Phase 1: Deserialize the input JSON into internal model objects
![Phase 1 Design](https://github.com/emiliavanderwerf/exceptional-engineer/blob/master/assignment1/EarnedValue/Images/Phase1_GetData_Design.jpg)

### Phase 2: Perform the Earned Value Plan calculations
![Phase 2 Design](https://github.com/emiliavanderwerf/exceptional-engineer/blob/master/assignment1/EarnedValue/Images/Phase2_DoCalculations_Design.jpg)

### Phase 3: Output the Earned Value Plan calculations to JSON files
![Phase 3 Design](https://github.com/emiliavanderwerf/exceptional-engineer/blob/master/assignment1/EarnedValue/Images/Phase3_OutputData_Design.jpg)

## Results

As shown by the Work Breakdown Structure below, I estimated that the project would take me a total of 5.8 hours to
complete, but it actually took 4.8 hours. Furthermore, I split the project deliverables into 3 portions: get data, do
calculations, and output data. The same development workflow was applied to each of the portions.

![My Earned Value Schedule](https://github.com/emiliavanderwerf/exceptional-engineer/blob/master/assignment1/EarnedValue/Images/DataActuals.PNG)

The below "Plan vs Actual Time" graph and trendline show that I tend to overestimated the planned number of hours I
believe it will take me to accomplish each of the tasks in the above Work Breakdown Structure screenshot. When I make
future predictions of how long a task will take me, I can use this trendline.

![Plan vs Actual Time Graph](https://github.com/emiliavanderwerf/exceptional-engineer/blob/master/assignment1/EarnedValue/Images/PlannedVsActualTime.PNG)

The below Project Rollup Plan Summary shows my productivity (in LOC/hour), the size of the program, and the defects I
both injected during development & removed.

![Project Rollup Plan Summary](https://github.com/emiliavanderwerf/exceptional-engineer/blob/master/assignment1/EarnedValue/Images/ProjectRollupPlanSummary.PNG)
