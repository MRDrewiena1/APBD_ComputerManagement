using ComputerManagement.Business.DTOs.Request;
using ComputerManagement.Business.DTOs.Response;
using ComputerManagement.Business.Interfaces;
using ComputerManagement.Data.Context;
using ComputerManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComputerManagement.Business.Services;

public class PcService : IPcService
{
    private readonly AppDbContext _context;

    public PcService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PcResponseDto>> GetAllPcsAsync()
    {
        return await _context.PCs
            .AsNoTracking()
            .Select(p => new PcResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
    }

    public async Task<PcComponentsResponseDto?> GetPcComponentsAsync(int id)
    {
        var pc = await _context.PCs
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Select(p => new PcComponentsResponseDto
            {
                PcId = p.Id,
                PcName = p.Name,
                Components = p.PCComponents.Select(pcc => new ComponentDetailDto
                {
                    Code = pcc.ComponentCode.Trim(),
                    Name = pcc.Component.Name,
                    Description = pcc.Component.Description,
                    Amount = pcc.Amount,
                    ComponentType = pcc.Component.ComponentType.Name,
                    Manufacturer = pcc.Component.Manufacturer.FullName
                }).ToList()
            })
            .FirstOrDefaultAsync();

        return pc;
    }

    public async Task<PcResponseDto> CreatePcAsync(PcRequestDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();

        return MapToDto(pc);
    }

    public async Task<PcResponseDto?> UpdatePcAsync(int id, PcRequestDto dto)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc is null) return null;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();

        return MapToDto(pc);
    }

    public async Task<bool> DeletePcAsync(int id)
    {
        var pc = await _context.PCs.FindAsync(id);
        if (pc is null) return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
        return true;
    }

    private static PcResponseDto MapToDto(PC pc) => new()
    {
        Id = pc.Id,
        Name = pc.Name,
        Weight = pc.Weight,
        Warranty = pc.Warranty,
        CreatedAt = pc.CreatedAt,
        Stock = pc.Stock
    };
}
