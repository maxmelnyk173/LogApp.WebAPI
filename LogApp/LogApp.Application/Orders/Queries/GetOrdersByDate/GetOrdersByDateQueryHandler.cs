using AutoMapper;
using LogApp.Application.Common.Interfaces;
using LogApp.Application.Orders.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Queries.GetOrdersByDate
{
    public class GetOrdersByDateQueryHandler : IRequestHandler<GetOrdersByDateQuery, List<OrderViewModel>>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetOrdersByDateQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderViewModel>> Handle(GetOrdersByDateQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Orders
                                .Include(c => c.CostCenter)
                                .Include(s => s.Shipment)
                                .Where(f => f.Created > request.FromDate)
                                .Where(t => t.Created < request.ToDate)
                                .Where(d => !d.IsDeleted)
                                .ToListAsync(cancellationToken);

            return _mapper.Map<List<OrderViewModel>>(result);
        }
    }
}

