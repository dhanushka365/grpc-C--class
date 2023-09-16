# grpc-C#-class

|GRPC API Type              |                                Description                                                                                   |              Use case                |  
| ------------------------- | -----------------------------------------------------------------------------------------------------------------------------| ------------------------------------ |  
| Unary                     | The client sends one request to the server and receives a single response. |   Standard request-response communication.                                   |  
| Server Streaming          | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |  <br><ul><li> When Server need to send lot of data</li>  <br><li> when server need to push data to client without having the client request for more( live feed, chat etc.)</br></li></ul>| 
| Client Streaming          | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |                                      | 
| Bi-directional Streaming  | The client will send one message to the server and will receive many responses from the server, possibly and infinite number |                                      |  
