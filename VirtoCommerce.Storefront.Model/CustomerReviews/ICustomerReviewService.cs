using System.Threading.Tasks;
using PagedList.Core;

namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    public interface ICustomerReviewService
    {
        IPagedList<CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria);

        Task<IPagedList<CustomerReview>> SearchReviewsAsync(CustomerReviewSearchCriteria criteria);

        Task SaveCustomerReview(CustomerReview customerReview);

        Task<double> GetAverageProductRatingAsync(string productId);

        Task<AveragePropertyRating[]> GetAveragePropertyRatingsAsync(string productId);
    }
}
