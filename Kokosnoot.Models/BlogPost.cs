using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kokosnoot.Models.Persistence;

namespace Kokosnoot.Models
{
    public class BlogPost : Document
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }
    }
}
