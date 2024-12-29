using DesafioPratico_GerenciadorDeLivraria.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPratico_GerenciadorDeLivraria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private static List<Book> BooksInMemory = MockBook.GetMockBooks();

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult GetBookById([FromRoute] int id)
    {
        try
        {
            var books = BooksInMemory;
            var book = books.Where(x => x.Id == id)?.FirstOrDefault();

            if (book == null)
                return NotFound("Não há livro com o id informado!");

            return Ok(new BookResponse(book));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("lista-de-livros")]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public IActionResult GetBookList()
    {
        try
        {
            var books = BooksInMemory;

            var responses = new List<BookResponse>();

            if (!books.Any())
                return NotFound("Não há livro com o id informado!");

            foreach (var book in books)
            {
                responses.Add(new BookResponse(book));
            }

            return Ok(responses);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(BookResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult PostBook([FromBody] BookInsertRequest book)
    {
        int newId = 1;

        if (BooksInMemory.Any())
            newId = BooksInMemory.LastOrDefault().Id + 1;

       
        BooksInMemory.Add(new Book
        {
            Id = newId,
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            Stock = book.Stock
        });

        var response = new BookResponse(book);

        return Created(string.Empty, response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateBook([FromBody] BookUpdateRequest bookUpdate)
    {
        var book = BooksInMemory.FirstOrDefault(b => b.Id == bookUpdate.Id);
        if (book == null)
            return NotFound();

        book.Price = bookUpdate.Price;
        book.Stock = bookUpdate.Stock;

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteBook([FromRoute] int id)
    {
        var book = BooksInMemory.FirstOrDefault(b => b.Id == id);
        if (book == null)
            return NotFound();

        BooksInMemory.Remove(book);

        return NoContent();
    }
}
