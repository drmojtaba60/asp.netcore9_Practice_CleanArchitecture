using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPractice.CleanArchitecture.Domain.Entities;
using MyPractice.CleanArchitecture.Domain.ValueObjects;

namespace MyPractice.Persistant.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TodoItem", "Task");
        builder.HasKey(x => x.Id);
        builder.HasOne(p=>p.List)
            .WithMany(p=>p.TodoItems)
            .HasForeignKey(p =>p.ListId);
        
        
    }
}