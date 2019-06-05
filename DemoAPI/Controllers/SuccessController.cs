using System.Web.Mvc;

namespace DemoAPI.Controllers
{
    public class SuccessController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Success";

            return View();
        }
    }
}