using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class WorkbookOperationError : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The error code.</summary>
        public string Code { get; set; }
        /// <summary>The innerError property</summary>
        public WorkbookOperationError InnerError { get; set; }
        /// <summary>The error message.</summary>
        public string Message { get; set; }
        /// <summary>
        /// Instantiates a new workbookOperationError and sets the default values.
        /// </summary>
        public WorkbookOperationError() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static WorkbookOperationError CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new WorkbookOperationError();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"code", n => { Code = n.GetStringValue(); } },
                {"innerError", n => { InnerError = n.GetObjectValue<WorkbookOperationError>(WorkbookOperationError.CreateFromDiscriminatorValue); } },
                {"message", n => { Message = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("code", Code);
            writer.WriteObjectValue<WorkbookOperationError>("innerError", InnerError);
            writer.WriteStringValue("message", Message);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
