namespace Library.Application.Commands.Account.Login;

public class LoginCommandHandler(
    LibraryContext context,
    TokenService tokenService
) : IRequestHandler<LoginCommand, ResultResponse<string>>
{
    public async Task<ResultResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == request.Username, cancellationToken);

        if (user is null)
            return new NotFoundResponse<string>(ErrorMessages.NotFound<User>());

        var verifyPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

        if (!verifyPassword)
            return new ConflictResponse<string>("Wrong password or username");

        var token = tokenService.GenerateToken(user);

        return new OkResponse<string>(token);
    }
}