using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class DeleteSetHandler : IRequestHandler<DeleteSetRqModel, DeleteSetRsModel>
    {
        private readonly CollectionContext _collectionContext;

        public DeleteSetHandler(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
        }

        public async Task<DeleteSetRsModel> Handle(DeleteSetRqModel request, CancellationToken cancellationToken)
        {
            _collectionContext.Sets.Remove(_collectionContext.Sets.Single(x => x.SetID == request.SetID));
            await _collectionContext.SaveChangesAsync();

            return new DeleteSetRsModel
            {
                ResultMessage = "Set Deleted Successfully"
            };
        }
    }
}
