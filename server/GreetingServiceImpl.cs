﻿using Greet;
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
    }
}
