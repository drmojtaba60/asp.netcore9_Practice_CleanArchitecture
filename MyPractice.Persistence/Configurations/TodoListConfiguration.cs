using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyPractice.CleanArchitecture.Domain.Entities;
using MyPractice.CleanArchitecture.Domain.ValueObjects;

namespace MyPractice.Persistant.Configurations;

public class TodoListConfiguration : IEntityTypeConfiguration<TodoList>
{
    public void Configure(EntityTypeBuilder<TodoList> builder)
    {
        builder.ToTable("TodoList", "Task");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .HasMaxLength(255);
        
        
        var colourConverter = new ValueConverter<Colour, string>(
            c => c.Code,         // از Colour به string (برای ذخیره در DB)
            s => Colour.From(s)  // از string به Colour (برای بارگذاری از DB)
        );

        builder
            .Property(x => x.Colour)
            .HasConversion(colourConverter)
            .HasMaxLength(7); // طول کدهای رنگ مثل #FFFFFF
    }
}