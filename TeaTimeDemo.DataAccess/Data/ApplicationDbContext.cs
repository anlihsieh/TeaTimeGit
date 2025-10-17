using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.Models;
namespace TeaTimeDemo.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CustomTemplate> CustomTemplates { get; set; }
        public DbSet<CustomGroup> CustomGroups { get; set; }
        public DbSet<CustomOption> CustomOptions { get; set; }
        public DbSet<CustomTemplateGroup> CustomTemplateGroups { get; set; }
        public DbSet<ProductCustomGroup> ProductCustomGroups { get; set; }
        public DbSet<ShoppingCartCustomOption> ShoppingCartCustomOptions { get; set; }
        public DbSet<OrderDetailCustomOption> OrderDetailCustomOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomOption>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<ShoppingCartCustomOption>()
                .Property(o => o.Price)
                .HasPrecision(18, 2);
            modelBuilder.Entity<OrderDetailCustomOption>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "果汁", DisplayOrder = 1 },
                new Category { Id = 2, Name = "茶", DisplayOrder = 2 },
                new Category { Id = 3, Name = "咖啡", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "水果茶", Size = "大杯", Description = "天然果飲，迷人多變", Price = 60, CategoryId = 1, ImageUrl = "" },
                new Product { Id = 2, Name = "鐵觀音", Size = "中杯", Description = "品鐵觀音，想人生的味道", Price = 35, CategoryId = 2, ImageUrl = "" },
                new Product { Id = 3, Name = "美式咖啡", Size = "中杯", Description = "用咖啡體悟悠閒時光", Price = 50, CategoryId = 3, ImageUrl = "" }
                );
            modelBuilder.Entity<Store>().HasData(
                new Store { Id = 1, Name = "台中一中店", Address = "台中市北區三民路三段129號", City = "台中市", PhoneNumber = "0987654321", Description = "鄰近台中一中商圈，學生消暑勝地。" },
                new Store { Id = 2, Name = "台北大安店", Address = "台北市大安區大安路一段11號", City = "台北市", PhoneNumber = "0911111111", Description = "濃厚的教育文化及熱鬧繁華的商圈，豐富整體氛圍。" },
                new Store { Id = 3, Name = "台南安平店", Address = "台南市安平區安平路22號", City = "台南市", PhoneNumber = "0922222222", Description = "歷史造就了現今的安平，茶香中蘊含了悠遠的歷史。" }
                );
            modelBuilder.Entity<CustomTemplate>().HasData(
                            new CustomTemplate { Id = 1, Name = "預設", Description = "" }
                );
            modelBuilder.Entity<CustomGroup>().HasData(
                new CustomGroup { Id = 1, Name = "尺寸", SelectionMode = 1, IsRequired = true, MinSelection = 1, MaxSelection = 1 },
                new CustomGroup { Id = 2, Name = "甜度", SelectionMode = 1, IsRequired = true, MinSelection = 1, MaxSelection = 1 },
                new CustomGroup { Id = 3, Name = "溫度", SelectionMode = 1, IsRequired = true, MinSelection = 1, MaxSelection = 1 },
                new CustomGroup { Id = 4, Name = "加料", SelectionMode = 2, IsRequired = false, MinSelection = 0, MaxSelection = 2 },
                new CustomGroup { Id = 5, Name = "尺寸", SelectionMode = 1, IsRequired = true, MinSelection = 1, MaxSelection = 1 },
                new CustomGroup { Id = 6, Name = "甜度", SelectionMode = 1, IsRequired = true, MinSelection = 1, MaxSelection = 1 },
                new CustomGroup { Id = 7, Name = "溫度", SelectionMode = 1, IsRequired = true, MinSelection = 1, MaxSelection = 1 },
                new CustomGroup { Id = 8, Name = "尺寸", SelectionMode = 1, IsRequired = true, MinSelection = 1, MaxSelection = 1 },
                new CustomGroup { Id = 9, Name = "溫度", SelectionMode = 1, IsRequired = true, MinSelection = 1, MaxSelection = 1 }
                );
            modelBuilder.Entity<CustomOption>().HasData(
                new CustomOption { Id = 1, Name = "中杯", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 1 },
                new CustomOption { Id = 2, Name = "大杯", Price = 5, MinQty = 0, MaxQty = 1, CustomGroupId = 1 },
                new CustomOption { Id = 3, Name = "全糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 2 },
                new CustomOption { Id = 4, Name = "少糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 2 },
                new CustomOption { Id = 5, Name = "半糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 2 },
                new CustomOption { Id = 6, Name = "微糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 2 },
                new CustomOption { Id = 7, Name = "一分糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 2 },
                new CustomOption { Id = 8, Name = "無糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 2 },
                new CustomOption { Id = 9, Name = "正常冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 3 },
                new CustomOption { Id = 10, Name = "少冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 3 },
                new CustomOption { Id = 11, Name = "微冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 3 },
                new CustomOption { Id = 12, Name = "去冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 3 },
                new CustomOption { Id = 13, Name = "常溫", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 3 },
                new CustomOption { Id = 14, Name = "溫", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 3 },
                new CustomOption { Id = 15, Name = "熱", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 3 },
                new CustomOption { Id = 16, Name = "珍珠", Price = 10, MinQty = 0, MaxQty = 2, CustomGroupId = 4 },
                new CustomOption { Id = 17, Name = "大杯", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 5 },
                new CustomOption { Id = 18, Name = "全糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 6 },
                new CustomOption { Id = 19, Name = "少糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 6 },
                new CustomOption { Id = 20, Name = "半糖", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 6 },
                new CustomOption { Id = 21, Name = "正常冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 7 },
                new CustomOption { Id = 22, Name = "少冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 7 },
                new CustomOption { Id = 23, Name = "微冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 7 },
                new CustomOption { Id = 24, Name = "去冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 7 },
                new CustomOption { Id = 25, Name = "中杯", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 8 },
                new CustomOption { Id = 26, Name = "正常冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 9 },
                new CustomOption { Id = 27, Name = "少冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 9 },
                new CustomOption { Id = 28, Name = "微冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 9 },
                new CustomOption { Id = 29, Name = "去冰", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 9 },
                new CustomOption { Id = 30, Name = "常溫", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 9 },
                new CustomOption { Id = 31, Name = "溫", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 9 },
                new CustomOption { Id = 32, Name = "熱", Price = 0, MinQty = 0, MaxQty = 1, CustomGroupId = 9 }
                );
            modelBuilder.Entity<CustomTemplateGroup>().HasData(
                new CustomTemplateGroup { Id = 1, CustomTemplateId = 1, CustomGroupId = 1, DisplayOrder = 0 },
                new CustomTemplateGroup { Id = 2, CustomTemplateId = 1, CustomGroupId = 2, DisplayOrder = 1 },
                new CustomTemplateGroup { Id = 3, CustomTemplateId = 1, CustomGroupId = 3, DisplayOrder = 2 },
                new CustomTemplateGroup { Id = 4, CustomTemplateId = 1, CustomGroupId = 4, DisplayOrder = 3 }
                );
            modelBuilder.Entity<ProductCustomGroup>().HasData(
                new ProductCustomGroup { Id = 1, ProductId = 1, CustomGroupId = 5, DisplayOrder = 0 },
                new ProductCustomGroup { Id = 2, ProductId = 1, CustomGroupId = 6, DisplayOrder = 1 },
                new ProductCustomGroup { Id = 3, ProductId = 1, CustomGroupId = 7, DisplayOrder = 2 },
                new ProductCustomGroup { Id = 4, ProductId = 2, CustomGroupId = 1, DisplayOrder = 0 },
                new ProductCustomGroup { Id = 5, ProductId = 2, CustomGroupId = 2, DisplayOrder = 1 },
                new ProductCustomGroup { Id = 6, ProductId = 2, CustomGroupId = 3, DisplayOrder = 2 },
                new ProductCustomGroup { Id = 7, ProductId = 2, CustomGroupId = 4, DisplayOrder = 3 },
                new ProductCustomGroup { Id = 8, ProductId = 3, CustomGroupId = 8, DisplayOrder = 0 },
                new ProductCustomGroup { Id = 9, ProductId = 3, CustomGroupId = 9, DisplayOrder = 1 }
            );
        }
    }
}
