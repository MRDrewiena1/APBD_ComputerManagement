using ComputerManagement.DTOs;
using ComputerManagement.Exceptions;
using ComputerManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace ComputerManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PcsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PcsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPcs()
    {
        var res = await _dbService.GetAllPcsAsync();
        return Ok(res);
    }

    [Route("{id}/components")]
    [HttpGet]
    public async Task<IActionResult> GetPcWithComponentsById(int id)
    {
        try
        {
            var res = await _dbService.GetPcWithComponentsByIdAsync(id);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddPc(AddPcDto pc)
    {
        var created = await _dbService.AddPcAsync(pc);
        return Created($"api/pcs/{created.Id}", created);
    }

    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdatePc(int id, UpdatePcDto pc)
    {
        try
        {
            await _dbService.UpdatePcAsync(id, pc);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> RemovePc(int id)
    {
        try
        {
            await _dbService.RemovePcByIdAsync(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
