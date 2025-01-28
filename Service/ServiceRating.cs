using Entite;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;


namespace Service
{
    public class ServiceRating : IServiceRating
    {
        IRepositoryRating repository;
        public ServiceRating(IRepositoryRating _repositoryProduct)
        {
            repository = _repositoryProduct;
        }
        public async Task AddRating(Rating rating)
        {
            await repository.AddRating(rating);
        }

    }
}