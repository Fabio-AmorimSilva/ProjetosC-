namespace Library.Application.Commands;

public class UpdateBookCommand : IRequest<ResultViewModel<Unit>>
{
    public Guid Id { get; set; }
    public string Title { get; init; }
    public DateTime Year { get; init; } 
    public int Pages { get; init; }
    public Guid AuthorId { get; init; }
    public Guid LibraryId { get; init; }
    public BookGenre Genre { get; init; }

    public UpdateBookCommand(
        Guid id, 
        string title, 
        DateTime year, 
        int pages, 
        Guid authorId, 
        Guid libraryId, 
        BookGenre genre
    )
    {
        Id = id;
        Title = title;
        Year = year;
        Pages = pages;
        AuthorId = authorId;
        LibraryId = libraryId;
        Genre = genre;
    }
}