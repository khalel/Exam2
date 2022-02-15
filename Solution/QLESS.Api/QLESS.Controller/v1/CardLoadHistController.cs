using Microsoft.AspNetCore.Mvc;
using QLESS.Controller.Service;

namespace QLESS.Controller.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardLoadHistController : ControllerBase
    {
        private readonly ICardLoadHistService _cardLoadHistService;

        public CardLoadHistController(ICardLoadHistService cardLoadHistService)
        {
            _cardLoadHistService = cardLoadHistService;
        }

        [HttpGet("List")]
        public ActionResult<object> GetCardLoadHists()
        {
            return Ok(_cardLoadHistService.GetCardLoadHists());
        }
    }
}
