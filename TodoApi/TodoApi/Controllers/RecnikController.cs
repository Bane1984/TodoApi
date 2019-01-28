using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;

namespace TodoApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RecnikController : ControllerBase
    {
        public (string, int) parV;

        /// <summary>
        /// Vrace broj elemenata u recniku
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int BrojElementeURecnik()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("jedan", 1);
            dictionary.Add("dva", 2);
            dictionary.Add("tri", 3);
            dictionary.Add("cetiri", 4);
            return dictionary.Count;
        }

        /// <summary>
        /// Vrace kljuc za unesenu vrijednost vrijednosti.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        [HttpGet("VraceKljucVrijednosti/{name}")]
        public int VraceKljucVrijednosti(string name)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("dva", 1);
            dictionary.Add("pet", 2);
            dictionary.Add("sest", 3);
            if (dictionary.ContainsKey(name))
            {
                int value = dictionary[name];
                return value;
            }

            return 0;
        }
        /// <summary>
        /// Vrati vrijednosti za uneseni kljuc.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [HttpGet("VratiVrijednost/{value}")]
        public string VratiVrijednost(string value)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {"jedan", "dva"},
                {"tri", "cetiri"},
                {"pet", "sest"},
                {"sedam", "osam"}
            };
            string test;
            if (dict.TryGetValue(value, out test))
            {
                return test;
            }

            return "Za uneseni kljuc nema vrijednosti!";
        }

        /// <summary>
        /// Vrace se recnik.
        /// </summary>
        /// <returns></returns>
        [HttpGet("VratiRecnik")]
        public Dictionary<string, int> VratiRecnik()
        {
            Dictionary<string, int> bane = new Dictionary<string, int>()
            {
                {"turska kafa", -1},
                {"caj", 5},
                {"espreso", 2},
                {"kapucino", 1}
            };

            return bane;

        }

        /// <summary>
        /// Proba da vrati vrijednosti kljuceva i vrijednosti preko torkija
        /// </summary>
        /// <returns></returns>

        [HttpGet("VratiRecnikforeach")]
        public (List<string>, List<int>) VratiRecnikforeach()
        {
            Dictionary<string, int> bane = new Dictionary<string, int>()
            {
                {"turska kafa", -1},
                {"caj", 5},
                {"espreso", 2},
                {"kapucino", 1}
            };
            var keyList = new List<string>();
            var valueList = new List<int>();

            foreach (KeyValuePair<string, int> par in bane)
            {
                keyList.Add(par.Key);
                valueList.Add(par.Value);
            }

            return (keyList, valueList);

        }

        /// <summary>
        /// Vrtatiti vrijednosti kljuceva po redosledu dodjeljivanja.
        /// </summary>
        /// <returns></returns>
        [HttpGet("VrtatiKljuceve")]
        public List<string> VrtatiKljuceve()
        {
            Dictionary<string, int> bane = new Dictionary<string, int>()
            {
                {"jedan", 0},
                {"dva", 2},
                {"tri", 1},
                {"cetiri", 3}
            };

            var list = new List<string>();
            foreach (KeyValuePair<string, int> kljucevi in bane)
            {
                list.Add(kljucevi.Key);
            }

            return list;
        }

        /// <summary>
        /// Provjra postojanja kljuca u Recniku.
        /// </summary>
        /// <param name="a">a.</param>
        /// <returns></returns>
        [HttpGet("PostojiKljuc/{a}")]
        public string PostojiKljuc(int a)
        {
            Dictionary<int, string> jole = new Dictionary<int, string>()
            {
                {0, "plus"},
                {3, "tri"},
                {8, "osam"},
                {1, "jedan"}
            };

            if (jole.ContainsKey(a))
            {
                return $"Navedeni kljuc postoji u recniku.";
            }

            return "Navedeni kljuc ne postoji u recniku.";
        }

        /// <summary>
        /// Vratis recnik kada su mu zadati kljuc i vrijednost.
        /// </summary>
        /// <param name="kljuc">The kljuc.</param>
        /// <param name="vrijednost">The vrijednost.</param>
        /// <returns></returns>
        [HttpGet("VratiRecnikk")]
        public Dictionary<string, string> VratiRecnikk(string kljuc, string vrijednost)
        {
            //string[] a = new string[]
            //{
            //    kljuc,
            //    vrijednost
            //};

            //var b = a.ToDictionary(op => op, ob => ob);
            //foreach (var par in b)
            //{
            //    a[0] = par.Key;
            //    a[1] = par.Value;
            //}

            //return a;

            var a = new Dictionary<string, string>();
            a.Add(kljuc, vrijednost);

            return a;
        }


    }
}