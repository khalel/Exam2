using Microsoft.AspNetCore.Mvc;
using QLESS.Controller.Service;

namespace QLESS.Controller.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardRegTypeController : ControllerBase
    {
        private readonly ICardRegTypeService _cardRegTypeService;

        public CardRegTypeController(ICardRegTypeService cardRegTypeService)
        {
            _cardRegTypeService = cardRegTypeService;
        }

        [HttpGet("List")]
        public ActionResult<object> GetCardRegTypes()
        {
            return Ok(_cardRegTypeService.GetCardRegTypes());
        }
    }
}
