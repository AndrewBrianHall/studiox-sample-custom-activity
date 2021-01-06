using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using UiPath.Shared.Activities;

namespace Sample.StudioX.Activities.Design
{
    public class MetaDataProvider : IRegisterMetadata
    {
        public void Register()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();

            CategoryAttribute studioCategory = new CategoryAttribute($"Custom.{Resources.ActivityCategory}");
            DisplayNameAttribute studioDisplayName = new DisplayNameAttribute("Sample Activity");

            builder.AddCustomAttributes(typeof(SampleActivity), studioCategory);
            builder.AddCustomAttributes(typeof(SampleActivity), studioDisplayName);
            builder.AddCustomAttributes(typeof(SampleActivity), new ActivityInfoAttribute
            {
                Color = Resources.CategoryColor,
            });
            builder.AddCustomAttributes(typeof(SampleActivity), new DesignerAttribute(typeof(SampleActivityDesigner)));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
