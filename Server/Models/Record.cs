using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Record
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Type { get; set; }

        public DateTime Time { get; set; }

        public int X_coordinate { get; set; }

        public int Y_coordinate { get; set; }
    }
}
