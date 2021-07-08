using AutoMapper;
using LogApp.Application.Common.Exceptions;
using LogApp.Application.Common.Interfaces;
using LogApp.Application.Orders.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderViewModel>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Orders.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Orders), request.Id);
            }

            _mapper.Map(request.Order, entity);

            await _context.SaveChangesAsync(cancellationToken);


            var order = _context.Orders.Where(i => i.Id == request.Id)
                                       .Include(o => o.CostCenter)
                                       .Include(s => s.Shipment)
                                       .FirstOrDefault();

            return _mapper.Map<OrderViewModel>(order);
        }
    }
}
