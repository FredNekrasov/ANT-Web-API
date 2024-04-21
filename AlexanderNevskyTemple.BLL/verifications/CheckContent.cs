using AlexanderNevskyTemple.BLL.utils;
using AlexanderNevskyTemple.DAL.entities;

namespace AlexanderNevskyTemple.BLL.verifications;
public static class CheckContent {
    public static bool? CheckData(this Content content) {
        if(content == null) return null;
        return !(content.Id.IsNull() || content.URL.IsBlank() || content.ArticleId.IsNull());
    }
}