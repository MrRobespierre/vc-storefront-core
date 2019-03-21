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

        public static reviewDto.CustomerReview ToCustomerReviewDto(this Model.CustomerReviews.CustomerReview item)
        {
            return new reviewDto.CustomerReview
            {
                Id = item.Id,
                AuthorNickname = item.AuthorNickname,
                Content = item.Content,
                CreatedBy = item.CreatedBy,
                CreatedDate = item.CreatedDate,
                IsActive = item.IsActive,
                ModifiedBy = item.ModifiedBy,
                ModifiedDate = item.ModifiedDate,
                ProductId = item.ProductId,
                ProductRating = item.ProductRating,
                PropertyValues = item.PropertyValues.Select(x => x.ToFavoritePropertyValueDto()).ToArray()
            };
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

        public static reviewDto.FavoritePropertyValue ToFavoritePropertyValueDto(this FavoritePropertyValue item)
        {
            return new reviewDto.FavoritePropertyValue
            {
                Id = item.Id,
                PropertyId = item.PropertyId,
                ReviewId = item.ReviewId,
                Rating = item.Rating,
                Property = item.Property.ToFavoritePropertyDto()
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

        public static reviewDto.FavoriteProperty ToFavoritePropertyDto(this FavoriteProperty item)
        {
            return new reviewDto.FavoriteProperty
            {
                Id = item.Id,
                Name = item.Name,
                PropertyId = item.PropertyId,
                ProductId = item.ProductId
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
