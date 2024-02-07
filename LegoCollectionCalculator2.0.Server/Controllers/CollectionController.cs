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
    public class CollectionController : MediatedControllerBase
    {
        private readonly IMediator _mediator;

        public CollectionController(IMediator mediator)
            : base(mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("theme")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetThemes([FromQuery] GetThemesRqModel request)
        {
            var result = await this._mediator.Send(request);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("theme/create")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateTheme([FromBody] CreateThemeRqModel request)
        {
            var result = await this._mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        [Route("theme/edit")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> EditTheme([FromBody] EditThemeRqModel request)
        {
            var result = await _mediator.Send(request);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("theme/{ThemeID}")]
        [AllowAnonymous]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTheme([FromRoute] DeleteThemeRqModel request)
        {
            var result = await this._mediator.Send(request);

            return Ok(result);
        }

    }
}
