using many_to_many;
using many_to_many.Models;

using var context = new AppDbContext();

var author = new Author
{
    FirstName = "Henryk",
    LastName = "Sienkiewicz"
};

var books = new List<Book>
{
    new() { Title = "Potop", Description = "Książka o potopie" },
    new() { Title = "Krzyżacy", Description = "Książka o krzyżakach" }
};

author.Books = books;

context.Add(author);
context.SaveChanges();

var authors = context.Authors.ToList();
authors.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName}"));