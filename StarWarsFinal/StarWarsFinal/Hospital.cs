using System;
using static System.Console;

namespace StarWarsFinal
{
    class Hospital : Building
    {

        private int lvl;
        private int cost;

        public Hospital(string name, int lvl, int cost)
        {
            this.name = name;
            this.lvl = lvl;
            string[] menuPositions = { "LECZ", "WYJDZ" };
            string[] menuPositions1 = { };
            menu = new Menu("Wybierz Jedną z poniższych opcji:", menuPositions);
            this.cost = cost;

        }

        public new void Start(Character player)
        {
            Clear();

            Console.Write(Photos.hospital);
            System.Threading.Thread.Sleep(3000);


            string text = $"Jesteś w Szpitalu, koszt leczenia to {cost}$ za każde {lvl * 2.5}% HP";

            int choice = menu.StartInterface(text);


            switch (choice)
            {
                case 0:
                    Heal(player);
                    break;
                case 1:

                    break;


            }





        }
        private void Heal(Character player)
        {
            if (player.health < 1000)
            {
                if (player.wallet >= cost)
                {
                    player.health += (lvl * 25);
                    player.wallet -= cost;

                    if (player.health > 1000)
                    {
                        player.health = 1000;
                    }
                    Clear();
                    TextDisplay.Frame(TextDisplay.CenterText($"Zostałeś uleczony o {lvl * 2.5}% HP"));
                    System.Threading.Thread.Sleep(1000);

                }
                else
                {
                    Clear();
                    TextDisplay.Frame(TextDisplay.CenterText("Masz zbyt mało pieniędzy"));
                    System.Threading.Thread.Sleep(1000);
                }
            }
            else
            {
                Clear();
                TextDisplay.Frame(TextDisplay.CenterText("JESTEŚ ZDROWY !!!"));
                System.Threading.Thread.Sleep(1000);
            }
            Start(player);
        }

    }
}
