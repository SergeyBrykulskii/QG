using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueGen.Infrastructure.Entities;

namespace QueueGen.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Установка первичного ключа
        builder.HasKey(u => u.Id);

        // Связь с группой (Group)
        builder.HasOne(u => u.Group)
            .WithMany(g => g.Users)
            .HasForeignKey(u => u.GroupId);

        // Связь с QueueUser
        builder.HasMany(u => u.QueueUsers)
            .WithOne(qu => qu.User)
            .HasForeignKey(qu => qu.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Удаление пользователя удаляет его записи в очереди

        // Связь с Coefficient
        builder.HasMany(u => u.Coefficients)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Удаление пользователя удаляет его коэффициенты

        // Настройка свойства Nickname
        builder.Property(u => u.Nickname)
            .HasMaxLength(100); // Ограничение длины строки
    }
}