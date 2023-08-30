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
            return "User not found";

        var token = _tokenService.GenerateToken(user);

        return token;
    }
}