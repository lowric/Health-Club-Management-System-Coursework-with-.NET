using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using EricDISLibrary;

namespace EricDISConsoleServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Define the channel within which client will communicate with the server.
            // Also define the port number (i.e 12000 in this case) for the communication.
            TcpChannel channel = new TcpChannel(12000);

            // Register the channel with the .NET Remoting runtime service
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                                typeof(EricRemoteStaff),
                                "EricRemotePrincipalService",
                                WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(
                                 typeof(EricRemoteLogin),
                                 "EricRemoteLoginService",
                                 WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(
                                 typeof(EricRemoteNationalManager),
                                 "EricRemoteNationalManagerService",
                                 WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(
                                 typeof(EricRemoteLocalManager),
                                 "EricRemoteLocalManagerService",
                                 WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(
                                typeof(EricRemoteAdministrator),
                                "EricRemoteAdministratorService",
                                WellKnownObjectMode.Singleton);
            /*RemotingConfiguration.RegisterWellKnownServiceType(
                                typeof(EricRemoteStaff),
                                "EricremoteHeadOfDepartmentService",
                                WellKnownObjectMode.Singleton);*/
            Console.WriteLine("Eric sever has started");
            Console.WriteLine("Listening for Clients requests...");
            Console.WriteLine("Press Enter Key to exit Server.");
            Console.ReadLine();
        }
    }
}
