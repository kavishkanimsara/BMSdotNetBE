using BookManagementApp.Db;
using BookManagementApp.Dtos;
using BookManagementApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementApp.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            return _context.Books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                PublicationDate = b.PublicationDate
            }).ToList();
        }

        public BookDto AddBook(BookCreateDto newBook)
        {
            var book = new Book
            {
                Title = newBook.Title,
                Author = newBook.Author,
                ISBN = newBook.ISBN,
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate
            };

        }

        public BookDto UpdateBook(int id, BookCreateDto newBook)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            book.Title = newBook.Title;
            book.ISBN = newBook.ISBN;
            book.Author = newBook.Author;

            _context.SaveChanges();

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate
            };
        }

        public BookDto GetBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return null;
            }

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublicationDate = book.PublicationDate
            };
        }

        public bool DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return false;
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }


    }
}
