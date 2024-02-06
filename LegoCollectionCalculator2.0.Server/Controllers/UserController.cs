using System.Net;
using LegoCollectionCalculator2._0.Server.API.Extension;
using LegoCollectionCalculator2._0.Server.RqModel;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LegoCollectionCalculator2._0.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : MediatedControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
            : base(mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("login")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Login([FromQuery] LoginRqModel request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRqModel request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
