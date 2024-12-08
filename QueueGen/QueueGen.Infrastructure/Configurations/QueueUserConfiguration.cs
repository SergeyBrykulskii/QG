using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueGen.Infrastructure.Entities;

namespace QueueGen.Infrastructure.Configurations;

public class QueueUserConfiguration : IEntityTypeConfiguration<QueueUser>
{
    public void Configure(EntityTypeBuilder<QueueUser> builder)
    {
        // Установка первичного ключа
        builder.HasKey(qu => qu.Id);

        // Связь с очередью (Queue)
        builder.HasOne(qu => qu.Queue)
            .WithMany(q => q.QueueUsers)
            .HasForeignKey(qu => qu.QueueId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Удаление очереди удаляет пользователей в очереди

        // Связь с пользователем (User)
        builder.HasOne(qu => qu.User)
            .WithMany(u => u.QueueUsers)
            .HasForeignKey(qu => qu.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Удаление пользователя удаляет его записи в очереди

        // Настройка свойства Position
        builder.Property(qu => qu.Position)
            .IsRequired(); // Убедитесь, что позиция обязательна
    }
}
