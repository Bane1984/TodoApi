using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IskaziController : ControllerBase
    {
        //Iskazi u C# programskom jeziku
        /// <summary>
        /// IF Iskaza.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("IfIskaz/{a}")]
        public string IfIskaz(int a)
        {
            if (a < 0)
            {
                return "Uneseni broj je negativan!";
            }
            else
                return "Uneseni broj je pozitivan!";
        }

        /// <summary>
        /// Case Iskaz.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet("CaseIskaz/{b}")]
        public string CaseIskaz(string b)
        {
            switch(b)
            {
                case "pon":
                    return "Unijeli ste skracenicu za ponedeljak!";
                    break;
                case "uto":
                    return "Unijeli ste skracenicu za utorak!";
                    break;
                case "sri":
                    return "Unijeli ste skracenicu za srijedu!";
                    break;
                case "cet":
                    return "Unijeli ste skracenicu za cetvrtak!";
                    break;
                case "pet":
                    return "Unijeli ste skracenicu za petak!";
                    break;
                case "sub":
                    return "Unijeli ste skracenicu za subotu!";
                    break;
                case "ned":
                    return "Unijeli ste skracenicu za nedelju!";
                    break;
                default:
                    return "Unijeli ste pogresnu skracenicu!";
                    break;
            }
        }
        /// <summary>
        /// For Iskaz.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpGet("ForIskaz/{c}")]
        public int[] ForIskaz(int c)
        {
            int[] d = new int[c];

            for (int i = 0; i < d.Length; i++)
            {
                d[i] = i+1;
            }
            return d;
        }

        /// <summary>
        /// While Iskaz.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpGet("WhileIskaz/{m}")]
        public string WhileIskaz(int m)
        {
            int br = 0;

            while (m > 0)
            {
                m = (m - (m % 10)) / 10;
                br++;
            }


            return $"Uneseni broj ima {br.ToString()} cifre.";
        }

    }
}