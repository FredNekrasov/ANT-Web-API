using AlexanderNevskyTemple.BLL.interactors;
using AlexanderNevskyTemple.BLL.models;
using AlexanderNevskyTemple.WebAPI.dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlexanderNevskyTemple.WebAPI.Controllers.implementation;
[Route("api/v2/[controller]")]
[ApiController]
public class CatalogController(IInteractor<CatalogModel, int> interactor, IMapper mapper) : IController<CatalogDto, int> {
    private readonly IInteractor<CatalogModel, int> _interactor = interactor;
    private readonly IMapper _mapper = mapper;
    [HttpDelete("{id}")]
    public override async Task<IActionResult> DeleteRecordAsync(int id) {
        bool? result = await _interactor.DeleteAsync(id);
        return result switch {
            null => BadRequest("this record is used as a foreign key in other entities"),
            false => BadRequest(),
            true => Ok()
        };
    }
    [HttpGet]
    public override async Task<ActionResult<IEnumerable<CatalogDto>>> GetListAsync() {
        var result = await _interactor.GetListAsync();
        if(result == null) return NoContent();
        return Ok(_mapper.Map<List<CatalogDto>>(result));
    }
    [HttpPost]
    public override async Task<IActionResult> PostRecordAsync(CatalogDto dto) {
        bool result = await _interactor.InsertAsync(_mapper.Map<CatalogModel>(dto));
        if(result) return Ok(); else return BadRequest();
    }
    [HttpPut("{id}")]
    public override async Task<IActionResult> PutRecordAsync(int id, CatalogDto dto) {
        bool? result = await _interactor.UpdateAsync(id, _mapper.Map<CatalogModel>(dto));
        return result switch {
            false => BadRequest(),
            null => NotFound(),
            true => Ok()
        };
    }
}