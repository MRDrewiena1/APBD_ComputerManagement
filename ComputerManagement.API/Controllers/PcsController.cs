using ComputerManagement.Business.DTOs.Request;
using ComputerManagement.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComputerManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }

    /// <summary>
    /// GET api/pcs — Pobiera listę wszystkich komputerów.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPcs()
    {
        var pcs = await _pcService.GetAllPcsAsync();
        return Ok(pcs);
    }

    /// <summary>
    /// GET api/pcs/{id}/components — Pobiera komponenty wybranego komputera.
    /// </summary>
    [HttpGet("{id}/components")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPcComponents(int id)
    {
        var result = await _pcService.GetPcComponentsAsync(id);
        if (result is null)
            return NotFound(new { message = $"Computer with id {id} was not found." });

        return Ok(result);
    }

    /// <summary>
    /// POST api/pcs — Dodaje nowy komputer.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePc([FromBody] PcRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _pcService.CreatePcAsync(dto);
        return CreatedAtAction(nameof(GetPcComponents), new { id = created.Id }, created);
    }

    /// <summary>
    /// PUT api/pcs/{id} — Aktualizuje dane komputera.
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdatePc(int id, [FromBody] PcRequestDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _pcService.UpdatePcAsync(id, dto);
        if (updated is null)
            return NotFound(new { message = $"Computer with id {id} was not found." });

        return Ok(updated);
    }

    /// <summary>
    /// DELETE api/pcs/{id} — Usuwa komputer.
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeletePc(int id)
    {
        var deleted = await _pcService.DeletePcAsync(id);
        if (!deleted)
            return NotFound(new { message = $"Computer with id {id} was not found." });

        return NoContent();
    }
}
