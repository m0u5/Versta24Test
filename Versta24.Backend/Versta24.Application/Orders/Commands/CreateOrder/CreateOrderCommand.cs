using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Versta24.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public int OrderNum { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddres { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddres { get; set; }
        public decimal CargoWeight { get; set; }
        public DateTime CollectionDate { get; set; }
    }
}
