namespace AlexanderNevskyTemple.WebAPI.dto;
public class ContentDto {
    public long Id { get; set; }
    public long ArticleId { get; set; }
    public string Data { get; set; } = string.Empty;//it can be contacts or images
}