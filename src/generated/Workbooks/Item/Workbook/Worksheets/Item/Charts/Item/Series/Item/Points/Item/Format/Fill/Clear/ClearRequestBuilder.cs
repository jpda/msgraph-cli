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
namespace ApiSdk.Workbooks.Item.Workbook.Worksheets.Item.Charts.Item.Series.Item.Points.Item.Format.Fill.Clear {
    /// <summary>Builds and executes requests for operations under \workbooks\{driveItem-id}\workbook\worksheets\{workbookWorksheet-id}\charts\{workbookChart-id}\series\{workbookChartSeries-id}\points\{workbookChartPoint-id}\format\fill\microsoft.graph.clear</summary>
    public class ClearRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke action clear
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            command.Description = "Invoke action clear";
            // Create options for all the parameters
            var driveItemIdOption = new Option<string>("--drive-item-id", description: "key: id of driveItem") {
            };
            driveItemIdOption.IsRequired = true;
            command.AddOption(driveItemIdOption);
            var workbookWorksheetIdOption = new Option<string>("--workbook-worksheet-id", description: "key: id of workbookWorksheet") {
            };
            workbookWorksheetIdOption.IsRequired = true;
            command.AddOption(workbookWorksheetIdOption);
            var workbookChartIdOption = new Option<string>("--workbook-chart-id", description: "key: id of workbookChart") {
            };
            workbookChartIdOption.IsRequired = true;
            command.AddOption(workbookChartIdOption);
            var workbookChartSeriesIdOption = new Option<string>("--workbook-chart-series-id", description: "key: id of workbookChartSeries") {
            };
            workbookChartSeriesIdOption.IsRequired = true;
            command.AddOption(workbookChartSeriesIdOption);
            var workbookChartPointIdOption = new Option<string>("--workbook-chart-point-id", description: "key: id of workbookChartPoint") {
            };
            workbookChartPointIdOption.IsRequired = true;
            command.AddOption(workbookChartPointIdOption);
            command.SetHandler(async (object[] parameters) => {
                var driveItemId = (string) parameters[0];
                var workbookWorksheetId = (string) parameters[1];
                var workbookChartId = (string) parameters[2];
                var workbookChartSeriesId = (string) parameters[3];
                var workbookChartPointId = (string) parameters[4];
                var cancellationToken = (CancellationToken) parameters[5];
                PathParameters.Clear();
                PathParameters.Add("driveItem_id", driveItemId);
                PathParameters.Add("workbookWorksheet_id", workbookWorksheetId);
                PathParameters.Add("workbookChart_id", workbookChartId);
                PathParameters.Add("workbookChartSeries_id", workbookChartSeriesId);
                PathParameters.Add("workbookChartPoint_id", workbookChartPointId);
                var requestInfo = CreatePostRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(driveItemIdOption, workbookWorksheetIdOption, workbookChartIdOption, workbookChartSeriesIdOption, workbookChartPointIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new ClearRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ClearRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/workbooks/{driveItem_id}/workbook/worksheets/{workbookWorksheet_id}/charts/{workbookChart_id}/series/{workbookChartSeries_id}/points/{workbookChartPoint_id}/format/fill/microsoft.graph.clear";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke action clear
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
    }
}
