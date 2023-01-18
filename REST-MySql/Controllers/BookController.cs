using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_MySql.Models;
using REST_MySql.Services;
using Microsoft.AspNetCore.Mvc.Versioning;


namespace REST_MySql.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BookController : ControllerBase
    {

        private readonly MyDbContext _myDbContext;
        public BookController(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            _myDbContext.Database.EnsureCreated();
        }
        [MapToApiVersion("1.0")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            return await _myDbContext.Books.ToListAsync();

        }

        [MapToApiVersion("1.0")]
        [HttpGet("{id}")]
        [Route("GetBookById")]

        public async Task<ActionResult> GetBookById(int id)
        {
            var book = await _myDbContext.Books.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            return Ok(book);


        }
        [MapToApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
        [HttpPut("{id}")]
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
        [MapToApiVersion("1.0")]
        [HttpDelete("{id}")]
        [Route("DeleteById")]

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

        [MapToApiVersion("1.0")]
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> DeleteMultipleBooks([FromQuery] int[] ids)
        {
            var books = new List<Book>();
            foreach (var id in ids)
            {
                var book = await _myDbContext.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }

                books.Add(book);
            }

            _myDbContext.Books.RemoveRange(books);
            await _myDbContext.SaveChangesAsync();

            return Ok(books);
        }



    }

}
