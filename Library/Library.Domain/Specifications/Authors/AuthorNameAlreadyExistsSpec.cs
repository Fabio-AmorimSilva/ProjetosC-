namespace Library.Domain.Specifications.Authors;

public sealed class AuthorNameAlreadyExistsSpec : Specification<Author>
{
    public AuthorNameAlreadyExistsSpec(
        Guid id, 
        string name
    ) =>  Query.Where(a => a.Id != id && a.Name == name);
}