using System.Threading;
using LegoCollectionCalculator2._0.Server.Contexts;
using LegoCollectionCalculator2._0.Server.Entities;
using LegoCollectionCalculator2._0.Server.RqModels;
using LegoCollectionCalculator2._0.Server.RsModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LegoCollectionCalculator2._0.Server.Handlers
{
    public class AddSetHandler : IRequestHandler<AddSetRqModel, AddSetRsModel>
    {
        private readonly CollectionContext _collectionContext;

        public AddSetHandler(CollectionContext collectionContext)
        {
            _collectionContext = collectionContext;
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
                var newSet = new SetDbo
                {
                    SetID = newSetID,
                    ThemeID = request.ThemeID,
                    Name = set.Name,
                    IdentificationNumber = set.IdentificationNum,
                    Condition = set.Condition
                };

                setList.Add(newSet);
                newSetID++;
            }

            return setList;
        }
    }
}
