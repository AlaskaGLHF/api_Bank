using api_bank.Models;

namespace api_Bank.Interfaces;

public interface ICardRepository
{
    public Task<List<Card>> GetAllAsyncCard();
    public Task<Card> GetByIdAsyncCard(int id);
    public Task<Card> AddAsyncCard(Card entity);
    public Task UpdateAsyncCard(Card entity);
    public Task DeleteAsyncCard(int id);
}