using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksandAuthorsVM GetPublisher(int PublisherId)
        {
            //var _publisher = _context.Publishers.Where(n => n.id == PublisherId) 
            //    .Select(n => new PublisherWithBooksandAuthorsVM()  
            //    {
            //        Name = n.Name,
            //        BookAuthors = n.Books.Select(n => new BookAuthorVM()
            //        {
            //           BookName = n.Title,
            //           BookAuthors = n.Book_Author.Select(n => n.Author.FullName).ToList()
            //        }).ToList()
            //    }).FirstOrDefault();
            //return _publisher;

            var _publihser = (from n in _context.Publishers
                              where n.id == PublisherId
                              select new PublisherWithBooksandAuthorsVM()
                              {
                                  Name = n.Name,
                                  BookAuthors = (from a in n.Books
                                                 select new BookAuthorVM()
                                                 {
                                                     BookName = a.Title,
                                                     BookAuthors = (from b in a.Book_Author
                                                                   select b.Author.FullName).ToList()
                                                 }).ToList()
                              }).FirstOrDefault();

            return _publihser;
        }                                                                                                      
    }
}

