using Greet;
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
        static async Task Main(string[] args)
        {
           Channel channel = new Channel(target, ChannelCredentials.Insecure);//create a channel

           await channel.ConnectAsync().ContinueWith((task) =>//connect to the server
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

            //var client = new Dummy.DummyService.DummyServiceClient(channel);//create a client
            //var client = new GreetingService.GreetingServiceClient(channel);//create a client
            //-------------------------------------------------------------------------------------------------------------------------------------
            var client = new GreetingService.GreetingServiceClient(channel);//create a client
            var greeting = new Greeting() 
            { 
                FirstName = "John",
                LastName = "Doe" 
            };//create a greeting

            var request = new GreetManyTimesRequest() { Greeting = greeting };//create a request
            var response = client.GreetManyTimes(request);//create a response
            while(await response.ResponseStream.MoveNext())//while there are responses
            {
                Console.WriteLine(response.ResponseStream.Current.Result);//print the response
                await Task.Delay(200);//wait for a second
            }
            //var response = client.Greet(new GreetingRequest() { Greeting = new Greeting() { FirstName = "John", LastName = "Doe" } });//send a request to the server
            //Console.WriteLine(response.Result);//print the response
            channel.ShutdownAsync().Wait();//wait for the channel to shutdown
            Console.ReadKey();//wait for the user to press a key
        }
    }
}
