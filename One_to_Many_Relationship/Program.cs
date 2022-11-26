namespace One_to_Many_Relationship
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Default Convention
            // -->Default convention yönteminde bire çok ilişkiyi kurarken foreign key kolonuna karşılık gelen bir property tanımlamak mecburiyetinde değilidiz. Eğer tanımlamazsak EF Core bunu kendisi tamamlayacak yok eğer tanımlarsak, tanımladığımızı baz alacaktır.
            // --> Class Calisan //Dependent Entity
            #endregion

            #region Data Annotations
            // --> Default convention yönteminde foreign key kolonuna karşılık gelen property'i tanımladığımızda bu property ismi temel geleneksel entity tanımlama kurallarına uymuyorsa eğer Data Annotations'lar ile müdahalede bulunabiliriz."
            // --> Class Calisan //Dependent Entity
            #endregion

            #region Fluent API

            #endregion
        }
    }
}