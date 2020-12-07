using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Serialization;

namespace Blockchain_App
{
    class Program
    {
        public static RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey; // instanciate private key
        private RSAParameters _publicKey; // instanciate public key
        public Program()
        {
            _privateKey = csp.ExportParameters(true); // setting to true produces private key 
            _publicKey = csp.ExportParameters(false); // setting to false produces public key
        }
        // method to produce the public key
        public string PublicKeyString()
        { 
            // working with string function
            var sw = new StringWriter();
            // public key is produced as an XML file. to change it to a string 
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw, _publicKey);
            
            return sw.ToString(); // produce the public key
        }
        public string PrivateKeyString()
        {
            // working with string function
            var sw = new StringWriter();
            // public key is produced as an XML file. to change it to a string 
            var xs = new XmlSerializer(typeof(RSAParameters));
            xs.Serialize(sw,_privateKey);

            return sw.ToString(); // produce the public key
        }
        // now to encrypt the text
        public string Encrypt(string plain_text)
        {
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(_publicKey);
            var data = Encoding.Unicode.GetBytes(plain_text);
            var cypher = csp.Encrypt(data,false);
            return Convert.ToBase64String(cypher);
        }
        public string Decrypt(string cypherText)
        {
            var dataBytes = Convert.FromBase64String(cypherText);
            csp.ImportParameters(_privateKey);
            var plainText = csp.Decrypt(dataBytes,false);
            return Encoding.Unicode.GetString(plainText);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            string cypher = String.Empty;
            Console.WriteLine("Public Key is: \n " +p.PublicKeyString()+"\n " );
            Console.WriteLine("Private Key is \n" +p.PrivateKeyString() +"\n \n");
            Console.WriteLine("Enter Text to encrypt");
            var text = Console.ReadLine();
            if (text != String.Empty)
            {
                cypher = p.Encrypt(text);
                Console.WriteLine("Cypher text is \n" +cypher);
            }
            Console.WriteLine("Press enter to decrypt");
            Console.ReadKey();
            var plainText = p.Decrypt(cypher);
            Console.WriteLine("Decrypted Text \n");
            Console.WriteLine(plainText);
            Console.ReadKey();
        }
    }
}
