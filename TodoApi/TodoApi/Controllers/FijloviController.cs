using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace TodoApi.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("ExistFile/{fajl}")]
        public bool ExistFile(string fajl)
        {
            string path = @"C:\Users\Bild33\source\repos\TodoApi\" + fajl + ".txt";
            if (System.IO.File.Exists(path))
            {
                return true;
            }
            return false;
        }

        [HttpGet("ReadLine/{id}")]
        public List<string> ReadFile(string fajl)
        {
            string path = @"C:\Users\Bild33\source\repos\TodoApi\" + fajl + ".txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            List<string> s = new List<string>();

            return s;
        }

        [HttpGet("upisiUFajl/{fajl}/{upis}")]
        public bool UpisiUFajl(string fajl, string upis)
        {
            string path = @"C:\Users\Bild33\source\repos\TodoApi\" + fajl + ".txt";
            StreamWriter sr = System.IO.File.AppendText(path);
            sr.WriteLine(upis);
            sr.Close();

            return true;
        }

        [HttpPut("kopirajFajl/{fajl}/{fajl2}")]
        public bool KopirajFajl(string fajl, string fajl2)
        {
            string path = @"C:\Users\Bild33\source\repos\TodoApi\" + fajl + ".txt";
            string copyPath = @"C:\Users\Bild33\source\repos\TodoApi\Copy" + fajl2 + ".txt";

            System.IO.File.Copy(path, copyPath);
            return true;
        }

        [HttpDelete("izbrisiFajl/{fajl}")]
        public bool Delete(string example)
        {
            string path = @"C:\Users\bild33\Desktop\" + example + ".txt";
            System.IO.File.Delete(path);
            return true;
        }
    }
}

