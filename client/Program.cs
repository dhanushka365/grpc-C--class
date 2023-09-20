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
        const string target = "127.0.0.1:50051"; // the server address

        static async Task Main(string[] args)
        {
            Channel channel = new Channel(target, ChannelCredentials.Insecure); // create a channel

            await channel.ConnectAsync().ContinueWith((task) => // connect to the server
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

            var client = new GreetingService.GreetingServiceClient(channel); // create a client
            var greeting = new Greeting()
            {
                FirstName = "John",
                LastName = "Doe"
            }; // create a greeting

            var request = new LongGreetRequest() { Greeting = greeting }; // create a request
            var stream = client.LongGreet(); // create a response

            foreach (int i in Enumerable.Range(1, 10))
            {
                // Console.WriteLine("Sending stream");
                await stream.RequestStream.WriteAsync(request); // send the request
            }
            await stream.RequestStream.CompleteAsync();

            var response = await stream.ResponseAsync;
            Console.WriteLine(response.Result); // print the response

            await channel.ShutdownAsync(); // wait for the channel to shutdown
            Console.ReadKey(); // wait for the user to press a key
        }
    }
}
