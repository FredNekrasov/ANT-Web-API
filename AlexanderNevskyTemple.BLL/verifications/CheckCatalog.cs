using AlexanderNevskyTemple.BLL.utils;
using AlexanderNevskyTemple.DAL.entities;

namespace AlexanderNevskyTemple.BLL.verifications;
public static class CheckCatalog {
    public static bool CheckData(this Catalog? catalog) {
        return !(catalog == null || catalog.Id.IsNull() || catalog.Name.IsBlank());
    }
}