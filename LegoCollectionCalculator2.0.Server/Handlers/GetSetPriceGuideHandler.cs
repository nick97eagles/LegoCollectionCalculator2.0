using AutoMapper;
using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.Entities.Bricklink;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using LegoCollectionCalculator2._0.Server.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class GetSetPriceGuideHandler : IRequestHandler<GetSetPriceGuideRqModel, GetSetPriceGuideRsModel>
    {
        private readonly IMapper _mapper;
        private readonly IBrickLinkService _bricklinkService;
        private readonly CollectionContext _collectionContext;

        public GetSetPriceGuideHandler(
            IMapper mapper,
            IBrickLinkService bricklinkService,
            CollectionContext collectionContext)
        {
            _mapper = mapper;
            _bricklinkService = bricklinkService;
            _collectionContext = collectionContext;
        }

        public async Task<GetSetPriceGuideRsModel> Handle(GetSetPriceGuideRqModel request, CancellationToken cancellationToken)
        {
            var setInfo = await _collectionContext.Sets
                    .Where(x => x.IdentificationNumber == request.SetID)
                    .FirstAsync(cancellationToken);

            var response = await _bricklinkService.GetSetPriceGuide(request.SetID, request.N_or_u, cancellationToken);
            BricklinkRespDbo<BricklinkPriceGuideDbo>? parsedResult = JsonConvert.DeserializeObject<BricklinkRespDbo<BricklinkPriceGuideDbo>>(response);

            if (parsedResult == null)
            {
                return new GetSetPriceGuideRsModel();
            }

            var mappedResults =  _mapper.Map<BricklinkRespDbo<BricklinkPriceGuideDbo>, GetSetPriceGuideRsModel>(parsedResult);

            // Update AvgPrice if price has changed
            if (String.IsNullOrEmpty(setInfo?.AvgPrice) ||
                mappedResults.Average_Price != setInfo.AvgPrice)
            {
                setInfo.AvgPrice = mappedResults.Average_Price;
                await _collectionContext.SaveChangesAsync(cancellationToken);
            }

            return mappedResults;
        }
    }
}
