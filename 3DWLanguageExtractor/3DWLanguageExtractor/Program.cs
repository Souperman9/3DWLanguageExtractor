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
                    var sarc = Hack.io.YAZ0.YAZ0.DecompressToMemoryStream(folderName + @"\MessageData\SystemMessage.szs").ToArray();
                    var msbt = new MsbtEditor.MSBT(new MemoryStream(SZS.SARC.UnpackRamN(sarc).Files["StageName.msbt"]));
                    Console.WriteLine(msbt.GetHashCode());
                    msbt.ExportToCSV(folderName + ".csv");
                    //File.WriteAllBytes(folderName + "StageName.msbt", sarcData.Files["StageName.msbt"]);
                }
                
            }
        }
    }
}
