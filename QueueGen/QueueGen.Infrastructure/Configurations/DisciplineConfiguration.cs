using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueGen.Infrastructure.Entities;

namespace QueueGen.Infrastructure.Configurations;

public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.HasKey(d => d.Id);

        // Настройка связи с группой (GroupId)
        builder.HasOne(d => d.Group)
            .WithMany(g => g.Disciplines)
            .HasForeignKey(d => d.GroupId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Удаление дисциплины удаляет связанные записи
        
        // Настройка свойства Name
        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100); // Ограничение длины строки

        // Описание может быть nullable
        builder.Property(d => d.Description)
            .HasMaxLength(500); // Ограничение длины строки
    }
}