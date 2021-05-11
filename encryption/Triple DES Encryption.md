# Triple DES Encryption

C# Tutorial - Triple DES Encryption
The Data Encryption Standard (DES) has been around since the 70's, enjoyed wide-spread adoption, and has since been retired due to its small key length and ease of brute-force attacks. Triple DES, which is basically the same approach times three, aimed to remove the practicality of attacks while keeping the same basic algorithm. Although it's slowly being replaced by AES, triple DES is still a viable approach for your basic encryption needs.
.NET provides everything we'll need in the form of the TripleDESCryptoServiceProvider Class. In this tutorial, we're going to use this object to encrypt and decrypt the contents of a file.
#	Create Key
Triple DES is a symmetric-key algorithm, which means we only need one private key to both encrypt and decrypt. This reduces the complexity of using this algorithm and makes it perfect for simple file encryption. Keys are supposed to be as random as possible, and I would highly recommend using the helper functions provided by .NET to create them. Besides the key, the algorithm also needs an initialization vector, which we can also generate using .NET.
```cs
using System.Security.Cryptography;

...

var crypto = new TripleDESCryptoServiceProvider();
crypto.GenerateKey();
crypto.GenerateIV();

Debug.WriteLine(string.Join(",", crypto.Key));
Debug.WriteLine(string.Join(",", crypto.IV));

// Key:
// 144,24,138,199,76,214,156,202,
// 215,2,80,234,152,204,95,48,
// 245, 68,36,8,104,231,212,199

// IV:
// 107,78,8,71,32,44,210,59
```
You only need to run this code once to generate the keys. Once you've got them, keep them safe and make sure you don't put them where someone whose not supposed to read your encrypted data can see them. Now it's time to use these to actually do some encrypting.
#	Encrypt a File
The first thing we need to do is put the key and initialization vector in our code somewhere.
```cs
namespace Killercodes.TripleDESTutorial
{
   class Program
   {
      /// <summary>
      /// Encryption key.
      /// </summary>
      private static readonly byte[] KEY = new byte[]
      {
         144,24,138,199,76,214,156,202,
         215,2,80,234,152,204,95,48,
         245,68,36,8,104,231,212,199
      };

      /// <summary>
      /// Encryption initialization vector.
      /// </summary>
      private static readonly byte[] IV = new byte[]
      {
         107,78,8,71,32,44,210,59
      };

      static void Main(string[] args)
      {

      }
   }
}
```
Since this is a simple command line application, let's add some basic argument handling to our main function.
```cs
static void Main(string[] args)
{
   try
   {
      if (args.Length != 2)
         throw new Exception("Input file and output file are required arguments.");

      // The file to be encrypted.
      var inputFile = args[0];

      // The file to that holds the encrypted version.
      var outputFile = args[1];

      // Encrypt the file.
      EncryptFile(inputFile, outputFile);

      // Decrypt the file and print its contents.
      Console.WriteLine(DecryptFile(outputFile));
   }
   catch (Exception ex)
   {
      Console.WriteLine(ex.Message);
   }
   finally
   {
      Console.WriteLine("Press [enter] to exit.");
      Console.ReadLine();
   }
}
```
As you may have noticed, this function references two other functions, EncryptFile and DecryptFile, that we haven't written yet. Let's start with EncryptFile.
```cs
/// <summary>
/// Encrypts a file and saves the output to a new file.
/// </summary>
/// <param name="inputFile">The file to encrypt.</param>
/// <param name="outputFile">File to save encrypted version.</param>
private static void EncryptFile(string inputFile, string outputFile)
{
   // Create encryption provider.
   var crypto = new TripleDESCryptoServiceProvider()
   {
      Key = KEY,
      IV = IV
   };

   // Get filestream for input file.
   using (var inputStream = 
      new FileStream(inputFile, FileMode.Open, FileAccess.Read))
   {
      // Get filestream for output file.
      using (var outputStream = 
         new FileStream(outputFile, FileMode.Create, FileAccess.Write))
      {
         // Create an encryption stream.
         using(var cryptoStream = 
            new CryptoStream(outputStream, 
               crypto.CreateEncryptor(), CryptoStreamMode.Write))
         {
            // Copy the input file stream to the encryption stream.
            inputStream.CopyTo(cryptoStream);
         }
      }
   }
}
```

This is a bit hard to read because of the many nested using statements, but since all of these streams implement IDisposable, they're needed to make our code exception safe. The first two streams, inputStream and outputStream, are pretty self explanatory - they're just streams accessing the file to encrypt and the file we'll be saving our encrypted version to.
The magic happens inside the CryptoStream Class. This stream wraps another stream, in this case the output stream, and encrypts everything written to it before passing the data through. Since we want to encrypt our entire file, I simply copy our input file stream to the CryptoStream and we're done.
The test file I used was pretty basic.
```
// Before encryption:
This is an example file.

// After encryption:
á¦íÐÅÅÔÝ ðºÊ±ÖÄ”µ7}ä¬-—yA&(¶8 
```

#	Decrypt a File
Now that our file is encrypted, we need to be able to decrypt it. We'll do this in another function named DecryptFile.
```cs
/// <summary>
/// Decrypts the specified file and returns the contents.
/// </summary>
/// <param name="inputFile">The file to decrypt.</param>
/// <returns>Contents of the file.</returns>
private static string DecryptFile(string inputFile)
{
   // Create encryption provider.
   var crypto = new TripleDESCryptoServiceProvider()
   {
      Key = KEY,
      IV = IV
   };

   // Get filestream for input file.
   using (var inputStream =
      new FileStream(inputFile, FileMode.Open, FileAccess.Read))
   {
      // Create an encryption stream.
      using (var cryptoStream =
         new CryptoStream(inputStream,
            crypto.CreateDecryptor(), CryptoStreamMode.Read))
      {
         using (var reader = new StreamReader(cryptoStream))
         {
            return reader.ReadToEnd();
         }
      }
   }
}
```
You'll notice this is very similar to encrypting the file with a few minor changes. The first being that instead of calling CreateEncryptor, we're now calling CreateDecryptor. The other is that we're passing CryptoStreamMode.Read instead of CryptoStreamMode.Write. Both of these should be pretty obvious changes.
Just like when encrypting, we're using the CryptoStream to do all of the work. Now when the stream is read it will be decrypted before being passed through. We simply wrap the stream in a StreamReader and read it out as text.
When we run this command line program now, we see something like this:
```
This is an example file.
Press [enter] to exit.
```

