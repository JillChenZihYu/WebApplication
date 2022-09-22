using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//04-03-11  using _03Model.Models;
using _03Model.Models;

namespace _03Model.Controllers
{
    public class DefaultController : Controller
    {
        
        dbSutdentEntities db = new dbSutdentEntities();






        public ActionResult Index()
        {
            var tStudent = db.tStudent.ToList();  /*讀出來的資料轉成list*/

            return View(tStudent);
        }


        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(tStudent s)
        {
            db.tStudent.Add(s);  /*在db的tStudent裡增加資料*/
            db.SaveChanges();    /*SaveChanges適用於新增、修改、刪除*/
            return RedirectToAction("Index");  /*若要回到Index列表需使用RedirectToAction*/
        }

        public ActionResult Delete(string id)
        {
            //SQL
            //delete from tStudent where s.fStuId =id;

            //Linq
            //var student = from s in db.tStudent
            //              where s.fStuId == id;
            //             select s;

            var student = db.tStudent.Where(s=>s.fStuId==id).FirstOrDefault();
            db.tStudent.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}