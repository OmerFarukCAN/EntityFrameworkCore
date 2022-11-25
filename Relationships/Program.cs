using Lesson9;

namespace Relationships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ECommerceDemo2DbContext context = new ECommerceDemo2DbContext();

            #region Relationship Terms

            #region Principal Entity
            // --> Kendi basina var olabilen tabloyu modelleyen entity'e denir. Departmanlar toblosunu modelleyen 'Departman' entity'sidir.
            #endregion

            #region Dependent Entity
            // --> Kendi basina var olamayan bir baska tabloya iliskisel olarak bagimli olan tabloyu modelleyen entity'dir. Calisanlar, Departmanlara bagimlidir o yuzden Calisan Entity'si dependent entity'dir.
            #endregion

            #region Foreign Key
            // --> Principal Entity ile Dependent Entity arasindaki iliskiyi saglayan key'dir.Dependent Entity'de tanimlanir.(Calisanlar Class'indaki DepartmanId property'si)
            #endregion

            #region Principal Key
            // --> Principal Entity'deki id'nin kendisidir. Principal Entity'nin kimligi olan kolonu ifade eden property'dir. (Departman Class'indaki Id property'si)
            #endregion

            #endregion

            #region Navigation Property
            // --> Iliskisel tablolar arasindaki fiziksel erisimi entity classlari uzerinden saglayan propertylerdir. Bir property'nin bir navigation property olabilmesi icin entity turunden olmasi gerekir. Entity'lerdeki tanimlara gore (n-n) yahut (1-n) seklinde iliski turlerini ifade etmektedir.
            #endregion

            #region Relationship Types

            #region One to One
            // --> Calisanlar ile Adresler arasindaki iliski, Karı-Koca arasindaki iliski.
            #endregion

            #region One to Many
            // --> Calisanlar ile Departmanlar arasindaki iliski, Anne-Cocuk arasindaki iliski(Her cocugun bir annesi olabilir fakat her annenin birden fazla cocugu olabilir)
            #endregion

            #region Many to Many
            // --> Calisanlar ile Projeler arasindaki iliski.
            #endregion

            #endregion

            #region EfCore'da Iliski Yapilandirma Yontemleri

            #region Default Conventions
            // --> Varsayilan Entity kurallarini kullanarak yapilan iliski yapilandirma yontemleridir. Navigation propertyleri kullanarak iliski sablonlarini cikarmaktadir.
            #endregion

            #region Data Annotations Attributes
            // --> Entity'nin niteliklerine gore ince ayarlar yapmamizi saglayan attribute'lardir. [Key], [ForeignKey]
            #endregion

            #region Fluent API
            // --> Entity modellerindeki iliskileri yapilandirirken daha detayli calismamizi saglayan yontemdir.

            #region HasOne
            // --> Ilgili Entity'nin iliskisel Entity'e bire bir ya da bire cok olacak sekilde iliskisini yapilandirmaya baslayan metottur.(1-1 veya 1-n)
            #endregion

            #region HasMany
            // --> Ilgili Entity'nin iliskisel Entity'e coka bir ya da coka cok olacak sekilde iliskisini yapilandirmaya baslayan metottur.(n-1 veya n-n)
            #endregion

            #region WithOne
            // --> HasOne ya da HasMany'den sonra bire bir ya da coka bir olacak sekilde iliski yapilandirmasini tamamlayan metottur.(1-1 veya n-1)
            #endregion

            #region WithMany
            // --> HasOne ya da HasMany'den sonra bire cok ya da coka cok olacak sekilde iliski yapilandirmasini tamamlayan metottur.(1-n veya n-n)
            #endregion

            #endregion

            #endregion
        }
    }
}