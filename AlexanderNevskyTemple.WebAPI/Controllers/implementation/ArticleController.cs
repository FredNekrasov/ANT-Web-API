using AlexanderNevskyTemple.BLL.interactors;
using AlexanderNevskyTemple.WebAPI.dto;
using AlexanderNevskyTemple.WebAPI.mappers;
using Microsoft.AspNetCore.Mvc;

namespace AlexanderNevskyTemple.WebAPI.Controllers.implementation;
[Route("api/v1/[controller]")]
[ApiController]
public class ArticleController(ArticleInteractor interactor) : IController<ArticleDto, long> {
    private readonly ArticleInteractor _interactor = interactor;
    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) {
        bool? result = await _interactor.DeleteAsync(id);
        return result switch {
            null => BadRequest("this record is used as a foreign key in other entities"),
            false => BadRequest(),
            true => Ok()
        };
    }
    [HttpGet]
    public override async Task<ActionResult<IEnumerable<ArticleDto>>> GetListAsync() {
        var articles = await _interactor.GetListAsync();
        if(articles == null) return NoContent();
        List<ArticleDto> dtos = [];
        foreach(var article in articles) {
            dtos.Add(article.ToDto());
        }
        return Ok(dtos);
    }
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(ArticleDto dto) {
        bool result = await _interactor.InsertAsync(dto.ToEntity());
        if(result) return Ok(); else return BadRequest();
    }
    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, ArticleDto dto) {
        bool? result = await _interactor.UpdateAsync(id, dto.ToEntity());
        return result switch {
            false => BadRequest(),
            null => NotFound(),
            true => NoContent(),
        };
    }
}