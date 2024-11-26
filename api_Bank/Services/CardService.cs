using api_Bank.Dtos;
using api_Bank.Interfaces;
using api_bank.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_Bank.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<List<CardDto.CardDtoRead>> GetAllAsyncCard()
        {
            var cards = await _cardRepository.GetAllAsyncCard();
            return cards.Select(card => new CardDto.CardDtoRead
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
                DeletedAt = card.DeletedAt
            }).ToList();
        }

        public async Task<CardDto.CardDtoRead> GetByIdAsyncCard(int id)
        {
            var card = await _cardRepository.GetByIdAsyncCard(id);
            if (card == null) throw new KeyNotFoundException("Card not found.");

            return new CardDto.CardDtoRead
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
                DeletedAt = card.DeletedAt
            };
        }

        public async Task<CardDto.CardDtoRead> CreateAsyncCard(CardDto.CardDtoCreate cardDto)
        {
            var card = new Card
            {
                UserId = cardDto.UserId,
                CardNumber = cardDto.CardNumber,
                ExpirationDate = cardDto.ExpirationDate,
                Balance = cardDto.Balance,
                IsDeleted = cardDto.IsDeleted,
                DeletedAt = cardDto.DeletedAt
            };

            var createdCard = await _cardRepository.AddAsyncCard(card);
            return new CardDto.CardDtoRead
            {
                CardId = createdCard.CardId,
                UserId = createdCard.UserId,
                CardNumber = createdCard.CardNumber,
                CardType = createdCard.CardType,
                ExpirationDate = createdCard.ExpirationDate,
                Balance = createdCard.Balance,
                CurrencyId = createdCard.CurrencyId,
                CreditLimit = createdCard.CreditLimit,
                IsDeleted = createdCard.IsDeleted,
                DeletedAt = createdCard.DeletedAt
            };
        }

        public async Task UpdateAsyncCard(int id, CardDto.CardDtoUpdate cardDto)
        {
            var card = await _cardRepository.GetByIdAsyncCard(id);
            if (card == null) throw new KeyNotFoundException("Card not found.");

            card.CardNumber = cardDto.CardNumber;
            card.CardType = cardDto.CardType;
            card.ExpirationDate = cardDto.ExpirationDate;
            card.Balance = cardDto.Balance;
            card.CreditLimit = cardDto.CreditLimit;
            card.DeletedAt = cardDto.DeletedAt;
            card.IsDeleted = cardDto.IsDeleted;

            await _cardRepository.UpdateAsyncCard(card);
        }

        public async Task<CardDto.CardDtoRead?> DeleteAsyncCard(int id)
        {
            var card = await _cardRepository.GetByIdAsyncCard(id);

            if (card == null)
            {
                // Можно выбросить исключение или вернуть null
                return null;  // Возвращаем null, если карта не найдена
            }

            card.IsDeleted = true;
            card.DeletedAt = DateTime.Now;

            await _cardRepository.UpdateAsyncCard(card);

            return new CardDto.CardDtoRead
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
                DeletedAt = card.DeletedAt
            };
        }

    }
}
