namespace Library.Application.Commands.Account.Login;

public class LoginCommandHandler(
    LibraryContext context,
    TokenService tokenService
) : IRequestHandler<LoginCommand, string>
{
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == request.Username, cancellationToken);

        if (user is null)
            return ErrorMessages.NotFound<User>();

        var verifyPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

        if (!verifyPassword)
            return "Wrong password or username";

        var token = tokenService.GenerateToken(user);

        return token;
    }
}