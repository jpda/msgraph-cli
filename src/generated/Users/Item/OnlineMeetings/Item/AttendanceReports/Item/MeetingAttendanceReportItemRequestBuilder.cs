using ApiSdk.Models;
using ApiSdk.Models.ODataErrors;
using ApiSdk.Users.Item.OnlineMeetings.Item.AttendanceReports.Item.AttendanceRecords;
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
namespace ApiSdk.Users.Item.OnlineMeetings.Item.AttendanceReports.Item {
    /// <summary>Provides operations to manage the attendanceReports property of the microsoft.graph.onlineMeeting entity.</summary>
    public class MeetingAttendanceReportItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildAttendanceRecordsCommand() {
            var command = new Command("attendance-records");
            var builder = new AttendanceRecordsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        /// <summary>
        /// Delete navigation property attendanceReports for users
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property attendanceReports for users";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var onlineMeetingIdOption = new Option<string>("--online-meeting-id", description: "key: id of onlineMeeting") {
            };
            onlineMeetingIdOption.IsRequired = true;
            command.AddOption(onlineMeetingIdOption);
            var meetingAttendanceReportIdOption = new Option<string>("--meeting-attendance-report-id", description: "key: id of meetingAttendanceReport") {
            };
            meetingAttendanceReportIdOption.IsRequired = true;
            command.AddOption(meetingAttendanceReportIdOption);
            var ifMatchOption = new Option<string>("--if-match", description: "ETag") {
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (invocationContext) => {
                var userId = invocationContext.ParseResult.GetValueForOption(userIdOption);
                var onlineMeetingId = invocationContext.ParseResult.GetValueForOption(onlineMeetingIdOption);
                var meetingAttendanceReportId = invocationContext.ParseResult.GetValueForOption(meetingAttendanceReportIdOption);
                var ifMatch = invocationContext.ParseResult.GetValueForOption(ifMatchOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("user%2Did", userId);
                requestInfo.PathParameters.Add("onlineMeeting%2Did", onlineMeetingId);
                requestInfo.PathParameters.Add("meetingAttendanceReport%2Did", meetingAttendanceReportId);
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
        /// The attendance reports of an online meeting. Read-only.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The attendance reports of an online meeting. Read-only.";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var onlineMeetingIdOption = new Option<string>("--online-meeting-id", description: "key: id of onlineMeeting") {
            };
            onlineMeetingIdOption.IsRequired = true;
            command.AddOption(onlineMeetingIdOption);
            var meetingAttendanceReportIdOption = new Option<string>("--meeting-attendance-report-id", description: "key: id of meetingAttendanceReport") {
            };
            meetingAttendanceReportIdOption.IsRequired = true;
            command.AddOption(meetingAttendanceReportIdOption);
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
                var userId = invocationContext.ParseResult.GetValueForOption(userIdOption);
                var onlineMeetingId = invocationContext.ParseResult.GetValueForOption(onlineMeetingIdOption);
                var meetingAttendanceReportId = invocationContext.ParseResult.GetValueForOption(meetingAttendanceReportIdOption);
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
                requestInfo.PathParameters.Add("user%2Did", userId);
                requestInfo.PathParameters.Add("onlineMeeting%2Did", onlineMeetingId);
                requestInfo.PathParameters.Add("meetingAttendanceReport%2Did", meetingAttendanceReportId);
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
        /// Update the navigation property attendanceReports in users
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property attendanceReports in users";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var onlineMeetingIdOption = new Option<string>("--online-meeting-id", description: "key: id of onlineMeeting") {
            };
            onlineMeetingIdOption.IsRequired = true;
            command.AddOption(onlineMeetingIdOption);
            var meetingAttendanceReportIdOption = new Option<string>("--meeting-attendance-report-id", description: "key: id of meetingAttendanceReport") {
            };
            meetingAttendanceReportIdOption.IsRequired = true;
            command.AddOption(meetingAttendanceReportIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (invocationContext) => {
                var userId = invocationContext.ParseResult.GetValueForOption(userIdOption);
                var onlineMeetingId = invocationContext.ParseResult.GetValueForOption(onlineMeetingIdOption);
                var meetingAttendanceReportId = invocationContext.ParseResult.GetValueForOption(meetingAttendanceReportIdOption);
                var body = invocationContext.ParseResult.GetValueForOption(bodyOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<MeetingAttendanceReport>(MeetingAttendanceReport.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                requestInfo.PathParameters.Add("user%2Did", userId);
                requestInfo.PathParameters.Add("onlineMeeting%2Did", onlineMeetingId);
                requestInfo.PathParameters.Add("meetingAttendanceReport%2Did", meetingAttendanceReportId);
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
        /// Instantiates a new MeetingAttendanceReportItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public MeetingAttendanceReportItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user%2Did}/onlineMeetings/{onlineMeeting%2Did}/attendanceReports/{meetingAttendanceReport%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property attendanceReports for users
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<MeetingAttendanceReportItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new MeetingAttendanceReportItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// The attendance reports of an online meeting. Read-only.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<MeetingAttendanceReportItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.Headers.Add("Accept", "application/json");
            if (requestConfiguration != null) {
                var requestConfig = new MeetingAttendanceReportItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property attendanceReports in users
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(MeetingAttendanceReport body, Action<MeetingAttendanceReportItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new MeetingAttendanceReportItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class MeetingAttendanceReportItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new meetingAttendanceReportItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public MeetingAttendanceReportItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>The attendance reports of an online meeting. Read-only.</summary>
        public class MeetingAttendanceReportItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class MeetingAttendanceReportItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public MeetingAttendanceReportItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new MeetingAttendanceReportItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new meetingAttendanceReportItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public MeetingAttendanceReportItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class MeetingAttendanceReportItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new meetingAttendanceReportItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public MeetingAttendanceReportItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
