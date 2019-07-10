using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOWEB.Models
{
    public class Todolist
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
        public int personId { get; set; }
    }
}
