using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
public record OrderDTO(DateTime OrderDate,double OrderSum,string UserUserName,List<OrderItemsDTO> OrderItems);
public record AddOrderDTO(DateTime OrderDate,double OrderSum,int UserId, List<OrderItemsDTO> OrderItems);

}
