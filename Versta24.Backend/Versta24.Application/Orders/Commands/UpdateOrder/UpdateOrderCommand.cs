using System;
using MediatR;

namespace Versta24.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand:IRequest
    {
        public Guid Id { get; set; }
        public int OrderNum { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddres { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddres { get; set; }
        public decimal CargoWeight { get; set; }
        public DateTime CollectionDate { get; set; }
    }
}
