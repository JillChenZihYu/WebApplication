using _03Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03Model.Controllers
{
    public class LinqController : Controller
    {
        //04-2-7 於LinqController建立DB Context物件
        NorthwindEntities db = new NorthwindEntities();

        public string ShowEmployee()
        {

            //Linq
            //var result = from m in db.員工
            //             select m;

            var result = db.員工;

            //select * from 員工

            string show = "";


            foreach (var item in result)
            {
                show += "員工編號:" + item.員工編號 + "<br>";
                show += "員工姓名:" + item.姓名 + "<br>";
                show += "員工職稱:" + item.職稱 + "<hr>";
            }

            return show;
    
        
        }



        public string ShowCustomerByAddress(string keyword)
        {
            string show = "";

            //Linq查詢運算式寫法
            //var result = from c in db.客戶
            //             where c.地址.Contains(keyword)  /*keyword如果是null值也不會報錯，但還是需要輸入值才能查詢*/
            //             select c;

            //Linq擴充方法寫法
            var result = db.客戶.Where(c => c.地址.Contains(keyword));
            //select * from  客戶 where 地址 like '%台北%' /*上述為只要地址內有台北就會被查詢到*/

            //select * from  客戶 where 地址 like '台北%'  /*查詢台北開頭的地址*/
            //var result = db.客戶.Where(c => c.地址.StartsWith(keyword));

            //select * from  客戶 where 地址 like '%台北'  /*查詢台北結尾的地址*/
            //var result = db.客戶.Where(c => c.地址.EndsWith(keyword));

            foreach (var item in result)
            {
                show += "客戶編號:" + item.客戶編號 + "<br>";
                show += "客戶名稱:" + item.公司名稱 + "<br>";
                show += "地址:" + item.地址 + "<hr>";
            }

            return show;

            //查詢式：Linq/ShowCustomerByAddress?keyword=xxxxx
        }


        public string ShowProduct()
        {
            string show = "";

            //Linq查詢運算式寫法
            //var result = from p in db.產品資料
            //             where p.單價>30
            //             orderby p.單價, p.庫存量 descending
            //             select p;

            //select * from 產品資料 where 單價>30
            //order by 單價,庫存量 desc

            //Linq擴充方法寫法
            var result = db.產品資料.Where(p => p.單價 > 30).OrderBy(p => p.單價).ThenByDescending(p => p.庫存量);
            //若order by條件式有兩種，第二個排序需寫ThenBy/ ThenByDescending

            foreach (var item in result)
            {
                show += "產品編號:" + item.產品編號 + "<br>";
                show += "產品名稱:" + item.產品 + "<br>";
                show += "單價:" + item.單價 + "<br>";
                show += "庫存量:" + item.庫存量 + "<hr>";
            }

            return show;
        }


        public string ShowProductInfo()
        {
            string show = "";

            //Linq查詢運算式寫法
            var result = from p in db.產品資料
                         select p;

            //select count(*),sum(單價),avg(單價),max(單價),min(單價) from 產品資料 


            //Linq擴充方法寫法
            //var result = db.產品資料.Where(p => p.單價 > 30).OrderBy(p => p.單價).ThenByDescending(p => p.庫存量);

           
                show += "產品筆數:" + result.Count()+ "<br>";
                show += "產品單價總和:" + result.Sum(p=>p.單價) + "<br>";
                show += "產品單價平均:" + result.Average(p => p.單價) + "<br>";
                show += "最高單價:" + result.Max(p => p.單價) + "<hr>";
                show += "最低單價:" + result.Min(p => p.單價) + "<hr>";
            

            return show;
        }





    }

}