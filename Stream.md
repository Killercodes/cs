# Stream

In C#, a stream is an abstract data type that represents a sequence of bytes that can be read from or written to. C# provides several types of streams that can be used to read from or write to various sources, such as files, network connections, memory buffers, and so on. Here are the main types of streams in C#:

FileStream: This stream is used to read from or write to files on disk. It supports random access to the file and allows you to read or write a specified number of bytes at a time.

MemoryStream: This stream is used to read from or write to an in-memory buffer. It is useful for scenarios where you want to manipulate data in memory before writing it to a file or sending it over a network.

NetworkStream: This stream is used to read from or write to a network connection. It is used in conjunction with the TcpClient and TcpListener classes to communicate over a network.

BufferedStream: This stream is used to add buffering to another stream. It reads data from the underlying stream in larger blocks to improve performance, and can be used to speed up read and write operations for other types of streams.

CryptoStream: This stream is used to provide cryptographic transformations on another stream. It is used in conjunction with the System.Security.Cryptography classes to perform encryption and decryption operations.

GZipStream: This stream is used to compress or decompress data using the GZip algorithm. It is used to reduce the size of data before transmitting it over a network or writing it to disk.

DeflateStream: This stream is similar to the GZipStream, but it uses the Deflate algorithm instead of GZip.

These are some of the most common types of streams in C#. Each stream has its own properties and methods that can be used to manipulate data, and choosing the right type of stream for your application depends on the specific requirements of your scenario.

```c#
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        // FileStream example
        string filePath = @"C:\path\to\file.txt";
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        {
            byte[] buffer = new byte[1024];
            int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
            while (bytesRead > 0)
            {
                Console.Write(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                bytesRead = fileStream.Read(buffer, 0, buffer.Length);
            }
        }

        // MemoryStream example
        byte[] buffer2 = Encoding.UTF8.GetBytes("Hello, world!");
        using (MemoryStream memoryStream = new MemoryStream(buffer2))
        {
            byte[] readBuffer = new byte[1024];
            int bytesRead = memoryStream.Read(readBuffer, 0, readBuffer.Length);
            while (bytesRead > 0)
            {
                Console.Write(Encoding.UTF8.GetString(readBuffer, 0, bytesRead));
                bytesRead = memoryStream.Read(readBuffer, 0, readBuffer.Length);
            }
        }

        // NetworkStream example
        string serverName = "www.example.com";
        int port = 80;
        using (TcpClient tcpClient = new TcpClient(serverName, port))
        using (NetworkStream networkStream = tcpClient.GetStream())
        {
            byte[] buffer3 = Encoding.UTF8.GetBytes("GET / HTTP/1.1\r\nHost: www.example.com\r\n\r\n");
            networkStream.Write(buffer3, 0, buffer3.Length);
            byte[] readBuffer = new byte[1024];
            int bytesRead = networkStream.Read(readBuffer, 0, readBuffer.Length);
            while (bytesRead > 0)
            {
                Console.Write(Encoding.UTF8.GetString(readBuffer, 0, bytesRead));
                bytesRead = networkStream.Read(readBuffer, 0, readBuffer.Length);
            }
        }

        // BufferedStream example
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        using (BufferedStream bufferedStream = new BufferedStream(fileStream))
        {
            byte[] buffer4 = new byte[1024];
            int bytesRead = bufferedStream.Read(buffer4, 0, buffer4.Length);
            while (bytesRead > 0)
            {
                Console.Write(Encoding.UTF8.GetString(buffer4, 0, bytesRead));
                bytesRead = bufferedStream.Read(buffer4, 0, buffer4.Length);
            }
        }

        // CryptoStream example
        byte[] key = Encoding.UTF8.GetBytes("secretkey");
        byte[] iv = Encoding.UTF8.GetBytes("12345678");
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        using (Aes aes = Aes.Create())
        using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(key, iv), CryptoStreamMode.Read))
        {
            byte[] buffer5 = new byte[1024];
            int bytesRead = cryptoStream.Read(buffer5, 0, buffer5.Length);
            while (bytesRead > 0)
            {
                Console.Write(Encoding.UTF8.GetString(buffer5, 0, bytesRead));
                bytesRead = cryptoStream.Read(buffer5, 0, buffer5.Length);
            }
        }

        // GZipStream example
        byte[] buffer6 = Encoding.UTF8.GetBytes("Hello, world!");
        using (MemoryStream memoryStream = new MemoryStream())
        using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
        {
            gzipStream.Write(buffer6, 0, buffer6.Length);
            gzipStream.Flush();

            Console.WriteLine("Original size: " + buffer6.Length);
            Console.WriteLine("Compressed size: " + memoryStream.Length);
        }
}

               
               
```
