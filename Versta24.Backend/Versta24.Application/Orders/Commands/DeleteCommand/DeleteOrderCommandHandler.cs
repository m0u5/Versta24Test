using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta24.Application.Common.Exceptions;
using Versta24.Application.interfaces;
using Versta24.Domain;

namespace Versta24.Application.Orders.Commands.DeleteCommand
{
    public class DeleteOrderCommandHandler:
        IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrdersDbContext _ordersDbContext;
        public DeleteOrderCommandHandler(IOrdersDbContext ordersDbContext) { _ordersDbContext = ordersDbContext; }
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
          var entity =   await _ordersDbContext.Orders.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null) { throw new NotFoundException(nameof(Order), request.Id); }
            _ordersDbContext.Orders.Remove(entity);
            await _ordersDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
            
        }
    }
}
