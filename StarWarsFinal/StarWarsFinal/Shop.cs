using System;
using System.Collections.Generic;
using static System.Console;

namespace StarWarsFinal
{
    class Shop : Building
    {

        private string planetName;
        private Menu menuBuy;
        private string[] items = new string[5];
        private string[] nameToBuy = new string[4];





        Dictionary<string, Equipment> equipment = new Dictionary<string, Equipment>();
        public Shop(string name, Equipment first, Equipment second, Equipment third, Equipment fourth, string planetName)
        {


            this.planetName = planetName;
            this.name = name;
            equipment.Add(first.name, first);
            equipment.Add(second.name, second);
            equipment.Add(third.name, third);
            equipment.Add(fourth.name, fourth);
            string[] menuPositions = { "KUP", "SPRZEDAJ", "NAPRAW", "WYJDZ" };
            string[] menuPositions1 = { };

            menu = new Menu("Wybierz Jedną z poniższych opcji:", menuPositions);
            menuBuy = new Menu("Wybierz Jedną z poniższych opcji:", menuPositions1);





        }



        public new void Start(Character player)
        {
            Clear();


            string text = "Witamy na kosmicznym targu na planecie " + planetName;

            int choice = menu.StartInterface(text);


            switch (choice)
            {
                case 0:
                    Buy(player);
                    break;
                case 1:
                    Sell(player);
                    break;
                case 2:
                    Fix(player);
                    break;
                case 3:

                    break;

            }




        }

        public void Fix(Character player)
        {
            string item;
            string[] menuPositions = { "TAK", "NIE" };

            Clear();



            item = DisplaySales(player);

            int indexFix = 0;


            if (item != "WYJDZ")

            {
                double value = ((double)player.equipment[item].condition * ((double)(player.equipment[item].price) * 0.01));
                int price = (int)((double)(player.equipment[item].price - value) * 0.8);
                if (player.equipment[item].condition < 100)
                {

                    if (player.wallet > price)
                    {
                        menuBuy.positions = menuPositions;
                        indexFix = menuBuy.StartInterface($"Koszt naprawy {player.equipment[item].name} wynosi {price}$");
                        switch (indexFix)
                        {
                            case 0:
                                player.equipment[item].condition = 100;
                                break;
                            case 1:

                                break;

                        }
                    }
                    else
                    {
                        Clear();
                        TextDisplay.Frame(TextDisplay.CenterText("MASZ ZBYT MAŁO PIENIĘDZY"));
                        System.Threading.Thread.Sleep(1000);
                    }
                }
                else
                {
                    Clear();
                    TextDisplay.Frame(TextDisplay.CenterText("PRZEDMIOT NIE PODLEGA NAPRAWIE"));
                    System.Threading.Thread.Sleep(1000);
                }


                Console.WriteLine("\n...TRANSAKCJA...ZAKOŃCZONA...");

            }

            Start(player);
        }

        public void Sell(Character player)
        {
            string item;
            string[] menuPositions = { "TAK", "NIE" };
            int indexSales = 0;

            Clear();



            item = DisplaySales(player);




            if (item != "WYJDZ")
            {
                double value = ((double)player.equipment[item].condition * 0.01);
                int price = (int)((double)(player.equipment[item].price * value) * 0.8);

                menuBuy.positions = menuPositions;
                indexSales = menuBuy.StartInterface($"Sprzedając {player.equipment[item].name} otrzymasz {price}$");
                switch (indexSales)
                {
                    case 0:
                        player.equipment.Remove(item);
                        player.wallet += price;
                        Console.WriteLine("\n...TRANSAKCJA...ZAKOŃCZONA...");
                        break;
                    case 1:

                        break;

                }



            }

            Start(player);


        }
        public void Buy(Character player)
        {
            string s;
            int index = 0;
            Console.WriteLine("Oto nasz asortyment: \n");

            index = this.Display();

            if (index < 4)
            {
                s = nameToBuy[index];

                if (this.CheckAvStore(s))
                {
                    if (player.equipment.Count < 5)
                    {
                        if (CheckIfYouAlreadyHave(s, player))
                        {
                            if (this.Check(player, s))
                            {
                                player.wallet -= equipment[s].price;
                                player.equipment.Add(s, equipment[s]);
                                Clear();
                                TextDisplay.Frame(TextDisplay.CenterText("Brawo kupiłeś " + equipment[s].name.ToUpper() + " !!!"));
                                System.Threading.Thread.Sleep(1000);

                            }
                        }
                    }
                    else
                    {
                        Clear();
                        TextDisplay.Frame(TextDisplay.CenterText("NIE MASZ MIEJSCA W PLECAKU"));
                        System.Threading.Thread.Sleep(1000);
                    }


                }

            }





            Start(player);
        }


