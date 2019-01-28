using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Fajlovi
    {
        static string path = @"C:\Users\Bild33\source\repos\TodoApi\example.txt";
        string[] lines = File.ReadAllLines(path);
        string allLines = File.ReadAllText(path);
        string copyPath = @"C:\Users\Bild33\source\repos\TodoApi\Copy\example.txt";
    }
}
