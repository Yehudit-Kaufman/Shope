using Entite;

namespace Service
{
    public interface IServiceRating
    {
        Task AddRating(Rating rating);
    }
}