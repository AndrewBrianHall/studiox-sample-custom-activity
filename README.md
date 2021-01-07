# Sample Custom Activity for StudioX
This repo contians a simple custom Workflow activity that can be used in UiPath Studio and StudioX. The purpose of this repo is to demonstrate how to create a custom category in StudioX if needed.

## Basics
Creating a custom activity for StudioX works basically the same way it does for Studio as covered in [Creating a Custom Activity](https://docs.uipath.com/activities/docs/creating-a-custom-activity)

A few guidelines for ensuring StudioX users will be successful with your activity:
- Assume that the user will not find properties not present in the designer unless instructed to do so. This means all commonly used properties should be placed into the designer.
- StudioX only gives users the ability to define basic types (String and Numbers). So if you expect the user to create the input to an activity themselves, design the activity to accept these types. For example, you should next expect the user to define an array and provide it as input. If your activity requires an array as input, consider allowing the user to create a delimited list and then convert it to an array in the activity (you can see an example of this in the "Input Dialog" activity added in 20.10 for the "Multiple Choice" input type. The user provides ; delimited text and the activity converts this to an array for them at runtime).
- StudioX is capable of saving any output type using "Save for Later" and then will allow the user to provide it as input to future activities. So if one activity needs to return a complex type that will serve as input for another activity, this should be fine.

## Registering A Custom Category in StudioX
The significant difference when adding custom activities to StudioX is, if you want to create a new category this requires additional work beyond how it functions in the Developer (Studio) profile

* The classes that provide any custom category registrations must be in an assembly that ends with .Design (excluding the file extension). _This sample project follows the best practice of separating the activity implementation and designers into separate assemblies. The registration logic lives in the Sample.StudioX.Activities.Design assembly._
- There are two classes that enable this behavior, both contained in [Sample.Studiox.Activites.Design/PackageInfoClasses.cs](https://github.com/AndrewBrianHall/studiox-sample-custom-activity/blob/main/src/Sample.StudioX.Activities.Design/PackageInfoClasses.cs)
    - **BusinessPackageDescriptor:** Implements BusinessPackageDescriptorBase and must return an instance of an object that implements PackageInfoService from the PackageInfoService property.
    - **SamplePackageInfoService:** Implements PackageInfoService and returns custom activity category information from the ActivityCategories property.
* When registering the activity category as you would for a normal activity in Studio, the end of the activity's category must match the end of the category ID as returned by the PackageInfoService implementation (for e.g. the category in Studio is registered as "Custom.Sample" then the ID of the ActivityCategory must end with "/Sample") you can see this in the registered ActivityCategory in [SamplePackageInfoService](https://github.com/AndrewBrianHall/studiox-sample-custom-activity/blob/main/src/Sample.StudioX.Activities.Design/PackageInfoClasses.cs) and the activities registration in [MetaDataProvider](https://github.com/AndrewBrianHall/studiox-sample-custom-activity/blob/main/src/Sample.StudioX.Activities.Design/MetaDataProvider.cs)
* You must add a [UiPath.Shared.Activities.PackageDescriptorAttribute](https://github.com/AndrewBrianHall/studiox-sample-custom-activity/blob/main/src/Sample.StudioX.Activities.Design/UiPath.Contracts.Types/PackageDescriptor.cs) to the .Design assembly's [AssemblyInfo.cs](https://github.com/AndrewBrianHall/studiox-sample-custom-activity/blob/main/src/Sample.StudioX.Activities.Design/Properties/AssemblyInfo.cs) that provides a value of "Business" for the profileKey parameter and the fully qualified name of the class that implements BusinessPacakgeDescriptorBase (discussed above) for the descriptorTypeFullName parameter.