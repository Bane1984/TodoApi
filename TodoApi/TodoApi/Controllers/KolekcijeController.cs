using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolekcijeController : ControllerBase
    {

        /// <summary>
        /// Niz.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet("vratiNiz/{a}/{b}")]
        public (int[], int) Nizovi(int a, int b)
        {
            int[] c = new int[a];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = i + 1;
            }
            return (c, c[b - 1]);
        }
        /// <summary>
        /// ArrayList-a.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("ListeNizova/{a}")]
        public (ArrayList, string, string, ArrayList, string) ListeNizova(int a)
        {
            ArrayList bane = new ArrayList();
            bane.Add(1);
            bane.Add("bane");
            bane.Add("vujovic");
            bane.Add(true);
            string m = $"Duzina liste je {bane.Count}!";
            string n = $"Uklonicemo {a}-i element liste!";
            ArrayList d = new ArrayList(bane);  //Kopiranje jedne liste u drugu preko konstruktora
            d.RemoveAt(a - 1);
            string o = $"Da li unesena lista sadrzi element cija je vrijednost Ana: {bane.Contains("Ana")}, a bane: {bane.Contains("bane")}";
            return (bane, m, n, d, o);
        }
        /// <summary>
        /// Stekovi.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("stek/{a}")]
        public (Stack, string, string, Stack) Stek(int a)
        {
            Stack st = new Stack();
            st.Push(1);
            st.Push(2);
            st.Push("ana");
            st.Push("Sanja");

            string m = $"Broj elemenata u steku je: {st.Count}";
            string n = $"Da li u Steku postoji vrijednost Sanja: {st.Contains("Sanja")}";

            Stack bt = new Stack(st);

            if (a == 1)
            {
                bt.Pop();
            }

            return (st, m, n, bt);
        }

        /// <summary>
        /// Redovi.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Redovi")]
        public (Queue, string, string, Queue) Redovi()
        {
            Queue qt = new Queue();
            qt.Enqueue("bane");
            qt.Enqueue(true);
            qt.Enqueue(3);
            qt.Enqueue('B');


            string a = $"Broj elemenata u Redu je: {qt.Count}";
            string b = $"Da li u Steku postoji vrijednost B: {qt.Contains('B')}";

            Queue c = new Queue(qt);

            c.Dequeue();

            return (qt, a, b, c);

        }

        /// <summary>
        /// Hestabele.
        /// </summary>
        /// <returns></returns>
        [HttpGet("HesTabela/{a}/{b}")]
        public Hashtable HesTabela(int a, string b)
        {
            //Samo kreirana tabela i dodata mogucnost da korisnik sam unese neku vrijednost.
            Hashtable ht = new Hashtable();
            ht.Add(1, ".Net");
            ht.Add(2, "C#");
            ht.Add(3, "ASP.Net");
            ht.Add(a, b);

            return ht;


        }
    }
}