using System;
using System.IO;
using Hack.io;

namespace _3DWLanguageExtractor
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Enable Shift-JIS encoding
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            System.Text.Encoding.GetEncoding("Shift-JIS");
            
            // Get 3DW path
            Console.Write("Input your path to 3DW: ");

            string gamePath = Console.ReadLine();
            var langFolders = Directory.GetDirectories((gamePath) + @"\LocalizedData");
            
            foreach (string folderName in langFolders)
            {
                if (!folderName.EndsWith("Common"))
                {
                    var systemMessage = Hack.io.YAZ0.YAZ0.DecompressToMemoryStream(folderName + @"\MessageData\SystemMessage.szs");
                    //FileStream file = new FileStream(folderName + ".szs", FileMode.Create, FileAccess.Write);
                    //systemMessage.WriteTo(file);
                }
                
            }
        }
    }
}
