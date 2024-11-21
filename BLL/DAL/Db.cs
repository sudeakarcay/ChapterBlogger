﻿using Microsoft.EntityFrameworkCore;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UsersBook { get; set; }

        public DbSet<Role> Roles { get; set; }
        public Db(DbContextOptions options) : base(options)
        {

        }
    }
}
