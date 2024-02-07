using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Models
{
    public class CustomLoggingActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Log the information before the action executes.
            Log("OnActionExecuting", context.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Log the information after the action executes.
            Log("OnActionExecuted", context.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            string message = methodName + " Controller:" + controllerName + " Action:" + actionName + " Date: "
                            + DateTime.Now.ToString() + Environment.NewLine;
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Action.txt");
            //saving the data in a text file called Log.txt
            File.AppendAllText(filePath, message);
        }
    }
}
