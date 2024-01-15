using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta24.Application.Orders.Commands.DeleteCommand
{
    public class DeleteOrderCommand : IRequest 
    {
        public Guid Id { get; set; }
    }
}
