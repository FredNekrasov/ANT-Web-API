using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.BLL.repository;

namespace AlexanderNevskyTemple.BLL.interactors; 
public class ChapterInteractor(
    IRepository<ArticleModel, long> articleRepository,
    IRepository<ContentModel, long> contentRepository
    ) {
    private readonly IRepository<ArticleModel, long> _articleRepository = articleRepository;
    private readonly IRepository<ContentModel, long> _contentRepository = contentRepository;
    public async Task<List<ChapterModel>> GetListAsync() {
        var contentList = await _contentRepository.GetListAsync();
        var articleList = await _articleRepository.GetListAsync();
        var chapterList = articleList.Select(it => {
            var content = contentList.Where(content => content.ArticleId == it.Id).Select(content => content.Data).ToList();
            return new ChapterModel {
                Id = it.Id,
                Catalog = it.Catalog,
                Title = it.Title,
                Description = it.Description,
                DateOrBanner = it.DateOrBanner,
                Content = content
            };
        }).ToList();
        return chapterList;
    }
}