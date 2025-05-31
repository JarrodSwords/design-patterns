using DesignPatterns.Builder3.Domain;
using Jgs.Errors;
using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Infrastructure.Write;

public class UserRepository(Context context) : IUserRepository
{
    public Result Create(Domain.User user)
    {
        if (context.User.Any(x => x.Id == user.Id))
            return UserAlreadyExists(user.Id);

        context.User.Add(user);

        return Result.Success();
    }

    public Result<Domain.User> Find(UserId id) => throw new NotImplementedException();

    private static Error UserAlreadyExists(uint id) =>
        new(
            "user.already.exists",
            $"User {id} already exists."
        );
}
