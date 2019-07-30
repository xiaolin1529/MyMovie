using System.Web.Mvc;

namespace MyMovie.Areas.T3
{
    public class T3AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "T3";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "T3_default",
                "T3/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}