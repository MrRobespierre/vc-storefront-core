using System;
using VirtoCommerce.Storefront.Model.Common;

namespace VirtoCommerce.Storefront.Model.CustomerReviews
{
    public partial class CustomerReview : Entity
    {
        public string AuthorNickname { get; set; }
        public string Content { get; set; }
        public bool? IsActive { get; set; }
        public string ProductId { get; set; }


        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public int? ProductRating { get; set; }

        public FavoritePropertyValue[] PropertyValues { get; set; }
    }

    public partial class FavoritePropertyValue : Entity
    {
        public string PropertyId { get; set; }

        public FavoriteProperty Property { get; set; }

        public string ReviewId { get; set; }

        public int? Rating { get; set; }
    }

    public partial class FavoriteProperty : Entity
    {
        public string ProductId { get; set; }

        public string PropertyId { get; set; }

        public string Name { get; set; }
    }
}
