using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Versta24.Application.interfaces;
using Microsoft.EntityFrameworkCore;
using Versta24.Application.Common.Exceptions;
using Versta24.Domain;
namespace Versta24.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IOrdersDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetOrderDetailsQueryHandler(IOrdersDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Orders.FirstOrDefaultAsync(ord=>ord.Id == request.Id, cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(Order), request.Id);
            return _mapper.Map<OrderDetailsVm>(entity);
        }
    }
}
