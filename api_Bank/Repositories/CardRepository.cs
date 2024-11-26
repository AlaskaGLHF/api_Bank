using api_Bank.Interfaces;
using api_bank.Models;
using Microsoft.EntityFrameworkCore;
using api_Bank.BankContext;

namespace api_bank.Repositories;

public class CardRepository : ICardRepository
{
    private readonly BankContext _context;

    public CardRepository(BankContext context)
    {
        _context = context;
    }


    public async Task<List<Card>> GetAllAsyncCard()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task<Card> GetByIdAsyncCard(int id)
    {
        var card = await _context.Cards.FindAsync(id);

        if (card == null)
        {
            throw new KeyNotFoundException($"Card with id {id} not found.");
        }

        return card;
    }

    public async Task<Card> AddAsyncCard(Card entity)
    {
        _context.Cards.Add(entity);
        await _context.SaveChangesAsync(); 
        return entity;
    }

    public async Task UpdateAsyncCard(Card entity)
    {
        _context.Cards.Update(entity);
        await _context.SaveChangesAsync(); 
    }

    public async Task DeleteAsyncCard(int id)
    {
        var  card = await _context.Cards.FindAsync(id);
        if (card != null)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}
