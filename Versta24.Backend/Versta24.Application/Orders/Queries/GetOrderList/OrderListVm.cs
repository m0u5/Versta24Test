using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versta24.Application.Orders.Queries.GetOrderList
{
    public class OrderListVm
    {
        public IList<OrderLookupDTO> Orders { get; set; }
    }
}
