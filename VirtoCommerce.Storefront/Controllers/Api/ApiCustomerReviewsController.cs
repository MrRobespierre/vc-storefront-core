using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using VirtoCommerce.Storefront.Infrastructure;
using VirtoCommerce.Storefront.Model;
using VirtoCommerce.Storefront.Model.Common;
using VirtoCommerce.Storefront.Model.CustomerReviews;


namespace VirtoCommerce.Storefront.Controllers.Api
{
    [StorefrontApiRoute("customerReviews")]
    public class ApiCustomerReviewsController : StorefrontControllerBase
    {
        private readonly ICustomerReviewService _customerReviewService;

        public ApiCustomerReviewsController(
            IWorkContextAccessor workContextAccessor,
            IStorefrontUrlBuilder urlBuilder,
            ICustomerReviewService customerReviewService)
            : base(workContextAccessor, urlBuilder)
        {
            _customerReviewService = customerReviewService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveCustomerReview([FromBody] CustomerReview customerReview)
        {
            await _customerReviewService.SaveCustomerReview(customerReview);
            return Ok();
        }
    }
}
