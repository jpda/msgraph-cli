using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class IosCompliancePolicy : DeviceCompliancePolicy, IParsable {
        /// <summary>Require that devices have enabled device threat protection .</summary>
        public bool? DeviceThreatProtectionEnabled { get; set; }
        /// <summary>Require Mobile Threat Protection minimum risk level to report noncompliance. Possible values are: unavailable, secured, low, medium, high, notSet.</summary>
        public DeviceThreatProtectionLevel? DeviceThreatProtectionRequiredSecurityLevel { get; set; }
        /// <summary>Indicates whether or not to require a managed email profile.</summary>
        public bool? ManagedEmailProfileRequired { get; set; }
        /// <summary>Maximum IOS version.</summary>
        public string OsMaximumVersion { get; set; }
        /// <summary>Minimum IOS version.</summary>
        public string OsMinimumVersion { get; set; }
        /// <summary>Indicates whether or not to block simple passcodes.</summary>
        public bool? PasscodeBlockSimple { get; set; }
        /// <summary>Number of days before the passcode expires. Valid values 1 to 65535</summary>
        public int? PasscodeExpirationDays { get; set; }
        /// <summary>The number of character sets required in the password.</summary>
        public int? PasscodeMinimumCharacterSetCount { get; set; }
        /// <summary>Minimum length of passcode. Valid values 4 to 14</summary>
        public int? PasscodeMinimumLength { get; set; }
        /// <summary>Minutes of inactivity before a passcode is required.</summary>
        public int? PasscodeMinutesOfInactivityBeforeLock { get; set; }
        /// <summary>Number of previous passcodes to block. Valid values 1 to 24</summary>
        public int? PasscodePreviousPasscodeBlockCount { get; set; }
        /// <summary>Indicates whether or not to require a passcode.</summary>
        public bool? PasscodeRequired { get; set; }
        /// <summary>The required passcode type. Possible values are: deviceDefault, alphanumeric, numeric.</summary>
        public RequiredPasswordType? PasscodeRequiredType { get; set; }
        /// <summary>Devices must not be jailbroken or rooted.</summary>
        public bool? SecurityBlockJailbrokenDevices { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new IosCompliancePolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new IosCompliancePolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"deviceThreatProtectionEnabled", n => { DeviceThreatProtectionEnabled = n.GetBoolValue(); } },
                {"deviceThreatProtectionRequiredSecurityLevel", n => { DeviceThreatProtectionRequiredSecurityLevel = n.GetEnumValue<DeviceThreatProtectionLevel>(); } },
                {"managedEmailProfileRequired", n => { ManagedEmailProfileRequired = n.GetBoolValue(); } },
                {"osMaximumVersion", n => { OsMaximumVersion = n.GetStringValue(); } },
                {"osMinimumVersion", n => { OsMinimumVersion = n.GetStringValue(); } },
                {"passcodeBlockSimple", n => { PasscodeBlockSimple = n.GetBoolValue(); } },
                {"passcodeExpirationDays", n => { PasscodeExpirationDays = n.GetIntValue(); } },
                {"passcodeMinimumCharacterSetCount", n => { PasscodeMinimumCharacterSetCount = n.GetIntValue(); } },
                {"passcodeMinimumLength", n => { PasscodeMinimumLength = n.GetIntValue(); } },
                {"passcodeMinutesOfInactivityBeforeLock", n => { PasscodeMinutesOfInactivityBeforeLock = n.GetIntValue(); } },
                {"passcodePreviousPasscodeBlockCount", n => { PasscodePreviousPasscodeBlockCount = n.GetIntValue(); } },
                {"passcodeRequired", n => { PasscodeRequired = n.GetBoolValue(); } },
                {"passcodeRequiredType", n => { PasscodeRequiredType = n.GetEnumValue<RequiredPasswordType>(); } },
                {"securityBlockJailbrokenDevices", n => { SecurityBlockJailbrokenDevices = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("deviceThreatProtectionEnabled", DeviceThreatProtectionEnabled);
            writer.WriteEnumValue<DeviceThreatProtectionLevel>("deviceThreatProtectionRequiredSecurityLevel", DeviceThreatProtectionRequiredSecurityLevel);
            writer.WriteBoolValue("managedEmailProfileRequired", ManagedEmailProfileRequired);
            writer.WriteStringValue("osMaximumVersion", OsMaximumVersion);
            writer.WriteStringValue("osMinimumVersion", OsMinimumVersion);
            writer.WriteBoolValue("passcodeBlockSimple", PasscodeBlockSimple);
            writer.WriteIntValue("passcodeExpirationDays", PasscodeExpirationDays);
            writer.WriteIntValue("passcodeMinimumCharacterSetCount", PasscodeMinimumCharacterSetCount);
            writer.WriteIntValue("passcodeMinimumLength", PasscodeMinimumLength);
            writer.WriteIntValue("passcodeMinutesOfInactivityBeforeLock", PasscodeMinutesOfInactivityBeforeLock);
            writer.WriteIntValue("passcodePreviousPasscodeBlockCount", PasscodePreviousPasscodeBlockCount);
            writer.WriteBoolValue("passcodeRequired", PasscodeRequired);
            writer.WriteEnumValue<RequiredPasswordType>("passcodeRequiredType", PasscodeRequiredType);
            writer.WriteBoolValue("securityBlockJailbrokenDevices", SecurityBlockJailbrokenDevices);
        }
    }
}
