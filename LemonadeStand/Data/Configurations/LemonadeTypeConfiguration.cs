using System;
using LemonadeStand.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonadeStand.Data.Configurations
{
	public class LemonadeTypeConfiguration : IEntityTypeConfiguration<LemonadeType>
	{
		public LemonadeTypeConfiguration()
		{
		}

		public void Configure(EntityTypeBuilder<LemonadeType> builder)
		{
			builder.ToTable("LemonadeType");
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

			builder.HasData(new LemonadeType
			{
				Id = 1,
				Name = "Regular Lemonade",
				Created = DateTime.Now,
				Udpdated = DateTime.Now
			}, new LemonadeType
			{
				Id = 2,
				Name = "Pink Lemonade",
				Created = DateTime.Now,
				Udpdated = DateTime.Now
			});
		}
	}
}

