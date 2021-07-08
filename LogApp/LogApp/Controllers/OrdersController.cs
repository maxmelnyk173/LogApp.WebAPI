using LogApp.Application.Enums;
using LogApp.Application.Orders.Commands.CreateOrder;
using LogApp.Application.Orders.Commands.DeleteOrder;
using LogApp.Application.Orders.Commands.UpdateOrder;
using LogApp.Application.Orders.Queries.GetOrderById;
using LogApp.Application.Orders.Queries.GetOrdersByDate;
using LogApp.Application.Orders.Queries.GetOrdersList;
using LogApp.Application.Orders.ViewModels;
using LogApp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<OrderViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetOrdersListQuery()));
        }

        [HttpGet("from={fromDate}/to={toDate}")]
        public async Task<ActionResult<List<OrderViewModel>>> GetByDate(DateTime fromDate, DateTime toDate)
        {
            return Ok(await Mediator.Send(new GetOrdersByDateQuery { FromDate = fromDate.ToUniversalTime(), ToDate = toDate.ToUniversalTime() } ));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderViewModel>> Get(Guid id)
        {
            var order = await Mediator.Send(new GetOrderByIdQuery { Id = id });

            if (order == null)
            {
                return NotFound();
            }

            return base.Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<OrderViewModel>> Create(CreateOrderCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteOrderCommand { Id = id });

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<OrderViewModel>> Update(Guid id, [FromBody] UpdateOrderViewModel body)
        {
            var result = await Mediator.Send(new UpdateOrderCommand { Id = id, Order = body});

            return Ok(result);
        }

        [HttpGet]
        [Route("packingtypes")]
        public ActionResult<List<EnumValueViewModel>> GetPackingType()
        {
            return GetEnums.GetValues<PackingType>();
        }

        [HttpGet]
        [Route("stackability")]
        public List<EnumValueViewModel> GetStackability()
        {
            return GetEnums.GetValues<Stackability>();
        }
    }
}
