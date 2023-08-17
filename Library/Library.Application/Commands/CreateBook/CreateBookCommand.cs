namespace Library.Application.Commands.CreateBook;

public struct CreateBookCommand : IRequest<ResultViewModel<Guid>>
{
    public string Title { get; init; }
    public DateTime Year { get; init; } 
    public int Pages { get; init; }
    public Guid AuthorId { get; init; }
    public Guid LibraryId { get; init; }
    public BookGenre Genre { get; init; }

    public CreateBookCommand(
        string title, 
        DateTime year, 
        int pages, 
        Guid authorId, 
        Guid libraryId, 
        BookGenre genre
    )
    {
        Title = title;
        Year = year;
        Pages = pages;
        AuthorId = authorId;
        LibraryId = libraryId;
        Genre = genre;
    }
}