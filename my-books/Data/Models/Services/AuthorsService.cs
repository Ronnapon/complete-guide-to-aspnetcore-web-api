using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthoWithBooksVM GetAuthor(int AuthorId)
        {
            var _authorWithBook = _context.Authors.Where(n => n.Id == AuthorId)
                .Select(author => new AuthoWithBooksVM()
                {
                    FullName = author.FullName,
                    // สามารถนำ Field มาใช้ได้เลย เนื่องจากใน Model มีการสร้าง Nevigator  ญพไว้แล้ว
                    BookTitle = author.Book_Author.Select(n => n.Book.Title).ToList()
                    //Books = author.Book_Author.Join(_context.Books, 
                    //a => a.BookId, 
                    //c => c.Id,
                    //(Book_Author, book) => new BookWithAuthorsVM()
                    //{
                    //    Title = book.Title,
                    //    Description = book.Description,
                    //    IsRead = book.IsRead,
                    //    DateRead = book.IsRead ? book.DateRead.Value : null,
                    //    Rate = book.Rate,
                    //    Genre = book.Genre,
                    //    CoverUrl = book.CoverUrl,
                    //    PublisherName = book.publisher.Name,
                    //    AuthorNames = book.Book_Author.Select(n => n.Author.FullName).ToList()
                    //}).ToList()
                }).FirstOrDefault();
            return _authorWithBook;
        }
    }
}
