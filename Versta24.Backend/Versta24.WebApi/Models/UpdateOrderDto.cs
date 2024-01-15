using AutoMapper;
using Versta24.Application.Common.Mappings;
using Versta24.Application.Orders.Commands.UpdateOrder;

namespace Versta24.WebApi.Models
{
    public class UpdateOrderDto:IMapWith<UpdateOrderCommand>
    {
        public Guid Id { get; set; }
        public int OrderNum { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddres { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddres { get; set; }
        public decimal CargoWeight { get; set; }
        public DateTime CollectionDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOrderDto, UpdateOrderCommand>();
        }
    }
}
