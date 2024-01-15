using MediatR;
using Microsoft.EntityFrameworkCore;
using Versta24.Application.Common.Exceptions;
using Versta24.Application.interfaces;
using Versta24.Domain;

namespace Versta24.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler: IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrdersDbContext _dbContext;
        public UpdateOrderCommandHandler(IOrdersDbContext dbContext) =>
           _dbContext = dbContext;
        public async Task<Unit> Handle (UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Orders.FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);
            if(entity == null)//если добавлять авторизацию надо здесь еще userid проверять
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }
            entity.CargoWeight = request.CargoWeight;
            entity.RecipientAddres = request.RecipientAddres;
            entity.RecipientCity = request.RecipientCity;
            entity.SenderAddres = request.SenderAddres;
            entity.SenderCity = request.SenderCity;
            entity.CollectionDate = request.CollectionDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
