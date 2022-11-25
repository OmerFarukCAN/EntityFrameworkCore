using Lesson9;
using Microsoft.EntityFrameworkCore;

namespace Tracking
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ECommerceDemo2DbContext context = new ECommerceDemo2DbContext();

            #region AsNoTracking Method
            // --> Context uzerinden gelen tum datalar Change Tracker mekanizmasi tarafindan takip edilmektedir. Change Tracker takip ettigi nesnelerin sayisiyla dogru orantili olacak sekilde bir maaliyete sahiptir. O yuzden uzerinde islem yapilmayacak verilerin takip edilmesi bizlere luzumsuz yere bir maaliyet ortaya cıkaracaktir.
            // --> AsNoTracking metodu, context uzerinden sorgu neticesinde gelecek olan verilerin Change Tracker trafindan takip edilmesini engeller. AsNoTracking metodu ile Change Tracker'in ihtiyac olmayan verilerdeki maaliyeti torpulemis oluruz. AsNoTracking fonksiyonu ile yapilan sorgulamalarda, verileri elde edebilir bu verileri istenilen noktalarda kullanabilir lakin veriler uzerinde herhangi bir degisiklik islemi yapamayiz. (Update,Remove, Add fonksiyonlari haric)

            //var users = await context.Users.AsNoTracking().ToListAsync();
            //users.ForEach(u => { Console.WriteLine(u.UserName); });            

            //User user = new User()
            //{
            //    Email = "user6@gmail.com",
            //    UserName = "User 6",
            //    Password = "password6"
            //};

            //await context.Users.AddAsync(user); // --> await context.Users.AsNoTracking().AddAsync(user); Bu sekilde bir degisiklik islemi yapilamaz.
            //await context.SaveChangesAsync();

            #endregion

            #region AsNoTrackingWithIdentityResolution
            // --> CT(Change Tracker) mekanizması yinelenen verileri tekil instance olarak getirir. Buradan ekstradan bir performans kazancı söz konusudur.
            // --> Bizler yaptığımız sorgularda takip mekanizmasının AsNoTracking metodu ile maliyetini kırmak isterken bazen maliyete sebebiyet verebiliriz.(Özellikle ilişkisel tabloları sorgularken bu duruma dikkat etmemiz gerekyior)
            // --> AsNoTracking ile elde edilen veriler takip edilmeyeceğinden dolayı yinelenen verilerin ayrı instancelarda olmasına sebebiyet veriyoruz. Çünkü CT mekanizması takip ettiği nesneden bellekte varsa eğer aynı nesneden birdaha oluşturma gereği duymaksızın o nesneye ayrı noktalardaki ihtiyacı aynı instance üzerinden gidermektedir.
            // --> Böyle bir durumda hem takip mekanizmasının maliyeitni ortadan kaldırmak hemide yinelenen dataları tek bir instance üzerinde karşılamak için AsNoTrackingWithIdentityResolution fonksiyonunu kullanabiliriz.
            // --> AsNoTrackingWithIdentityResolution fonksiyonu AsNoTracking fonkisyonuna nazaran daha yavastir/maaliyetlidir lakin CT'a nazaran daha performanslı ve az maaliyetlidir. AsNoTrackingWithIdentityResolution genellikle iliskisel sorgularda tercih edilir.

            // var books = await context.Users.Include(u => u.Roles).ToListAsync();
            // var books = await context.Users.Include(u => u.Roles).AsNoTracking().ToListAsync();
            // var books = await context.Users.Include(u => u.Roles).AsNoTrackingWithIdentityResolution().ToListAsync();

            #endregion

            #region AsTracking
            // --> Context uzerinden gelen datalarin CT tarafindan takip edilmesini iradeli bir sekilde ifade etmemizi saglayan bir fonksiyondur.
            // --> UseQueryTrackingBehavior metodunun davranışı gereği uygulama seviyesinde CT'ın default olarak devrede olup olmamasını ayarlıyor olacağız. Eğer ki default olarak pasif hale getirilirse böyle durumda takip mekanizmasının ihtiyaç olduğu sorgularda AsTracking fonksiyonunu kullanabilir ve böylece takip mekanizmasını iradeli bir şekilde devreye sokmuş oluruz.

            // var books = await context.Books.AsTracking().ToListAsync();
            #endregion

            #region UseQueryTrackingBehavior
            // --> EF Core seviyesinde/uygulama seviyesinde ilgili contextten gelen verilerin üzerinde CT mekanizmasının davranışı temel seviyede belirlememizi sağlayan fonksiyondur. Yani konfigürasyon fonksiyonudur.
            #endregion            
        }
    }
}