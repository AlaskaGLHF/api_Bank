using api_Bank.Dtos;

namespace api_Bank.Interfaces;

public interface ICardService
{
    
    Task<List<CardDto.Read>> GetAllAsync();
    
    Task<CardDto.Read> GetByIdAsync(int id);

    Task<CardDto.Read> CreateAsync(CardDto.Create cardDto);
   
    Task UpdateAsync(int id, CardDto.Update cardDto);
    
    Task<CardDto.Read> DeleteAsync(int id);
}