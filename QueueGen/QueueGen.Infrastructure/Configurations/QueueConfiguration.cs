using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueGen.Infrastructure.Entities;

namespace QueueGen.Infrastructure.Configurations;

public class QueueConfiguration : IEntityTypeConfiguration<Queue>
{
    public void Configure(EntityTypeBuilder<Queue> builder)
    {
        // Установка первичного ключа
        builder.HasKey(q => q.Id);

        // Связь с дисциплиной (Discipline)
        builder.HasOne(q => q.Discipline)
            .WithMany(d => d.Queues)
            .HasForeignKey(q => q.DisciplineId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Удаление дисциплины удаляет очереди

        // Связь с пользователями через QueueUser
        builder.HasMany(q => q.QueueUsers)
            .WithOne(qu => qu.Queue)
            .HasForeignKey(qu => qu.QueueId)
            .OnDelete(DeleteBehavior.Cascade); // Удаление очереди удаляет пользователей в очереди

        // Настройка свойства LastClassDate
        builder.Property(q => q.LastClassDate)
            .IsRequired(); // Убедитесь, что дата обязательно присутствует
    }
}
