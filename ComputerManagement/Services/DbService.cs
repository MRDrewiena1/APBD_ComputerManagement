using ComputerManagement.Data;
using ComputerManagement.DTOs;
using ComputerManagement.Entities;
using ComputerManagement.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ComputerManagement.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetAllPcsDto>> GetAllPcsAsync()
    {
        return await _dbContext.PCs
            .Select(p => new GetAllPcsDto
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

    public async Task<GetPcWithComponentsDto> GetPcWithComponentsByIdAsync(int id)
    {
        var res = await _dbContext.PCs
            .Where(p => p.Id == id)
            .Select(p => new GetPcWithComponentsDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock,
                Components = p.PCComponents.Select(pc => new PcComponentDto
                {
                    Code = pc.ComponentCode.Trim(),
                    Name = pc.Component.Name,
                    Description = pc.Component.Description,
                    Amount = pc.Amount,
                    ComponentType = pc.Component.ComponentType.Name,
                    Manufacturer = pc.Component.Manufacturer.FullName
                })
            })
            .FirstOrDefaultAsync();

        if (res == null)
        {
            throw new NotFoundException($"PC with id {id} was not found.");
        }

        return res;
    }

    public async Task<GetAllPcsDto> AddPcAsync(AddPcDto pcDto)
    {
        var pc = new PC()
        {
            Name = pcDto.Name,
            Weight = pcDto.Weight,
            Warranty = pcDto.Warranty,
            CreatedAt = pcDto.CreatedAt,
            Stock = pcDto.Stock
        };

        await _dbContext.AddAsync(pc);
        await _dbContext.SaveChangesAsync();

        return new GetAllPcsDto()
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task UpdatePcAsync(int id, UpdatePcDto pcDto)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException($"PC with id {id} was not found.");
        }

        pc.Name = pcDto.Name;
        pc.Weight = pcDto.Weight;
        pc.Warranty = pcDto.Warranty;
        pc.CreatedAt = pcDto.CreatedAt;
        pc.Stock = pcDto.Stock;

        await _dbContext.SaveChangesAsync();
    }

    public async Task RemovePcByIdAsync(int id)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null)
        {
            throw new NotFoundException($"PC with id {id} was not found.");
        }

        _dbContext.PCs.Remove(pc);
        await _dbContext.SaveChangesAsync();
    }
}
