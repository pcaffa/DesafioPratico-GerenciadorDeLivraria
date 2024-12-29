using DesafioPratico_GerenciadorDeLivraria.Enums;

namespace DesafioPratico_GerenciadorDeLivraria.Entities;

public class BookResponse
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }

    public BookResponse(Book book)
    {
        Title = book.Title;
        Author = book.Author;
        Genre = book.Genre;
        Price = book.Price;
        Stock = book.Stock;
    }

    public BookResponse(BookInsertRequest book)
    {
        Title = book.Title;
        Author = book.Author;
    }

    public BookResponse(BookUpdateRequest book)
    {
        Price = book.Price;
        Stock = book.Stock;
    }
}
