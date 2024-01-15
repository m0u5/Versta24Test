using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta24.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator: AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator() 
        {
            RuleFor(createOrderCommand =>
            createOrderCommand.SenderAddres).NotEmpty().MaximumLength(500);
            RuleFor(createOrderCommand =>
            createOrderCommand.SenderCity).NotEmpty().MaximumLength(500);
            RuleFor(createOrderCommand =>
            createOrderCommand.RecipientCity).NotEmpty().MaximumLength(500);
            RuleFor(createOrderCommand =>
            createOrderCommand.RecipientAddres).NotEmpty().MaximumLength(500);
            RuleFor(createOrderCommand =>
            createOrderCommand.CargoWeight).NotEmpty();
            RuleFor(createOrderCommand =>
            createOrderCommand.CollectionDate).NotEmpty();
        }
    }
}
