using System;
using System.Collections.Generic;

namespace StarWarsFinal
{
    class Character
    {
        public string name;
        public string type;
        public int experience;
        public int strength;
        public int health;
        public int defense;
        public int lives;
        public int wallet;
        private Menu menu;

        public Dictionary<string, Equipment> equipment = new Dictionary<string, Equipment>();

        public Character(string name, string type, int experience, int strength, int health, int defense, int lives, int wallet)
        {
            this.name = name;
            this.type = type;
            this.experience = experience;
            this.strength = strength;
            this.health = health;
            this.defense = defense;
            this.lives = lives;
            this.wallet = wallet;
            string[] pozycjeMenu1 = { };
            this.menu = new Menu("Wybierz Jedną z poniższych opcji:", pozycjeMenu1);
        }

        public void ShowEq()
        {
            Console.WriteLine("[Backpack]");

            int i = 1;
            foreach (KeyValuePair<string, Equipment> kvp in equipment)
            {


                TextDisplay.Frame(TextDisplay.CenterText(("position num." + i + kvp.Value.description)));

                i++;
            }

        }

        public void AddToBackpack(Equipment item)
        {
            this.equipment.Add(item.name, item);
        }


        public string ChooseGun()


        {

            string score = "BRAK";
            int gunQuantity = 0;

            foreach (KeyValuePair<string, Equipment> kvp in equipment)
            {
                if (kvp.Value.type != "Defensive")
                {
                    gunQuantity++;

                }
            }
            if (gunQuantity > 0)
            {
                string[] nameToChoose = new string[gunQuantity];
                int index = 0;
                int i = 0;
                foreach (KeyValuePair<string, Equipment> kvp in equipment)
                {
                    if (kvp.Value.type != "Defensive")
                    {
                        string item = kvp.Value.name + " atak: " + kvp.Value.attribute + " stan: " + kvp.Value.condition;

                        nameToChoose[i] = kvp.Value.name;
                        i++;
                    }
                }

                foreach (string ff in nameToChoose)
                {
                    Console.WriteLine(ff);
                }

                menu.positions = nameToChoose;
                index = menu.StartInterface("Wybierz Broń do Walki");
                score = nameToChoose[index];
            }



            return score;
        }

        public int Attack(string gun)
        {

            int item = 0;
            if (CheckBackpack(gun))
            {
                item = this.equipment[gun].Attack();
            }
            int strike = this.strength + item;

            return strike;
        }

        public int Defense()
        {

            int armor = 0;
            foreach (KeyValuePair<string, Equipment> kvp in equipment)
            {
                if (kvp.Value.type == "Defensive")
                {
                    armor += kvp.Value.Defense();

                }


            }


            return this.defense + armor;
        }

        public bool CheckBackpack(string item)
        {
            bool x = false;
            foreach (KeyValuePair<string, Equipment> kvp in equipment)
            {
                if (item == kvp.Key)
                {
                    x = true;
                }


            }
            return x;
        }



    }

}
