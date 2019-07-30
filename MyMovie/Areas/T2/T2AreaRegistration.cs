using System.Web.Mvc;

namespace MyMovie.Areas.T2
{
    public class T2AreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "T2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "T2_default",
                "T2/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}