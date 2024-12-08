using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueGen.Infrastructure.Entities;

namespace QueueGen.Infrastructure.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        // Установка первичного ключа
        builder.HasKey(g => g.Id);

        // Связь с администратором (User)
        builder.HasOne(g => g.Admin)
            .WithMany()
            .HasForeignKey(g => g.AdminId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Удаление группы удаляет администратора

        // Связь с пользователями (User)
        builder.HasMany(g => g.Users)
            .WithOne(u => u.Group)
            .HasForeignKey(u => u.GroupId)
            .OnDelete(DeleteBehavior.Cascade); // Удаление группы удаляет пользователей

        // Связь с дисциплинами (Discipline)
        builder.HasMany(g => g.Disciplines)
            .WithOne(d => d.Group)
            .HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.Cascade); // Удаление группы удаляет дисциплины

        // Настройка свойства Name
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100); // Ограничение длины строки
    }
}
