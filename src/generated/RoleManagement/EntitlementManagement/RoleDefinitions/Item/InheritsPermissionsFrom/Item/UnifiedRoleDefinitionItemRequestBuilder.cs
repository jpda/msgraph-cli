using ApiSdk.Models;
using ApiSdk.Models.ODataErrors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.RoleManagement.EntitlementManagement.RoleDefinitions.Item.InheritsPermissionsFrom.Item {
    /// <summary>Provides operations to manage the inheritsPermissionsFrom property of the microsoft.graph.unifiedRoleDefinition entity.</summary>
    public class UnifiedRoleDefinitionItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Delete navigation property inheritsPermissionsFrom for roleManagement
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property inheritsPermissionsFrom for roleManagement";
            // Create options for all the parameters
            var unifiedRoleDefinitionIdOption = new Option<string>("--unified-role-definition-id", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionIdOption.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionIdOption);
            var unifiedRoleDefinitionId1Option = new Option<string>("--unified-role-definition-id1", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionId1Option.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionId1Option);
            var ifMatchOption = new Option<string>("--if-match", description: "ETag") {
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (invocationContext) => {
                var unifiedRoleDefinitionId = invocationContext.ParseResult.GetValueForOption(unifiedRoleDefinitionIdOption);
                var unifiedRoleDefinitionId1 = invocationContext.ParseResult.GetValueForOption(unifiedRoleDefinitionId1Option);
                var ifMatch = invocationContext.ParseResult.GetValueForOption(ifMatchOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("unifiedRoleDefinition%2Did", unifiedRoleDefinitionId);
                requestInfo.PathParameters.Add("unifiedRoleDefinition%2Did1", unifiedRoleDefinitionId1);
                requestInfo.Headers["If-Match"] = ifMatch;
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.";
            // Create options for all the parameters
            var unifiedRoleDefinitionIdOption = new Option<string>("--unified-role-definition-id", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionIdOption.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionIdOption);
            var unifiedRoleDefinitionId1Option = new Option<string>("--unified-role-definition-id1", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionId1Option.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionId1Option);
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
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            var jsonNoIndentOption = new Option<bool>("--json-no-indent", r => {
                if (bool.TryParse(r.Tokens.Select(t => t.Value).LastOrDefault(), out var value)) {
                    return value;
                }
                return true;
            }, description: "Disable indentation for the JSON output formatter.");
            command.AddOption(jsonNoIndentOption);
            command.SetHandler(async (invocationContext) => {
                var unifiedRoleDefinitionId = invocationContext.ParseResult.GetValueForOption(unifiedRoleDefinitionIdOption);
                var unifiedRoleDefinitionId1 = invocationContext.ParseResult.GetValueForOption(unifiedRoleDefinitionId1Option);
                var select = invocationContext.ParseResult.GetValueForOption(selectOption);
                var expand = invocationContext.ParseResult.GetValueForOption(expandOption);
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                var jsonNoIndent = invocationContext.ParseResult.GetValueForOption(jsonNoIndentOption);
                var outputFilter = invocationContext.BindingContext.GetRequiredService<IOutputFilter>();
                var outputFormatterFactory = invocationContext.BindingContext.GetRequiredService<IOutputFormatterFactory>();
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = CreateGetRequestInformation(q => {
                    q.QueryParameters.Select = select;
                    q.QueryParameters.Expand = expand;
                });
                requestInfo.PathParameters.Add("unifiedRoleDefinition%2Did", unifiedRoleDefinitionId);
                requestInfo.PathParameters.Add("unifiedRoleDefinition%2Did1", unifiedRoleDefinitionId1);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            });
            return command;
        }
        /// <summary>
        /// Update the navigation property inheritsPermissionsFrom in roleManagement
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property inheritsPermissionsFrom in roleManagement";
            // Create options for all the parameters
            var unifiedRoleDefinitionIdOption = new Option<string>("--unified-role-definition-id", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionIdOption.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionIdOption);
            var unifiedRoleDefinitionId1Option = new Option<string>("--unified-role-definition-id1", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionId1Option.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionId1Option);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (invocationContext) => {
                var unifiedRoleDefinitionId = invocationContext.ParseResult.GetValueForOption(unifiedRoleDefinitionIdOption);
                var unifiedRoleDefinitionId1 = invocationContext.ParseResult.GetValueForOption(unifiedRoleDefinitionId1Option);
                var body = invocationContext.ParseResult.GetValueForOption(bodyOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<UnifiedRoleDefinition>(UnifiedRoleDefinition.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                requestInfo.PathParameters.Add("unifiedRoleDefinition%2Did", unifiedRoleDefinitionId);
                requestInfo.PathParameters.Add("unifiedRoleDefinition%2Did1", unifiedRoleDefinitionId1);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new UnifiedRoleDefinitionItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public UnifiedRoleDefinitionItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/roleManagement/entitlementManagement/roleDefinitions/{unifiedRoleDefinition%2Did}/inheritsPermissionsFrom/{unifiedRoleDefinition%2Did1}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property inheritsPermissionsFrom for roleManagement
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<UnifiedRoleDefinitionItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new UnifiedRoleDefinitionItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<UnifiedRoleDefinitionItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new UnifiedRoleDefinitionItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property inheritsPermissionsFrom in roleManagement
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(UnifiedRoleDefinition body, Action<UnifiedRoleDefinitionItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new UnifiedRoleDefinitionItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class UnifiedRoleDefinitionItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new unifiedRoleDefinitionItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public UnifiedRoleDefinitionItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.</summary>
        public class UnifiedRoleDefinitionItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class UnifiedRoleDefinitionItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public UnifiedRoleDefinitionItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new UnifiedRoleDefinitionItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new unifiedRoleDefinitionItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public UnifiedRoleDefinitionItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class UnifiedRoleDefinitionItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new unifiedRoleDefinitionItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public UnifiedRoleDefinitionItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
