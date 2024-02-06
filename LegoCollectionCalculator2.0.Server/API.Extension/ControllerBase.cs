using System.Collections;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LegoCollectionCalculator2._0.Server.API.Extension
{
    public abstract class MediatedControllerBase : ControllerBase
    {
        protected MediatedControllerBase(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected async Task<IActionResult> GetOrNoContent<TRqModel, TRsModel>(TRqModel rqModel, Func<TRsModel, object> transformResult = null)
            where TRqModel : IRequest<TRsModel>
        {
            var rsModel = await Mediator.Send(rqModel);

            if (rsModel == null)
            {
                return NoContent();
            }

            var enumerableRsModel = rsModel as IEnumerable;
            if (enumerableRsModel != null && !enumerableRsModel.GetEnumerator().MoveNext())
            {
                return NoContent();
            }

            return Ok(transformResult == null ? rsModel : transformResult(rsModel));

        }

        protected IMediator Mediator { get; }
    }
}
