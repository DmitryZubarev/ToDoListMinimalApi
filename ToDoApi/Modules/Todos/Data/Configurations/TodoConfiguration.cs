using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Modules.Todos.Models;

namespace TodoApi.Modules.Todos.Data.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.ToTable("Todos");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.IsComplete)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(t => t.Name).IsRequired().HasDefaultValue("Unknown todo item");

            builder.HasIndex(t => t.Name);
        }
    }
}
