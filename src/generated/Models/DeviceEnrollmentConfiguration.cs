using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    /// <summary>The Base Class of Device Enrollment Configuration</summary>
    public class DeviceEnrollmentConfiguration : Entity, IParsable {
        /// <summary>The list of group assignments for the device configuration profile</summary>
        public List<EnrollmentConfigurationAssignment> Assignments { get; set; }
        /// <summary>Created date time in UTC of the device enrollment configuration</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>The description of the device enrollment configuration</summary>
        public string Description { get; set; }
        /// <summary>The display name of the device enrollment configuration</summary>
        public string DisplayName { get; set; }
        /// <summary>Last modified date time in UTC of the device enrollment configuration</summary>
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        /// <summary>Priority is used when a user exists in multiple groups that are assigned enrollment configuration. Users are subject only to the configuration with the lowest priority value.</summary>
        public int? Priority { get; set; }
        /// <summary>The version of the device enrollment configuration</summary>
        public int? Version { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DeviceEnrollmentConfiguration CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            var mappingValueNode = parseNode.GetChildNode("@odata.type");
            var mappingValue = mappingValueNode?.GetStringValue();
            return mappingValue switch {
                "#microsoft.graph.deviceEnrollmentLimitConfiguration" => new DeviceEnrollmentLimitConfiguration(),
                "#microsoft.graph.deviceEnrollmentPlatformRestrictionsConfiguration" => new DeviceEnrollmentPlatformRestrictionsConfiguration(),
                "#microsoft.graph.deviceEnrollmentWindowsHelloForBusinessConfiguration" => new DeviceEnrollmentWindowsHelloForBusinessConfiguration(),
                _ => new DeviceEnrollmentConfiguration(),
            };
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"assignments", n => { Assignments = n.GetCollectionOfObjectValues<EnrollmentConfigurationAssignment>(EnrollmentConfigurationAssignment.CreateFromDiscriminatorValue).ToList(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"description", n => { Description = n.GetStringValue(); } },
                {"displayName", n => { DisplayName = n.GetStringValue(); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"priority", n => { Priority = n.GetIntValue(); } },
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
            writer.WriteCollectionOfObjectValues<EnrollmentConfigurationAssignment>("assignments", Assignments);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteIntValue("priority", Priority);
            writer.WriteIntValue("version", Version);
        }
    }
}
