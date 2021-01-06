using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.StudioX.Activities
{
    public class SampleActivity : NativeActivity
    {
        public InArgument<string> Message { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            Console.WriteLine(Message.Get(context));
        }
    }
}
