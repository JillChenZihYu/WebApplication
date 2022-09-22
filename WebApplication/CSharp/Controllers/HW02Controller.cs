using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class HW02Controller : Controller
    {

        //1.判斷質數
        public string Num(int n)
        {

            for (int i = 2; i < n; i++)  //將i設定為從2開始除，不須超過n，故設小於
            {
                if (n % i == 0)
                {
                    return n + "不是質數";
                }

            }
            return (n + "是質數");



            //int i = 2;
            //    while(i < n)
            //{
            //    if (n % i == 0)
            //    {
            //        return n + "不是質數";
            //    }
            //    i++;
            //}

            //return (n + "是質數");


        }




        //2.最大公因數
        public string Num2(int m, int n)
        {
        
            
                int M = m, N = n;
                int z = 0;//這個變數來放餘數

                while (M % N != 0)
                {
                    z = M % N;
                    M = N;
                    N = z;
                }

                return m + "與" + n + "之最大公因數為" + N;
            


        }

        //HW02/Num2?m=16&n=12



        //3.迴文判斷

        public string No3(int n)
        {

            int N = n, result = 0;
            int q = 0, r = 0;


            do
            {
                r = N % 10;  //取餘數
                q = N / 10;  //取商數
                N = q;

                result *= 10;
                result += r;
            }
            while (q != 0);

            if (n == result)
                return n + "是迴文";

            return n + "不是迴文";




        }


















    }
}