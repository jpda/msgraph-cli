using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class SubjectRightsRequestDetail : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Count of items that are excluded from the request.</summary>
        public long? ExcludedItemCount { get; set; }
        /// <summary>Count of items per insight.</summary>
        public List<KeyValuePair> InsightCounts { get; set; }
        /// <summary>Count of items found.</summary>
        public long? ItemCount { get; set; }
        /// <summary>Count of item that need review.</summary>
        public long? ItemNeedReview { get; set; }
        /// <summary>Count of items per product, such as Exchange, SharePoint, OneDrive, and Teams.</summary>
        public List<KeyValuePair> ProductItemCounts { get; set; }
        /// <summary>Count of items signed off by the administrator.</summary>
        public long? SignedOffItemCount { get; set; }
        /// <summary>Total item size in bytes.</summary>
        public long? TotalItemSize { get; set; }
        /// <summary>
        /// Instantiates a new subjectRightsRequestDetail and sets the default values.
        /// </summary>
        public SubjectRightsRequestDetail() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static SubjectRightsRequestDetail CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new SubjectRightsRequestDetail();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"excludedItemCount", n => { ExcludedItemCount = n.GetLongValue(); } },
                {"insightCounts", n => { InsightCounts = n.GetCollectionOfObjectValues<KeyValuePair>(KeyValuePair.CreateFromDiscriminatorValue).ToList(); } },
                {"itemCount", n => { ItemCount = n.GetLongValue(); } },
                {"itemNeedReview", n => { ItemNeedReview = n.GetLongValue(); } },
                {"productItemCounts", n => { ProductItemCounts = n.GetCollectionOfObjectValues<KeyValuePair>(KeyValuePair.CreateFromDiscriminatorValue).ToList(); } },
                {"signedOffItemCount", n => { SignedOffItemCount = n.GetLongValue(); } },
                {"totalItemSize", n => { TotalItemSize = n.GetLongValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteLongValue("excludedItemCount", ExcludedItemCount);
            writer.WriteCollectionOfObjectValues<KeyValuePair>("insightCounts", InsightCounts);
            writer.WriteLongValue("itemCount", ItemCount);
            writer.WriteLongValue("itemNeedReview", ItemNeedReview);
            writer.WriteCollectionOfObjectValues<KeyValuePair>("productItemCounts", ProductItemCounts);
            writer.WriteLongValue("signedOffItemCount", SignedOffItemCount);
            writer.WriteLongValue("totalItemSize", TotalItemSize);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
