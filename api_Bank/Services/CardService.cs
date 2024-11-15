using api_Bank.Dtos;
using api_Bank.Interfaces;
using api_bank.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api_Bank.Services;

public class CardService : ICardService
{
    
    private readonly ICardRepository _cardRepository;

    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
    
    
    
    public async Task<List<CardDto.Read>> GetAllAsync()
    {
        var cards = await _cardRepository.GetAllAsync
            ();
        return (List<CardDto.Read>)cards.Select(e => new CardDto.Read
        {
            CardId = e.CardId,
            UserId = e.UserId,
            CardNumber = e.CardNumber,
            CardType = e.CardType,
            ExpirationDate = e.ExpirationDate,
            Balance = e.Balance,
            CurrencyId = e.CurrencyId,
            CreditLimit = e.CreditLimit,
            IsDeleted = e.IsDeleted,
            DeletedAt = e.DeletedAt,
        });

    }

    public async Task<CardDto.Read> GetByIdAsync(int id)
    {
        var cards = await _cardRepository.GetByIdAsync(id);

        if (cards == null)
        {
            return null;}

        return new CardDto.Read
        {
            CardId = cards.CardId,
            UserId = cards.UserId,
            CardNumber = cards.CardNumber,
            Balance = cards.Balance,
            CurrencyId = cards.CurrencyId,
            IsDeleted = cards.IsDeleted,
            DeletedAt = cards.DeletedAt,
        };
    }

    public async Task<CardDto.Read> CreateAsync(CardDto.Create cardDto)
    {
        var cards = new Card
        {
            UserId = cardDto.UserId,
            CardId = cardDto.CardId,
            Balance = cardDto.Balance,
            CardNumber = cardDto.CardNumber,
            IsDeleted = cardDto.IsDeleted,
            DeletedAt = cardDto.DeletedAt,
        };

        var createdCard = await _cardRepository.AddAsync(cards);

        return new CardDto.Read
        {
            CardId = createdCard.CardId,
            Balance = createdCard.Balance,
            CardNumber = createdCard.CardNumber,
            CardType = createdCard.CardType,
            CurrencyId = createdCard.CurrencyId,
            IsDeleted = createdCard.IsDeleted,
            DeletedAt = createdCard.DeletedAt,
        };

    }

    public async Task UpdateAsync(int id, CardDto.Update cardDto)
    {
        var card = await _cardRepository.GetByIdAsync(id);

        if (card == null) return;

        card.CardNumber = cardDto.CardNumber;
        card.Balance = cardDto.Balance;
        card.CardType = cardDto.CardType;
        card.ExpirationDate = cardDto.ExpirationDate;
        card.CreditLimit = cardDto.CreditLimit;
        
        await _cardRepository.UpdateAsync(card);
    }
    
    public async Task<CardDto.Read> DeleteAsync(int id)
    {
        var card = await _cardRepository.GetByIdAsync(id);
        if (card == null)
        {
            return null;
        }
        
        card.IsDeleted = true;
        card.DeletedAt = DateTime.UtcNow;

        await _cardRepository.UpdateAsync(card);
        
        return new CardDto.Read
        {
            CardId = card.CardId,
            UserId = card.UserId,
            CardNumber = card.CardNumber,
            CardType = card.CardType,
            ExpirationDate = card.ExpirationDate,
            Balance = card.Balance,
            CurrencyId = card.CurrencyId,
            CreditLimit = card.CreditLimit,
            IsDeleted = card.IsDeleted,
            DeletedAt = card.DeletedAt,
        };
    }
    
}