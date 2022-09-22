using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01Controller.Controllers
{
    public class SimpleBindController : Controller
    {
        // Action
        public ActionResult Create()
        {
            //ViewBag.Date=DateTime.Now;
            
            return View();
        }


        [HttpPost]//未標post都會預設get模式，get模式為從URL輸入。
        public ActionResult Create(string PId, string PName, int Price)//將上面輸入的值呈現在下方表格
        {
            ViewBag.PId = PId;
            ViewBag.PName = PName;
            ViewBag.Price = Price;

            return View();
        }






    }
}