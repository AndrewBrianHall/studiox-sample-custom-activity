using System;

namespace UiPath.Shared.Activities
{
    /// <summary>
    /// Convention class, copied in each of the activity packages
    /// Used to associate metadata to packages, without referencing a contract assembly
    /// !! Do not modify namespace or class name
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal class PackageDescriptorAttribute : Attribute
    {
        /// <summary>
        /// Indicates the profile key to which this descriptor corresponds
        /// </summary>
        public string ProfileKey { get; }

        /// <summary>
        /// The type of the descriptor
        /// </summary>
        public string DescriptorTypeFullName { get; }


        public PackageDescriptorAttribute(string profileKey, string descriptorTypeFullName)
        {
            ProfileKey = profileKey;
            DescriptorTypeFullName = descriptorTypeFullName;
        }
    }
}