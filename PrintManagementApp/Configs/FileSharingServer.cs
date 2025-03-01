using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class FileSharingServer
{
    private TcpListener _listener;

    public FileSharingServer(string ip, int port)
    {
        _listener = new TcpListener(IPAddress.Parse(ip), port);
    }

    public void Start()
    {
        _listener.Start();
        Console.WriteLine("File Sharing Server started...");

        while (true)
        {
            TcpClient client = _listener.AcceptTcpClient();
            Thread thread = new Thread(HandleClient);
            thread.Start(client);
        }
    }

    private void HandleClient(object obj)
    {
        TcpClient client = (TcpClient)obj;
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        if (request == "REQUEST_FILE")
        {
            // Send a file to the client
            SendFile(stream);
        }
        else
        {
            // Receive a file from the client
            ReceiveFile(stream, request);
        }

        stream.Close();
        client.Close();
    }

    private void SendFile(NetworkStream stream)
    {
        // Send a file to the client
        string filePath = "example.txt"; // Replace with the actual file path
        string fileName = Path.GetFileName(filePath);

        // Send the file name
        byte[] fileNameBytes = Encoding.UTF8.GetBytes(fileName);
        stream.Write(fileNameBytes, 0, fileNameBytes.Length);
        stream.WriteByte(0); // Null terminator

        // Send the file content
        using (FileStream fileStream = File.OpenRead(filePath))
        {
            fileStream.CopyTo(stream);
        }
    }

    private void ReceiveFile(NetworkStream stream, string fileName)
    {
        // Receive a file from the client
        using (FileStream fileStream = File.Create(fileName))
        {
            stream.CopyTo(fileStream);
        }
    }
}