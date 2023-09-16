# grpc-C#-class

|GRPC API Type              |                                Description                                                                                   |              Use case                |  
| ------------------------- | -----------------------------------------------------------------------------------------------------------------------------| ------------------------------------ |  
| Unary                     | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |                                      |  
| Server Streaming          | The client will send one message to the server and will receive many responses from the server, possibly and infinite number | \n - When Server need to send lot of data \n - when server need to push data to client without having the client request for more( live feed, chat etc.)| 
| Client Streaming          | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |                                      | 
| Bi-directional Streaming  | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |                                      |  
