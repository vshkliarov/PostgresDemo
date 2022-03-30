using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace PostgresDemo.App.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
    }
}
