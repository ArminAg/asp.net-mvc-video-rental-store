using System.Web.Mvc;

namespace asp.net_mvc_video_rental_store.Controllers
{
    public class RentalsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}