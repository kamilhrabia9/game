using System;

namespace StarWarsFinal
{
    abstract class Gun
    {
        public string name { get; set; }
        public int price { get; set; }
        public string type { get; set; }
        public int condition { get; set; }


        public void ShowInfo(string txt_s1 = "", int txt_1 = 0, string txt_s2 = "", int txt_2 = 0)
        {
            Console.WriteLine("name: " + this.name);
            Console.WriteLine("price: " + this.price);
            Console.WriteLine("type: " + this.type);
            Console.WriteLine("condition: " + this.condition);
            Console.WriteLine(txt_s1 + ": " + txt_1);
            Console.WriteLine(txt_s2 + ": " + txt_2);

        }




    }
}
