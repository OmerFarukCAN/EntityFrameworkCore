using Microsoft.EntityFrameworkCore;

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
        }

        public DbSet<Product> Products { get; set; }
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
    }
}