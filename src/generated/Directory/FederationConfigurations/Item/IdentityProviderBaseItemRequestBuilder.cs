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
namespace ApiSdk.Directory.FederationConfigurations.Item {
    /// <summary>Provides operations to manage the federationConfigurations property of the microsoft.graph.directory entity.</summary>
    public class IdentityProviderBaseItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Delete navigation property federationConfigurations for directory
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property federationConfigurations for directory";
            // Create options for all the parameters
            var identityProviderBaseIdOption = new Option<string>("--identity-provider-base-id", description: "key: id of identityProviderBase") {
            };
            identityProviderBaseIdOption.IsRequired = true;
            command.AddOption(identityProviderBaseIdOption);
            var ifMatchOption = new Option<string>("--if-match", description: "ETag") {
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (invocationContext) => {
                var identityProviderBaseId = invocationContext.ParseResult.GetValueForOption(identityProviderBaseIdOption);
                var ifMatch = invocationContext.ParseResult.GetValueForOption(ifMatchOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("identityProviderBase%2Did", identityProviderBaseId);
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
        /// Configure domain federation with organizations whose identity provider (IdP) supports either the SAML or WS-Fed protocol.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Configure domain federation with organizations whose identity provider (IdP) supports either the SAML or WS-Fed protocol.";
            // Create options for all the parameters
            var identityProviderBaseIdOption = new Option<string>("--identity-provider-base-id", description: "key: id of identityProviderBase") {
            };
            identityProviderBaseIdOption.IsRequired = true;
            command.AddOption(identityProviderBaseIdOption);
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
                var identityProviderBaseId = invocationContext.ParseResult.GetValueForOption(identityProviderBaseIdOption);
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
                requestInfo.PathParameters.Add("identityProviderBase%2Did", identityProviderBaseId);
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
        /// Update the navigation property federationConfigurations in directory
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property federationConfigurations in directory";
            // Create options for all the parameters
            var identityProviderBaseIdOption = new Option<string>("--identity-provider-base-id", description: "key: id of identityProviderBase") {
            };
            identityProviderBaseIdOption.IsRequired = true;
            command.AddOption(identityProviderBaseIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (invocationContext) => {
                var identityProviderBaseId = invocationContext.ParseResult.GetValueForOption(identityProviderBaseIdOption);
                var body = invocationContext.ParseResult.GetValueForOption(bodyOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<IdentityProviderBase>(IdentityProviderBase.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                requestInfo.PathParameters.Add("identityProviderBase%2Did", identityProviderBaseId);
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
        /// Instantiates a new IdentityProviderBaseItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public IdentityProviderBaseItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/directory/federationConfigurations/{identityProviderBase%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property federationConfigurations for directory
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IdentityProviderBaseItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new IdentityProviderBaseItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Configure domain federation with organizations whose identity provider (IdP) supports either the SAML or WS-Fed protocol.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<IdentityProviderBaseItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new IdentityProviderBaseItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property federationConfigurations in directory
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(IdentityProviderBase body, Action<IdentityProviderBaseItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new IdentityProviderBaseItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class IdentityProviderBaseItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new identityProviderBaseItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public IdentityProviderBaseItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configure domain federation with organizations whose identity provider (IdP) supports either the SAML or WS-Fed protocol.</summary>
        public class IdentityProviderBaseItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class IdentityProviderBaseItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public IdentityProviderBaseItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new IdentityProviderBaseItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new identityProviderBaseItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public IdentityProviderBaseItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class IdentityProviderBaseItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new identityProviderBaseItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public IdentityProviderBaseItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
