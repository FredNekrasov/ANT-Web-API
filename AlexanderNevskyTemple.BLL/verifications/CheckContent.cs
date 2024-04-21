using AlexanderNevskyTemple.BLL.utils;
using AlexanderNevskyTemple.DAL.entities;

namespace AlexanderNevskyTemple.BLL.verifications;
public static class CheckContent {
    public static bool CheckData(this Content? content) {
        return !(content == null || content.Id.IsNull() || content.URL.IsBlank() || content.ArticleId.IsNull());
    }
}