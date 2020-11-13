using System;
using System.Reflection;

namespace Assignment3_n01390572_Kunal_SectionA.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}