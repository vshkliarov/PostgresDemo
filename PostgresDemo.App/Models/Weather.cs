using System;
using System.Collections.Generic;

namespace PostgresDemo.App.Models
{
    public partial class Weather
    {
        public int WeatherId { get; set; }
        public string City { get; set; }
        public int TempLo { get; set; }
        public int TempHi { get; set; }
        public float Prcp { get; set; }
        public DateOnly Date { get; set; }
    }
}
