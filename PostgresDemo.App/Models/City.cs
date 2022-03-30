using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace PostgresDemo.App.Models
{
    public partial class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public NpgsqlPoint Location { get; set; }
    }
}
