using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
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


                Student student = new Student() { Name = "BThang" };
                Clipboard.SetData(student.ToString(), student);
                if (Clipboard.ContainsData(student.ToString()))
                {
                    var studentTest = Clipboard.GetData(student.ToString()) as Student;
                    Console.WriteLine(studentTest.Name);
                }
                
            }

        }

        [Serializable]
        public class Student
        {
            private string name;
            public string Name { get; set; }
        }
    }
}
