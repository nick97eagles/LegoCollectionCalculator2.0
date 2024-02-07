using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.RqModels
{
    public class DeleteThemeRqModel : IRequest<DeleteThemeRsModel>
    {
        public int ThemeID { get; set; }
    }
}
