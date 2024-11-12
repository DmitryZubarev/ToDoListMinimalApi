using Microsoft.EntityFrameworkCore;
using TodoApi.Modules.Todos.Models;

namespace TodoApi.Modules.Todos.Data
{
    class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var neededAssembly = typeof(TodoDb).Assembly;
            builder.ApplyConfigurationsFromAssembly(neededAssembly);
        }
    }
}