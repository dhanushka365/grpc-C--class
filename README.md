# grpc-C#-class

|GRPC API Type              |                                Description                                                                                   |              Use case                |  
| ------------------------- | -----------------------------------------------------------------------------------------------------------------------------| ------------------------------------ |  
| Unary                     | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |                                      |  
| Server Streaming          | The client will send one message to the server and will receive many responses from the server, possibly and infinite number | When Server need to send lot of data | 
| Client Streaming          | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |                                      | 
| Bi-directional Streaming  | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |                                      |  
