using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models.Microsoft.Graph {
    public class WorkbookWorksheetProtection : Entity, IParsable {
        /// <summary>Indicates if the worksheet is protected.  Read-only.</summary>
        public bool? @Protected { get; set; }
        /// <summary>Sheet protection options. Read-only.</summary>
        public WorkbookWorksheetProtectionOptions Options { get; set; }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>>(base.GetFieldDeserializers<T>()) {
                {"@Protected", (o,n) => { (o as WorkbookWorksheetProtection).@Protected = n.GetBoolValue(); } },
                {"options", (o,n) => { (o as WorkbookWorksheetProtection).Options = n.GetObjectValue<WorkbookWorksheetProtectionOptions>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteBoolValue("@Protected", @Protected);
            writer.WriteObjectValue<WorkbookWorksheetProtectionOptions>("options", Options);
        }
    }
}