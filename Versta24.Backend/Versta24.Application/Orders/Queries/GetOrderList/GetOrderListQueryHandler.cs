using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta24.Application.interfaces;

namespace Versta24.Application.Orders.Queries.GetOrderList
{
    public class GetOrderListQueryHandler:
        IRequestHandler<GetOrderListQuery, OrderListVm>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrderListQueryHandler(IOrdersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
            var ordersQuery = await _dbContext.Orders.ProjectTo<OrderLookupDTO>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new OrderListVm { Orders = ordersQuery };
        }
    }
}
