using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    //public record OrderDTO(DateTime OrderDate,double OrderSum,string UserUserName,List<OrderItemsDTO> OrderItems);
    //public record AddOrderDTO(int OrderId,DateTime OrderDate,double OrderSum, List<OrderItemsDTO> OrderItems);

    public record OrderDTO(int OrderId, DateTime OrderDate, double OrderSum, string UserUsername, List<OrderItemsDTO> OrderItems);

    public record PostOrderDTO(DateTime OrderDate, double OrderSum, int UserId, List<OrderItemsDTO> OrderItems);
}
