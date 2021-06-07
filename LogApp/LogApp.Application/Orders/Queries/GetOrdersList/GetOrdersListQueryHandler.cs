using AutoMapper;
using LogApp.Application.Common.Interfaces;
using LogApp.Application.Orders.Queries.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderViewModel>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetOrdersListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Orders
                                .Include(c => c.CostCenter)
                                .Include(s => s.Shipment)
                                .Where(d => !d.IsDeleted)
                                .ToListAsync(cancellationToken);

            return _mapper.Map<List<OrderViewModel>>(result);
        }
    }
}
