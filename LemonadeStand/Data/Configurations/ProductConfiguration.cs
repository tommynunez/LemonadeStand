
using System;
using LemonadeStand.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonadeStand.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("Product");
			builder.HasKey(li => li.Id);
			builder.Property(l => l.LemonadeTypeId)
				.IsRequired()
				.HasColumnType("int")
				.HasColumnName("LemonadeTypeId");
			builder.Property(l => l.SizeId)
				.IsRequired()
				.HasColumnType("int")
				.HasColumnName("SizeId");
			builder.Property(l => l.Amount)
				.IsRequired()
				.HasColumnType("float")
				.HasColumnName("Amount");
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
				.ValueGeneratedOnAddOrUpdate(); ;
			builder.Property(l => l.Deleted)
				.HasColumnType("datetime")
				.HasColumnName("Deleted");

			builder.HasMany(x => x.LineItems)
				.WithOne(x => x.Product);

			builder.HasOne(x => x.LemonadeTypes)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.LemonadeTypeId)
				.HasConstraintName("ForeignKey_Product_LemonadeTypes");

			builder.HasOne(x => x.Sizes)
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.SizeId)
				.HasConstraintName("ForeignKey_Product_Sizes");

			builder.HasOne(x => x.Sizes);

			builder.HasData(new Product
			{
				Id = 1,
				LemonadeTypeId = 1,
				SizeId = 1,
				Amount = 0.75,
				Created = DateTime.Now,
				Udpdated = DateTime.Now
			},
			new Product
			{
				Id = 2,
				LemonadeTypeId = 1,
				SizeId = 2,
				Amount = 1.50,
				Created = DateTime.Now,
				Udpdated = DateTime.Now
			}, new Product
			{
				Id = 3,
				LemonadeTypeId = 2,
				SizeId = 1,
				Amount = 0.75,
				Created = DateTime.Now,
				Udpdated = DateTime.Now
			}, new Product
			{
				Id = 4,
				LemonadeTypeId = 2,
				SizeId = 2,
				Amount = 1.50,
				Created = DateTime.Now,
				Udpdated = DateTime.Now
			});
		}
	}
}

