using System;
using System.Runtime.Serialization;

using DotLiquid;

namespace VirtoCommerce.LiquidThemeEngine.Objects
{
    [DataContract]
    public class CustomerReview : Drop
    {
        [DataMember]
        public string AuthorNickname { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public bool? IsActive { get; set; }

        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public DateTime? CreatedDate { get; set; }

        [DataMember]
        public int? ProductRating { get; set; }

        [DataMember]
        public FavoritePropertyValue[] PropertyValues { get; set; }
    }

    public class FavoritePropertyValue : Drop
    {
        [DataMember]
        public FavoriteProperty Property { get; set; }

        [DataMember]
        public string ReviewId { get; set; }

        [DataMember]
        public int? Rating { get; set; }
    }

    public class FavoriteProperty : Drop
    {
        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public string PropertyId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
