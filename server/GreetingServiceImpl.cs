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

        public override async Task<LongGreetResponse> LongGreet (IAsyncStreamReader<LongGreetRequest> requestStream ,ServerCallContext serverCallContext)
        {
            string result = "";

            while(await requestStream.MoveNext())
            {
                result += string.Format("Hello {0} {1} {2} \n", requestStream.Current.Greeting.FirstName, requestStream.Current.Greeting.LastName ,Environment.NewLine);
            }
                return new LongGreetResponse() { Result = result };
        }
     
    }
}
