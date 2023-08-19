using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class News
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Body { get; set; }
    }
}