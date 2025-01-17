using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class MediaContentRatingNewZealand : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Movies rating selected for New Zealand. Possible values are: allAllowed, allBlocked, general, parentalGuidance, mature, agesAbove13, agesAbove15, agesAbove16, agesAbove18, restricted, agesAbove16Restricted.</summary>
        public RatingNewZealandMoviesType? MovieRating { get; set; }
        /// <summary>TV rating selected for New Zealand. Possible values are: allAllowed, allBlocked, general, parentalGuidance, adults.</summary>
        public RatingNewZealandTelevisionType? TvRating { get; set; }
        /// <summary>
        /// Instantiates a new mediaContentRatingNewZealand and sets the default values.
        /// </summary>
        public MediaContentRatingNewZealand() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static MediaContentRatingNewZealand CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MediaContentRatingNewZealand();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"movieRating", n => { MovieRating = n.GetEnumValue<RatingNewZealandMoviesType>(); } },
                {"tvRating", n => { TvRating = n.GetEnumValue<RatingNewZealandTelevisionType>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<RatingNewZealandMoviesType>("movieRating", MovieRating);
            writer.WriteEnumValue<RatingNewZealandTelevisionType>("tvRating", TvRating);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
