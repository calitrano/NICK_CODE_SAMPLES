using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuffaloNYTourism012019.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult BuffaloView()
        {
            ViewBag.Message = " Buffalo NY page ";

            return View();
        }


        public ActionResult SimpleView()
        {

            ViewBag.Message = "Simple View";
            return View();

        }
        //public ActionResult ArtView()
        //{

        //    ViewBag.Message = "ArtView";
        //    return View();

        //}

        public ActionResult Art()
        {

            ViewBag.Message = "Art";
            return View();

        }

        public ActionResult Food()
        {

            ViewBag.Message = "Food";
            return View();

        }
        public ActionResult Bills()
        {

            ViewBag.Message = "Bills";
            return View();

        }
        public ActionResult BisonsBandits()
        {

            ViewBag.Message = "Bisons Bandits";
            return View();

        }
        public ActionResult Buffalonian()
        {

            ViewBag.Message = "Buffalonian";
            return View();

        }
        //public ActionResult BuffaloView()
        //{

        //    ViewBag.Message = "BuffaloView";
        //    return View();

        //}
        public ActionResult canadianBands()
        {

            ViewBag.Message = "Canadian Bands";
            return View();

        }
        public ActionResult CanadianDeals()
        {

            ViewBag.Message = "Canadian Deals";
            return View();

        }
        public ActionResult Code()
        {

            ViewBag.Message = "Code";
            return View();

        }
        //public ActionResult Contact()
        //{

        //    ViewBag.Message = "Contact";
        //    return View();

        //}
        public ActionResult DataLevel()
        {

            ViewBag.Message = "Data Level";
            return View();

        }
        public ActionResult Default()
        {

            ViewBag.Message = "Default";
            return View();

        }
        public ActionResult FeedbackNew()
        {

            ViewBag.Message = "Feedback New";
            return View();

        }
        public ActionResult FeedbackS()
        {

            ViewBag.Message = "FeedbackS";
            return View();

        }
        public ActionResult Festivals()
        {

            ViewBag.Message = "Festivals";
            return View();

        }
        //public ActionResult Food()
        //{

        //    ViewBag.Message = "Food";
        //    return View();

        //}
        public ActionResult History()
        {

            ViewBag.Message = "History";
            return View();

        }
        //public ActionResult Index()
        //{

        //    ViewBag.Message = "Index";
        //    return View();

        //}
        public ActionResult Music()
        {

            ViewBag.Message = "Music";
            return View();

        }
        public ActionResult Sabres()
        {

            ViewBag.Message = "Sabres";
            return View();

        }
        //public ActionResult SimpleView()
        //{

        //    ViewBag.Message = "SimpleView";
        //    return View();

        //}
        public ActionResult Sports()
        {

            ViewBag.Message = "Sports";
            return View();

        }
        public ActionResult Subway()
        {

            ViewBag.Message = "Subway";
            return View();

        }
        public ActionResult WebMaster()
        {

            ViewBag.Message = "WebMaster";
            return View();

        }
        public ActionResult NFView()
        {

            ViewBag.Message = "NFView";
            return View();

        }


    }
}