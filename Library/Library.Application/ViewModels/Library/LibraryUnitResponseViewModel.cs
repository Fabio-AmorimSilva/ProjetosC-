using Library.Domain.Entities;

namespace Library.Application.ViewModels.Library;

public struct LibraryUnitResponseViewModel
{
    public string Name { get; init; }
    public string City { get; init; }
    public List<Book> Books { get; init; }
}
