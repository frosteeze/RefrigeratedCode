using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefrigeratedCode.Models
{
    public class BlogPost
    {
        public int PostId { get; set; }
        public DateTime PostedOn { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public DateTime? EditedOn { get; set; }
    }
}
