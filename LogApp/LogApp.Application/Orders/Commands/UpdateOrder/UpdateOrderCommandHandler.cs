using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Orders), request.Id);
            }

            entity.LotName = request.LotName;
            entity.PackingType = request.PackingType;
            entity.GoodsQuantity = request.GoodsQuantity;
            entity.Dimensions = request.Dimensions;
            entity.Weight = request.Weight;
            entity.Stackability = request.Stackability;
            entity.Route = request.Route;
            entity.PickUpDate = request.PickUpDate;
            entity.DeliveryDate = request.DeliveryDate;
            entity.BusinessId = request.BusinessId;
            entity.GoodsGL = request.GoodsGL;
            entity.GoodsType = request.GoodsType;
            entity.Notes = request.Notes;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
