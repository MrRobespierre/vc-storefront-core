using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PagedList.Core;

using VirtoCommerce.Storefront.AutoRestClients.CustomerReviews.WebModuleApi;
using VirtoCommerce.Storefront.Domain.CustomerReview;
using VirtoCommerce.Storefront.Extensions;
using VirtoCommerce.Storefront.Infrastructure;
using VirtoCommerce.Storefront.Model.Common.Caching;
using VirtoCommerce.Storefront.Model.CustomerReviews;

namespace VirtoCommerce.Storefront.Domain
{
    public class CustomerReviewService : ICustomerReviewService
    {
        private readonly ICustomerReviews _customerReviewsApi;

        public CustomerReviewService(ICustomerReviews customerReviewsApi)
        {
            _customerReviewsApi = customerReviewsApi;
        }

        public IPagedList<Model.CustomerReviews.CustomerReview> SearchReviews(CustomerReviewSearchCriteria criteria)
        {
            return SearchReviewsAsync(criteria).GetAwaiter().GetResult();
        }

        public async Task<IPagedList<Model.CustomerReviews.CustomerReview>> SearchReviewsAsync(CustomerReviewSearchCriteria criteria)
        {
            var result = await _customerReviewsApi.SearchCustomerReviewsAsync(criteria.ToSearchCriteriaDto());
            return new StaticPagedList<Model.CustomerReviews.CustomerReview>(result.Results.Select(x => x.ToCustomerReview()),
                criteria.PageNumber, criteria.PageSize, result.TotalCount.Value);
        }

        public async Task SaveCustomerReview(Model.CustomerReviews.CustomerReview customerReview)
        {
            var itemDto = customerReview.ToCustomerReviewDto();
            await _customerReviewsApi.UpdateWithHttpMessagesAsync(new[] { itemDto });
        }

        public async Task<double> GetAverageProductRatingAsync(string productId)
        {
            var result = await _customerReviewsApi.GetAverageProductRatingWithHttpMessagesAsync(productId);
            return result.Body.Rating ?? 0;
        }

        public async Task<AveragePropertyRating[]> GetAveragePropertyRatingsAsync(string productId)
        {
            var result = await _customerReviewsApi.GetAveragePropertyRatingsWithHttpMessagesAsync(productId);
            return result.Body.Select(x => x.ToAveragePropertyRating()).ToArray();
        }
    }
}
