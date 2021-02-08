using System;
using System.Collections.Generic;

namespace Playground.Models
{
    public class Chart
    {
        public string Name { get; set; }
        public ChartData ChartData { get; set; }
    }

    public class ChartData
    {
        public List <int> PriceList { get; set; }
        public List <DateTime> DateList { get; set; }

        public ChartData()
        {
            PriceList = new List<int>();
            DateList = new List<DateTime>();
        }
    }
}
