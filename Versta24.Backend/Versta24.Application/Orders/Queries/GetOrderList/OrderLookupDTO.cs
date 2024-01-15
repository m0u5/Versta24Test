using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta24.Application.Common.Mappings;
using Versta24.Domain;

namespace Versta24.Application.Orders.Queries.GetOrderList
{
    public class OrderLookupDTO : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public int OrderNum { get; set; }
        public string SenderCity { get; set; }
        public string SenderAddres { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientAddres { get; set; }
        public decimal CargoWeight { get; set; }
        private DateTime _collectionDate;
        public DateTime CollectionDate { get {return _collectionDate.ToUniversalTime(); } set {_collectionDate = value; } }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderLookupDTO>();
                
        }
    }
}
