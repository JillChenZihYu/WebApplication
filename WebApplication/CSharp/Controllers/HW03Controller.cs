using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class HW03Controller : Controller
    {

        //1.弄一副牌出來〈放到陣列中〉
        //2.洗牌〈把陣列中的元素隨機打亂）
        //3.發牌〈把陣列中的元素依序顯示〉 







        //1.弄一副牌出來〈放到陣列中〉
        public void DealCard()
        {
            string[] poker = new string[52];  //宣告52個元素大小的陣列，索引值為0~51

            for (int i = 0; i < poker.Length; i++) 
            {
                poker[i] = (i+1).ToString();  //ToString()將括號內改成字串
            }

            //測試用
            //foreach(var item in poker)
            //{
            //    Response.Write("<img src='../poker_img/" + item + ".gif' />");

            //}




            //2.洗牌〈把陣列中的元素隨機打亂）
            Random r = new Random();
            int temp = 0;
            string x = "";

            for (int i = 0; i < poker.Length; i++)
            {
                temp = r.Next(52);  //取一個亂數值
                x = poker[i];  //先將第一張牌放到x
                poker[i]=poker[temp];  //將亂數抽到的牌放到第一張牌的位置
                poker[temp] = x;  //將第一張牌放到亂數抽到的牌的位置

                //再進行第二張牌

            }

            //測試用
            //foreach (var item in poker)
            //{
            //    Response.Write("<img src='../poker_img/" + item + ".gif' />");

            //}
            //Response.Write("<br>");



            //3.發牌〈把陣列中的元素依序顯示〉 
            string p1 = "",p2 = "", p3 = "", p4 = "";
            string result = "";
            for (var i = 0; i < poker.Length; i++)
            {
                result= "<img src='../poker_img/" + poker[i] + ".gif' />";

                switch (i%4)
                {
                    case 0:
                        p1 += result;
                        break;
                    case 1:
                        p2 += result;
                        break;
                    case 2:
                        p3 += result;
                        break;
                    case 3:
                        p4 += result;
                        break;
                }
            
            
            }

            Response.Write("玩家1:" + p1 + "<br>");
            Response.Write("玩家2:" + p2 + "<br>");
            Response.Write("玩家3:" + p3 + "<br>");
            Response.Write("玩家4:" + p4 + "<br>");




            //int number = 0;
            //Random r = new Random();//鑄造亂數物件
            ////OOO XX = new OOO() 此為特定格式，為鑄造物件的公式，XX為變數，可自行修改
            ////類別〈物件的設計圖/食譜/食材〉   物件〈煮好的菜〉  = new  建構子〈建構函數〉〈煮菜的方法〉; 

            //number = r.Next();  //r.為將r的功能寫在.後方，Next的功能為傳回亂數。若()內沒寫數字，就會隨機寫入32為園內的數值；若(100)，會寫入0~99的亂數；若(100,500)，會寫入100~499的亂數。



        }












    }
}