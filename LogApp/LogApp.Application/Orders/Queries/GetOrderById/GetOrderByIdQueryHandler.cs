using AutoMapper;
using LogApp.Application.Common.Interfaces;
using LogApp.Application.Orders.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderViewModel>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Orders
                                        .Include(o => o.CostCenter)
                                        .Include(s => s.Shipment)
                                        .Where(c => c.Id == request.Id)
                                        .Where(d => !d.IsDeleted)
                                        .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<OrderViewModel>(result);
        }
    }
}
