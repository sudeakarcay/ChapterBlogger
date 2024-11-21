using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface IPostService
    {
        public IQueryable<PostModel> Query();
        public ServiceBase Create(Post record);
        public ServiceBase Update(Post record);

        public ServiceBase Delete(int Id);
    }
    public class PostService : ServiceBase, IPostService
    {
        public PostService(Db db) : base(db)
        {
        }
        public ServiceBase Create(Post record)
        {
            if (_db.Posts.Any(u => u.BookTitle.ToUpper() == record.BookTitle.ToUpper().Trim()))
            {
                return Error("Post with the same book title exixts");
            }
            record.BookTitle = record.BookTitle?.Trim();
            _db.Posts.Add(record);
            _db.SaveChanges();
            return Success("Post created successfully");
        }

        public ServiceBase Delete(int Id)
        {
            var entity = _db.Posts.Include(u => u.Posts).SingleOrDefault(u => u.Id == Id);
            if (entity is null)
                return Error("Post cannot be found");
            if (entity.Posts.Any())
                return Error("Post has a relation with Users!");
            _db.Posts.Remove(entity);
            _db.SaveChanges();
            return Success("Post is deleted successfully");
        }

        public IQueryable<PostModel> Query()
        {
            return _db.Posts.OrderBy(u => u.BookTitle).Select(u => new PostModel() { Record = u });
        }

        public ServiceBase Update(Post record)
        {
            if (_db.Posts.Any(u => u.Id != record.Id && u.BookTitle.ToUpper() == record.BookTitle.ToUpper().Trim()))
            {
                return Error("Post with the same book title exists!");
            }
            var entity = _db.Posts.SingleOrDefault(u => u.Id == record.Id);
            if (entity is null)
                return Error("Post cannot be found!");
            entity.BookTitle = record.BookTitle?.Trim();
            _db.Posts.Update(entity);
            _db.SaveChanges();
            return Success();
        }
    }
}
