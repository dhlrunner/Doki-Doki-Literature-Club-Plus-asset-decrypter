using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddlcXordecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            byte key = 40;
            int buffersize = 2048;
            string filename = args[0];
            Console.WriteLine("Infile: {0}", filename);
            using(BinaryReader cy = new BinaryReader(File.OpenRead(filename)))
            {
                Console.WriteLine("Size: {0}", cy.BaseStream.Length);
                using (BinaryWriter decrypted = new BinaryWriter(File.Create(filename + ".decrypted")))
                {                   
                    while(cy.BaseStream.Position < cy.BaseStream.Length)
                    {
                        byte[] buffer = cy.ReadBytes(buffersize);
                        for(int i=0; i< buffer.Length; i++)
                        {
                            buffer[i] = (byte)(buffer[i] ^ key);
                        }
                        decrypted.Write(buffer);
                    }
                    Console.WriteLine("Decrypt Completed. out file: {0}.decrypted", filename);
                }
            }
           
        }
    }
}
