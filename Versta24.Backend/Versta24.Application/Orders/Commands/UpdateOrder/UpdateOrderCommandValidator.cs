using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta24.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator:AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator() 
        {
            RuleFor(updateOrderCommand =>
            updateOrderCommand.SenderAddres).NotEmpty().MaximumLength(500);
            RuleFor(updateOrderCommand =>
            updateOrderCommand.SenderCity).NotEmpty().MaximumLength(500);
            RuleFor(updateOrderCommand =>
            updateOrderCommand.RecipientCity).NotEmpty().MaximumLength(500);
            RuleFor(updateOrderCommand =>
            updateOrderCommand.RecipientAddres).NotEmpty().MaximumLength(500);
            RuleFor(updateOrderCommand =>
            updateOrderCommand.CargoWeight).NotEmpty();
            RuleFor(updateOrderCommand =>
            updateOrderCommand.CollectionDate).NotEmpty();
            RuleFor(updateOrderCommand=>updateOrderCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
