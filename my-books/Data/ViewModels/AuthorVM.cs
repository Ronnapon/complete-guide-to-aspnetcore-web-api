using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.ViewModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthoWithBooksVM
    {
        public string FullName { get; set; }

        public List<string> BookTitle { get; set; }
       
        // public List<BookWithAuthorsVM> Books { get; set; }
    }
}
