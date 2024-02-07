using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.Entities;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class CreateThemeHandler : IRequestHandler<CreateThemeRqModel, CreateThemeRsModel>
    {
        private readonly CollectionContext _collectionContext;

        public CreateThemeHandler(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }

        public async Task<CreateThemeRsModel> Handle(CreateThemeRqModel request, CancellationToken cancellationToken)
        {
            var themeId = await _collectionContext.Themes.OrderByDescending(x => x.ThemeID).Select(x => x.ThemeID).FirstOrDefaultAsync() + 1;

            var newTheme = new ThemeDbo
            {
                ThemeID = themeId,
                Name = request.ThemeName,
                Description = request.ThemeDescription,
                CollectionID = request.CollectionID
            };

            await _collectionContext.Themes.AddAsync(newTheme);
            await _collectionContext.SaveChangesAsync();

            return new CreateThemeRsModel
            {
                ThemeID = newTheme.ThemeID,
                Name = newTheme.Name,
                Description = newTheme.Description,
            };
        }
    }
}
