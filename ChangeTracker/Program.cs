using Lesson9;
using Microsoft.EntityFrameworkCore;

namespace ChangeTracker
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ECommerceDemo2DbContext context = new ECommerceDemo2DbContext();

            #region Change Tracking Nedir ?
            // --> Context nesnesi uzerinden gelen tum nesneler/veriler otomatik olarak bir takip mekanizmasi tarafindan izlenirler. Bu takip mekanizmasina Change Tracker denir. Change Tracker ile nesneler uzerindeki degisikler/islemler takip edilerek netice itibariyle bu islemlerin fitratina uygun sq sorgucuklari generate edilir. Iste bu isleme Change Tracking denir.
            #endregion

            #region ChangeTracker Propertysi            
            // --> Takip edilen nesnelere erisebilmemizi saglayan ve gerektigi taktirde islemler gerceklestirmemizi saglayan bir propertydir. Context sinifinin base class'i olan DbContext sinifinin bir memberidir.

            //var products = await context.Products.ToListAsync();

            //var product = await context.Products.FirstOrDefaultAsync(p => p.Id == 7);
            //product.Price = 25;

            //products[5].Price = 123; // Update
            //context.Products.Remove(products[6]); // Delete
            //products[7].ProductName = "Test AB *";

            //var datas = context.ChangeTracker.Entries().ToList();
            //datas.ForEach(data => { Console.WriteLine(data); });
            //await context.SaveChangesAsync();            
            #endregion

            #region DetectChanges Method
            // --> EfCore, context nesnesi tarafindan izlenen tum nesnelerdeki degisiklikleri Change Tracker sayesinde takip edebilmekte ve nesnelerde olan verisel degisiklikler yakalanarak bunların anlık goruntuleri(snapshot)'ni olusturabilir.
            // --> Yapilan degisikliklerin veritabanina gonderilmeden once algilandigindan emin olmak gerekir. SaveChanges fonksiyonu cagirildiginda nesneler EfCore tarafindan otomatik kontrol edilirler.
            // --> Ancak yapilan operasyonlarda guncel tracking verilerinden emin olabilmek icin degisikliklerin algilanmasini opsiyonel olarak gerceklestirmek isteyebiliriz. Iste bunun icin DetectChange fonksiyonu kullanilabilir ve her ne kadar EfCore degisiklikleri otomatik algiliyor olsa da siz yine de iradenizle kontrole zorlayabilirsiniz.

            //var product = await context.Products.FirstOrDefaultAsync(p => p.Id == 3);
            //product.Price = 123;

            //context.ChangeTracker.DetectChanges(); // SaveChanges ile bu islem yapilmis olsa da garanti altina almis olduk. Hassas islemlerde tercih edilir.
            //await context.SaveChangesAsync();
            #endregion

            #region AutoDetectChangesEnabled Property
            // --> Ilgili metotlar(SaveChanges, Entries) tarafindan DetectChanges metodunun otomatik olarak tetiklenmesinin konfigurasyonunu yapmamizi saglayan propertydir.
            // --> SaveChanges fonksiyonu tetiklendiginde DetectChanges metodunu icerisinde default olarak cagirmaktadir. Bu durumda DetectChanges fonksiyonunun kullanimini irademizle yonetmek ve maliyet/performans optimizasyonu yapmak istedigimiz durumlarda AutoDetectChangesEnabled ozelligi kapatilabilir.
            #endregion

            #region Entries Metodu
            // --> Contextde ki Entry metodunun koleksiyonel versiyonudur. Change Tracker mekanizmasi tarafindan izlenen her entity nesnesinin bilgisini EntityEntry turunden elde etmemizi saglar ve belirli islemler yapabilmemize olanak tanir. Entries metodu, DetectChanges metodunu tetikler. Bu durumda tipki SaveChanges da oldugu gibi bir maliyettir. Buradaki maaliyetten kacinmak icin AutoDetectChangesEnabled ozelligine false degeri verilebilir.

            //var products = await context.Products.ToListAsync();
            //products.FirstOrDefault(p => p.Id == 7).Price = 125;
            //context.Products.Remove(products.FirstOrDefault(p => p.Id == 8));
            //products.FirstOrDefault(p => p.Id == 9).ProductName = "Test ABC *";

            //context.ChangeTracker.Entries().ToList().ForEach(e =>
            //{
            //    if (e.State == EntityState.Unchanged)
            //    {
            //        // islemler yapilir...
            //    }
            //    else if (e.State == EntityState.Deleted)
            //    {
            //        // islemleri yapilir...
            //    }
            //});

            //context.ChangeTracker.Entries().ToList().ForEach((e) => { Console.WriteLine(e); });
            #endregion

            #region AcceptAllChanges Method
            // --> SaveChanges() veya SaveChanges(true) tetiklendiginde EfCore her seyin yolunda oldugunu varsayarak track ettigi verilerin takibini keser. Yeni degisikliklerin takip edilmesini bekler. Boyle bir durumda beklenmeyen bir durum/olasi bir hata soz konusu olursa eger EfCore takip ettigi nesneleri birakacagi icin bir duzeltme mevzu bahis olmayacaktir.
            // --> Bu durumda devreye SaveChanges(false) ve AcceptAllChanges metotlari girecektir. SaveChanges(false), EfCore'a gerekli veritabani komutlarini yurutmesini soyler ancak gerektiginde yeniden oynatilabilmesi icin degisiklikleri beklemeye / nesneleri takip etmeye devam eder ta ki AcceptAllChanges metodunu irademizle cagirana kadar!
            // --> SaveChanges(false) ile islemin basarili oldugundan emin olursaniz AcceptAllChanges metodu ile nesnelerin takibini kesebilirsiniz.

            //var products = await context.Products.ToListAsync();
            //products.FirstOrDefault(p => p.Id == 7).Price = 125;
            //context.Products.Remove(products.FirstOrDefault(p => p.Id == 8));
            //products.FirstOrDefault(p => p.Id == 9).ProductName = "Test ABC *";

            //await context.SaveChangesAsync(false);
            //context.ChangeTracker.AcceptAllChanges();
            #endregion

            #region HasChanges Method
            // --> Takip edilen nesneler arasindan degisiklik yapilanlarin olup olmadigi bilsini verir. Arkaplanda DetectChanges metodunu tetikler.

            //var result = context.ChangeTracker.HasChanges();
            #endregion

            #region Entity States
            // --> Entity nesnelerinin durumlarini ifade eder.

            #region Detached
            // Nesnenin change tracker mekanizmasi tarafindan takip edilmedigini ifade eder.

            //Product product = new Product();
            //Console.WriteLine(context.Entry(product).State);
            //product.ProductName = "Test";
            //await context.SaveChangesAsync(); // Izlenmedigi icin herhangi bir degisiklik veri tabaninda olmayacaktir.
            #endregion

            #region Added
            // Veri tabanina eklenecek nesneyi ifade eder. Added henuz veritabanina islenmeyen veriyi ifade eder. SaveChanges fonksiyonu cagrildiginda insert sorugu olusturulacagi anlamina gelir.

            //Product product = new Product() { Price = 1, ProductName = "Test 2" };
            //Console.WriteLine(context.Entry(product).State);
            //await context.Products.AddAsync(product);
            //Console.WriteLine(context.Entry(product).State);
            //await context.SaveChangesAsync();
            //Console.WriteLine(context.Entry(product).State);
            #endregion

            #region Unchanged
            // --> Veri tabanindan sorgulandigindan beri nesne uzerinde herhangi bir degisiklik yapilmadigini ifade eder. Sorgu neticesinde elde edilen tum nesneler baslangicta bu state degerindedir.
            #endregion

            #region Modified
            // --> Nesne uzerinde degisiklik/guncelleme yapildigini ifade eder. SaveChanges fonksiyonu cagrildiginda update sorgusu olusturulacagi anlamina gelir.

            //var product = await context.Products.FirstOrDefaultAsync(p => p.Id == 7);
            //product.ProductName = "Test1234 *";
            //await context.SaveChangesAsync(false);
            //Console.WriteLine(context.Entry(product).State); // State'i modified olarak kaldi ve veritabanindaki degeri degisti fakat hala izlenmeye devam edilmekte.
            //product.ProductName = "Test 12345 *"; // Hala izlenmekte oldugundan dolayi tekrar degerini degistirebildim.            
            //await context.SaveChangesAsync(false);
            //Console.WriteLine(context.Entry(product).State); // Hala izlenmekte oldugundan dolayi veritabaninda degerini degistirebildim.
            //context.ChangeTracker.AcceptAllChanges(); // Son degerden emin oldugumdan dolayi artik izlenmeyi kendi irademle kestim.
            //Console.WriteLine(context.Entry(product).State);
            #endregion

            #region Deleted
            // --> Nesnenin silindigini ifade eder. SaveChanges fonksiyonu cagirildigi anda delete sorgusu olusturulacagi anlamina gelir.
            #endregion

            #endregion

            #region Context Nesnesi Uzerinden Change Tracker
            //var product = await context.Products.FirstOrDefaultAsync(p => p.Id == 7);
            //product.Price = 321;
            //product.ProductName = "Test";

            #region Entry Method

            #region OriginalValues Property
            // --> Veritabanina yansitilmadan onceki original degerleri bu property sayesinde alabailiriz.

            //var productName = context.Entry(product).OriginalValues.GetValue<string>(nameof(Product.ProductName));
            //var productPrice = context.Entry(product).OriginalValues.GetValue<float>(nameof(Product.Price));
            //Console.WriteLine(productName + " , " + productPrice);
            #endregion

            #region CurrentValues Property
            // --> Veritabanina yansitilmadan once mevcut degerleri bu sekilde gorebiliriz.

            //var currentProductName = context.Entry(product).CurrentValues.GetValue<string>(nameof(Product.ProductName));
            //var currentProductPrice = context.Entry(product).CurrentValues.GetValue<float>(nameof(Product.Price));
            //Console.WriteLine(currentProductName + " , " + currentProductPrice);
            #endregion

            #region GetDatabaseValues Property
            // --> OriginalValues Property ile benzer işi yapar.

            //var productNameGetDatabase = await context.Entry(product).GetDatabaseValuesAsync();
            //Console.WriteLine(productNameGetDatabase.EntityType);
            //Console.WriteLine(productNameGetDatabase.GetValue<string>(nameof(Product.ProductName)));
            #endregion

            #endregion

            #endregion

            #region Change Tracker'in Interceptor Olarak Kullanilmasi

            #endregion
        }
    }
}