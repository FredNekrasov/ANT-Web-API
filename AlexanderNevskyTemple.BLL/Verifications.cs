using AlexanderNevskyTemple.BLL.models;

namespace AlexanderNevskyTemple.BLL;
public static class Verifications {//Only extenstion functions that check the data
    //simplification of conditions
    public static bool IsBlank(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    public static bool IsNegative(this long l) => l < 0;
    public static bool IsNegative(this int i) => i < 0;
    //Validate data
    public static bool IsDataValid(this CatalogModel catalog) => !(catalog.Id.IsNegative() || catalog.Name.IsBlank());
    public static bool IsDataValid(this ArticleModel article) => !(article.Id.IsNegative() || article.Title.IsBlank() || article.Catalog.Id.IsNegative());
    public static bool IsDataValid(this ContentModel content) => !(content.Id.IsNegative() || content.Data.IsBlank() || content.ArticleId.IsNegative());
}