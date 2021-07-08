using AutoMapper;
using LogApp.Application.Common.Interfaces;
using LogApp.Application.Orders.ViewModels;
using LogApp.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderViewModel>
    {
        private readonly IApplicationDbContext _context;

        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Order>(request);

            var result = _context.Orders.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            var order = _context.Orders.Where(i => i.Id == result.Entity.Id)
                                       .Include(o => o.CostCenter)
                                       .Include(s => s.Shipment)
                                       .FirstOrDefault();

            return _mapper.Map<OrderViewModel>(order);
        }
    }
}
