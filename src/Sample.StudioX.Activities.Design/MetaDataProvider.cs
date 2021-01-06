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

            // Register the display name for the activity
            DisplayNameAttribute activityDisplayName = new DisplayNameAttribute(Resources.SampleActivityDisplayName);
            builder.AddCustomAttributes(typeof(SampleActivity), activityDisplayName);

            // Register the activity and provide the full category as it will be used in Studio (.'s delimit hierarchy)
            CategoryAttribute studioCategory = new CategoryAttribute($"Custom.{Resources.ActivityCategory}");
            builder.AddCustomAttributes(typeof(SampleActivity), studioCategory);

            // Sets the color of the activity used in the StudioX designer (controls left margin and border when selected)
            // Usually this matches the category
            builder.AddCustomAttributes(typeof(SampleActivity), new ActivityInfoAttribute
            {
                Color = Resources.CategoryColor,
            });

            //Register the custom designer for the activity
            builder.AddCustomAttributes(typeof(SampleActivity), new DesignerAttribute(typeof(SampleActivityDesigner)));

            MetadataStore.AddAttributeTable(builder.CreateTable());
        }
    }
}
