using Library.Application.Commands.Account.Login;

namespace Library.Application.Commands.Account.Signup;

public class SignupCommandHandler(LibraryContext context) : IRequestHandler<SignupCommand, ResultViewModel<Unit>>
{
    public async Task<ResultViewModel<Unit>> Handle(SignupCommand request, CancellationToken cancellationToken)
    {
        var userExists = await context
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

        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return new ResultViewModel<Unit>();
    }
}