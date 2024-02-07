using MediatR;
using LegoCollectionCalculator2._0.Server.RsModels;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class EditThemeRqModel : IRequest<EditThemeRsModel>
    {
        public int ThemeID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
