using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;

namespace WorkingWithStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkWithText();
            WorkWithXml();
            WorkWithCompression(useBrotli: true);
        }

        static string[] callsigns = new string[]
        {
                "Husker", "Starbuck", "Apollo", "Boomer",
                "Bulldog", "Athena", "Helo", "Racetrack"
        };

        static void WorkWithText()
        {

            string textFile = Combine(CurrentDirectory, "streams.txt");

            StreamWriter text = File.CreateText(textFile);
            foreach ( string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close();
            WriteLine("{0} contains {1:N0} bytes.", arg0: textFile, arg1: new FileInfo(textFile).Length);
            WriteLine(File.ReadAllText(textFile));

        }

        static void WorkWithXml()
        {
            string xmlFile = Combine(CurrentDirectory, "streams.xml");

            FileStream xmlFileStream = null;
            XmlWriter xml = null;

            try
            {
                xmlFileStream = File.Create(xmlFile);
                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

                xml.WriteStartDocument();
                xml.WriteStartElement("callsigns");

                foreach (string item in callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                xml.WriteEndElement();

            }
            catch(Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Close();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }

                if (xmlFileStream != null)
                {
                    xmlFileStream.Close();
                    WriteLine("The file stream's unmanaged resource have been disposed.");
                }

                WriteLine("{0} contains {1:N0} bytes.",
                    arg0: xmlFile,
                    arg1: new FileInfo(xmlFile).Length);
                WriteLine(File.ReadAllText(xmlFile));
            }

        }

        static void WorkWithCompression(bool useBrotli = true)
        {
            string fileExt = useBrotli ? "brotli" : "gzip";
            string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");
            FileStream file = File.Create(filePath);

            Stream compressor;

            if (useBrotli) {

                compressor = new BrotliStream(file, CompressionMode.Compress);

            } else
            {
                compressor = new GZipStream(file, CompressionMode.Compress);
            }

            using (compressor)
            {
                using (XmlWriter xml = XmlWriter.Create(compressor))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("callsigns");
                    foreach (string item in callsigns)
                    {
                        xml.WriteElementString("callsign", item);
                    }
                }
            }

            WriteLine("{0} contains {1:N0} bytes.", filePath, new FileInfo(filePath).Length);
            WriteLine("The compressed contents:");
            WriteLine(File.ReadAllText(filePath));

            WriteLine("Reading the compressed XML file:");
            file = File.Open(filePath, FileMode.Open);

            Stream decompressor;

            if (useBrotli)
            {
                decompressor = new BrotliStream(file, CompressionMode.Decompress);
            } else
            {
                decompressor = new GZipStream(file, CompressionMode.Decompress);
            }

            using (decompressor)
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                        {
                            reader.Read();
                            WriteLine(reader.Value);
                        }
                    }
                }
            }
        }
    }
}
