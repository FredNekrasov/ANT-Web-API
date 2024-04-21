using AlexanderNevskyTemple.BLL.utils;
using AlexanderNevskyTemple.DAL.entities;

namespace AlexanderNevskyTemple.BLL.verifications; 
public static class CheckArticle {
    public static bool CheckData(this Article? article) {
        return !(article == null || article.Id.IsNull() || article.Title.IsBlank() || article.Description.IsBlank() || article.Date.IsBlank() || article.CatalogId.IsNull());
    }
}