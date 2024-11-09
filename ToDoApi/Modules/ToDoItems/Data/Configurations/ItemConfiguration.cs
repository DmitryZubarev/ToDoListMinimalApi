using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApi.Modules.ToDoItems.Models;

namespace ToDoApi.Modules.ToDoItems.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(x => x.Id);
            builder
                .HasOne(e => e.Type)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.TypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.Property(e => e.Header).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            //Item.Deadline can be null

            builder.HasIndex(e => e.Header);

        }
    }
}
