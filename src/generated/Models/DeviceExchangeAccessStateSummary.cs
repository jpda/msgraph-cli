using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    /// <summary>Device Exchange Access State summary</summary>
    public class DeviceExchangeAccessStateSummary : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Total count of devices with Exchange Access State: Allowed.</summary>
        public int? AllowedDeviceCount { get; set; }
        /// <summary>Total count of devices with Exchange Access State: Blocked.</summary>
        public int? BlockedDeviceCount { get; set; }
        /// <summary>Total count of devices with Exchange Access State: Quarantined.</summary>
        public int? QuarantinedDeviceCount { get; set; }
        /// <summary>Total count of devices for which no Exchange Access State could be found.</summary>
        public int? UnavailableDeviceCount { get; set; }
        /// <summary>Total count of devices with Exchange Access State: Unknown.</summary>
        public int? UnknownDeviceCount { get; set; }
        /// <summary>
        /// Instantiates a new deviceExchangeAccessStateSummary and sets the default values.
        /// </summary>
        public DeviceExchangeAccessStateSummary() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static DeviceExchangeAccessStateSummary CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceExchangeAccessStateSummary();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allowedDeviceCount", n => { AllowedDeviceCount = n.GetIntValue(); } },
                {"blockedDeviceCount", n => { BlockedDeviceCount = n.GetIntValue(); } },
                {"quarantinedDeviceCount", n => { QuarantinedDeviceCount = n.GetIntValue(); } },
                {"unavailableDeviceCount", n => { UnavailableDeviceCount = n.GetIntValue(); } },
                {"unknownDeviceCount", n => { UnknownDeviceCount = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("allowedDeviceCount", AllowedDeviceCount);
            writer.WriteIntValue("blockedDeviceCount", BlockedDeviceCount);
            writer.WriteIntValue("quarantinedDeviceCount", QuarantinedDeviceCount);
            writer.WriteIntValue("unavailableDeviceCount", UnavailableDeviceCount);
            writer.WriteIntValue("unknownDeviceCount", UnknownDeviceCount);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
