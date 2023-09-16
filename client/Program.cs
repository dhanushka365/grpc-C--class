using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        const string target = "127.0.0.1:50051";//the server address
        static void Main(string[] args)
        {
           Channel channel = new Channel(target, ChannelCredentials.Insecure);//create a channel

           channel.ConnectAsync().ContinueWith((task) =>//connect to the server
           {
               if (task.Status == TaskStatus.RanToCompletion)
               {
                   Console.WriteLine("The client connected successfully");
               }
               else
               {
                   Console.WriteLine("Failed to connect to the server");
               }
                   
           });

            var client = new Dummy.DummyService.DummyServiceClient(channel);//create a client

            channel.ShutdownAsync().Wait();//wait for the channel to shutdown
            Console.ReadKey();//wait for the user to press a key
        }
    }
}
