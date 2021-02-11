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
            bool correctPath = false;

            string[] langFolders = null;

            Console.Write("Input your path to 3DW: ");

            while (!correctPath)
            {
                

                string gamePath = Console.ReadLine();
                try
                {
                    langFolders = Directory.GetDirectories(Path.Join(gamePath, "LocalizedData"));
                    correctPath = true;
                }
                catch
                {
                    Console.WriteLine("Invalid path!");
                    Console.Write("Input your path to 3DW: ");
                }
                
            }

            int i = 1;

            foreach (string folderName in langFolders)
            {
                if (!folderName.EndsWith("Common"))
                {
                    var sarc = Hack.io.YAZ0.YAZ0.DecompressToMemoryStream(Path.Join(folderName, "MessageData", "SystemMessage.szs")).ToArray();
                    var msbt = new MsbtEditor.MSBT(new MemoryStream(SZS.SARC.UnpackRamN(sarc).Files["StageName.msbt"]));
                    Console.WriteLine("Extracting " + i + "/" + (langFolders.Length - 1));
                    msbt.ExportToCSV(folderName + ".txt");
                    i++;
                }
                
            }
        }
    }
}
