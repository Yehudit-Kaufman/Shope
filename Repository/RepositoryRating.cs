using Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryRating : IRepositoryRating
    {
        ShopApiContext _context;
        public RepositoryRating(ShopApiContext shopApiContext)
        {
            _context = shopApiContext;
        }
        public async Task AddRating(Rating rating)
        {
            _context.Ratings.AddAsync(rating);
            await _context.SaveChangesAsync();
            return;
        }
    }
}
