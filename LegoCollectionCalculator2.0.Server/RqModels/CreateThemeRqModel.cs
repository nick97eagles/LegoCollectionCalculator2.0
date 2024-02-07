using MediatR;
using LegoCollectionCalculator2._0.Server.RsModels;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class CreateThemeRqModel : IRequest<CreateThemeRsModel>
    {
        public int CollectionID { get; set; }

        public string ThemeName { get; set; }

        public string ThemeDescription { get; set; }
    }
}
