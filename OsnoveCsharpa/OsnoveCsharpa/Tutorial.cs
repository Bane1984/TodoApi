using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsnoveCsharpa
{
    public interface BaneInterface
    {
        void SetTutorial(int a, string b);
        string GetTutorial();
    }

    //abstract class Tutorial
    //{
    //    public virtual void Set()
    //    {

    //    }
    //    //public Tutorial()
    //    //{
    //    //    id = 0;
    //    //    nameT = "bane";
    //    //}

    //}

    class Bane : BaneInterface
    {
        protected int id;
        protected string nameT;

        

        public void SetTutorial(int a, string b)
        {
            id = a;
            nameT = b;
        }

        //public void SetTutorial(string b)
        //{
        //    nameT = b;
        //}
        public string GetTutorial()
        {
            return nameT;
        }

        //public void RenameTutorial(string newName)
        //{
        //    nameT = newName;
        //}
    


    //static void Main(string[] args)
    //    {
    //        //Tutorial p = new Tutorial();
    //        //p.SetTutorial(1, ".Net");
    //        //Console.WriteLine(p.GetTutorial());
    //        //Tutorial a = new Tutorial();
    //        //Console.WriteLine($"Kreiran objekat a sa difoltnom vrijednosti name: {a.GetTutorial()}");

    //        //p.SetTutorial("jole");
    //        //Console.WriteLine(p.GetTutorial());
    //        Bane b= new Bane();
    //        //b.RenameTutorial("ana");
    //        b.SetTutorial(1, ".Net");
    //        Console.WriteLine(b.GetTutorial());
    //        Console.ReadKey();
    //    }
    }
 }
