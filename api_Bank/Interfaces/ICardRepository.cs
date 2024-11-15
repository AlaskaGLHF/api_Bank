using api_bank.Models;

namespace api_Bank.Interfaces;

public interface ICardRepository
{
    public Task<List<Card>> GetAllAsync();
    public Task<Card> GetByIdAsync(int id);
    public Task<Card> AddAsync(Card entity);
    public Task UpdateAsync(Card entity);
    public Task DeleteAsync(int id);
}