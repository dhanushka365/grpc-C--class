using Greet;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{     class Program
    {
        const int Port = 50051;
        static void Main(string[] args)
        {
            Server server = null;
            try
            {
                server = new Server
                {
                    Services = {GreetingService.BindService(new GreetingServiceImpl())},
                    Ports = { new ServerPort("127.0.0.1", Port, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine("Server listening on port " + Port);
                Console.ReadKey();
            }
            catch(IOException e)
            { 
                Console.WriteLine("Server failed to start: " + e.Message);
                throw new Exception("Server failed to start", e);
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }
        }
    }
}
