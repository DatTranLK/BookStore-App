using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BusinessObject.Models
{
    public partial class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext()
        {
        }

        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookInStore> BookInStores { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<RequestBook> RequestBooks { get; set; }
        public virtual DbSet<RequestBookDetail> RequestBookDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =MMOONALTER; database = BookStoreDB;uid=sa;pwd=huytmse150802;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Avatar).HasColumnType("ntext");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Account_Role");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Account_Store");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Author).HasMaxLength(100);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(20)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.ReleaseYear)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Book_Category");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK_Book_Publisher");
            });

            modelBuilder.Entity<BookInStore>(entity =>
            {
                entity.ToTable("BookInStore");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookInStores)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BookInStore_Book");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.BookInStores)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_BookInStore_Store");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus).HasMaxLength(50);

                entity.Property(e => e.ShippingAddress).HasColumnType("ntext");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Account");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.OrderStaffs)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Order_Staff");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_OrderDetail_Book");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<RequestBook>(entity =>
            {
                entity.ToTable("RequestBook");

                entity.Property(e => e.AddBookState).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.RequestBooks)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_RequestBook_Account");
            });

            modelBuilder.Entity<RequestBookDetail>(entity =>
            {
                entity.ToTable("RequestBookDetail");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.RequestBookDetails)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_RequestBookDetail_Book");

                entity.HasOne(d => d.RequestBook)
                    .WithMany(p => p.RequestBookDetails)
                    .HasForeignKey(d => d.RequestBookId)
                    .HasConstraintName("FK_RequestBookDetail_ReqBook");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Address).HasColumnType("ntext");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
