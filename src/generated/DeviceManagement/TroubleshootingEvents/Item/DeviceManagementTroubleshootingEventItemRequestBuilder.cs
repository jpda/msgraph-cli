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
namespace ApiSdk.DeviceManagement.TroubleshootingEvents.Item {
    /// <summary>Builds and executes requests for operations under \deviceManagement\troubleshootingEvents\{deviceManagementTroubleshootingEvent-id}</summary>
    public class DeviceManagementTroubleshootingEventItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// The list of troubleshooting events for the tenant.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "The list of troubleshooting events for the tenant.";
            // Create options for all the parameters
            var deviceManagementTroubleshootingEventIdOption = new Option<string>("--device-management-troubleshooting-event-id", description: "key: id of deviceManagementTroubleshootingEvent") {
            };
            deviceManagementTroubleshootingEventIdOption.IsRequired = true;
            command.AddOption(deviceManagementTroubleshootingEventIdOption);
            command.SetHandler(async (object[] parameters) => {
                var deviceManagementTroubleshootingEventId = (string) parameters[0];
                var cancellationToken = (CancellationToken) parameters[1];
                PathParameters.Clear();
                PathParameters.Add("deviceManagementTroubleshootingEvent_id", deviceManagementTroubleshootingEventId);
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(deviceManagementTroubleshootingEventIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// The list of troubleshooting events for the tenant.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The list of troubleshooting events for the tenant.";
            // Create options for all the parameters
            var deviceManagementTroubleshootingEventIdOption = new Option<string>("--device-management-troubleshooting-event-id", description: "key: id of deviceManagementTroubleshootingEvent") {
            };
            deviceManagementTroubleshootingEventIdOption.IsRequired = true;
            command.AddOption(deviceManagementTroubleshootingEventIdOption);
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
                var deviceManagementTroubleshootingEventId = (string) parameters[0];
                var select = (string[]) parameters[1];
                var expand = (string[]) parameters[2];
                var output = (FormatterType) parameters[3];
                var outputFilterOption = (string) parameters[4];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[5];
                var cancellationToken = (CancellationToken) parameters[6];
                PathParameters.Clear();
                PathParameters.Add("deviceManagementTroubleshootingEvent_id", deviceManagementTroubleshootingEventId);
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                formatter.WriteOutput(response);
            }, new CollectionBinding(deviceManagementTroubleshootingEventIdOption, selectOption, expandOption, outputOption, outputFilterOption, new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// The list of troubleshooting events for the tenant.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "The list of troubleshooting events for the tenant.";
            // Create options for all the parameters
            var deviceManagementTroubleshootingEventIdOption = new Option<string>("--device-management-troubleshooting-event-id", description: "key: id of deviceManagementTroubleshootingEvent") {
            };
            deviceManagementTroubleshootingEventIdOption.IsRequired = true;
            command.AddOption(deviceManagementTroubleshootingEventIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var deviceManagementTroubleshootingEventId = (string) parameters[0];
                var body = (string) parameters[1];
                var cancellationToken = (CancellationToken) parameters[2];
                PathParameters.Clear();
                PathParameters.Add("deviceManagementTroubleshootingEvent_id", deviceManagementTroubleshootingEventId);
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<DeviceManagementTroubleshootingEvent>();
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(deviceManagementTroubleshootingEventIdOption, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new DeviceManagementTroubleshootingEventItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public DeviceManagementTroubleshootingEventItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceManagement/troubleshootingEvents/{deviceManagementTroubleshootingEvent_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The list of troubleshooting events for the tenant.
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
        /// The list of troubleshooting events for the tenant.
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
        /// The list of troubleshooting events for the tenant.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(DeviceManagementTroubleshootingEvent body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// <summary>The list of troubleshooting events for the tenant.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}