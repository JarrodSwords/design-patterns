using Jgs.Errors.Results;

namespace DesignPatterns.Builder3.Domain;

public interface IUserRepository
{
    Result Create(User user);
    Result<User> Find(UserId id);
}
