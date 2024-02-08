using Library.Domain.Messages;

namespace Library.Application.Commands;

public class SignupCommandHandler : IRequestHandler<SignupCommand, ResultViewModel<Unit>>
{
    private readonly LibraryContext _context;

    public SignupCommandHandler(LibraryContext context)
        => _context = context;
    
    public async Task<ResultViewModel<Unit>> Handle(SignupCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _context
            .Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);

        if(userExists)
            return new ResultViewModel<Unit>(ErrorMessages.AlreadyExists(nameof(LoginCommand.Username)));
        
        var user = new User(
            name: request.Name,
            email: request.Email,
            role: request.Role
        );
        
        user.SetPassword(password: BCrypt.Net.BCrypt.HashPassword(request.Password));

        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}