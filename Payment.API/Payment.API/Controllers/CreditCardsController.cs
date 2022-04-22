using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Payment.API.Entities;
using Payment.API.Results;
using Payment.API.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardsController : Controller
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardsController(CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("getusercreditcards")]
        public async Task<ActionResult<List<CreditCard>>> GetUserCreditCards()
        {
            var cards = await _creditCardService.GetAsync();

            if (cards is null)
            {
                return NotFound();
            }
            return cards;
        }

        [HttpGet("getbyid")]
        public async Task<ActionResult<CreditCard>> Get(string id)
        {
            var creditCard = await _creditCardService.GetAsync(id);

            if (creditCard is null)
            {
                return NotFound();
            }

            return creditCard;
        }

        [HttpPost]
        public async Task<ActionResult<IResult>> Post([FromBody]CreditCard creditCard)
        {
            await _creditCardService.CreateAsync(creditCard);

            return new SuccessResult("Kredi Kartı Eklendi");
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(string id, CreditCard creditCard)
        {
            var book = await _creditCardService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            creditCard.UserId = creditCard.UserId;

            await _creditCardService.UpdateAsync(id, creditCard);

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IResult> Delete(string id)
        {
            var creditCard = await _creditCardService.GetAsync(id);

            if (creditCard is null)
            {
                return new ErrorResult("Kredi kartı bulunamadı.");
            }

            await _creditCardService.RemoveAsync(id);

            return new SuccessResult("Kredi kartı silindi.");
        }
    }
}
