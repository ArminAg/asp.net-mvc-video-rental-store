using System.Web.Mvc;

namespace asp.net_mvc_video_rental_store.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}