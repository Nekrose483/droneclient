/*



//implementation of sha1

byte[] data = new byte[DATA_SIZE];
byte[] result; 

SHA1 sha = new SHA1CryptoServiceProvider(); 
// This is one implementation of the abstract class SHA1.
result = sha.ComputeHash(data);


ENCRYPTION:

EncryptionTest('stuff', Encoding.UTF8.GetBytes('hypn0sh1t'));

void EncryptionTest(string text, byte[] key){
 byte[] plain = Encoding.UTF8.GetBytes(text);
 BaseCrypto enc = new SimpleEncryptor(key), dec = new SimpleDecryptor(key);
 byte[] cipher = enc.TransformFinalBlock(plain, 0, plain.Length);
 byte[] plain2 = dec.TransformFinalBlock(cipher, 0, cipher.Length);
 // plain and plain2 should now be byte-for-byte equal
}


XML

using System;

using System.Xml;

namespace ReadXml1

{

    class Class1

    {

        static void Main(string[] args)

        {

            // Create an isntance of XmlTextReader and call Read method to read the file

            XmlTextReader textReader = new XmlTextReader("C:\\books.xml");

            textReader.Read();

            // If the node has value

            while (textReader.Read())

            {

                // Move to fist element

                textReader.MoveToElement();

                Console.WriteLine("XmlTextReader Properties Test");

                Console.WriteLine("===================");

                // Read this element's properties and display them on console

                Console.WriteLine("Name:" + textReader.Name);

                Console.WriteLine("Base URI:" + textReader.BaseURI);

                Console.WriteLine("Local Name:" + textReader.LocalName);

                Console.WriteLine("Attribute Count:" + textReader.AttributeCount.ToString());

                Console.WriteLine("Depth:" + textReader.Depth.ToString());

                Console.WriteLine("Line Number:" + textReader.LineNumber.ToString());

                Console.WriteLine("Node Type:" + textReader.NodeType.ToString());

                Console.WriteLine("Attribute Count:" + textReader.Value.ToString());

            }

        }

    }

}


XML example and drop down chooser example:

http://www.codeproject.com/Articles/7718/Using-XML-in-C-in-the-simplest-way

CREATING XML DOCUMENTS

http://www.java2s.com/Code/CSharp/XML/ASimpleXMLExample.htm

*/
