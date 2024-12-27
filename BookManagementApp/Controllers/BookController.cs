using BookManagementApp.Dtos;
using BookManagementApp.Models;
using BookManagementApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooks(int id)
        {
            var book = _bookService.GetBookById(id);
            if(book == null)
            {
                return NotFound("Book not found !");
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBooks(BookCreateDto newBook)
        {
            var book = _bookService.AddBook(newBook);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id , BookCreateDto request)
        {
            var book = _bookService.UpdateBook(id, request);
            if (book == null)
            {
                return NotFound("Book not found.");
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var success = _bookService.DeleteBook(id);

            if (!success)
            {
                return NotFound("Book not found");
            }

            return Ok("Book deleted Successfully !");
        }
    }
}
