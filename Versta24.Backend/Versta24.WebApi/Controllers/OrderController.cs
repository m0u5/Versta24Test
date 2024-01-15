using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Versta24.Application.Orders.Commands.CreateOrder;
using Versta24.Application.Orders.Commands.DeleteCommand;
using Versta24.Application.Orders.Commands.UpdateOrder;
using Versta24.Application.Orders.Queries.GetOrderDetails;
using Versta24.Application.Orders.Queries.GetOrderList;
using Versta24.WebApi.Models;

namespace Versta24.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class OrderController:BaseController
    {
        private readonly IMapper _mapper;
        public OrderController(IMapper mapper)=>_mapper=mapper;
        [HttpGet]
        public async Task<ActionResult<OrderListVm>> GetAll()
        {
            var query = new GetOrderListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderListVm>> Get(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateOrderDto createOrderDto)
        {
            var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
            var noteId= await Mediator.Send(command);
            return Created(noteId.ToString(), noteId);// правильно ли так делать
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateOrderDto updateOrderDto)
        {
            var command = _mapper.Map<UpdateOrderCommand>(updateOrderDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOrderCommand { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
