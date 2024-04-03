using AutoMapper;
using LegoCollectionCalculator2._0.Server.Entities.Bricklink;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using LegoCollectionCalculator2._0.Server.Services;
using MediatR;
using Newtonsoft.Json;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class GetSetHandler : IRequestHandler<GetSetRqModel, GetSetRsModel>
    {
        private readonly IBrickLinkService _brickLinkService;
        private readonly IMapper _mapper;

        public GetSetHandler(IBrickLinkService brickLinkService, IMapper mapper)
        {
            _mapper = mapper;
            _brickLinkService = brickLinkService;
        }

        public async Task<GetSetRsModel> Handle(GetSetRqModel request, CancellationToken cancellation)
        {
            var result = await _brickLinkService.GetSet(request.SetID);
            BricklinkRespDbo<BricklinkSetDbo>? parsedResult = JsonConvert.DeserializeObject<BricklinkRespDbo<BricklinkSetDbo>>(result);

            if (parsedResult == null)
            {
                return new GetSetRsModel();
            }

            return _mapper.Map<BricklinkRespDbo<BricklinkSetDbo>, GetSetRsModel>(parsedResult);
        }
    }
}
