using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class GetThemesHandler : IRequestHandler<GetThemesRqModel, GetThemesRsModel>
    {
        private readonly CollectionContext _collectinContext;

        public GetThemesHandler(CollectionContext collectinContext)
        {
            _collectinContext = collectinContext;
        }

        public async Task<GetThemesRsModel> Handle(GetThemesRqModel request, CancellationToken cancellationToken)
        {
            var themes = _collectinContext.Themes.Where(x => x.CollectionID == request.CollectionID).ToList();

            if (themes.Any())
            {
                return new GetThemesRsModel
                {
                    Themes = themes,
                };
            }

            return new GetThemesRsModel();
        }
    }
}
