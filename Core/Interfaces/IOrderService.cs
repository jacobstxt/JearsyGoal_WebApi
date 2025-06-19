using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Order;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderModel>> GetOrdersAsync();
    }
}
