using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class TemporaryAccessPassAuthenticationMethodConfiguration : AuthenticationMethodConfiguration, IParsable {
        /// <summary>Default length, in characters, of a temporaryAccessPass, between 8 and 48 characters.</summary>
        public int? DefaultLength { get; set; }
        /// <summary>Default lifetime, in minutes, for a temporaryAccessPass. Value can be between the minimumLifetimeInMinutes and maximumLifetimeInMinutes.</summary>
        public int? DefaultLifetimeInMinutes { get; set; }
        /// <summary>A collection of users or groups who are enabled to use the authentication method.</summary>
        public List<AuthenticationMethodTarget> IncludeTargets { get; set; }
        /// <summary>If true, all the passes in the tenant will be restricted to one-time use. If false, passes in the tenant can be created to be either one-time use or multiple time use.</summary>
        public bool? IsUsableOnce { get; set; }
        /// <summary>Maximum lifetime in minutes for any temporaryAccessPass created in the tenant. Value can be between 10 and 43200 minutes (equivalent to 30 days).</summary>
        public int? MaximumLifetimeInMinutes { get; set; }
        /// <summary>Minimum lifetime in minutes for any temporaryAccessPass created in the tenant. Value can be between 10 and 43200 minutes (equivalent to 30 days).</summary>
        public int? MinimumLifetimeInMinutes { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new TemporaryAccessPassAuthenticationMethodConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new TemporaryAccessPassAuthenticationMethodConfiguration();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"defaultLength", n => { DefaultLength = n.GetIntValue(); } },
                {"defaultLifetimeInMinutes", n => { DefaultLifetimeInMinutes = n.GetIntValue(); } },
                {"includeTargets", n => { IncludeTargets = n.GetCollectionOfObjectValues<AuthenticationMethodTarget>(AuthenticationMethodTarget.CreateFromDiscriminatorValue).ToList(); } },
                {"isUsableOnce", n => { IsUsableOnce = n.GetBoolValue(); } },
                {"maximumLifetimeInMinutes", n => { MaximumLifetimeInMinutes = n.GetIntValue(); } },
                {"minimumLifetimeInMinutes", n => { MinimumLifetimeInMinutes = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteIntValue("defaultLength", DefaultLength);
            writer.WriteIntValue("defaultLifetimeInMinutes", DefaultLifetimeInMinutes);
            writer.WriteCollectionOfObjectValues<AuthenticationMethodTarget>("includeTargets", IncludeTargets);
            writer.WriteBoolValue("isUsableOnce", IsUsableOnce);
            writer.WriteIntValue("maximumLifetimeInMinutes", MaximumLifetimeInMinutes);
            writer.WriteIntValue("minimumLifetimeInMinutes", MinimumLifetimeInMinutes);
        }
    }
}
