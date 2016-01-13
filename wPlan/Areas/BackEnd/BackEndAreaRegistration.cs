using System.Web.Mvc;

namespace OdrorirBoard.Areas.BackEnd
{
    public class BackEndAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BackEnd";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "BackEnd_def",
                url: "BackEnd/{controller}/{action}/{id}",
                defaults: new { controller ="Teams", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"OdrorirBoard.Areas.BackEnd.Controllers"}
            );

        }
    }
}