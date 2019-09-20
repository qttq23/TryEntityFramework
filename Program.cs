using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;


namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (TECHNETEntities db = new TECHNETEntities())
            {
                //---- below is used for database-first----
                //---- remove folder 'Migrations' to run following codes
                //---- folder 'Migrations' is generated when using Code-first paradism.
                //---- reference: https://www.c-sharpcorner.com/article/entity-framework-introduction-using-c-sharp-part-one/

                //// simple test
                //Articoli art = db
                //    .Articolis.Where((x) => x.CodArt == "ART001")
                //    .FirstOrDefault();


                //Console.WriteLine(art.DesArt);


                //// test joining two tables
                //var art = db.Articolis
                //.Join(db.Famiglies,
                //      articolo => articolo.CodFamiglia,
                //      famiglia => famiglia.CodFamiglia,
                //      (articolo, famiglia) => new { Articoli = articolo, Famiglie = famiglia })
                //.Where((x) => x.Articoli.CodArt == "ART005")
                //.FirstOrDefault();

                //Console.WriteLine(art.Articoli.DesArt + " - " + art.Famiglie.DesFamiglia);


                //// test after adding relation between two tables
                //Articoli art = db.Articolis.Where((x) => x.CodArt == "ART005").FirstOrDefault();

                //Console.WriteLine(art.DesArt + " - " + art.Famiglie.DesFamiglia);
            }


        }

        static void TryEntityFramework()
        {


        }

        static void TryClipboard()
        {
            if (Clipboard.ContainsText())
            {
                //var text = Clipboard.GetText();
                //Console.WriteLine(text);

                //text = "From Visual Studio 2019";
                //Clipboard.SetText(text);

                //var returnAudioStream = Clipboard.GetAudioStream();
                ////Clipboard.SetAudio(replacementAudioStream);
                //Console.WriteLine(returnAudioStream);

                //var image = Clipboard.GetImage();


                //Student student = new Student() { Name = "BThang" };
                //Clipboard.SetData(student.ToString(), student);
                //if (Clipboard.ContainsData(student.ToString()))
                //{
                //    var studentTest = Clipboard.GetData(student.ToString()) as Student;
                //    Console.WriteLine(studentTest.Name);
                //}



            }

        }

        static void ReadXml()
        {
            // filename
            string xmlFilename = AppDomain.CurrentDomain.BaseDirectory + "book.xml";
            // Create an isntance of XmlTextReader and call Read method to read the file  
            XmlTextReader textReader = new XmlTextReader(xmlFilename);

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
                Console.WriteLine("Value:" + textReader.Value.ToString());

                if (textReader.NodeType == XmlNodeType.Attribute)
                {
                    Console.WriteLine("-->This is attribute");
                }
            }
        }

        static void WriteXml_XmlTextWritter()
        {
            // filename 
            string filename = AppDomain.CurrentDomain.BaseDirectory + "Laptop.xml";


            // Create a new file in C:\\ dir  
            XmlTextWriter textWriter = new XmlTextWriter(filename, null);
            // Opens the document  
            textWriter.WriteStartDocument();
            // Write comments  
            textWriter.WriteComment("First Comment XmlTextWriter Sample Example");
            textWriter.WriteComment("myXmlFile.xml in root dir");
            // Write first element  
            textWriter.WriteStartElement("Student");
            //textWriter.WriteStartElement("r", "RECORD", "urn:record");
            // Write next element  
            textWriter.WriteStartElement("Name", "");
            textWriter.WriteString("Student");
            textWriter.WriteEndElement();
            // Write one more element  
            textWriter.WriteStartElement("Address", "");
            textWriter.WriteString("Colony");
            textWriter.WriteEndElement();
            // WriteChars  
            char[] ch = new char[3];
            ch[0] = 'a';
            ch[1] = 'r';
            ch[2] = 'c';
            textWriter.WriteStartElement("Char");
            textWriter.WriteChars(ch, 0, ch.Length);
            textWriter.WriteEndElement();


            // write users
            textWriter.WriteStartElement("users");

            textWriter.WriteStartElement("user");
            textWriter.WriteAttributeString("age", "42");
            textWriter.WriteString("John Doe");
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("user");
            textWriter.WriteAttributeString("age", "39");
            textWriter.WriteString("Jane Doe");

            
            // Ends the document.  
            textWriter.WriteEndDocument();
            // close writer  
            textWriter.Close();
        }

        static void WriteXml_XmlDocument()
        {
            string filename = AppDomain.CurrentDomain.BaseDirectory + "MacBook.xml";

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("users");
            xmlDoc.AppendChild(rootNode);

            XmlNode userNode = xmlDoc.CreateElement("user");
            XmlAttribute attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "42";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "John Doe";
            rootNode.AppendChild(userNode);

            userNode = xmlDoc.CreateElement("user");
            attribute = xmlDoc.CreateAttribute("age");
            attribute.Value = "39";
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "Jane Doe";
            rootNode.AppendChild(userNode);

            xmlDoc.Save(filename);
        }

        [Serializable]
        public class Student
        {
            private string name;
            public string Name { get; set; }
        }
    }
}
