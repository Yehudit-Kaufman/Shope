using Entite;

namespace Repository
{
    public interface IRepositoryRating
    {
        Task AddRating(Rating rating);
    }
}