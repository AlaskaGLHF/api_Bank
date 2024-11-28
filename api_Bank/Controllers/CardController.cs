using api_Bank.Dtos;
using Microsoft.AspNetCore.Mvc;
using api_Bank.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace api_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        // GET: api/cards
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDto.CardDtoRead>>> GetAllCards()
        {
            var cards = await _cardService.GetAllAsyncCard();
            return Ok(cards);
        }

        // GET: api/cards/{id}
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDto.CardDtoRead>> GetCardById(int id)
        {
            var card = await _cardService.GetByIdAsyncCard(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card); 
        }

        // POST: api/cards
        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<ActionResult<CardDto.CardDtoRead>> CreateCard([FromBody] CardDto.CardDtoCreate cardDto)
        {
            if (cardDto == null)
            {
                return BadRequest(); 
            }

            var createdCard = await _cardService.CreateAsyncCard(cardDto);
            return CreatedAtAction(nameof(GetCardById), new { id = createdCard.CardId }, createdCard);
        }

        // PUT: api/cards/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateCard(int id, [FromBody] CardDto.CardDtoUpdate cardDto)
        {
            if (cardDto == null)
            {
                return BadRequest();
            }

            var existingCard = await _cardService.GetByIdAsyncCard(id);
            if (existingCard == null)
            {
                return Ok(cardDto);
            }

            await _cardService.UpdateAsyncCard(id, cardDto);
            return Ok(cardDto);
        }

        // DELETE: api/cards/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _cardService.GetByIdAsyncCard(id);
            if (card == null)
            {
                return NotFound();
            }
            
            await _cardService.DeleteAsyncCard(id);
            return Ok(card);
        }
    }
}
