using MediatR;
using Versta24.Application.interfaces;
using Versta24.Domain;
namespace Versta24.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommantHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrdersDbContext _dbContext;
        public CreateOrderCommantHandler(IOrdersDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                SenderCity = request.SenderCity,
                SenderAddres = request.SenderAddres,
                RecipientCity = request.RecipientCity,
                RecipientAddres = request.RecipientAddres,
                CargoWeight = request.CargoWeight,
                CollectionDate = request.CollectionDate,
                OrderNum = _dbContext.Orders.Count()+1
            };
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
