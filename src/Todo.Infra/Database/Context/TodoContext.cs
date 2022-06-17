using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Utilities;
using Todo.Domain.Common;
using Todo.Domain.Entities;

namespace Todo.Infra.Database.Context
{
    public class TodoContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TodoContext(DbContextOptions<TodoContext> options) : base(options){ }

        public TodoContext(DbContextOptions<TodoContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                var user = _httpContextAccessor?.HttpContext.User?.Identity?.Name ?? "admin";

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = user;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = user;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
