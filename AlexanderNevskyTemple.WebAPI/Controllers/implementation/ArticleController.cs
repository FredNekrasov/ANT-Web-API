using AlexanderNevskyTemple.BLL.interactors;
using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.WebAPI.dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlexanderNevskyTemple.WebAPI.Controllers.implementation;
[Route("api/v2/[controller]")]
[ApiController]
public class ArticleController(IInteractor<ArticleModel, long> interactor, IMapper mapper) : IController<ArticleDto, long> {
    private readonly IInteractor<ArticleModel, long> _interactor = interactor;
    private readonly IMapper _mapper = mapper;
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
        return Ok(_mapper.Map<List<ArticleDto>>(articles));
    }
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(ArticleDto dto) {
        bool result = await _interactor.InsertAsync(_mapper.Map<ArticleModel>(dto));
        if(result) return Ok(); else return BadRequest();
    }
    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, ArticleDto dto) {
        bool? result = await _interactor.UpdateAsync(id, _mapper.Map<ArticleModel>(dto));
        return result switch {
            false => BadRequest(),
            null => NotFound(),
            true => NoContent(),
        };
    }
}