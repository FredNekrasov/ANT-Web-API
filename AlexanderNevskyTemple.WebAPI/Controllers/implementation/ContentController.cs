using AlexanderNevskyTemple.BLL.interactors;
using AlexanderNevskyTemple.DAL.entities;
using AlexanderNevskyTemple.WebAPI.dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlexanderNevskyTemple.WebAPI.Controllers.implementation;
[Route("api/v2/[controller]")]
[ApiController]
public class ContentController(IInteractor<Content, long> interactor, IMapper mapper) : IController<ContentDto, long> {
    private readonly IInteractor<Content, long> _interactor = interactor;
    private readonly IMapper _mapper = mapper;
    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(long id) {
        bool? result = await _interactor.DeleteAsync(id);
        if((result != null) && (result == true)) return Ok(); else return BadRequest();
    }
    [HttpGet]
    public override async Task<ActionResult<IEnumerable<ContentDto>>> GetListAsync() {
        var result = await _interactor.GetListAsync();
        if(result == null) return NoContent();
        return Ok(_mapper.Map<List<ContentDto>>(result));
    }
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(ContentDto dto) {
        bool result = await _interactor.InsertAsync(_mapper.Map<Content>(dto));
        if(result) return Ok(); else return BadRequest();
    }
    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(long id, ContentDto dto) {
        bool? result = await _interactor.UpdateAsync(id, _mapper.Map<Content>(dto));
        return result switch {
            false => BadRequest(),
            null => NotFound(),
            true => NoContent(),
        };
    }
}