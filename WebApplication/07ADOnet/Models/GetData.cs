using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace _07ADOnet.Models
{
    


    public class GetData
    {
        //1.執行SqlConnection(連到DataBase)
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["aaa"].ConnectionString);
        //括號內的路徑為webconfig內的ConnectionStrings=>name"aaa"=>ConnectionString

        SqlDataAdapter adp = new SqlDataAdapter("", conn); //從DB取資料到記憶體內
        DataSet ds = new DataSet(); //記憶體內的資料集合
        DataTable dt = new DataTable(); //dataTable為資料集合內的小單位 



        /// <summary>
        /// 傳入SqlCommand或SP名稱
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmt"></param>
        /// <returns></returns>

        public DataTable querySql(string sql,CommandType cmt)
        {
            //2.執行CRUD
            adp.SelectCommand.CommandType = cmt;  //設定參數cmt為要求傳回的值，預設值為text
            adp.SelectCommand.CommandText = sql; //將參數設定為從DB取到記憶體的資料內的資料
            adp.Fill(ds);  //將adp內搜尋出來的的資料填入ds(記憶體內的資料集合)內
            dt = ds.Tables[0];

            return dt;
        }

        /// <summary>
        /// 傳入SqlCommand或SP名稱,可自行取DataTable名稱
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmt"></param>
        /// <param name="dtName"></param>
        /// <returns></returns>

        public DataTable querySql(string sql, CommandType cmt,string dtName)
        {
            
            adp.SelectCommand.CommandType = cmt;
            adp.SelectCommand.CommandText = sql;
            adp.Fill(ds,dtName);
            dt = ds.Tables[dtName];

            return dt;
        }




        public DataTable querySql(string sql, CommandType cmt, List<SqlParameter> para)
        {
            
            foreach (SqlParameter p in para)
            {
                adp.SelectCommand.Parameters.Add(p);
            }


            adp.SelectCommand.CommandType = cmt;
            adp.SelectCommand.CommandText = sql;
            adp.Fill(ds);
            dt = ds.Tables[0];

            return dt;
        }




    }
}