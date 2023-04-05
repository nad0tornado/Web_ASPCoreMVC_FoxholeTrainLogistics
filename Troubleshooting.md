#Troubleshooting Guide
### Foxhole Train Logistics System

- When cloning the repo for the first time, if the project reference for "FoxholeItemAPI" in "FoxholeTrainLogistics.sln" doesn't work,
check to make sure that there's no "rogue assemblies" in the references list for "FoxholeItemAPI" ... remove the dodgy ones and then re-add the project reference. It should work after that.