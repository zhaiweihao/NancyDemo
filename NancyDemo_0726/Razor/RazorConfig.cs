using Nancy.ViewEngines.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyDemo_0726.Razor
{
    public class RazorConfig : IRazorConfiguration
    {
        public bool AutoIncludeModelNamespace
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "NancyDemo_0726.Model";
            yield return "NancyDemo_0726.Website";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "NancyDemo_0726.Models";
            yield return "NancyDemo_0726.Website.Infrastructure.Helpers";
        }
    }
}