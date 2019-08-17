using CBTWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CBTWebAPI.Controllers
{
    public class ResultController : Controller
    {
        private CBTWebAPIContext db = new CBTWebAPIContext();
        // GET: Result
        public ActionResult Index()
        {
            var r = Result.GetAllResults(db);

            return View(r);
        }
    }
}