using ApiSdk.Me.CalendarGroups.Item.Calendars.Item;
using ApiSdk.Models.Microsoft.Graph;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.Me.CalendarGroups.Item.Calendars {
    /// <summary>Builds and executes requests for operations under \me\calendarGroups\{calendarGroup-id}\calendars</summary>
    public class CalendarsRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public List<Command> BuildCommand() {
            var builder = new CalendarRequestBuilder(PathParameters, RequestAdapter);
            var commands = new List<Command> { 
                builder.BuildCalendarPermissionsCommand(),
                builder.BuildCalendarViewCommand(),
                builder.BuildDeleteCommand(),
                builder.BuildEventsCommand(),
                builder.BuildGetCommand(),
                builder.BuildGetScheduleCommand(),
                builder.BuildMultiValueExtendedPropertiesCommand(),
                builder.BuildPatchCommand(),
                builder.BuildSingleValueExtendedPropertiesCommand(),
            };
            return commands;
        }
        /// <summary>
        /// The calendars in the calendar group. Navigation property. Read-only. Nullable.
        /// </summary>
        public Command BuildCreateCommand() {
            var command = new Command("create");
            command.Description = "The calendars in the calendar group. Navigation property. Read-only. Nullable.";
            // Create options for all the parameters
            command.AddOption(new Option<string>("--calendargroup-id", description: "key: id of calendarGroup"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string>(async (calendarGroupId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ApiSdk.Models.Microsoft.Graph.Calendar>();
                var requestInfo = CreatePostRequestInformation(model);
                if (!String.IsNullOrEmpty(calendarGroupId)) requestInfo.PathParameters.Add("calendarGroup_id", calendarGroupId);
                var result = await RequestAdapter.SendAsync<ApiSdk.Models.Microsoft.Graph.Calendar>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteObjectValue(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            });
            return command;
        }
        /// <summary>
        /// The calendars in the calendar group. Navigation property. Read-only. Nullable.
        /// </summary>
        public Command BuildListCommand() {
            var command = new Command("list");
            command.Description = "The calendars in the calendar group. Navigation property. Read-only. Nullable.";
            // Create options for all the parameters
            command.AddOption(new Option<string>("--calendargroup-id", description: "key: id of calendarGroup"));
            command.AddOption(new Option<int?>("--top", description: "Show only the first n items"));
            command.AddOption(new Option<int?>("--skip", description: "Skip the first n items"));
            command.AddOption(new Option<string>("--filter", description: "Filter items by property values"));
            command.AddOption(new Option<bool?>("--count", description: "Include count of items"));
            command.AddOption(new Option<object>("--orderby", description: "Order items by property values"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.Handler = CommandHandler.Create<string, int?, int?, string, bool?, object, object>(async (calendarGroupId, top, skip, filter, count, orderby, select) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(calendarGroupId)) requestInfo.PathParameters.Add("calendarGroup_id", calendarGroupId);
                requestInfo.QueryParameters.Add("top", top);
                requestInfo.QueryParameters.Add("skip", skip);
                if (!String.IsNullOrEmpty(filter)) requestInfo.QueryParameters.Add("filter", filter);
                requestInfo.QueryParameters.Add("count", count);
                requestInfo.QueryParameters.Add("orderby", orderby);
                requestInfo.QueryParameters.Add("select", select);
                var result = await RequestAdapter.SendAsync<CalendarsResponse>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteObjectValue(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new CalendarsRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public CalendarsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/me/calendarGroups/{calendarGroup_id}/calendars{?top,skip,filter,count,orderby,select}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The calendars in the calendar group. Navigation property. Read-only. Nullable.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.GET,
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
        /// The calendars in the calendar group. Navigation property. Read-only. Nullable.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(ApiSdk.Models.Microsoft.Graph.Calendar body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// The calendars in the calendar group. Navigation property. Read-only. Nullable.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<CalendarsResponse> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<CalendarsResponse>(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>
        /// The calendars in the calendar group. Navigation property. Read-only. Nullable.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<ApiSdk.Models.Microsoft.Graph.Calendar> PostAsync(ApiSdk.Models.Microsoft.Graph.Calendar model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePostRequestInformation(model, h, o);
            return await RequestAdapter.SendAsync<ApiSdk.Models.Microsoft.Graph.Calendar>(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>The calendars in the calendar group. Navigation property. Read-only. Nullable.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Include count of items</summary>
            public bool? Count { get; set; }
            /// <summary>Filter items by property values</summary>
            public string Filter { get; set; }
            /// <summary>Order items by property values</summary>
            public string[] Orderby { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
            /// <summary>Skip the first n items</summary>
            public int? Skip { get; set; }
            /// <summary>Show only the first n items</summary>
            public int? Top { get; set; }
        }
    }
}
