using ApiSdk.DirectoryRoles.Item.Members.Item.Application;
using ApiSdk.DirectoryRoles.Item.Members.Item.Device;
using ApiSdk.DirectoryRoles.Item.Members.Item.Group;
using ApiSdk.DirectoryRoles.Item.Members.Item.OrgContact;
using ApiSdk.DirectoryRoles.Item.Members.Item.Ref;
using ApiSdk.DirectoryRoles.Item.Members.Item.ServicePrincipal;
using ApiSdk.DirectoryRoles.Item.Members.Item.User;
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
namespace ApiSdk.DirectoryRoles.Item.Members.Item {
    /// <summary>Builds and executes requests for operations under \directoryRoles\{directoryRole-id}\members\{directoryObject-id}</summary>
    public class DirectoryObjectItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildApplicationCommand() {
            var command = new Command("application");
            var builder = new ApplicationRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildDeviceCommand() {
            var command = new Command("device");
            var builder = new DeviceRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildGroupCommand() {
            var command = new Command("group");
            var builder = new GroupRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildOrgContactCommand() {
            var command = new Command("org-contact");
            var builder = new OrgContactRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildRefCommand() {
            var command = new Command("ref");
            var builder = new RefRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildDeleteCommand());
            return command;
        }
        public Command BuildServicePrincipalCommand() {
            var command = new Command("service-principal");
            var builder = new ServicePrincipalRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildUserCommand() {
            var command = new Command("user");
            var builder = new UserRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new DirectoryObjectItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public DirectoryObjectItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/directoryRoles/{directoryRole%2Did}/members/{directoryObject%2Did}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
    }
}
