using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class MacOSCompliancePolicy : DeviceCompliancePolicy, IParsable {
        /// <summary>Require that devices have enabled device threat protection.</summary>
        public bool? DeviceThreatProtectionEnabled { get; set; }
        /// <summary>Require Mobile Threat Protection minimum risk level to report noncompliance. Possible values are: unavailable, secured, low, medium, high, notSet.</summary>
        public DeviceThreatProtectionLevel? DeviceThreatProtectionRequiredSecurityLevel { get; set; }
        /// <summary>Corresponds to the &apos;Block all incoming connections&apos; option.</summary>
        public bool? FirewallBlockAllIncoming { get; set; }
        /// <summary>Whether the firewall should be enabled or not.</summary>
        public bool? FirewallEnabled { get; set; }
        /// <summary>Corresponds to &apos;Enable stealth mode.&apos;</summary>
        public bool? FirewallEnableStealthMode { get; set; }
        /// <summary>Maximum MacOS version.</summary>
        public string OsMaximumVersion { get; set; }
        /// <summary>Minimum MacOS version.</summary>
        public string OsMinimumVersion { get; set; }
        /// <summary>Indicates whether or not to block simple passwords.</summary>
        public bool? PasswordBlockSimple { get; set; }
        /// <summary>Number of days before the password expires. Valid values 1 to 65535</summary>
        public int? PasswordExpirationDays { get; set; }
        /// <summary>The number of character sets required in the password.</summary>
        public int? PasswordMinimumCharacterSetCount { get; set; }
        /// <summary>Minimum length of password. Valid values 4 to 14</summary>
        public int? PasswordMinimumLength { get; set; }
        /// <summary>Minutes of inactivity before a password is required.</summary>
        public int? PasswordMinutesOfInactivityBeforeLock { get; set; }
        /// <summary>Number of previous passwords to block. Valid values 1 to 24</summary>
        public int? PasswordPreviousPasswordBlockCount { get; set; }
        /// <summary>Whether or not to require a password.</summary>
        public bool? PasswordRequired { get; set; }
        /// <summary>The required password type. Possible values are: deviceDefault, alphanumeric, numeric.</summary>
        public RequiredPasswordType? PasswordRequiredType { get; set; }
        /// <summary>Require encryption on Mac OS devices.</summary>
        public bool? StorageRequireEncryption { get; set; }
        /// <summary>Require that devices have enabled system integrity protection.</summary>
        public bool? SystemIntegrityProtectionEnabled { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new MacOSCompliancePolicy CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new MacOSCompliancePolicy();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"deviceThreatProtectionEnabled", n => { DeviceThreatProtectionEnabled = n.GetBoolValue(); } },
                {"deviceThreatProtectionRequiredSecurityLevel", n => { DeviceThreatProtectionRequiredSecurityLevel = n.GetEnumValue<DeviceThreatProtectionLevel>(); } },
                {"firewallBlockAllIncoming", n => { FirewallBlockAllIncoming = n.GetBoolValue(); } },
                {"firewallEnabled", n => { FirewallEnabled = n.GetBoolValue(); } },
                {"firewallEnableStealthMode", n => { FirewallEnableStealthMode = n.GetBoolValue(); } },
                {"osMaximumVersion", n => { OsMaximumVersion = n.GetStringValue(); } },
                {"osMinimumVersion", n => { OsMinimumVersion = n.GetStringValue(); } },
                {"passwordBlockSimple", n => { PasswordBlockSimple = n.GetBoolValue(); } },
                {"passwordExpirationDays", n => { PasswordExpirationDays = n.GetIntValue(); } },
                {"passwordMinimumCharacterSetCount", n => { PasswordMinimumCharacterSetCount = n.GetIntValue(); } },
                {"passwordMinimumLength", n => { PasswordMinimumLength = n.GetIntValue(); } },
                {"passwordMinutesOfInactivityBeforeLock", n => { PasswordMinutesOfInactivityBeforeLock = n.GetIntValue(); } },
                {"passwordPreviousPasswordBlockCount", n => { PasswordPreviousPasswordBlockCount = n.GetIntValue(); } },
                {"passwordRequired", n => { PasswordRequired = n.GetBoolValue(); } },
                {"passwordRequiredType", n => { PasswordRequiredType = n.GetEnumValue<RequiredPasswordType>(); } },
                {"storageRequireEncryption", n => { StorageRequireEncryption = n.GetBoolValue(); } },
                {"systemIntegrityProtectionEnabled", n => { SystemIntegrityProtectionEnabled = n.GetBoolValue(); } },
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
            writer.WriteBoolValue("firewallBlockAllIncoming", FirewallBlockAllIncoming);
            writer.WriteBoolValue("firewallEnabled", FirewallEnabled);
            writer.WriteBoolValue("firewallEnableStealthMode", FirewallEnableStealthMode);
            writer.WriteStringValue("osMaximumVersion", OsMaximumVersion);
            writer.WriteStringValue("osMinimumVersion", OsMinimumVersion);
            writer.WriteBoolValue("passwordBlockSimple", PasswordBlockSimple);
            writer.WriteIntValue("passwordExpirationDays", PasswordExpirationDays);
            writer.WriteIntValue("passwordMinimumCharacterSetCount", PasswordMinimumCharacterSetCount);
            writer.WriteIntValue("passwordMinimumLength", PasswordMinimumLength);
            writer.WriteIntValue("passwordMinutesOfInactivityBeforeLock", PasswordMinutesOfInactivityBeforeLock);
            writer.WriteIntValue("passwordPreviousPasswordBlockCount", PasswordPreviousPasswordBlockCount);
            writer.WriteBoolValue("passwordRequired", PasswordRequired);
            writer.WriteEnumValue<RequiredPasswordType>("passwordRequiredType", PasswordRequiredType);
            writer.WriteBoolValue("storageRequireEncryption", StorageRequireEncryption);
            writer.WriteBoolValue("systemIntegrityProtectionEnabled", SystemIntegrityProtectionEnabled);
        }
    }
}
