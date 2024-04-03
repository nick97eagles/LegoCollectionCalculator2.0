using AutoMapper;
using LegoCollectionCalculator2._0.Server.Entities.Bricklink;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using LegoCollectionCalculator2._0.Server.Services;
using MediatR;
using Newtonsoft.Json;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class GetSetPriceGuideHandler : IRequestHandler<GetSetPriceGuideRqModel, GetSetPriceGuideRsModel>
    {
        private readonly IMapper _mapper;
        private readonly IBrickLinkService _bricklinkService;

        public GetSetPriceGuideHandler(IMapper mapper, IBrickLinkService bricklinkService)
        {
            _mapper = mapper;
            _bricklinkService = bricklinkService;
        }

        public async Task<GetSetPriceGuideRsModel> Handle(GetSetPriceGuideRqModel request, CancellationToken cancellationToken)
        {
            var response = await _bricklinkService.GetSetPriceGuide(request.SetID, request.N_or_u, cancellationToken);
            BricklinkRespDbo<BricklinkPriceGuideDbo>? parsedResult = JsonConvert.DeserializeObject<BricklinkRespDbo<BricklinkPriceGuideDbo>>(response);

            if (parsedResult == null)
            {
                return new GetSetPriceGuideRsModel();
            }

            return _mapper.Map<BricklinkRespDbo<BricklinkPriceGuideDbo>, GetSetPriceGuideRsModel>(parsedResult);
        }
    }
}
