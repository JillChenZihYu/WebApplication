using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;

namespace WinFormAPP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55489/api/values");

            HttpResponseMessage response = client.GetAsync("http://localhost:55489/api/values").Result;    //GetAsync非同步
            IEnumerable<Customers> data = null;

            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsAsync<IEnumerable<Customers>>().Result;

                foreach (var item in data)
                { 
                listBox1.Items.Add("客戶名稱："+item.CompanyName+",聯絡人："+item.ContactName+",職稱："+item.ContactTitle);
                }
            }
        }



        public class Customers
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public object Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public object[] Orders { get; set; }
        }


    }
}
