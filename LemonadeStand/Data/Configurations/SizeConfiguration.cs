using LemonadeStand.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonadeStand.Data.Configurations
{
	public class SizeConfiguration : IEntityTypeConfiguration<Size>
	{
		public SizeConfiguration()
		{
		}

		public void Configure(EntityTypeBuilder<Size> builder)
		{
			builder.ToTable("Size");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name)
					.IsRequired()
					.HasColumnType("varchar(50)")
					.HasColumnName("Name");
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
				.HasColumnName("Deleted");

			builder.HasData(new Size
			{
				Id = 1,
				Name = "Regular Size",
				Created = DateTime.Now,
				Udpdated = DateTime.Now
			}, new Size
			{
				Id = 2,
				Name = "Large Size",
				Created = DateTime.Now,
				Udpdated = DateTime.Now
			});
		}
	}
}

