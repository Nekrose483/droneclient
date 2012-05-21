/*



//implementation of sha1

byte[] data = new byte[DATA_SIZE];
byte[] result; 

SHA1 sha = new SHA1CryptoServiceProvider(); 
// This is one implementation of the abstract class SHA1.
result = sha.ComputeHash(data);


ENCRYPTION:

public void EncryptionExamples() {
        // Client, Method 1: call the full constructor
        ClientInfo encrypted1 = new ClientInfo(socket1, null, myReadBytesHandler,
                ClientDirection.Both, true, EncryptionType.ServerKey);
        // Client, Method 2: delay receiving and set EncryptionType
        ClientInfo encrypted2 = new ClientInfo(socket2, false);
        encrypted2.EncryptionType = EncryptionType.ServerRSAClientKey;
        encrypted2.OnReadBytes = myReadBytesHandler;
        encrypted2.BeginReceive();
        // Server: set DefaultEncryptionType
        server = new Server(2345, new ClientConnect(ClientConnect));
        server.DefaultEncryptionType = EncryptionType.ServerRSAClientKey;
}

There are three encryption modes supported. The first, None, performs no encryption, and is the default. EncryptionType.ServerKey means that the server sends a symmetric key for the connection when the client first connects; because the key is sent unencrypted, this is not very secure, but it does mean that the communication is not in plain text. The most secure method is ServerRSAClientKey: the server will send an RSA public key upon connection, and the client will generate a symmetric key and encrypt it with the RSA key before sending it to the server. This means the key is never visible to a third party and the connection is quite secure; to access the message you would need to break the encryption algorithm.

If you choose to use encrypted sockets, very little is different in your application code. However, in your server, you should respond to the ClientReady event, not ClientConnect, in most cases. ClientReady is called when key exchange is complete and a client is ready to send and receive data; attempting to send data to a client before this event will result in an exception. Similarly, if you want to send data through an encrypted client socket, you should respond to the OnReady event or check the EncryptionReady property before sending data.


SIMPLE CLIENT:

using System.Net.Sockets;
using Hypnoflow.Net;

class TextClient{
  ClientInfo client;
  void Start(){
    Socket sock = Sockets.CreateTCPSocket("www.myserver.com", 2345);
    client = new ClientInfo(sock, false); // Don't start receiving yet
    client.OnRead += new ConnectionRead(ReadData);
    client.Delimiter = '\n';  // this is the default, shown for illustration
    client.BeginReceive();
  }

  void ReadData(ClientInfo ci, String text){ //var ci keeps track of what connection it is
    Console.WriteLine("Received text message: "+text);
  }
}












*/
