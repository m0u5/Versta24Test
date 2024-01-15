using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta24.Application.Orders.Commands.DeleteCommand
{
    public class DeleteOrderCommandValidator:AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator() 
        {
            RuleFor(deleteCommand=>deleteCommand.Id).NotEqual(Guid.Empty);    
        }
    }
}
