using ApiSdk.Models.Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Workbooks.Item.Workbook.Functions.Subtotal {
    public class SubtotalRequestBody : IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        public Json FunctionNum { get; set; }
        public Json Values { get; set; }
        /// <summary>
        /// Instantiates a new subtotalRequestBody and sets the default values.
        /// </summary>
        public SubtotalRequestBody() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"functionNum", (o,n) => { (o as SubtotalRequestBody).FunctionNum = n.GetObjectValue<Json>(); } },
                {"values", (o,n) => { (o as SubtotalRequestBody).Values = n.GetObjectValue<Json>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Json>("functionNum", FunctionNum);
            writer.WriteObjectValue<Json>("values", Values);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}