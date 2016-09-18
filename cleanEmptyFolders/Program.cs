using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using SearchOption = System.IO.SearchOption;

namespace cleanEmptyFolders
{
    static class Program
    {
        static void Main(string[] args)
        {
            var allDirectories = Directory.GetDirectories(args[0], "*", SearchOption.AllDirectories);

            var toDelete = allDirectories.Where(IsEmpty).ToList();

            foreach (var folder in toDelete)
            {
                if (Directory.Exists(folder))
                {
                    FileSystem.DeleteDirectory(folder, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
            }
        }

        private static bool IsEmpty(string item)
        {
            var allFiles = Directory.GetFiles(item, "*", SearchOption.AllDirectories);

            return !allFiles.Any();
        }
    }
}
