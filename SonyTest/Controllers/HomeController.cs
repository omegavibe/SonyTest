using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SonyTest.Models;
using System.Net.Http;

namespace SonyTest.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Default page Order's Screen
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveOrder(OrderRequest request)
        {
            var repo = new DbRepository("DefaultConnection");
            repo.SaveOrder(request);

            return new JsonResult();
        }
    }
}