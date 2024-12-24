using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entite;

namespace DTO
{
    public record ProductDTO(int ProductID,string ProductName,double Price,string Description,string CategoryCategoryName,string? Image);

}
