namespace Many_to_Many_Relationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Default Convention
            // --> İki entity arasındaki ilişkiyi navigation propertyler üzerinden çoğul olarak kurmalıyız. (ICollection, List)
            // --> Default Convention'da cross table'ı manuel oluşturmak zorunda değiliz. EF Core tasarıma uygun bir şekilde cross table'ı kendisi otomatik basacak ve generate edecektir.
            // --> Ve oluşturulan cross table'ın içerisinde composite primary key'i de otomatik oluşturmuş olacaktır.
            #endregion

            #region Data Annotations
            // --> Cross table manuel olarak oluşturulmak zorundadır.
            // --> Entity'lerde oluşturduğumuz cross table entity si ile bire çok bir ilişki kurulmalı.
            // --> Cross Table'da composite primary key'i data annotation(Attributes)lar ile manuel kuramıyoruz. Bunun için de Fluent API'da çalışma yaopmamız gerekiyor.
            // --> Cross table'a karşılık bir entity modeli oluşturuyorsak eğer bunu context sınıfı içerisinde DbSet property'si olarka bildirmek mecburiyetinde değiliz!
            #endregion

            #region Fluent API
            //Cross table manuel oluşturulmalı
            //DbSet olarak eklenmesine lüzum yok, 
            //Composite PK Haskey metodu ile kurulmalı!
            #endregion
        }
    }
}