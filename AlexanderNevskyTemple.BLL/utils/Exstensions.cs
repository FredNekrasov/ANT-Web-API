namespace AlexanderNevskyTemple.BLL.utils;
public static class Exstensions {
    public static bool IsBlank(this string str) => string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str);
    public static bool IsNull(this long l) => l <= 0;
    public static bool IsNull(this int i) => i <= 0;
}