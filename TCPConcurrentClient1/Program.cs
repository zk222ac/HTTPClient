using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPConcurrentClient1
{
    class Program
    {
        private static TcpClient _clientSocket;
        private static Stream _nstream;
        private static StreamWriter _streamWriter;
        private static StreamReader _streamReader;
        

        static void Main(string[] args)
        {
            try
            {
                // Server IP  - we use here always server IP address
                // Server port 
                // 127.0.0.1 -- client and server are on the same machine 

                _clientSocket = new TcpClient("127.0.0.1", 6789);
                using (_nstream = _clientSocket.GetStream())
                {
                    _streamWriter = new StreamWriter(_nstream) { AutoFlush = true };
                    _streamReader = new StreamReader(_nstream);
                    // Insert first Message here 
                    Console.WriteLine("Insert first Message here");

                    // Requesting for request
                    //var request = Console.ReadLine();
                    // Http request --> Http method ( GET , POST, PUT , DELETE)
                    // server resource --> www.gmail.com/temp/index.html
                    // server resource --> C:/temp/index.html

                    // Http version ---> HTTP 1.0 / Htttp 1.1
                    var request = Console.ReadLine();
                    while (request != null)
                    {
                        _streamWriter.WriteLine(request);
                        // request for responding
                        var respond = _streamReader.ReadLine();
                        Console.WriteLine("Server Msg:" + respond);
                        Console.WriteLine("...................................");
                        Console.WriteLine("kindly insert message again or either insert null for client stop");
                        request = Console.ReadLine();
                    }

                    Console.WriteLine("Client Stopped Now");
                    Console.ReadKey();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
           



        }
    }
}
