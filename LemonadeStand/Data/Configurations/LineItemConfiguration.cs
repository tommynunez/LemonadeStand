using LemonadeStand.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LemonadeStand.Data.Configurations
{
  public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
  {
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
      builder.ToTable("LineIitem");
      builder.HasKey(li => li.Id);
      builder.Property(l => l.ProductId)
       .IsRequired()
       .HasColumnType("int")
       .HasColumnName("ProductId");
      builder.Property(l => l.OrderId)
       .IsRequired()
       .HasColumnType("int")
       .HasColumnName("OrderId");
      builder.Property(l => l.Quantity)
       .IsRequired()
       .HasColumnType("int")
       .HasColumnName("Quantity");
      builder.Property(l => l.Cost)
       .IsRequired()
       .HasColumnType("float")
       .HasColumnName("Cost");
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

      builder.HasOne(li => li.Order)
       .WithMany(x => x.LineItems)
       .HasForeignKey(x => x.OrderId)
       .HasConstraintName("ForeignKey_Order_LineItems");
      builder.HasOne(li => li.Product)
       .WithMany(x => x.LineItems)
       .HasForeignKey(x => x.ProductId)
       .HasConstraintName("ForeignKey_Product_LineItems");
    }
  }
}

