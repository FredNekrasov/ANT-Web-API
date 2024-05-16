using AlexanderNevskyTemple.BLL.interactors;
using AlexanderNevskyTemple.WebAPI.dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlexanderNevskyTemple.WebAPI.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class ChapterController(ChapterInteractor interactor, IMapper mapper) : ControllerBase {
    private readonly ChapterInteractor _interactor = interactor;
    private readonly IMapper _mapper = mapper;
    [HttpGet]
    public async Task<ActionResult<ICollection<ChapterDto>>> GetListAsync() {
        var chapters = await _interactor.GetListAsync();
        if(chapters == null) return NoContent();
        return Ok(_mapper.Map<List<ChapterDto>>(chapters));
    }
    [HttpGet("{type}")]
    public async Task<ActionResult<ICollection<ChapterDto>>> GetListAsyncByType(string type) {
        var chapters = await _interactor.GetListAsync();
        if(chapters == null) return NoContent();
        chapters = chapters.GroupBy(i => i.Catalog.Name).FirstOrDefault(i => i.Key == type)?.ToList();
        return Ok(_mapper.Map<List<ChapterDto>>(chapters));
    }
}