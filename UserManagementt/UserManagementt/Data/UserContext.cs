﻿using Microsoft.EntityFrameworkCore;
using UserManagementt.Model;

namespace UserManagementt.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User>Users { get; set; }
    }
}