        public int Display()
        {
            int indexBuy = 0;
            string item = "";
            int i = 1;
            foreach (KeyValuePair<string, Equipment> kvp in equipment)
            {
                item = kvp.Value.name + " cena: " + kvp.Value.price + " atak: " + kvp.Value.attribute + " stan: " + kvp.Value.condition;



                items[i - 1] = item.ToUpper();
                nameToBuy[i - 1] = kvp.Value.name;
                i++;
            }
            items[4] = "WYJDŹ";


            menuBuy.positions = items;
            indexBuy = menuBuy.StartInterface("Witaj w dziale sprzedaży");

            return indexBuy;



        }
        public string DisplaySales(Character player)

        {

            string[] nameSale = new string[player.equipment.Count + 1];
            string[] itemsSale = new string[player.equipment.Count + 1];
            int index = 0;
            int i = 0;
            foreach (KeyValuePair<string, Equipment> kvp in player.equipment)
            {

                string przedmiot = kvp.Value.name + " cena: " + kvp.Value.price + " atak: " + kvp.Value.attribute + " stan: " + kvp.Value.condition;
                itemsSale[i] = przedmiot;
                nameSale[i] = kvp.Value.name;
                i++;
            }
            itemsSale[i] = "WYJDŹ";
            nameSale[i] = "WYJDZ";
            menuBuy.positions = itemsSale;
            index = menuBuy.StartInterface("TU MOŻESZ SPRZEDAĆ SWOJĄ BROŃ");


            return nameSale[index];
        }




        public bool Check(Character player, string gun)
        {
            bool x = false;

            if (player.wallet >= equipment[gun].price)
            {
                x = true;
            }
            else
            {
                Clear();
                TextDisplay.Frame(TextDisplay.CenterText("Masz za mało pieniędzy!"));
                System.Threading.Thread.Sleep(1000);

            }
            return x;


        }

        public bool CheckAvStore(string item) // sprawdz dostepnosc
        {
            bool x = false;
            foreach (KeyValuePair<string, Equipment> kvp in equipment)
            {
                if (item == kvp.Key)
                {
                    x = true;
                }


            }
            if (x == false)
            {

                Console.WriteLine("Nie mamy takiego przedmiotu");
            }
            return x;

        }


        public bool CheckAvBackpack(string item, Character player)
        {
            bool x = false;
            foreach (KeyValuePair<string, Equipment> kvp in player.equipment)
            {
                if (item == kvp.Key)
                {
                    x = true;
                }


            }
            if (x == false)
            {
                Console.WriteLine("Nie masz tego w plecaku");
            }
            return x;






        }

        public bool CheckIfYouAlreadyHave(string item, Character player)
        {
            bool x = true;
            foreach (KeyValuePair<string, Equipment> kvp in player.equipment)
            {
                if (item == kvp.Key)
                {
                    x = false;
                }


            }
            if (x == false)
            {
                Clear();
                TextDisplay.Frame(TextDisplay.CenterText("Masz już ten przedmiot!"));
                System.Threading.Thread.Sleep(1000);
            }
            return x;






        }


    }
}
