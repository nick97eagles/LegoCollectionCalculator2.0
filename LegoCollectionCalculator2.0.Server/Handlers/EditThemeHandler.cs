using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class EditThemeHandler : IRequestHandler<EditThemeRqModel, EditThemeRsModel>
    {
        private readonly CollectionContext _collectionContext;

        public EditThemeHandler(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }

        public async Task<EditThemeRsModel> Handle(EditThemeRqModel request, CancellationToken cancellationToken)
        {
            var theme = _collectionContext.Themes.First(x => x.ThemeID == request.ThemeID);

            if (theme == null)
            {
                return new EditThemeRsModel();
            }
            
            if (!string.IsNullOrEmpty(request.Name))
            {
                theme.Name = request.Name;
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                theme.Description = request.Description;
            }

            await _collectionContext.SaveChangesAsync(cancellationToken);

            return new EditThemeRsModel
            {
                ResultMessage = "Edit Successfull"
            };
        }
    }
}
