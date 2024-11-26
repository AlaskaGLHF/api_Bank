using api_Bank.Dtos;

namespace api_Bank.Interfaces;

public interface ICardService
{
    
    Task<List<CardDto.CardDtoRead>> GetAllAsyncCard();
    Task<CardDto.CardDtoRead> GetByIdAsyncCard(int id);
    Task<CardDto.CardDtoRead> CreateAsyncCard(CardDto.CardDtoCreate cardDto);
    Task UpdateAsyncCard(int id, CardDto.CardDtoUpdate cardDto);
    Task<CardDto.CardDtoRead?> DeleteAsyncCard(int id);
}