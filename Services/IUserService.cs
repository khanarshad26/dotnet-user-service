using mydotnet.Models;

namespace mydotnet.Services;
public interface IUserService
{
    User GetById(int id);

    IEnumerable<User> GetAll();

    void Create(Dto model);

    void Update(Dto model, int id);

    void Delete(int id);
}