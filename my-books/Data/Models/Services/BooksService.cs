using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data.Models.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookwithAuthor(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublsherId
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach(var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<BookWithAuthorsVM> GetAllBooks()
        {
            var allBooks = _context.Books.Select(book => new BookWithAuthorsVM()
                 {
                     Title = book.Title,
                     Description = book.Description,
                     IsRead = book.IsRead,
                     DateRead = book.IsRead ? book.DateRead.Value : null,
                     Rate = book.Rate,
                     Genre = book.Genre,
                     CoverUrl = book.CoverUrl,
                     PublisherName = book.publisher.Name,
                     // LIST AUTHOR FULLNAME
                     AuthorNames = book.Book_Author.Select(n => n.Author.FullName).ToList()
                 }).ToList();
            return allBooks;
        }

        public BookWithAuthorsVM GetBook(int bookId)
        {
            // SELECT BOOK WITH @ID = BOOKID
            // LIST BOOK TITLE DESC IS READ DATAREAD RATE GENERE
            var _bookWithAuthor = _context.Books.Where(n => n.Id == bookId)
                .Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.publisher.Name,
                // LIST AUTHOR FULLNAME
                AuthorNames = book.Book_Author.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthor;
        }

        public Book UpdateBook(BookVM book, int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.Rate;
                _book.Genre = book.Genre;
                _book.CoverUrl = book.CoverUrl;
                _context.SaveChanges();
            };
            return _book;
        }

        public void DeleteBook(int bookId)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
