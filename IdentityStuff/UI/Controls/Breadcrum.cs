using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;
using ClimbFind.Web.Mvc.Controllers;


namespace IdentityStuff.UI.Controls
{
    public class BreadCrumb<T> : IBreadCrumb where T : BaseController
    {
        private ViewContext _ctx;

        public string Text { get; set; }
        public Expression<Action<T>> LinkAction { get; set; }
        public Type Controller { get { return typeof(T); } }
        public string Link { get { return GetLink(); } }

        private BreadCrumb() { }

        public BreadCrumb(ViewContext ctx, string text, Expression<Action<T>> linkAction)
        {
            _ctx = ctx;

            Text = text;
            LinkAction = linkAction;
        }

        private string GetLink()
        {
            MethodCallExpression call = LinkAction.Body as MethodCallExpression;

            string actionName = call.Method.Name;
            // TODO: Use better logic to chop off the controller suffix
            string controllerName = Controller.Name;// typeof(T).Name;
            if (controllerName.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
            {
                controllerName = controllerName.Remove(controllerName.Length - 10, 10);
            }

            RouteValueDictionary values = LinkBuilder.BuildParameterValuesFromExpression(call);

            values = values ?? new RouteValueDictionary();
            values.Add("controller", controllerName);
            values.Add("action", actionName);

            VirtualPathData vpd = RouteTable.Routes.GetVirtualPath(_ctx, values);
            return vpd.VirtualPath;
        }

    }

    public interface IBreadCrumb
    {
        string Text { get; set; }
        string Link { get; }
    }
}
