using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class DatabaseFixure
    {
        public ShopApiContext Context { get; private set; }
        public DatabaseFixure()
        {
            var options = new DbContextOptionsBuilder<ShopApiContext>()
                .UseSqlServer("Server=SRV2\\PUPILS;Database=Shop_Api_Test;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;
            Context = new ShopApiContext(options);
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Database.EnsureCreated();
            Context.Dispose();
        }
    }
}
