using AlexanderNevskyTemple.DAL.entities;

namespace AlexanderNevskyTemple.BLL;
public static class Verifications {//Only extenstion functions that check the data
    //simplification of conditions
    public static bool IsBlank(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    public static bool IsNull(this long l) => l <= 0;
    public static bool IsNull(this int i) => i <= 0;
    //Validate data
    public static bool IsDataValid(this Catalog catalog) => !(catalog.Id.IsNull() || catalog.Name.IsBlank());
    public static bool IsDataValid(this Article article) => !(article.Id.IsNull() || article.Title.IsBlank() || article.Description.IsBlank() || article.Date.IsBlank() || article.CatalogId.IsNull());
    public static bool IsDataValid(this Content content) => !(content.Id.IsNull() || content.URL.IsBlank() || content.ArticleId.IsNull());
}