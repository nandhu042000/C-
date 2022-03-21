using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SakNan
{
    public class IceCream {
        public int SNo { get; set; }
        public string name { get; set; }
        public int amt { get; set; }
        public List<string> ingredients { get; set; }
        public List<string> a = new List<string>();
        public IceCream(int sno = 1, string name = "Nan", int amt = 20, List<string> ing = null){
            this.name = name;
            this.SNo = sno;
            this.amt = amt;
            this.ingredients = ing ?? new List<string>() { 
                "vannila"
            };
        }
    }
    public class IceCreamDivision{
        private List<IceCream> icecreams;
        public IceCreamDivision() {
            icecreams = new List<IceCream>();
        }
        public bool addIceCream(IceCream a) {
            foreach(IceCream i in this.icecreams)
            {
                if (i.SNo == a.SNo)
                    return false;
            }
            this.icecreams.Add(a);
            return true;
        }
        public List<string> contains(string ing) {
            List<string> cont = new List<string>();
            foreach (IceCream i in this.icecreams) { 
                if(i.ingredients.FindIndex(x => x.Equals(ing)) != -1)
                {
                    Console.WriteLine(i.ingredients.FindIndex(x => x.Equals(ing)));
                    cont.Add(i.name);
                }
            }
            return cont;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> ingredients = new List<string>();
            IceCreamDivision icd = new IceCreamDivision();
            Console.WriteLine("Enter no. of IceCream:");
            int n=Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++) {
                ingredients.Clear();
                Console.WriteLine("Enter the sno:");
                int sno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the amount:");
                int amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter no of ingredients:");
                int ingredientsCount = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < ingredientsCount; j++) {
                    string a = Console.ReadLine();
                    ingredients.Add(a);
                }
                if(!icd.addIceCream(new IceCream(sno,name,amount,ingredients)))
                {
                    Console.WriteLine("Not inserted");
                }
            }
            Console.WriteLine("Enter the ingredient to check:");
            string ing = Console.ReadLine();
            List<string> names = icd.contains(ing);
            Console.WriteLine("The icecreams are");
            foreach(string name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
