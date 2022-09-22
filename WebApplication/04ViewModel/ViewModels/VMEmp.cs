using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _04ViewModel.Models;

namespace _04ViewModel.ViewModels
{
    public class VMEmp
    {
        public List<tDepartment> department { get; set; }  //將資料型別改為tDepartment的資料型別，並作List
        public List<tEmployee> employee { get; set; }
    }
}