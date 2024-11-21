using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IUserService
    {
        public IQueryable<UserModel> Query();
        public ServiceBase Create(User record);
        public ServiceBase Update(User record);

        public ServiceBase Delete(int Id);
    }
    public class UserService : ServiceBase, IUserService
    {
        public UserService(Db db) : base(db) 
        { 
        }

        public ServiceBase Create(User record)
        {
            if (_db.Users.Any(u => u.Name.ToUpper() == record.Name.ToUpper().Trim()))
            {
                return Error("User with the same name exixts");
            }
            record.Name = record.Name?.Trim();
            _db.Users.Add(record);
            _db.SaveChanges();
            return Success("User created successfully");
        }

        public ServiceBase Delete(int Id)
        {
            var entity = _db.Users.Include(u => u.Posts).SingleOrDefault(u => u.Id == Id);
            if (entity is null)
                return Error("User cannot be found");
            if (entity.Posts.Any())
                return Error("User has a relation with Posts!");
            _db.Users.Remove(entity);
            _db.SaveChanges();
            return Success("User is deleted successfully");
        }

        public IQueryable<UserModel> Query()
        {
           return _db.Users.OrderBy(u => u.Name).Select(u => new UserModel() { Record = u});
        }

        public ServiceBase Update(User record)
        {
            if (_db.Users.Any(u => u.Id != record.Id && u.Name.ToUpper() == record.Name.ToUpper().Trim()))
            {
                return Error("User with the same name exists!");
            }
            var entity = _db.Users.SingleOrDefault(u => u.Id == record.Id);
            if (entity is null)
                return Error("User cannot be found!");
            entity.Name = record.Name?.Trim();
            _db.Users.Update(entity);
            _db.SaveChanges();
            return Success();
        }
    }
}
