using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using RomoteLibrary;

namespace RemoteMain
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel hc = new HttpChannel(86);


            ChannelServices.RegisterChannel(hc);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteServices), "OurRemoteServices",
                WellKnownObjectMode.Singleton);
            Console.WriteLine("Server Services started at Port No. 86.......");
            Console.WriteLine("Press any key to stop the server");
            Console.Read();
        }
    }
}
