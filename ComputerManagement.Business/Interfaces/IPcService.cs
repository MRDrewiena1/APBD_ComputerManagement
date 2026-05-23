using ComputerManagement.Business.DTOs.Request;
using ComputerManagement.Business.DTOs.Response;

namespace ComputerManagement.Business.Interfaces;

public interface IPcService
{
    Task<IEnumerable<PcResponseDto>> GetAllPcsAsync();
    Task<PcComponentsResponseDto?> GetPcComponentsAsync(int id);
    Task<PcResponseDto> CreatePcAsync(PcRequestDto dto);
    Task<PcResponseDto?> UpdatePcAsync(int id, PcRequestDto dto);
    Task<bool> DeletePcAsync(int id);
}
