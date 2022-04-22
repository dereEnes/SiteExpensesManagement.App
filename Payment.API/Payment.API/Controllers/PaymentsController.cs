using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Payment.API.Entities;
using Payment.API.Results;
using Payment.API.Services;
using System.Threading.Tasks;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public async Task<ActionResult<IResult>> DoPayment(PaymentDto payment)
        {
            var result = await _paymentService.CreateAsync(payment);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(new Result
            {
                Message = "Ödeme tamamlandı.",
                Success = true
            });
        }
    }
}
