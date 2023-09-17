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

        public override async Task GreetManyTimes(GreetManyTimesRequest request, IServerStreamWriter<GreetManyTimesResponse> responseStream, ServerCallContext context)
        {
            Console.WriteLine("The server received the request: " + request.ToString());
            string result = "Hello " + request.Greeting.FirstName + " " + request.Greeting.LastName;
            for (int i = 0; i < 10; i++)
            {
                GreetManyTimesResponse response = new GreetManyTimesResponse() { Result = result };
                await responseStream.WriteAsync(response);
            }
            //return base.GreetManyTimes(request, responseStream, context);
        }
    }
}
