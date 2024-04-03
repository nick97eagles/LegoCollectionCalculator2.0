using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class GetSetsHandler : IRequestHandler<GetSetsRqModel, GetSetsRsModel>
    {
        private readonly CollectionContext _collectionContext;

        public GetSetsHandler(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }

        public async Task<GetSetsRsModel> Handle(GetSetsRqModel request, CancellationToken cancellationToken)
        {
            var sets = _collectionContext.Sets.Where(x => x.ThemeID == request.ThemeID).ToList();

            // TODO: implement AutoMapper
            if (sets.Any())
            {
                var setList = new List<GetSetModel>();

                foreach(var set in sets)
                {
                    setList.Add(new GetSetModel
                    {
                       SetID = set.SetID,
                       ThemeID = set.ThemeID,
                       Name = set.Name,
                       Condition = set.Condition,
                       IdentificationNumber = set.IdentificationNumber
                    });
                }

                return new GetSetsRsModel
                {
                    Sets = setList
                };
            }

            return new GetSetsRsModel();
        }
    }
}
