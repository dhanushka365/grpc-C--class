using Greet;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Greet.GreetingService;

namespace server
{
    public class GreetingServiceImpl :GreetingServiceBase
    {
        public override Task<GreetingResponse> Greet(GreetingRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GreetingResponse() { Result = "Hello " + request.Greeting.FirstName + " " + request.Greeting.LastName });
        }


        public override async Task GreetEveryone( IAsyncStreamReader<EveryoneGreetingRequest> requestStream, IServerStreamWriter<EveryoneGreetingResponse> responseStream,ServerCallContext context)
        {
            while (await requestStream.MoveNext())
            {
                var result = string.Format(
                    "Hello {0} {1} {2} \n",
                    requestStream.Current.Greeting.FirstName,
                    requestStream.Current.Greeting.LastName,
                    Environment.NewLine);

                Console.WriteLine("Received:" + result);

                await responseStream.WriteAsync(new EveryoneGreetingResponse() { Result = result });
            }
            // No need to throw an exception in this method; it's void.
        }

    }


}
