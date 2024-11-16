using api_Bank.Dtos;
using Microsoft.AspNetCore.Mvc;
using api_Bank.Interfaces;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDto.Read>>> GetAllCards()
        {
            var cards = await _cardService.GetAllAsync();
            return Ok(cards);
        }

        // GET: api/cards/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDto.Read>> GetCardById(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            if (card == null)
            {
                return NotFound(); // Возвращаем статус 404
            }
            return Ok(card); // Возвращаем статус 200
        }

        // POST: api/cards
        [HttpPost]
        public async Task<ActionResult<CardDto.Read>> CreateCard([FromBody] CardDto.Create cardDto)
        {
            if (cardDto == null)
            {
                return BadRequest(); 
            }

            var createdCard = await _cardService.CreateAsync(cardDto);
            return CreatedAtAction(nameof(GetCardById), new { id = createdCard.CardId }, createdCard);
        }

        // PUT: api/cards/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(int id, [FromBody] CardDto.Update cardDto)
        {
            if (cardDto == null)
            {
                return BadRequest();
            }

            var existingCard = await _cardService.GetByIdAsync(id);
            if (existingCard == null)
            {
                return Ok(cardDto);
            }

            await _cardService.UpdateAsync(id, cardDto);
            return NoContent(); 
        }

        // DELETE: api/cards/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            
            await _cardService.DeleteAsync(id);
            return Ok(card);
        }
    }
}
