using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models
{
    public class Publisher
    {
        public int id { get; set; }
        public string Name { get; set; }

        //  Navigation Properties
        public List<Book> Books { get ;set;}
    }
}
