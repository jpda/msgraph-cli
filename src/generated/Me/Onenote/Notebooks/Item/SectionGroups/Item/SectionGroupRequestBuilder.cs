using ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item.ParentNotebook;
using ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item.ParentSectionGroup;
using ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item.SectionGroups;
using ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item.Sections;
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
namespace ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item {
    /// <summary>Builds and executes requests for operations under \me\onenote\notebooks\{notebook-id}\sectionGroups\{sectionGroup-id}</summary>
    public class SectionGroupRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// The section groups in the notebook. Read-only. Nullable.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "The section groups in the notebook. Read-only. Nullable.";
            // Create options for all the parameters
            command.AddOption(new Option<string>("--notebook-id", description: "key: id of notebook"));
            command.AddOption(new Option<string>("--sectiongroup-id", description: "key: id of sectionGroup"));
            command.Handler = CommandHandler.Create<string, string>(async (notebookId, sectionGroupId) => {
                var requestInfo = CreateDeleteRequestInformation();
                if (!String.IsNullOrEmpty(notebookId)) requestInfo.PathParameters.Add("notebook_id", notebookId);
                if (!String.IsNullOrEmpty(sectionGroupId)) requestInfo.PathParameters.Add("sectionGroup_id", sectionGroupId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// The section groups in the notebook. Read-only. Nullable.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The section groups in the notebook. Read-only. Nullable.";
            // Create options for all the parameters
            command.AddOption(new Option<string>("--notebook-id", description: "key: id of notebook"));
            command.AddOption(new Option<string>("--sectiongroup-id", description: "key: id of sectionGroup"));
            command.AddOption(new Option<object>("--select", description: "Select properties to be returned"));
            command.AddOption(new Option<object>("--expand", description: "Expand related entities"));
            command.Handler = CommandHandler.Create<string, string, object, object>(async (notebookId, sectionGroupId, select, expand) => {
                var requestInfo = CreateGetRequestInformation();
                if (!String.IsNullOrEmpty(notebookId)) requestInfo.PathParameters.Add("notebook_id", notebookId);
                if (!String.IsNullOrEmpty(sectionGroupId)) requestInfo.PathParameters.Add("sectionGroup_id", sectionGroupId);
                requestInfo.QueryParameters.Add("select", select);
                requestInfo.QueryParameters.Add("expand", expand);
                var result = await RequestAdapter.SendAsync<SectionGroup>(requestInfo);
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
        public Command BuildParentNotebookCommand() {
            var command = new Command("parent-notebook");
            var builder = new ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item.ParentNotebook.ParentNotebookRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCopyNotebookCommand());
            command.AddCommand(builder.BuildDeleteCommand());
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildPatchCommand());
            return command;
        }
        public Command BuildParentSectionGroupCommand() {
            var command = new Command("parent-section-group");
            var builder = new ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item.ParentSectionGroup.ParentSectionGroupRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildDeleteCommand());
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildPatchCommand());
            return command;
        }
        /// <summary>
        /// The section groups in the notebook. Read-only. Nullable.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "The section groups in the notebook. Read-only. Nullable.";
            // Create options for all the parameters
            command.AddOption(new Option<string>("--notebook-id", description: "key: id of notebook"));
            command.AddOption(new Option<string>("--sectiongroup-id", description: "key: id of sectionGroup"));
            command.AddOption(new Option<string>("--body"));
            command.Handler = CommandHandler.Create<string, string, string>(async (notebookId, sectionGroupId, body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<SectionGroup>();
                var requestInfo = CreatePatchRequestInformation(model);
                if (!String.IsNullOrEmpty(notebookId)) requestInfo.PathParameters.Add("notebook_id", notebookId);
                if (!String.IsNullOrEmpty(sectionGroupId)) requestInfo.PathParameters.Add("sectionGroup_id", sectionGroupId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        public Command BuildSectionGroupsCommand() {
            var command = new Command("section-groups");
            var builder = new ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item.SectionGroups.SectionGroupsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildSectionsCommand() {
            var command = new Command("sections");
            var builder = new ApiSdk.Me.Onenote.Notebooks.Item.SectionGroups.Item.Sections.SectionsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new SectionGroupRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public SectionGroupRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/me/onenote/notebooks/{notebook_id}/sectionGroups/{sectionGroup_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The section groups in the notebook. Read-only. Nullable.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// The section groups in the notebook. Read-only. Nullable.
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
        /// The section groups in the notebook. Read-only. Nullable.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(SectionGroup body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// The section groups in the notebook. Read-only. Nullable.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateDeleteRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>
        /// The section groups in the notebook. Read-only. Nullable.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<SectionGroup> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<SectionGroup>(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>
        /// The section groups in the notebook. Read-only. Nullable.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(SectionGroup model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePatchRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>The section groups in the notebook. Read-only. Nullable.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}