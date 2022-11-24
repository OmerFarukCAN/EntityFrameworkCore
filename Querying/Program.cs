using Lesson9;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Querying
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            ECommerceDemo2DbContext context = new ECommerceDemo2DbContext();

            #region En Temel Basit Sorgulama Nasil Yapilir?
            #region Method Syntax
            //var products = await context.Products.ToListAsync();
            #endregion
            #region Query Syntax
            //var products2 = from product in context.Products
            //                select product;
            //foreach (var product in products2)
            //{
            //    Console.WriteLine(product.ProductName);
            //}            
            #endregion
            #endregion

            #region IQueryable ve IEnumerable Basit Olarak Nedir?
            // --> IQueryable sorguya karsilik gelir. Ef core uzerinden yapilmis olan sorgunun execute edilmemis halini ifade eder.
            // --> IEnumerable sorgunun calistirilip/execute edilip verilerin in memorye yuklenmis halini ifade eder.

            // IQueryable
            //var products = from product in context.Products
            //               select product;

            // IEnumerable
            //var products2 = await (from product in context.Products
            //                       select product).ToListAsync();
            #endregion

            #region Foreach
            //// --> IQueyable sorgusunu ToListAsync haricinde bu sekilde de cagirabiliriz.
            //var products = from product in context.Products
            //                      select product;
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}            
            #endregion

            #region Deferred Execution(Ertelenmis Calisma)
            //int productId = 3;

            //var products = from product in context.Products
            //               where product.Id > productId
            //               select product;

            // --> IQueyable calismalarinda ilgili kod yazildigi noktada tetiklenmez/calistirilmaz yani ilgili kod yazildigi noktada sorguyu generate etmez! productId sorgulamadan sonra degeri degismesine ragmen karsilastirma productId = 200 'e gore yapilir. Sorgulama execute edilecegi zaman calisacagindan dolayi execute edilene kadar yapilan bir degisiklik sorgudan sonra yapilsa bile sorguyu etkiler! ToListAsync() metodu da sorguyu execute edeceginden dolayi foreach yerine bu metodu da kullansaydik metoda kadar olan degisiklikler sorguyu etkileyecekti.
            //productId = 200;

            //foreach (Product product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}          
            #endregion

            #region Cogul Veri Getiren Sorgulama Fonksiyonlari
            #region ToListAsyn()
            // --> Uretilen sorguyu execute ettirmemizi saglayan fonskiyon(IQueryable to IEnumerable)
            // var products = await context.Products.ToListAsync();
            #endregion

            #region Where
            // --> Olusturulan sorguya where sarti ekleyen fonkisyondur.

            // --> Method Syntax
            //var products = await context.Products.Where(p => p.Id > 3 && p.ProductName.Contains("Test")).ToListAsync();
            //foreach (Product product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}            

            // --> Query Syntax
            //var products2 = from product in context.Products
            //                where product.Id > 3 && product.ProductName.Contains("Test")
            //                select product;
            //foreach (var product in products2)
            //{
            //    Console.WriteLine(product.ProductName);
            //}            
            #endregion

            #region Order By
            // --> Sorgu uzerinde siralama yapmamizi saglayan bir fonksiyondur. Default Ascending

            // --> Method Syntax
            //var products = await context.Products.Where(p => p.Id > 7 || p.ProductName.EndsWith("*")).OrderBy(p => p.ProductName).ToListAsync();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            // --> Query Syntax
            //var products2 = from product in context.Products
            //                where product.Id > 7 || product.ProductName.EndsWith("*")
            //                orderby product.ProductName
            //                select product;
            //foreach (var product in products2)
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            // --> Query Syntax 2
            //var products = from product in context.Products
            //               where product.Id > 6 && product.ProductName.StartsWith("T")
            //               orderby product.ProductName, product.Price descending, product.Stock descending
            //               select product;

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName + " " + product.Price + " " + product.Stock);
            //}            
            #endregion

            #region ThenBy
            // --> OrderBy uzerinde yapilan siralama islemini farkli kolonlara da uygulamamizi saglayan bir fonksiyondur. Default Ascending

            //var products = await context.Products.Where(p => p.Id > 6 && p.ProductName.StartsWith("T")).OrderBy(p => p.ProductName).ThenBy(p => p.Price).ThenByDescending(p => p.Stock).ToListAsync();            

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName + " " + product.Price + " " + product.Stock);
            //}            
            #endregion
            #endregion

            #region Tekil Veri Getiren Sorgulama Fonksiyonlari

            // --> Yapilan sorguda sade ve sadece tek bir verinin gelmesi amaclaniyorsa Single ya da SingleOrDefault fonksiyonlari kullanilabilir. 
            #region SingleAsync
            // --> Eger ki sorgu neticesinde birden fazla veri geliyorsa ya da hic veri gelmiyorsa her iki durumda da exception firlatir.            

            //var product = await context.Products.SingleAsync(p => p.Id == 4 && p.ProductName.StartsWith("T"));
            //Console.WriteLine(product.ProductName);
            #endregion

            #region SingleOrDefaultAsync
            // --> Eger ki sorgu neticesinde birden fazla veri geliyorsa exception firlatir, hic veri gelmiyorsa null doner.

            // --> Tek Veri Donduruyorsa
            //var product = await context.Products.SingleOrDefaultAsync(p => p.Id == 4 && p.ProductName.StartsWith("T"));
            //Console.WriteLine(product.ProductName);

            // --> Hic Veri Gelmiyorsa
            //var product2 = await context.Products.SingleOrDefaultAsync(p => p.Id > 55 && p.ProductName.StartsWith("T"));
            //if (product2 == null)
            //{
            //    Console.WriteLine("Null");
            //}
            #endregion

            // --> Yapilan sorguda tek bir verinin gelmesi amaclaniyorsa First ya da FirstOrDefault fonkisyonlari kullanilabilir.
            #region FirstAsync
            // --> Sorgu neticesinde elde edilen verilerden ilkini getirir. Eger ki hic veri gelmiyorsa hata firlatir.

            //var product = await context.Products.FirstAsync(p => p.ProductName == "Test A *");
            //Console.WriteLine(product.Id); // --> Id 7 ve Id 13 urunlerinin ikisinin de adi Test A * olmasina ragmen bize ilkini yani Id = 7 yi getirdi. 
            #endregion

            #region FirstOrDefaultAsync
            // --> Sorgu neticesinde elde edilen verilerden ilkini getirir. Eger ki hic veri gelmiyorsa null degerini dondurur.

            // --> Hic kayit gelmiyorsa
            //var product = await context.Products.FirstOrDefaultAsync(p => p.ProductName == "Test ABCD *");
            //if (product == null)
            //{
            //    Console.WriteLine("Null");
            //}
            #endregion

            #region SingleAsync, SingleOrDefaultAsync, FirstAsync, FirstOrDefaultAsync Karsilastirilmasi
            // --> Look EfCore-15.png
            #endregion

            #region FindAsync
            // --> Find fonksiyonu, primary key kolonuna ozel hizli bir sekilde sorgulama yapmamizi saglayan bir fonksiyondur.

            //Product product = await context.Products.FindAsync(7);
            //Console.WriteLine(product.Id);

            // --> Composite Primary Key Durumu
            //ProductItem pi = await context.ProductItem.FindAsync(2, 5);
            #endregion

            #region FindAsync ile SingleAsync, SingleOrDefaultAsync, FirstAsync, FirstOrDefaultAsync Karsilastirilmasi
            // --> Look EfCore-16.png
            #endregion

            #region LastAsync
            // --> Davranis olarak FirstAsync ile aynidir sadece son veriyi alir. Last fonksiyonlarini kullanmak icin oncelikle OrderBy yapmak zorundayiz! Eger hic veri gelmiyora hata firlatir.

            //var product = await context.Products.OrderBy(p => p.Id).LastAsync(p => p.ProductName == "Test A *");
            //Console.WriteLine(product.Id);
            #endregion

            #region LastOrDefaultAsync
            // --> Davranis olarak FirstOrDefaultAsync ile aynidir sadece son veriyi alir. Last fonksiyonlarini kullanmak icin oncelikle OrderBy yapmak zorundayiz! Eger ki hic veri gelmiyorsa null doner.
            //var product = await context.Products.OrderBy(p => p.Id).LastOrDefaultAsync(p => p.ProductName == "Test A *");
            #endregion

            #endregion

            #region Diger Sorgulama Fonksiyonlari
            // --> IQueryable sorgulariyla calismak performans olarak cok daha iyidir.

            #region CountAsync
            // --> Olusturulan sorgunun execute edilmesi sonucunda kac adet satirin elde edilecegini sayisal olarak(int) olarak bildiren fonksiyondur

            // var products = (await context.Products.ToListAsync()).Count(); // Bu sekilde hesaplama yapmak maaliyetlidir.
            //var products = await context.Products.CountAsync(); // Veri tabaninda COUNT(*) sorgusunu yapar direkt olarak. Cok daha performanslidir.
            //Console.WriteLine(products);
            #endregion

            #region LongCountAsync
            // --> Olusturulan sorgunun execute edilmesi sonucunda kac adet satirin elde edilecegini sayisal olarak(long) olarak bildiren fonksiyondur

            //var products = await context.Products.LongCountAsync(); // Veri tabaninda COUNT_BIG(*) sorgusunu yapar direkt olarak.
            //Console.WriteLine(products);

            //var products = await context.Products.LongCountAsync(p => p.Price > 100); // Bu sekilde de adet sorgulamasi yapilabilir. CountAsync icinde gecerlidir.
            //Console.WriteLine(products);
            #endregion

            #region AnyAsync
            // --> Sorgu neticesinde verinin gelip gelmedigini bool turunde donen fonksiyondur.

            //var products = await context.Products.AnyAsync(p => p.ProductName.Contains("Test"));
            //var products2 = await context.Products.Where(p => p.ProductName.Contains("Test")).AnyAsync(); // Yukaridaki sorguyla aynidir. Performans olarak fark etmez
            //Console.WriteLine(products2);
            #endregion

            #region MaxAsync
            //var price = await context.Products.MaxAsync(p => p.Price);
            //Console.WriteLine(price);
            #endregion

            #region MinAsync
            //var price = await context.Products.MinAsync(p => p.Price);
            //Console.WriteLine(price);
            #endregion

            #region Distinc
            // --> Sorguda mukerrer kayitlarin varsa bunlari tekillestiren bir isleve sahip fonksiyondur

            //var products = await context.Products.Select(p => p.ProductName).Distinct().ToListAsync();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product);
            //}
            #endregion

            #region AllAsync
            // --> Bir sorgu neticesinde gelen verilerin verilen sarta uyup uymadigini kontrol etmektedir. Eger tum veriler sarta uyuyorsa true, uymuyorsa false dondurur.

            //var b = await context.Products.AllAsync(p => p.Price > 100);
            //Console.WriteLine(b);
            #endregion

            #region SumAsync
            //var totalPrice = await context.Products.SumAsync(x => x.Price);
            //Console.WriteLine(totalPrice);
            #endregion

            #region AverageAsync
            //var averagePrice = await context.Products.AverageAsync(x => x.Price);
            //Console.WriteLine(averagePrice);
            #endregion

            #region ContainsAsync
            // --> LIKE '%...%' sorgusu olusturmamizi saglar.
            //var products = await context.Products.Where(p => p.ProductName.Contains("t")).ToListAsync();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            #endregion

            #region StartsWith
            // --> LIKE '...%' sorugus olusturmamizi saglar.
            //var products = await context.Products.Where(p=> p.ProductName.StartsWith("A")).ToListAsync();
            #endregion

            #region EndWith
            // --> LIKE '%...' sorgusu olusturmamizi saglar.            
            //var products = await context.Products.Where(p => p.ProductName.EndsWith("A")).ToListAsync();
            #endregion
            #endregion

            #region Sorgu Sonucu Donusum Fonksiyonlari
            // --> Bu fonksiyonlar ile sorgu neticesinde elde edilen verileri istegimiz dogrultusunda farkli turlerde projeksiyon edebiliyoruz.

            #region ToDictionaryAsync
            // Sorgu neticesinde gelecek olan veriyi bir dictionary olarak elde etmek/tutmak/karsilamak istiyorsak eger kullanilir! ToList ile ayni amaca hizmet etmektedir. Yani olusturulan sorguyu execute edip neticesini alirlar. ToList: Gelen sorgu neticesini entity turunde bir koleysiyona (List<TEntity>) donusturmekteyken. ToDictionary : Gelen sorgu neticesini Dictionary turunden bir koleksiyona donusturecektir.

            //var products = await context.Products.ToDictionaryAsync(p => p.ProductName, p => p.Price);
            #endregion

            #region ToArrayAsync
            // --> Olusturulan sorguyu dizi olarak elde eder. ToList ile muadil amaca hizmet eder. Yani sorguyu execute eder lakin gelen sonucu entity dizisi olarak elde ed

            //var products = await context.Products.ToArrayAsync();
            #endregion

            #region Select
            // --> Select fonksiyonunun islevsel olarak birden fazla davranisi soz konusudur.

            // --> 1 - Select fonksiyonu, generate edilecek sorgunun cekilecek kolonlarini ayarlamamizi saglamaktadir
            //var products = await context.Products.Select(p => new Product
            //{
            //    Id = p.Id,
            //    Price = p.Price,
            //}).ToListAsync();

            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.Id + " - " + product.Price); // Bu degerler haricinde diger degerler alinmayacagindan sorguya null dondurur.
            //}

            // --> 2 - Select fonksiyonu gelen verileri farkli turlerde karsilamamizi saglar. T, anonim

            // --> Anonim
            //var products = await context.Products.Select(p => new
            //{
            //    Id = p.Id,
            //    Price = p.Price,
            //}).ToListAsync();

            // --> Istedigimiz herhangi bir tur(T)
            //var products = await context.Products.Select(p => new ProductDetail
            //{
            //    Id = p.Id,
            //    Price = p.Price,
            //}).ToListAsync();
            #endregion

            #region SelectMany
            // --> Select ile ayni hizmete amac eder lakin iliskisel tablolar neticesinde gelen koleksiyonel verileri de tekillestirip projecksiyon etmemizi saglar.

            //var products = await context.Products.Include(i => i.Items).SelectMany(p => p.Items, (p,i) => new
            //{
            //    p.Id,
            //    p.Price,
            //    i.ItemName
            //}).ToListAsync();
            #endregion
            #endregion

            #region GroupBy Fonksiyonu

            #region Method Syntax
            //var datas = await context.Products.GroupBy(p => p.Price).Select(group => new
            //{
            //    Count = group.Count(),
            //    Price = group.Key
            //}).ToListAsync();
            #endregion

            #region Query Syntaz
            //var datas = await (from product in context.Products
            //                   group product by product.Price
            //                   into g
            //                   select new
            //                   {
            //                       Price = g.Key,
            //                       Count = g.Count()
            //                   }).ToListAsync();

            //foreach (var product in datas)
            //{
            //    Console.WriteLine(product.Price + " " + product.Count);
            //}

            // --> Yukaridaki kodun SQL sorgusu bu sekildedir.
            //SELECT Price, COUNT(*) FROM Products
            //GROUP BY Price

            #endregion

            #endregion

            #region Foreach Fonksiyonu
            // --> Bir sorgulama fonksiyonu degildir! Sorgulama neticesinde elde edilen koleksiyonel veriler uzerinde iterasyonel olarak donmemizi ve teker teker verileri elde edip islemler yapabilmemizi saglayan bir fonksiyondur. Foreach dongusunun metot halidir.

            //var datas = await (from product in context.Products
            //                   group product by product.Price
            //                   into g
            //                   select new
            //                   {
            //                       Price = g.Key,
            //                       Count = g.Count()
            //                   }).ToListAsync();

            //datas.ForEach(data => Console.WriteLine(data.Price + " " + data.Count));
            #endregion
        }
    }
}