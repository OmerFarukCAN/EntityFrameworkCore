using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson9
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ECommerceDemo2DbContext context = new ECommerceDemo2DbContext();

            #region Veri Ekleme
            #region Veri Nasil Eklenir?
            //Product product = new Product()
            //{
            //    ProductName = "Test A",
            //    Price = 100,
            //    Stock = 10
            //};

            // --> AddAsync Method
            //await context.AddAsync(product);

            // --> Dbset.AddAsync Method
            //await context.Products.AddAsync(product); // Type safety

            // --> Insert, Update ve Delete sorgularini olusturup bir transaction esliginde veritabanina gonderip execute eden fonksiyondur. Eger ki olusturulan sorgulardan herhangi biri basarisiz olursa tum islemleri geri alir(rollback). Bu fonksiyon her tetiklendiginde bir transaction olusturcagindan dolayi EFCore ile yapilan her bir isleme ozel kullanmaktan kacinmaliyiz! Cunku her isleme ozel transaction veritabani acisindan extradan maliyet demektir. O yuzden mumkun mertebe tum islemlerimizi tek bir transaction esliginde veritabanina gonderebilmek icin SaveChanges tek seferde kullanmak hem maaliyet hem de yonetilebilirlik acisindan katkida bulunmus olacaktir.
            //await context.SaveChangesAsync();
            #endregion

            #region EFCore Bir Verinin Eklenmesi Gerektigini Nasil Anlar?
            //Product product = new Product()
            //{
            //    ProductName = "Test B",
            //    Price = 1000,
            //};

            //Console.WriteLine(context.Entry(product).State);

            //await context.Products.AddAsync(product); // Ekleme methodlarindan sonra state degisir. Bu sekilde eklenmesi gerektigi anlasilir.

            //Console.WriteLine(context.Entry(product).State);

            //await context.SaveChangesAsync();

            //Console.WriteLine(context.Entry(product).State);

            #endregion

            #region Birden Fazla Veri Eklenirken Nelere Dikkat Edilmelidir?
            //Product product = new Product()
            //{
            //    ProductName = "Test C",
            //    Price = 100,
            //    Stock = 15
            //};

            //Product product2 = new Product()
            //{
            //    ProductName = "Test D",
            //    Price = 100,
            //    Stock = 15
            //};

            //Product product3 = new Product()
            //{
            //    ProductName = "Test E",
            //    Price = 100,
            //    Stock = 15
            //};

            //await context.Products.AddRangeAsync(product, product2, product3);
            //await context.SaveChangesAsync();
            #endregion

            #region Eklenen Verinin Generate Edilen Id'sini Elde Etme
            //Product product = new Product()
            //{
            //    ProductName = "Test F",
            //    Price = 100,
            //    Stock = 15
            //};

            //await context.Products.AddAsync(product);
            //await context.SaveChangesAsync();
            //Console.WriteLine(product.Id);
            #endregion
            #endregion

            #region Veri Guncelleme
            #region Veri Nasıl Guncellenir?
            //Product product = await context.Products.FirstOrDefaultAsync(p => p.Id == 3);
            //product.ProductName = "Test C2";
            //product.Price = 10;
            //await context.SaveChangesAsync();
            #endregion

            #region ChangeTracker Kısaca Nedir?
            // --> Context uzerinden gelen verilerin takibinden sorumlu bir mekanizmadir. Bu takip mekanizmasi sayesinde context uzerinden gelen verilerle ilgili islemler neticesinde update yahut delate sorgularinin olusturulacagi anlasilir.
            #endregion

            #region Takip Edilmeyen Nesneler Nasil Guncellenir?
            //Product product = new()
            //{
            //    Id = 3, // Id kesin olarak verilmelidir!!!
            //    ProductName = "Test C3",
            //    Price = 123,
            //    Stock = 1
            //};

            //// --> ChangeTracker mekanizmasi tarafindan takip edilmeyen nesnelerin guncellenebilmesi icin Update fonksiyonu kullanilir. Update fonksiyonunun kullanilabilmesi icin ilgili nesnede KESINLIKLE id degeri verilmelidir!!!
            //context.Products.Update(product);
            //await context.SaveChangesAsync();
            #endregion

            #region EntityState Nedir?
            // --> Bir entity instance'inin durumunu ifade eden bir referanstir.
            //Product product = new();
            //Console.WriteLine(context.Products.Entry(product).State);
            #endregion

            #region EFCore Verinin Guncellenecegini Nasil Anlar?
            //Product product = await context.Products.FirstOrDefaultAsync(p => p.Id == 3);
            //Console.WriteLine(context.Products.Entry(product).State);
            //product.ProductName = "Test C4";
            //Console.WriteLine(context.Products.Entry(product).State);
            //product.Price = 10;
            //await context.SaveChangesAsync();
            //Console.WriteLine(context.Products.Entry(product).State);
            #endregion

            #region Birden Fazla Veri Guncellenirken Nelere Dikkat Edilmelidir?
            //var products = await context.Products.ToListAsync();
            //foreach (var product in products)
            //{
            //    product.ProductName += " *";
            //    //await context.SaveChangesAsync(); --> Eger burada SaveChangesAsync yaparsak her defasinda transaction olusur ve maaliyeti yuksek olur.
            //}
            //await context.SaveChangesAsync();
            #endregion
            #endregion

            #region Veri Silme
            #region Veri Nasil Silinir?
            //Product product = await context.Products.FirstOrDefaultAsync(p => p.Id == 5); // Context uzerinden nesneyi aldik.
            //context.Products.Remove(product);
            //await context.SaveChangesAsync();
            #endregion

            #region Silme Isleminde ChangeTracker'in Rolu
            // --> Context uzerinden gelen verilerin takibinden sorumlu bir mekanizmadir. Bu takip mekanizmasi sayesinde context uzerinden gelen verilerle ilgili islemler neticesinde update yahut delate sorgularinin olusturulacagi anlasilir.
            #endregion

            #region Takip Edilmeyen Nesneler Nasil Silinir?
            // --> Burada urunu context uzerinden almamis oluyoruz.
            //Product product = new Product()
            //{
            //    Id = 6
            //};
            //context.Products.Remove(product);
            //await context.SaveChangesAsync();
            #endregion

            #region EntityState Ile Silme Islemi
            //Product product = new() { Id = 1 };
            //context.Products.Entry(product).State = EntityState.Deleted;
            //await context.SaveChangesAsync();
            #endregion

            #region Birden Cok Veri Silinirken Nelere Dikkat Edilmeli?
            // --> Ekleme ve guncellemede oldugu gibi tum islemlerin sonunda bir kere SaveChanges kullanmaliyiz.
            #endregion

            #region RemoveRange
            // --> 1. Yontem
            //List<Product> products = await context.Products.Where(p => p.Id == 2 && p.Id == 3).ToListAsync();
            //context.Products.RemoveRange(products);
            //await context.SaveChangesAsync();

            // --> 2. Yontem
            //Product product = new() { Id = 2 };
            //Product product2 = new() { Id = 3 };
            //context.Products.RemoveRange(product, product2);
            //await context.SaveChangesAsync();
            #endregion
            #endregion
        }
    }

    // --> Database
    public class ECommerceDemo2DbContext : DbContext
    {
        // --> EfCore tool'unu yapilandirmak icin kullandigimiz bir metotdur. Override edilerek kullanilmalidir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // --> Provider, Connection String, Lazy Loading vb.
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ECommerceDemo2;User Id=ofarukcan;Password=prostreet273;TrustServerCertificate=True");
            //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); // --> Bu sekilde takip edilme kesilebilir. Default parametre TrackAll ' dur.
        }

        // --> Modellerin(entity) veritabaninda generate edilecek yapilari bu fonksiyon icerisinde konfigure edilir. (Fluent API)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Primary Key
            modelBuilder.Entity<ProductItem>().HasKey(up => new { up.ProductId, up.ItemId });

            #region Data Annotations (n-n)
            // --> Data Annotations (n-n)
            //modelBuilder.Entity<KitapYazar>().HasKey(ky => new { ky.KId, ky.YId });
            #endregion

            #region Fluent API (1-1)
            //modelBuilder.Entity<CalisanAdres>()
            //    .HasKey(c => c.Id);

            //modelBuilder.Entity<Calisan>()
            //    .HasOne(c => c.CalisanAdresleri)
            //    .WithOne(c => c.Calisan)
            //    .HasForeignKey<CalisanAdres>(c => c.Id);
            #endregion

            #region Fluent API (1-n)
            //modelBuilder.Entity<Calisan>()
            //    .HasOne(c => c.Departman)
            //    .WithMany(d => d.Calisanlar);
            ////.HasForeignKey(c => c.DID) --> Istedigimiz kolonu FK yapmak icin
            #endregion

            #region Fluent API (n-n)
            //modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });

            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(ba => ba.Book)
            //    .WithMany(b => b.Authors)
            //    .HasForeignKey(ba => ba.BookId);

            //modelBuilder.Entity<BookAuthor>()
            //    .HasOne(ba => ba.Author)
            //    .WithMany(a => a.Books)
            //    .HasForeignKey(ba => ba.AuthorId);
            #endregion            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ProductItem> ProductItem { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        //public DbSet<Book> Books { get; set; }
        //public DbSet<Author> Authors { get; set; }

        //public DbSet<Departman> Departmanlar { get; set; }
        //public DbSet<Calisan> Calisanlar { get; set; }
        //public DbSet<CalisanAdres> CalisanAdresler { get; set; }        
    }

    // --> Entity
    public class Product
    {
        // --> EFCore, her tablonun default olarak bir primary key kolonu olmasi gerektigini kabul eder. Haliyle bu kolonu temsil eden bir property tanimlamadigimiz takdirde hata verecektir. Asagidaki gibi property isimlendirmeleri default primary key olarak kabul edilir.
        //public int ID { get; set; }
        //public int ProductId { get; set; }
        //public int ProductID { get; set; }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }

        public ICollection<Item> Items { get; set; }
    }
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
    }
    public class ProductItem
    {
        public int ProductId { get; set; }
        public int ItemId { get; set; }
        public Product Product { get; set; }
        public Item Item { get; set; }
    }
    public class ProductDetail
    {
        public int Id { get; set; }
        public float Price { get; set; }
    }

    public class User
    {
        public User() => Console.WriteLine("The user object has been created.");
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
    public class Role
    {
        public Role() => Console.WriteLine("The role object has been created.");
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<User> Users { get; set; }
    }

    #region One to One Relationship

    #region Default Convention (1-1)
    //public class Calisan
    //{
    //    public int Id { get; set; }
    //    public string CalisanAdi { get; set; }
    //    public CalisanAdres CalisanAdresleri { get; set; } // Navigation Property
    //}

    //public class CalisanAdres
    //{
    //    public int Id { get; set; }
    //    public int CalisanId { get; set; } // FK, Dependent, Default Convention
    //    public int Adres { get; set; }
    //    public Calisan Calisan { get; set; }
    //}
    #endregion

    #region Data Annotations (1-1)
    //public class Calisan
    //{
    //    public int Id { get; set; }
    //    public string CalisanAdi { get; set; }
    //    public CalisanAdres CalisanAdresleri { get; set; } // Navigation Property
    //}

    //public class CalisanAdres
    //{
    //    [Key, ForeignKey(nameof(Calisan))] // Id property'si hem Primary Key, Hem de Foreign Key yapmis olduk. Dependent bir iliski kurmus olduk.
    //    public int Id { get; set; }
    //    public int Adres { get; set; }
    //    public Calisan Calisan { get; set; }
    //}
    #endregion

    #region Fluent API (1-1)
    //public class Calisan
    //{
    //    public int Id { get; set; }
    //    public string CalisanAdi { get; set; }
    //    public CalisanAdres CalisanAdresleri { get; set; } // Navigation Property
    //}

    //public class CalisanAdres
    //{
    //    public int Id { get; set; }
    //    public int Adres { get; set; }
    //    public Calisan Calisan { get; set; }
    //}
    #endregion

    #endregion

    #region One to Many Relationship

    #region Default Convention (1-n)
    //public class Calisan
    //{
    //    public int Id { get; set; }
    //    //public int DepartmanId { get; set; } // --> FK, 1-n iliskilerinde istege baglidir.
    //    public string CalisanAdi { get; set; }
    //    public Departman Departman { get; set; }
    //}

    //public class Departman
    //{
    //    public int Id { get; set; }
    //    public string DepartmanAdi { get; set; }
    //    public ICollection<Calisan> Calisanlar { get; set; }
    //}
    #endregion

    #region Data Annotations (1-n)
    //public class Calisan
    //{
    //    public int Id { get; set; }
    //    // [ForeignKey(nameof(Departman))] // --> Istege bagli FK isimlendirmesi icin
    //    public int DId { get; set; }
    //    public string CalisanAdi { get; set; }
    //    public Departman Departman { get; set; }
    //}

    //public class Departman
    //{
    //    public int Id { get; set; }
    //    public string DepartmanAdi { get; set; }
    //    public ICollection<Calisan> Calisanlar { get; set; }
    //}
    #endregion

    #region Fluent API (1-n)
    //public class Calisan
    //{
    //    public int Id { get; set; }
    //    // public int DId { get; set; } // --> Istedigimiz kolonu FK yapmak icin
    //    public string CalisanAdi { get; set; }
    //    public Departman Departman { get; set; }
    //}

    //public class Departman
    //{
    //    public int Id { get; set; }
    //    public string DepartmanAdi { get; set; }
    //    public ICollection<Calisan> Calisanlar { get; set; }
    //}
    #endregion

    #endregion

    #region Many to Many Relationship

    #region Default Convention (n-n)
    //public class Book
    //{
    //    public int Id { get; set; }
    //    public string BookName { get; set; }

    //    public ICollection<Author> Authors { get; set; }
    //}
    //public class Author
    //{
    //    public int Id { get; set; }
    //    public string AuthorName { get; set; }

    //    public ICollection<Book> Books { get; set; }
    //}
    #endregion

    #region Data Annotations (n-n)
    //public class Book
    //{
    //    public int Id { get; set; }
    //    public string BookName { get; set; }
    //    public ICollection<BookAuthor> Authors { get; set; }
    //}
    //// --> Cross Table
    //public class BookAuthor
    //{
    //    //[ForeignKey(nameof(Book))] // --> Tercihe gore FK isimlerini kendimiz gore ayarlama
    //    //public int BId { get; set; }
    //    //[ForeignKey(nameof(Author))] // --> Tercihe gore FK isimlerini kendimiz gore ayarlama
    //    //public int AId { get; set; }
    //    public int BookId { get; set; }
    //    public int AuthorId { get; set; }
    //    public Book Book { get; set; }
    //    public Author Author { get; set; }
    //}
    //public class Author
    //{
    //    public int Id { get; set; }
    //    public string AuthorName { get; set; }
    //    public ICollection<BookAuthor> Books { get; set; }
    //}
    #endregion

    #region Fluent API (n-n)
    //public class Book
    //{
    //    public int Id { get; set; }
    //    public string BookName { get; set; }
    //    public ICollection<BookAuthor> Authors { get; set; }
    //}
    //// --> Cross Table
    //public class BookAuthor
    //{
    //    //public int AId { get; set; }
    //    public int BookId { get; set; }
    //    public int AuthorId { get; set; }
    //    public Book Book { get; set; }
    //    public Author Author { get; set; }
    //}
    //public class Author
    //{
    //    public int Id { get; set; }
    //    public string AuthorName { get; set; }
    //    public ICollection<BookAuthor> Books { get; set; }
    //}
    #endregion

    #endregion

    
}