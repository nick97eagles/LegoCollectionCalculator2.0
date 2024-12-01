using System.Threading;
using AutoMapper;
using Azure.Core;
using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.Entities;
using LegoCollectionCalculator2._0.Server.Entities.Bricklink;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using LegoCollectionCalculator2._0.Server.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class AddSetHandler : IRequestHandler<AddSetRqModel, AddSetRsModel>
    {
        private readonly IMapper _mapper;
        private readonly CollectionContext _collectionContext;
        private readonly IBrickLinkService _brickLinkService;

        public AddSetHandler(
            IMapper mapper,
            IBrickLinkService brickLinkService,
            CollectionContext collectionContext)
        {
            _mapper = mapper;
            _collectionContext = collectionContext;
            _brickLinkService = brickLinkService;
        }

        public async Task<AddSetRsModel> Handle(AddSetRqModel request, CancellationToken cancellationToken)
        {
            var setList = await CreateSetListAsync(request, cancellationToken);

            await _collectionContext.Sets.AddRangeAsync(setList);
            await _collectionContext.SaveChangesAsync();

            return new AddSetRsModel
            {
                ResultMessage = "Set Added Successfully"
            };
        }

        private async Task<List<SetDbo>> CreateSetListAsync(AddSetRqModel request, CancellationToken cancellationToken)
        { 
            var setList = new List<SetDbo>();
            var newSetID = await _collectionContext.Sets.OrderByDescending(x => x.SetID).Select(x => x.SetID).FirstOrDefaultAsync(cancellationToken) + 1;

            foreach (var set in request.Sets)
            {
                var priceGuide = await GetPriceGuideAsync(set.IdentificationNum, set.Condition, cancellationToken);

                var newSet = new SetDbo
                {
                    SetID = newSetID,
                    ThemeID = request.ThemeID,
                    Name = set.Name,
                    IdentificationNumber = set.IdentificationNum,
                    Condition = set.Condition,
                    AvgPrice = priceGuide?.Average_Price
                };

                setList.Add(newSet);
                newSetID++;
            }

            return setList;
        }

        private async Task<GetSetPriceGuideRsModel> GetPriceGuideAsync(string identificationNum, string condition, CancellationToken cancellationToken)
        {
            var response = await _brickLinkService.GetSetPriceGuide(identificationNum, condition, cancellationToken);
            BricklinkRespDbo<BricklinkPriceGuideDbo>? parsedResult = JsonConvert.DeserializeObject<BricklinkRespDbo<BricklinkPriceGuideDbo>>(response);

            if (parsedResult == null)
            {
                return new GetSetPriceGuideRsModel();
            }

            return _mapper.Map<BricklinkRespDbo<BricklinkPriceGuideDbo>, GetSetPriceGuideRsModel>(parsedResult);
        }
    }
}
