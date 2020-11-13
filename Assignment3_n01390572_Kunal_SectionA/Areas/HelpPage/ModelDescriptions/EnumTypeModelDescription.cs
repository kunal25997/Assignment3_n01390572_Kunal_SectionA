using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assignment3_n01390572_Kunal_SectionA.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        public Collection<EnumValueDescription> Values { get; private set; }
    }
}