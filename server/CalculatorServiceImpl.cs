using Calculator;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Calculator.CalculatorService;

namespace server
{
    public class CalculatorServiceImpl :CalculatorServiceBase
    {
        public override Task<sumResponse> Sum(sumRequest request, ServerCallContext context)
        {
            int result = request.FirstNumber + request.SecondNumber;

            return Task.FromResult(new sumResponse() { SumResult = result });
        }

    }
}
