using ApiSdk.Models.Microsoft.Graph;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Cli.Commons.Binding;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.DeviceManagement.TermsAndConditions.Item.Assignments.Item {
    /// <summary>Builds and executes requests for operations under \deviceManagement\termsAndConditions\{termsAndConditionsItem-id}\assignments\{termsAndConditionsAssignment-id}</summary>
    public class TermsAndConditionsAssignmentItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// The list of assignments for this T&C policy.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "The list of assignments for this T&C policy.";
            // Create options for all the parameters
            var termsAndConditionsItemIdOption = new Option<string>("--terms-and-conditions-item-id", description: "key: id of termsAndConditions") {
            };
            termsAndConditionsItemIdOption.IsRequired = true;
            command.AddOption(termsAndConditionsItemIdOption);
            var termsAndConditionsAssignmentIdOption = new Option<string>("--terms-and-conditions-assignment-id", description: "key: id of termsAndConditionsAssignment") {
            };
            termsAndConditionsAssignmentIdOption.IsRequired = true;
            command.AddOption(termsAndConditionsAssignmentIdOption);
            command.SetHandler(async (object[] parameters) => {
                var termsAndConditionsItemId = (string) parameters[0];
                var termsAndConditionsAssignmentId = (string) parameters[1];
                var cancellationToken = (CancellationToken) parameters[2];
                PathParameters.Clear();
                PathParameters.Add("termsAndConditionsItem_id", termsAndConditionsItemId);
                PathParameters.Add("termsAndConditionsAssignment_id", termsAndConditionsAssignmentId);
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(termsAndConditionsItemIdOption, termsAndConditionsAssignmentIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// The list of assignments for this T&C policy.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The list of assignments for this T&C policy.";
            // Create options for all the parameters
            var termsAndConditionsItemIdOption = new Option<string>("--terms-and-conditions-item-id", description: "key: id of termsAndConditions") {
            };
            termsAndConditionsItemIdOption.IsRequired = true;
            command.AddOption(termsAndConditionsItemIdOption);
            var termsAndConditionsAssignmentIdOption = new Option<string>("--terms-and-conditions-assignment-id", description: "key: id of termsAndConditionsAssignment") {
            };
            termsAndConditionsAssignmentIdOption.IsRequired = true;
            command.AddOption(termsAndConditionsAssignmentIdOption);
            var selectOption = new Option<string[]>("--select", description: "Select properties to be returned") {
                Arity = ArgumentArity.ZeroOrMore
            };
            selectOption.IsRequired = false;
            command.AddOption(selectOption);
            var expandOption = new Option<string[]>("--expand", description: "Expand related entities") {
                Arity = ArgumentArity.ZeroOrMore
            };
            expandOption.IsRequired = false;
            command.AddOption(expandOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            var outputFilterOption = new Option<string>("--query");
            command.AddOption(outputFilterOption);
            command.SetHandler(async (object[] parameters) => {
                var termsAndConditionsItemId = (string) parameters[0];
                var termsAndConditionsAssignmentId = (string) parameters[1];
                var select = (string[]) parameters[2];
                var expand = (string[]) parameters[3];
                var output = (FormatterType) parameters[4];
                var outputFilterOption = (string) parameters[5];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[6];
                var cancellationToken = (CancellationToken) parameters[7];
                PathParameters.Clear();
                PathParameters.Add("termsAndConditionsItem_id", termsAndConditionsItemId);
                PathParameters.Add("termsAndConditionsAssignment_id", termsAndConditionsAssignmentId);
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                formatter.WriteOutput(response);
            }, new CollectionBinding(termsAndConditionsItemIdOption, termsAndConditionsAssignmentIdOption, selectOption, expandOption, outputOption, outputFilterOption, new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// The list of assignments for this T&C policy.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "The list of assignments for this T&C policy.";
            // Create options for all the parameters
            var termsAndConditionsItemIdOption = new Option<string>("--terms-and-conditions-item-id", description: "key: id of termsAndConditions") {
            };
            termsAndConditionsItemIdOption.IsRequired = true;
            command.AddOption(termsAndConditionsItemIdOption);
            var termsAndConditionsAssignmentIdOption = new Option<string>("--terms-and-conditions-assignment-id", description: "key: id of termsAndConditionsAssignment") {
            };
            termsAndConditionsAssignmentIdOption.IsRequired = true;
            command.AddOption(termsAndConditionsAssignmentIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var termsAndConditionsItemId = (string) parameters[0];
                var termsAndConditionsAssignmentId = (string) parameters[1];
                var body = (string) parameters[2];
                var cancellationToken = (CancellationToken) parameters[3];
                PathParameters.Clear();
                PathParameters.Add("termsAndConditionsItem_id", termsAndConditionsItemId);
                PathParameters.Add("termsAndConditionsAssignment_id", termsAndConditionsAssignmentId);
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<TermsAndConditionsAssignment>();
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(termsAndConditionsItemIdOption, termsAndConditionsAssignmentIdOption, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new TermsAndConditionsAssignmentItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public TermsAndConditionsAssignmentItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceManagement/termsAndConditions/{termsAndConditionsItem_id}/assignments/{termsAndConditionsAssignment_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The list of assignments for this T&C policy.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// The list of assignments for this T&C policy.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (q != null) {
                var qParams = new GetQueryParameters();
                q.Invoke(qParams);
                qParams.AddQueryParameters(requestInfo.QueryParameters);
            }
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// The list of assignments for this T&C policy.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(TermsAndConditionsAssignment body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>The list of assignments for this T&C policy.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}