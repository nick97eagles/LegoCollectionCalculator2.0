using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class DeleteThemeHandler : IRequestHandler<DeleteThemeRqModel, DeleteThemeRsModel>
    {
        public readonly CollectionContext _collectionContext;

        public DeleteThemeHandler(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }

        public async Task<DeleteThemeRsModel> Handle(DeleteThemeRqModel request, CancellationToken cancellationToken)
        {
            _collectionContext.Themes.Remove(_collectionContext.Themes.Single(x => x.ThemeID == request.ThemeID));
            await _collectionContext.SaveChangesAsync();

            return new DeleteThemeRsModel
            {
                ResultMessage = "Theme Deleted Successfully"
            };
        }
    }
}
