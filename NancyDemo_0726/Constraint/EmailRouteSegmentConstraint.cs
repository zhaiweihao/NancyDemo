using Nancy.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyDemo_0726.Constraint
{
    public class EmailRouteSegmentConstraint : RouteSegmentConstraintBase<string>
    {
        public override string Name
        {
            get
            {
                return "email";
            }
        }

        protected override bool TryMatch(string constraint, string segment, out string matchedValue)
        {
            if (segment.Contains("@"))
            {
                matchedValue = segment;
                return true;
            }

            matchedValue = null;
            return false;
        }
    }
}