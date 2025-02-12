using LemonadeStand.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonadeStand.Data.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable("Order");
			builder.HasKey(li => li.Id);
			builder.Property(x => x.FirstName)
				.IsRequired()
				.HasColumnType("varchar(50)")
				.HasColumnName("FirstName");
			builder.Property(x => x.LastName)
				.IsRequired()
				.HasColumnType("varchar(75)")
				.HasColumnName("LastName");
			builder.Property(x => x.Phone)
				.HasColumnType("varchar(75)")
				.HasColumnName("Phone");
			builder.Property(x => x.Email)
				.HasColumnType("varchar(75)")
				.HasColumnName("Email");
			builder.Property(l => l.Created)
				.IsRequired()
				.HasColumnType("datetime")
				.HasColumnName("Created")
				.HasDefaultValueSql("date('now')")
				.ValueGeneratedOnAdd();
			builder.Property(l => l.Udpdated)
				.HasColumnType("datetime")
				.HasColumnName("Updated")
				.HasDefaultValueSql("date('now')")
				.ValueGeneratedOnAddOrUpdate();
			builder.Property(l => l.Deleted)
				.HasColumnType("datetime")
				.HasColumnName("Deleted")
				.HasDefaultValueSql(null);
		}
	}
}

