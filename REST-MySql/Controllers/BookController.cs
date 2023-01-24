using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_MySql.Models;
using REST_MySql.Services;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.ComponentModel.DataAnnotations;

namespace REST_MySql.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]  //only one for each controller
    [Route("api/v{version:apiVersion}/[Controller]/[Action]")]
    public class BookController : ControllerBase
    {

        private readonly MyDbContext _myDbContext;
        public BookController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {         
            return await _myDbContext.Books.ToListAsync();

        }

        [HttpGet]
        public async Task<ActionResult> GetBookById(int id)
        {
            var book = await _myDbContext.Books.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return Ok(book);


        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostProduct(Book book)
        {
            _myDbContext.Books.Add(book);
            await _myDbContext.SaveChangesAsync();

            return CreatedAtAction(
                "GetBookById",
                new { id = book.Id },
                book);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(int id, Book book)
        {
            var bookToBeUpdate = await _myDbContext.Books.FindAsync(id);
            if (bookToBeUpdate != null)
            {
                bookToBeUpdate.Title = book.Title;
                bookToBeUpdate.Language = book.Language;
                bookToBeUpdate.Author = book.Author;
                await _myDbContext.SaveChangesAsync();
                return Ok(book);
            }
            return NotFound();

        }
        [HttpDelete]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _myDbContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _myDbContext.Books.Remove(book);
            await _myDbContext.SaveChangesAsync();

            return book;
        }


        [HttpPost]
        public async Task<ActionResult> DeleteMultipleBooks([FromQuery] int[] ids)
        {
            var books = new List<Book>();
            foreach (var id in ids)
            {
                var bookToBeDeleted = await _myDbContext.Books.FindAsync(id);

                if (bookToBeDeleted == null)
                {
                    return NotFound();
                }

                books.Add(bookToBeDeleted);
            }

            _myDbContext.Books.RemoveRange(books);
            await _myDbContext.SaveChangesAsync();

            return Ok(books);



        }

        [HttpPost]
        public ActionResult DeleteAll()
        {
            IEnumerable<Book> bookList = _myDbContext.Books.Where(i => i.Id != null);
            foreach (var Item in bookList)
            {

                _myDbContext.Books.Remove(Item);
            }

            _myDbContext.SaveChanges();
            return Ok();

        }
    }


}


