using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiPath.Shared.Activities
{
    /// <summary>
    /// Convention class, copied in each of the activity packages
    /// Used to associate metadata to activities, without referencing a contract assembly
    /// !! Please do not modify namespace or class name
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class ActivityInfoAttribute : Attribute
    {
        /// <summary>
        /// Color associated to this activity, when rendered in a Designer
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// True if the activity is card 
        /// </summary>
        public bool IsCard { get; set; }

        /// <summary>
        /// Indicates the type of the expression assistant associated with this activity type (if any).
        /// </summary>
        public Type ExpressionAssistant { get; set; }

        /// <summary>
        /// Indicates the type of the scope assistant associated with this activity type (if any).
        /// </summary>
        public Type ScopeAssistant { get; set; }

        /// <summary>
        /// Indicates the type that provides information about this card type, if it is a card.
        /// studioX 19.10 - 20.02 uses this provider
        /// </summary>
        //[Obsolete("please use IsCard/ScopeAssistant")]
        public Type CardInformationProvider { get; set; }
    }
}
