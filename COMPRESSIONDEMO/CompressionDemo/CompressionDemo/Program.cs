using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Compression;
using System.IO;

namespace CompressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //set infile and outfile strings
            string infile = @"C:\localhost\FiletoCompress.txt";
            string outfile = @"C:\localhost\FiletoCompress.txt.gz";

            CompressFile(infile, outfile);

            //switching files for decompression
            string temp;
            temp = infile;
            infile = outfile;
            outfile = temp;

            Console.WriteLine("To decompress, we will set Infile to {0} and outfile to {1}", infile, outfile);

            DecompressFile(infile, outfile);


            
            
        }


        //2.3.1
        static void CompressFile(string inFilename, string outFilename)
        {
            // string filename = @"C:\localhost\FiletoCompress.txt";

            //Create in and out Streams
            FileStream sourceFile = File.OpenRead(inFilename);
            FileStream destFile = File.Create(outFilename);

            //Create Gzipstream - Should reference compressing the destination file
            GZipStream compStream = new GZipStream(destFile, CompressionMode.Compress);

            //Stream the data in the source file to the compression file one byte at a time
            int theByte = sourceFile.ReadByte();
            while(theByte != -1)
            {
                compStream.WriteByte((byte)theByte);
                theByte = sourceFile.ReadByte();
            }

            Console.WriteLine("The file {0} was compressed in file {1}", inFilename, outFilename);

            compStream.Close();
            sourceFile.Close();
            destFile.Close();

            //Remove the original file from the directory
            File.Delete(inFilename);
        }

        //2.3.2
        static void DecompressFile(string inFilename, string outFilename)
        {
            //Create in and out Streams (inFilename will be zipped file)
            FileStream sourceFile = File.OpenRead(inFilename);
            FileStream destFile = File.Create(outFilename);

            //Create Gzipstream - should reference Decompressing sourcefile
            GZipStream compStream = new GZipStream(sourceFile, CompressionMode.Decompress);

            //Stream data in compression file into destination file one byte at a time
            int theByte = compStream.ReadByte();
            while (theByte != -1)
            {
                destFile.WriteByte((byte)theByte);
                theByte = compStream.ReadByte();
            }

            Console.WriteLine("The file {1} was recreated from {0}", inFilename, outFilename);

            compStream.Close();
            sourceFile.Close();
            destFile.Close();

        }
    }
}
