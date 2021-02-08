using Newtonsoft.Json;
using Playground.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playground.Controllers
{
    //http://www.tutorialsteacher.com/mvc/asp.net-mvc-tutorials
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

        //Function gets a stock data from a "database call" and creates the inputs necessary to build the Highstock Chart on the front end
        [HttpPost]
        public JsonResult GetChartData(string name)
        {
            //Simulate DB Call
            DataTable table = SelectChartData(name);

            ChartData chartData = new ChartData();
            chartData.PriceList = new List<int>();
            chartData.DateList = new List<DateTime>();

            foreach (DataRow dr in table.Rows)
            {
                int price = int.Parse(dr["Price"].ToString());          
                DateTime date = DateTime.Parse(dr["Date"].ToString());

                chartData.PriceList.Add(price);
                chartData.DateList.Add(date);
            }

            //Object returned as 'retData' to the Client
            Chart chart = new Chart();
            chart.Name = name;
            chart.ChartData = chartData;

            return Json(chart, JsonRequestBehavior.AllowGet);
        }

        //This function simulates a DB Call
        public DataTable SelectChartData(string name)
        {
            //Some DB Query would happen with the variable name as input to retrieve the following table

            DataTable table = new DataTable();
            table.Columns.Add("Price", typeof(string)); table.Columns.Add("Date", typeof(string)); 

            table.Rows.Add(new object[] { "9", "2019-07-22" });
            table.Rows.Add(new object[] { "7", "2019-07-23" });
            table.Rows.Add(new object[] { "11", "2019-07-24" });
            table.Rows.Add(new object[] { "7", "2019-07-25" });
            table.Rows.Add(new object[] { "6", "2019-07-26" });
            table.Rows.Add(new object[] { "8", "2019-07-29" });
            table.Rows.Add(new object[] { "8", "2019-07-30" });
            table.Rows.Add(new object[] { "9", "2019-07-31" });
            table.Rows.Add(new object[] { "10", "2019-08-01" });
            table.Rows.Add(new object[] { "12", "2019-08-02" });

            return table;
        }
    }  
}
