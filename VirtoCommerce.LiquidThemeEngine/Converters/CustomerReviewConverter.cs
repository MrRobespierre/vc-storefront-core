using System.Linq;

using VirtoCommerce.LiquidThemeEngine.Objects;
using storefrontModel = VirtoCommerce.Storefront.Model.CustomerReviews;

namespace VirtoCommerce.LiquidThemeEngine.Converters
{
    public static class CustomerReviewStaticConverter
    {
        public static CustomerReview ToShopifyModel(this storefrontModel.CustomerReview item)
        {
            return new ShopifyModelConverter().ToLiquidCustomerReview(item);
        }
    }

    public partial class ShopifyModelConverter
    {
        public virtual CustomerReview ToLiquidCustomerReview(storefrontModel.CustomerReview item)
        {
            return new CustomerReview
            {
                AuthorNickname = item.AuthorNickname,
                Content = item.Content,
                CreatedDate = item.CreatedDate,
                IsActive = item.IsActive,
                ProductId = item.ProductId,
                ProductRating = item.ProductRating,
                PropertyValues = item.PropertyValues.Select(ToFavoritePropertyValue).ToArray()
            };
        }

        public virtual FavoritePropertyValue ToFavoritePropertyValue(storefrontModel.FavoritePropertyValue item)
        {
            return new FavoritePropertyValue
            {
                ReviewId = item.ReviewId,
                Property = ToFavoriteProperty(item.Property),
                Rating = item.Rating
            };
        }

        public virtual FavoriteProperty ToFavoriteProperty(storefrontModel.FavoriteProperty item)
        {
            return new FavoriteProperty
            {
                ProductId = item.ProductId,
                PropertyId = item.PropertyId,
                Name = item.Name
            };
        }

        public virtual AveragePropertyRating ToAveragePropertyRating(storefrontModel.AveragePropertyRating item)
        {
            return new AveragePropertyRating
            {
                Rating = item.Rating,
                Property = ToFavoriteProperty(item.Property)
            };
        }
    }
}
