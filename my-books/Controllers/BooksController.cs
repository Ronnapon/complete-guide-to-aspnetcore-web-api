using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    // api/books/api-enpoint
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book")]
        // Shceme ถูกสร้างจาก [FromBody] BookVM
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookwithAuthor(book);
            return Ok();
        }

        [HttpGet("get-book-all")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _booksService.GetAllBooks();
            return Ok(allbooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBook(int id)
        {
            var allbooks = _booksService.GetBook(id);
            return Ok(allbooks);
        }

        [HttpPut("update-book/{id}")]
        public IActionResult UpdateBook([FromBody] BookVM book, int id)
        {
            _booksService.UpdateBook(book, id);
            return Ok();
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _booksService.DeleteBook(id);
            return Ok();
        }
    }
}
