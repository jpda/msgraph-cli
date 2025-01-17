using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    /// <summary>Policy used to configure detailed management settings for a specified set of apps for all users not targeted by a TargetedManagedAppProtection Policy</summary>
    public class DefaultManagedAppProtection : ManagedAppProtection, IParsable {
        /// <summary>Type of encryption which should be used for data in a managed app. (iOS Only). Possible values are: useDeviceSettings, afterDeviceRestart, whenDeviceLockedExceptOpenFiles, whenDeviceLocked.</summary>
        public ManagedAppDataEncryptionType? AppDataEncryptionType { get; set; }
        /// <summary>List of apps to which the policy is deployed.</summary>
        public List<ManagedMobileApp> Apps { get; set; }
        /// <summary>A set of string key and string value pairs to be sent to the affected users, unalterned by this service</summary>
        public List<KeyValuePair> CustomSettings { get; set; }
        /// <summary>Count of apps to which the current policy is deployed.</summary>
        public int? DeployedAppCount { get; set; }
        /// <summary>Navigation property to deployment summary of the configuration.</summary>
        public ManagedAppPolicyDeploymentSummary DeploymentSummary { get; set; }
        /// <summary>When this setting is enabled, app level encryption is disabled if device level encryption is enabled. (Android only)</summary>
        public bool? DisableAppEncryptionIfDeviceEncryptionIsEnabled { get; set; }
        /// <summary>Indicates whether managed-app data should be encrypted. (Android only)</summary>
        public bool? EncryptAppData { get; set; }
        /// <summary>Indicates whether use of the FaceID is allowed in place of a pin if PinRequired is set to True. (iOS Only)</summary>
        public bool? FaceIdBlocked { get; set; }
        /// <summary>Define the oldest required Android security patch level a user can have to gain secure access to the app. (Android only)</summary>
        public string MinimumRequiredPatchVersion { get; set; }
        /// <summary>Versions less than the specified version will block the managed app from accessing company data. (iOS Only)</summary>
        public string MinimumRequiredSdkVersion { get; set; }
        /// <summary>Define the oldest recommended Android security patch level a user can have for secure access to the app. (Android only)</summary>
        public string MinimumWarningPatchVersion { get; set; }
        /// <summary>Indicates whether screen capture is blocked. (Android only)</summary>
        public bool? ScreenCaptureBlocked { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static new DefaultManagedAppProtection CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DefaultManagedAppProtection();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"appDataEncryptionType", n => { AppDataEncryptionType = n.GetEnumValue<ManagedAppDataEncryptionType>(); } },
                {"apps", n => { Apps = n.GetCollectionOfObjectValues<ManagedMobileApp>(ManagedMobileApp.CreateFromDiscriminatorValue).ToList(); } },
                {"customSettings", n => { CustomSettings = n.GetCollectionOfObjectValues<KeyValuePair>(KeyValuePair.CreateFromDiscriminatorValue).ToList(); } },
                {"deployedAppCount", n => { DeployedAppCount = n.GetIntValue(); } },
                {"deploymentSummary", n => { DeploymentSummary = n.GetObjectValue<ManagedAppPolicyDeploymentSummary>(ManagedAppPolicyDeploymentSummary.CreateFromDiscriminatorValue); } },
                {"disableAppEncryptionIfDeviceEncryptionIsEnabled", n => { DisableAppEncryptionIfDeviceEncryptionIsEnabled = n.GetBoolValue(); } },
                {"encryptAppData", n => { EncryptAppData = n.GetBoolValue(); } },
                {"faceIdBlocked", n => { FaceIdBlocked = n.GetBoolValue(); } },
                {"minimumRequiredPatchVersion", n => { MinimumRequiredPatchVersion = n.GetStringValue(); } },
                {"minimumRequiredSdkVersion", n => { MinimumRequiredSdkVersion = n.GetStringValue(); } },
                {"minimumWarningPatchVersion", n => { MinimumWarningPatchVersion = n.GetStringValue(); } },
                {"screenCaptureBlocked", n => { ScreenCaptureBlocked = n.GetBoolValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<ManagedAppDataEncryptionType>("appDataEncryptionType", AppDataEncryptionType);
            writer.WriteCollectionOfObjectValues<ManagedMobileApp>("apps", Apps);
            writer.WriteCollectionOfObjectValues<KeyValuePair>("customSettings", CustomSettings);
            writer.WriteIntValue("deployedAppCount", DeployedAppCount);
            writer.WriteObjectValue<ManagedAppPolicyDeploymentSummary>("deploymentSummary", DeploymentSummary);
            writer.WriteBoolValue("disableAppEncryptionIfDeviceEncryptionIsEnabled", DisableAppEncryptionIfDeviceEncryptionIsEnabled);
            writer.WriteBoolValue("encryptAppData", EncryptAppData);
            writer.WriteBoolValue("faceIdBlocked", FaceIdBlocked);
            writer.WriteStringValue("minimumRequiredPatchVersion", MinimumRequiredPatchVersion);
            writer.WriteStringValue("minimumRequiredSdkVersion", MinimumRequiredSdkVersion);
            writer.WriteStringValue("minimumWarningPatchVersion", MinimumWarningPatchVersion);
            writer.WriteBoolValue("screenCaptureBlocked", ScreenCaptureBlocked);
        }
    }
}
