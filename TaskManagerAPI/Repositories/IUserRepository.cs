public interface IUserRepository
{
    Task<User> GetById(int id);
    Task Create(User user);
}
