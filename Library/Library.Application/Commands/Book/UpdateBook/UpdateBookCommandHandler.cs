﻿using Library.Domain.Messages;

namespace Library.Application.Commands;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public UpdateBookCommandHandler(LibraryContext context)
        =>  _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (book is null)
            return new ResultViewModel<Unit>(ErrorMessages.NotFound<User>());
        
        var result = book.UpdateBook(
            title: request.Title, 
            year: request.Year, 
            pages: request.Pages,
            authorId: request.AuthorId, 
            libraryId: request.LibraryId, 
            genre: request.Genre
        );

        if (result is { Success: false, Message: not null })
            return new ResultViewModel<Unit>(result.Message);
        
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>("Book has been updated!");
    }
}