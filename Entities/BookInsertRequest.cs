﻿using DesafioPratico_GerenciadorDeLivraria.Enums;

namespace DesafioPratico_GerenciadorDeLivraria.Entities;

public sealed class BookInsertRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public BookGenre Genre { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
}
