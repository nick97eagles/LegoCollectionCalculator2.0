using System.Net;
using LegoCollectionCalculator2._0.Server.API.Extension;
using LegoCollectionCalculator2._0.Server.RqModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LegoCollectionCalculator2._0.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrickLinkController : MediatedControllerBase
    {
        private readonly IMediator _mediator;

        public BrickLinkController(IMediator mediator)
            : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("set/{SetID}")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetSetInfo([FromRoute] GetSetRqModel request)
        {
            var result = await this._mediator.Send(request);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
