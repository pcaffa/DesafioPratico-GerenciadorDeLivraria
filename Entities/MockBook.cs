using DesafioPratico_GerenciadorDeLivraria.Enums;

namespace DesafioPratico_GerenciadorDeLivraria.Entities;

public static class MockBook
{
    public static List<Book> GetMockBooks()
    {
        return new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "O cérebro do mundo digital",
                Author = "Maryanne Wolf",
                Genre = BookGenre.Fiction,
                Price = 10.99,
                Stock = 25
            },
            new Book
            {
                Id = 2,
                Title = "Julieta",
                Author = "Anne Fortier",
                Genre = BookGenre.Romance,
                Price = 14.99,
                Stock = 10
            },
            new Book
            {
                Id = 3,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Genre = BookGenre.Technology,
                Price = 39.99,
                Stock = 5
            }
        };
    }
}
