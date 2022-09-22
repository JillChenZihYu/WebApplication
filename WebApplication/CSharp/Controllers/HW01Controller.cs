using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class HW01Controller : Controller
    {
        //1.請宣告變數a為整數，值為42，宣告變數b為浮點數，值2.5，將兩值分別做加、減、乘、除及取餘數之運算，並輸出五種運算的執行結果。
        public void Number()
        {
            int a = 42;
            float b = 2.5f;


            Response.Write(a + b);
            Response.Write("<hr>");
            Response.Write(a - b);
            Response.Write("<hr>");
            Response.Write(a * b);
            Response.Write("<hr>");
            Response.Write(a / b);
            Response.Write("<hr>");
            Response.Write(a % b);

        }

        //HW01/Number



        //2.寫一個將攝氏溫度轉換為華氏溫度的程式，攝氏溫度的值可url傳入參數。(華氏＝攝氏*9/5+32)。
        public void Degree(int c)
        {

            int f = c * 9 / 5 + 32;


            Response.Write(f);
        }

        //HW01/Degree?c=35


        //3.設有兩個變數X與Y，其值為任何整數，試寫在不另宣告其他變數的情況下，交換X與Y的值的程式，X與Y的值須由參數傳入。 (例X=3,Y=5，執行完您的程式後X=5,Y=3)
        //var x = 3; var y = 5;

        //x = x + y;
        //y = x - y;
        //x = x - y;
        //document.write("x=" + x + ",y=" + y)

        public void SwitchNumber(int x, int y)
        {
            x = x + y;
            y = x - y;
            x = x - y;

            Response.Write("執行程式後x=" + x + ",y=" + y);
        }

        //HW01/SwitchNumber?x=80&y=20


        //4.請利用switch敘述，分別試寫判斷成績等第之程式。90分以上為優等，80~89為甲等，70~79為乙等，60~69為丙等，其餘為丁等，成績的值須由參數傳入(不必判斷值的合理性,但亦不可另外搭配if 敘述句)
        public string Score(int a)
        {
            a = a / 10;

            switch (a)
            {
                case 10:
                case 9:
                    return "優等";
                case 8:
                    return "甲等";
                case 7:
                    return "乙等";
                case 6:
                    return "丙等";
            }
            return "丁等";
        }

        //  /HW01/Score?a= 68


        //5.請利用回圈敘述寫一顯示1~Ｎ的整數中，不是5的倍數的程式，並輸出其結果，Ｎ的值須由參數傳入。If 除以五餘數非零

        public void WithoutFive(int n)
        {
            for (int m = 0; m <= n; m++)
            {
                if (m % 5 != 0)
                {
                    Response.Write(m);

                }
                Response.Write("<br>");
            }
        }

        //  HW01/WithoutFive?n=19

        //6.請利用回圈敘述計算1 ~N的整數中，除了3倍數以外所有數的總合，並輸出其結果，Ｎ的值須由參數傳入。

        public void WithoutThree(int i)
        {
            int sum = 0;


            for (int j = 0; j <= i; j++)
            {
                if (j % 3 != 0)
                {

                    sum += j;

                }

            }
            Response.Write(sum);

        }

        //HW01/WithoutThree?i=5

        //7.請利用while敘述顯示出下方圖形，最後一列的＊數量為Ｎ，Ｎ的值須由參數傳入。(不可以使用巢狀回圈)

        public void Stars(int r)
        {
            string h = "";
            int v = 1;

            while (v <= r)
            {
                h += "*";
                v++;
                Response.Write(h);
                Response.Write("<br>");
            }
        }

        //HW01/Stars?r=5


        //8.請利用回圈敘述寫一九九乘法表，並輸出其結果，畫面不限。

        public void Times()
        {
            int o = 1;
            int p = 0;

            while (o <= 9)
            {
                p = 1;
                while (p <= 9)
                {
                    Response.Write(o + "*" + p + "=" + o * p);
                    p++;
                    Response.Write("<br>");
                }
                o++;
                Response.Write("<br>");
            }


        }

        //public void Times()
        //{
        //    for (int o = 1; o <= 9; o++)
        //    {
        //        for (int p = 1; p <= 9; p++)
        //        {
        //            Response.Write(o + "*" + p + "=" + o * p);
        //            Response.Write("<br>");
        //        }
        //        Response.Write("<br>");
        //    }

        //}





    }
}