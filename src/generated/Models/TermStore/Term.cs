using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models.TermStore {
    /// <summary>Provides operations to manage the collection of application entities.</summary>
    public class Term : Entity, IParsable {
        /// <summary>Children of current term.</summary>
        public List<Term> Children { get; set; }
        /// <summary>Date and time of term creation. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Description about term that is dependent on the languageTag.</summary>
        public List<LocalizedDescription> Descriptions { get; set; }
        /// <summary>Label metadata for a term.</summary>
        public List<LocalizedLabel> Labels { get; set; }
        /// <summary>Last date and time of term modification. Read-only.</summary>
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        /// <summary>Collection of properties on the term.</summary>
        public List<ApiSdk.Models.KeyValue> Properties { get; set; }
        /// <summary>To indicate which terms are related to the current term as either pinned or reused.</summary>
        public List<Relation> Relations { get; set; }
        /// <summary>The [set] in which the term is created.</summary>
        public ApiSdk.Models.TermStore.Set Set { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new Term CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Term();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"children", n => { Children = n.GetCollectionOfObjectValues<Term>(Term.CreateFromDiscriminatorValue).ToList(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"descriptions", n => { Descriptions = n.GetCollectionOfObjectValues<LocalizedDescription>(LocalizedDescription.CreateFromDiscriminatorValue).ToList(); } },
                {"labels", n => { Labels = n.GetCollectionOfObjectValues<LocalizedLabel>(LocalizedLabel.CreateFromDiscriminatorValue).ToList(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"properties", n => { Properties = n.GetCollectionOfObjectValues<ApiSdk.Models.KeyValue>(ApiSdk.Models.KeyValue.CreateFromDiscriminatorValue).ToList(); } },
                {"relations", n => { Relations = n.GetCollectionOfObjectValues<Relation>(Relation.CreateFromDiscriminatorValue).ToList(); } },
                {"set", n => { Set = n.GetObjectValue<ApiSdk.Models.TermStore.Set>(ApiSdk.Models.TermStore.Set.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteCollectionOfObjectValues<Term>("children", Children);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteCollectionOfObjectValues<LocalizedDescription>("descriptions", Descriptions);
            writer.WriteCollectionOfObjectValues<LocalizedLabel>("labels", Labels);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteCollectionOfObjectValues<ApiSdk.Models.KeyValue>("properties", Properties);
            writer.WriteCollectionOfObjectValues<Relation>("relations", Relations);
            writer.WriteObjectValue<ApiSdk.Models.TermStore.Set>("set", Set);
        }
    }
}
