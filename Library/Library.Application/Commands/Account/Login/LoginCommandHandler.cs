using Library.Domain.ErrorMessages;

namespace Library.Application.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly LibraryContext _context;
    private readonly TokenService _tokenService;
    
    public LoginCommandHandler(
        LibraryContext context, 
        TokenService tokenService
    )
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == request.Username, cancellationToken);

        if (user is null)
            return ErrorMessages.NotFound<User>();

        var verifyPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

        if (!verifyPassword)
            return "Wrong password or username";

        var token = _tokenService.GenerateToken(user);

        return token;
    }
}