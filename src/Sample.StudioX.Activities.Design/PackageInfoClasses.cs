using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Activities.Contracts;
using UiPath.Activities.Contracts.Services;

namespace Sample.StudioX.Activities.Design
{
    // This class is loaded by StudioX and the value returned by the PackageInfoService property is
    // used for creating any categories in StudioX 
    // Notes: 
    //       - The descriptorTypeFullName property of the PackageDescriptor attribute in the AssemblyInfo.cs file 
    //         must provide the fully qualified name of this class for StudioX to load the information.
    //       - The BusinessPackageDescriptorBase base class is contained in UiPath.Activities.Contracts.dll which should be referenced
    //         from a StudioX installation matching the oldest version you plan to target
    internal class BusinessPackageDescriptor : BusinessPackageDescriptorBase
    {
        public override PackageInfoService PackageInfoService => new SamplePackageInfoService();

    }

    // This is the class that returns the information for any custom activity categories added by the package including:
    //    - Color of the catgory square in the Activites panel filter
    //    - Displayed "Label" of the category
    //    - Tooltip displayed (Description) when the user hovers over the category
    // Note: The PackageInfoService base class is contained in UiPath.Activities.Contracts.dll which should be referenced
    //       from a StudioX installation matching the oldest version you plan to target
    internal class SamplePackageInfoService : PackageInfoService
    {
        private static readonly IEnumerable<ActivityCategory> Categories = new List<ActivityCategory>()
        {
            new ActivityCategory
            {
                Color = Resources.CategoryColor,
                // The string to the right of the / must match the last registered category level registed for the activity
                // See how in this example here is is Resources.ActivityCategory in in MetaDataProvider.cs the category used
                // in Studio is $"Custom.{Resources.ActivityCategory}"
                Id = $"{typeof(SamplePackageInfoService).Assembly.FullName}/{Resources.ActivityCategory}",
                Description = Resources.StudioXCategoryDescription,
                IconBrushUri = null,
                Label = Resources.StudioXCategoryLabel
            },
        };

        public override IEnumerable<ActivityCategory> ActivityCategories => Categories;
    }
}
