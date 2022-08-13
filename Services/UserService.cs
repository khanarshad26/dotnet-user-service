using Microsoft.EntityFrameworkCore.ChangeTracking;
using mydotnet.Models;

namespace mydotnet.Services;

public class UserService : IUserService
{
    private UserDbContext _userDbContext;
    public UserService(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public void Create(Dto model)
    {
        var user = new User{
            Name = model.Name,
            Email = model.Email,
            Password = model.Password
        };
        try{
            var savedUser = _userDbContext.Users.Add(user);
            if(savedUser == null) throw new KeyNotFoundException("User not found");
            _userDbContext.SaveChanges();
        }catch(Exception e){
            throw new Exception("Error during creating User."+e.Message);
        }
    }

    public  IEnumerable<User> GetAll()
    {
        var users = _userDbContext.Users;
        if(users == null) throw new KeyNotFoundException("User not found");
        return users; 
    }

    public User GetById(int id)
    {
        try{
            var user = getUser(id);
            return user;
        }catch(Exception e){
            throw new Exception("Error during getting User."+e.Message);
        }
    }

    public void Update(Dto model, int id)
    {
        var user = getUser(id);
        user.Name = model.Name;
        try{
            _userDbContext.Users.Update(user);
            _userDbContext.SaveChanges();
        }catch(Exception e){
            throw new Exception("Error during updating User."+e.Message);
        }
    }

    public void Delete(int id)
    {
        var user = getUser(id);
        try{
            _userDbContext.Users.Remove(user);
            _userDbContext.SaveChanges();
        }catch(Exception e){
            throw new Exception("Error during deleting User."+e.Message);
        }
        
    }

    private User getUser(int id)
    {
        var user = _userDbContext.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}