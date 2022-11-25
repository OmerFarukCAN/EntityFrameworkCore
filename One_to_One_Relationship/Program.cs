using Lesson9;

namespace One_to_One_Relationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ECommerceDemo2DbContext context = new ECommerceDemo2DbContext();

            #region Default Convention
            // --> Her iki entity de navigation prop ile birbirlerini tekil olarak referans ederek fiziksel bir iliskinin olacagini ifade eder.
            // --> One to One iliski turunde, dependent entity'nin hangisi oldugunu default olarak belirleyebilmek pek kolay degildir. Bu durumda fiziksel olarak bir foreign key'e karsilik property tanimlayarak cozum getirebiliyoruz. Boylece foreign key'e karsilik property tanimlayarak luzumsuz bir kolon olusturmus oluyoruz.
            #endregion

            #region Data Annotations
            // --> Navigation propertyler tanimlanmalidir.
            // --> Foreign kolonunun ismi default convention'in disinda bir kolon olacaksa eger ForeignKey attribute ile bunu bildirebiliriz
            // --> Foreign Key kolonu olusturulmak zorunda degildir.
            // --> 1-1 iliskide ekstradan Foreign Key kolonuna ihtiyac olmayacagindan dolayi dependent entity'deki id kolonunu hem foreign key hem de primary key olarak kullanmayi tercih ediyoruz ve bu duruma ozen gosteriyoruz.
            #endregion

            #region Fluent API
            // --> Navigation propertyler tanimlanmali!
            // --> Fleunt API yönteminde entity'ler arasındaki ilişki context sınıfı içerisinde OnModelCreating fonksiyonun override edilerek metotlar aracılığıyla tasarlanması gerekmektedir. Yani tüm sorumluluk bu fonksiyon içerisindeki çalışmalardadır.
            #endregion
        }
    }
}