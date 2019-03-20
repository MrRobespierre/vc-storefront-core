using System.Linq;

using VirtoCommerce.Storefront.Model.CustomerReviews;
using reviewDto = VirtoCommerce.Storefront.AutoRestClients.CustomerReviews.WebModuleApi.Models;

namespace VirtoCommerce.Storefront.Domain.CustomerReview
{
    public static partial class CustomerReviewConverter
    {
        public static Model.CustomerReviews.CustomerReview ToCustomerReview(this reviewDto.CustomerReview itemDto)
        {
            var result = new Model.CustomerReviews.CustomerReview
            {
                Id = itemDto.Id,
                AuthorNickname = itemDto.AuthorNickname,
                Content = itemDto.Content,
                CreatedBy = itemDto.CreatedBy,
                CreatedDate = itemDto.CreatedDate,
                IsActive = itemDto.IsActive,
                ModifiedBy = itemDto.ModifiedBy,
                ModifiedDate = itemDto.ModifiedDate,
                ProductId = itemDto.ProductId,
                ProductRating = itemDto.ProductRating,
                PropertyValues = itemDto.PropertyValues.Select(x => x.ToFavoritePropertyValue()).ToArray()
            };

            return result;
        }

        public static FavoritePropertyValue ToFavoritePropertyValue(this reviewDto.FavoritePropertyValue itemDto)
        {
            return new FavoritePropertyValue
            {
                Id = itemDto.Id,
                PropertyId = itemDto.PropertyId,
                ReviewId = itemDto.ReviewId,
                Rating = itemDto.Rating,
                Property = itemDto.Property.ToFavoriteProperty()
            };
        }

        public static FavoriteProperty ToFavoriteProperty(this reviewDto.FavoriteProperty itemDto)
        {
            return new FavoriteProperty
            {
                Id = itemDto.Id,
                Name = itemDto.Name,
                PropertyId = itemDto.PropertyId,
                ProductId = itemDto.ProductId
            };
        }

        public static AveragePropertyRating ToAveragePropertyRating(this reviewDto.AveragePropertyRating itemDto)
        {
            return new AveragePropertyRating
            {
                Rating = itemDto.Rating,
                Property = itemDto.FavoriteProperty.ToFavoriteProperty()
            };
        }

        public static reviewDto.CustomerReviewSearchCriteria ToSearchCriteriaDto(this CustomerReviewSearchCriteria criteria)
        {
            var result = new reviewDto.CustomerReviewSearchCriteria
            {
                IsActive = criteria.IsActive,
                ProductIds = criteria.ProductIds,

                Skip = criteria.Start,
                Take = criteria.PageSize,
                Sort = criteria.Sort
            };

            return result;
        }
    }
}
