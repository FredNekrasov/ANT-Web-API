using Microsoft.AspNetCore.Mvc;

namespace AlexanderNevskyTemple.WebAPI.Controllers; 
public abstract class IController<D, I> : ControllerBase {
    public abstract Task<ActionResult<IEnumerable<D>>> GetListAsync();
    public abstract Task<IActionResult> PutRecordAsync(I id, D dto);
    public abstract Task<IActionResult> PostRecordAsync(D dto);
    public abstract Task<IActionResult> DeleteRecordAsync(I id);
}