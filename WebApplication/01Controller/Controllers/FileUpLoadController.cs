using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO; /*IO:Input/Output*/



namespace CSharp.Controllers
{
    public class FileUpLoadController : Controller
    {

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {
            if (photo != null)
            {

                if (photo.ContentLength > 0)
                {
                    photo.SaveAs(Server.MapPath("~/Photos/" + photo.FileName));
                   
                    ViewBag.Message = "上傳成功";
                }

            }
            else
            {
                ViewBag.Message = "您沒有上傳任何檔案";
            }
            return View();
        }


        //建立ShowPhoto()一般方法-可顯示Photos資料夾下所有圖檔
        public string ShowPhoto()
        {
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/Photos/"));
            FileInfo[] files = d.GetFiles();


            string show = "";
            foreach(FileInfo item in files)
            {
                show += "<img src='../Photos/" + item.Name + "' />";
               
            }
      


            show += "<hr><a href='/FileUpLoad/Create'>點我回上傳照片頁面</a>";
           
            return show;
        
        
        
        
        }

      
    }
}