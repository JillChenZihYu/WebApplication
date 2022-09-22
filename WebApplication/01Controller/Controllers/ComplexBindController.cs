using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01Controller.Models;  //要找到Product的NameSpace才可以在這裡使用product裡寫的內容
//引入命名空間(NameSpace)

namespace _01Controller.Controllers
{
    public class ComplexBindController : Controller
    {
        // Action
        public ActionResult Create()
        {
           

            return View();
        }


        [HttpPost]//未標post都會預設get模式，get模式為從URL輸入。
        public ActionResult Create(Product p)//將上面輸入的值呈現在下方表格
        {
            ViewBag.PId = p.PId;
            ViewBag.PName = p.PName;
            ViewBag.Price = p.Price;

            return View();
        }

    }
}