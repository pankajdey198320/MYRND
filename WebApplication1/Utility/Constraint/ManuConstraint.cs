using System.Web.Routing;

namespace WebApplication1.Utility.Constraint
{
    public class ManuConstraint : IRouteConstraint
    {
        string _valToMatch;
        public ManuConstraint(string val)
        {
            _valToMatch = val;
        }

        public bool Match(System.Web.HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return string.Equals(value.ToString(), _valToMatch, System.StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}