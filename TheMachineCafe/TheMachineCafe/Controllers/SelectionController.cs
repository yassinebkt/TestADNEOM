using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMachineCafe.Models;

namespace TheMachineCafe.Controllers
{
    [Authorize]
    public class SelectionController : Controller
    {
        // GET: Selection
        public ActionResult Index()
        {
            return View();
        }
    }
}