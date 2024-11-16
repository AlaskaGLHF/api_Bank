using api_Bank.Interfaces;
using api_bank.Models;
using Microsoft.EntityFrameworkCore;

namespace api_bank.Repositories;

public class CardRepository : ICardRepository
{
    private readonly BankContext _context;

    public CardRepository(BankContext context)
    {
        _context = context;
    }


    public async Task<List<Card>> GetAllAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task<Card> GetByIdAsync(int id)
    {
        return await _context.Cards.FindAsync(id); 
    }

    public async Task<Card> AddAsync(Card entity)
    {
        _context.Cards.Add(entity);
        await _context.SaveChangesAsync(); 
        return entity;
    }

    public async Task UpdateAsync(Card entity)
    {
        _context.Cards.Update(entity);
        await _context.SaveChangesAsync(); 
    }

    public async Task DeleteAsync(int id)
    {
        var  card = await _context.Cards.FindAsync(id);
        if (card != null)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}
