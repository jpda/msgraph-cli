using ApiSdk.Print.Shares.Item.AllowedUsers.Item.Ref;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApiSdk.Print.Shares.Item.AllowedUsers.Item {
    /// <summary>Builds and executes requests for operations under \print\shares\{printerShare-id}\allowedUsers\{user-id}</summary>
    public class UserItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildRefCommand() {
            var command = new Command("ref");
            var builder = new RefRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildDeleteCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new UserItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public UserItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/print/shares/{printerShare%2Did}/allowedUsers/{user%2Did}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
    }
}
