using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Activities.Contracts;
using UiPath.Activities.Contracts.Services;

namespace Sample.StudioX.Activities.Design
{
    internal class Resources
    {
        public const string CategoryColor = "#B4009E";
        public const string ActivityCategory = "Sample";
    }

    internal class BusinessPackageDescriptor : BusinessPackageDescriptorBase
    {
        public override PackageInfoService PackageInfoService => new SamplePackageInfoService();

        public override IEnumerable<InjectedActionsService> InjectedActionsServices => new InjectedActionsService[] { };
    }

    internal class SamplePackageInfoService : PackageInfoService
    {
        private static readonly IEnumerable<ActivityCategory> Categories = new List<ActivityCategory>()
        {
            new ActivityCategory
            {
                Color = Resources.CategoryColor,
                Id = $"{typeof(SamplePackageInfoService).Assembly.FullName}/{Resources.ActivityCategory}",
                Description = "Sample custom activities",
                IconBrushUri = null,
                Label = "Sample"
            },
        };

        public override IEnumerable<ActivityCategory> ActivityCategories => Categories;
    }
}
