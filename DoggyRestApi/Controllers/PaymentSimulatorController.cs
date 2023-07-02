using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoggyRestApi.Controllers
{
    /// <summary>
    /// This is a simulator of payment settlement center
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PaymentSimulatorController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId">order Id</param>
        /// <param name="returnOK">true:return successful payment result; false; return failed payment result</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromQuery] Guid orderId, [FromQuery] bool returnOK = true)
        {
            if (orderId == Guid.Empty)
                return BadRequest(new { err = "order Id cannot be empty!" });

            //Pretend to be processing the payment
            await Task.Delay(2 * 1000);

            if (returnOK)
                return Ok(new
                {
                    id = Guid.NewGuid(),
                    created = DateTime.UtcNow,
                    approved = true,
                    message = "Accept",
                    payment_metohd = "Credit Card",
                    order_number = orderId,
                    card = new
                    {
                        card_type = "Credit Card",
                        last_four = "1234"
                    }
                });
            else
                return Ok(new
                {
                    id = Guid.NewGuid(),
                    created = DateTime.UtcNow,
                    approved = false,
                    message = "Reject",
                    payment_metohd = "Debit Card",
                    order_number = orderId,
                    card = new
                    {
                        card_type = "Debit Card",
                        last_four = "5678"
                    }
                });
        }


    }
}
