using _07ADOnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _07ADOnet.Controllers
{
    public class HomeController : Controller
    {
        GetData gd = new GetData();

       
        
        
        public ActionResult Index()
        {
            
            return View(gd.querySql("select * from 學生",CommandType.Text));
        }


        public ActionResult GetEmployee()
        {
            return View(gd.querySql("select * from 員工", CommandType.Text,"employee"));
        }


        public ActionResult GetCoursePivot()
        {

            var result = gd.querySql("getCoursePivot", CommandType.StoredProcedure);//()內為預存程序的名稱
            return View(result);
        }


    }
}