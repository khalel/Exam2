using Microsoft.AspNetCore.Mvc;
using QLESS.Contract.Request;
using QLESS.Controller.Service;

namespace QLESS.Controller.v1
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

        [HttpGet("List")]
        public ActionResult<object> GetCards()
        {
            return Ok(_cardService.GetCards());
        }

        [HttpPost("Add")]
        public ActionResult<object> AddCard()
        {
            return Ok(_cardService.AddCard());
        }

        [HttpGet("BySerialNumber")]
        public ActionResult<object> GetCardBySerialNumber(string serialNumber)
        {
            return Ok(_cardService.GetCardBySerialNumber(serialNumber));
        }

        [HttpPost("Register")]
        public ActionResult<object> CardRegister([FromBody]PostCardRegisterRequest request)
        {
            return Ok(_cardService.CardRegister(request));
        }

        [HttpPost("Use")]
        public ActionResult<object> CardUse(string serialNumber)
        {
            return Ok(_cardService.CardUse(serialNumber));
        }

        [HttpPost("Reload")]
        public ActionResult<object> CardReload(string serialNumber, int amount)
        {
            return Ok(_cardService.CardReload(serialNumber, amount));
        }
    }
}
