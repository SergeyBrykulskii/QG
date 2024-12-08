using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueueGen.Infrastructure.Entities;

namespace QueueGen.Infrastructure.Configurations;

public class CoefficientConfiguration : IEntityTypeConfiguration<Coefficient>
{
    public void Configure(EntityTypeBuilder<Coefficient> builder)
    {
        // Установка первичного ключа
        builder.HasKey(c => c.Id);

        // Настройка связи с пользователем
        builder.HasOne(c => c.User)
            .WithMany(u => u.Coefficients) // Предполагаем, что у пользователя будет коллекция Coefficients
            .HasForeignKey(c => c.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Удаление пользователя удаляет связанные коэффициенты

        // Настройка связи с дисциплиной
        builder.HasOne(c => c.Discipline)
            .WithMany(d => d.Coefficients) // Предполагаем, что у дисциплины будет коллекция Coefficients
            .HasForeignKey(c => c.DisciplineId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // Удаление дисциплины удаляет связанные коэффициенты

        // Настройка свойства Value (коэффициент)
        builder.Property(c => c.Value)
            .IsRequired();

        // Настройка свойства LastSubmissionDate (дата последней сдачи)
        builder.Property(c => c.LastSubmissionDate)
            .IsRequired();
    }
}