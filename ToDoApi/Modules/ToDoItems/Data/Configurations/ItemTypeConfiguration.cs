using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.Modules.ToDoItems.Models;

namespace ToDoApi.Modules.ToDoItems.Data.Configurations
{
    public class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType>
    {
        public void Configure(EntityTypeBuilder<ItemType> builder)
        {
            builder.ToTable("ItemTypes");

            builder.HasKey(e => e.Id);
            builder
                .HasMany(e => e.Items)
                .WithOne(e => e.Type)
                .HasForeignKey(e => e.TypeId)
                .IsRequired();

            builder.Property(e => e.Name).IsRequired();

            builder.HasIndex(e => e.Name);

            
        }
    }
}
