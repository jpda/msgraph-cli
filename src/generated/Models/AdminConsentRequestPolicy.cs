using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    /// <summary>Provides operations to manage the policyRoot singleton.</summary>
    public class AdminConsentRequestPolicy : Entity, IParsable {
        /// <summary>Specifies whether the admin consent request feature is enabled or disabled. Required.</summary>
        public bool? IsEnabled { get; set; }
        /// <summary>Specifies whether reviewers will receive notifications. Required.</summary>
        public bool? NotifyReviewers { get; set; }
        /// <summary>Specifies whether reviewers will receive reminder emails. Required.</summary>
        public bool? RemindersEnabled { get; set; }
        /// <summary>Specifies the duration the request is active before it automatically expires if no decision is applied.</summary>
        public int? RequestDurationInDays { get; set; }
        /// <summary>Required.</summary>
        public List<AccessReviewReviewerScope> Reviewers { get; set; }
        /// <summary>Specifies the version of this policy. When the policy is updated, this version is updated. Read-only.</summary>
        public int? Version { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new AdminConsentRequestPolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new AdminConsentRequestPolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"isEnabled", n => { IsEnabled = n.GetBoolValue(); } },
                {"notifyReviewers", n => { NotifyReviewers = n.GetBoolValue(); } },
                {"remindersEnabled", n => { RemindersEnabled = n.GetBoolValue(); } },
                {"requestDurationInDays", n => { RequestDurationInDays = n.GetIntValue(); } },
                {"reviewers", n => { Reviewers = n.GetCollectionOfObjectValues<AccessReviewReviewerScope>(AccessReviewReviewerScope.CreateFromDiscriminatorValue).ToList(); } },
                {"version", n => { Version = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("isEnabled", IsEnabled);
            writer.WriteBoolValue("notifyReviewers", NotifyReviewers);
            writer.WriteBoolValue("remindersEnabled", RemindersEnabled);
            writer.WriteIntValue("requestDurationInDays", RequestDurationInDays);
            writer.WriteCollectionOfObjectValues<AccessReviewReviewerScope>("reviewers", Reviewers);
            writer.WriteIntValue("version", Version);
        }
    }
}
