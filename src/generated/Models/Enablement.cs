namespace ApiSdk.Models {
    /// <summary>Provides operations to manage the deviceManagement singleton.</summary>
    public enum Enablement {
        /// <summary>Device default value, no intent.</summary>
        NotConfigured,
        /// <summary>Enables the setting on the device.</summary>
        Enabled,
        /// <summary>Disables the setting on the device.</summary>
        Disabled,
    }
}
