using ComputerManagement.DTOs;

namespace ComputerManagement.Services;

public interface IDbService
{
    Task<IEnumerable<GetAllPcsDto>> GetAllPcsAsync();
    Task<GetPcWithComponentsDto> GetPcWithComponentsByIdAsync(int id);
    Task<GetAllPcsDto> AddPcAsync(AddPcDto pcDto);
    Task UpdatePcAsync(int id, UpdatePcDto pcDto);
    Task RemovePcByIdAsync(int id);
}
