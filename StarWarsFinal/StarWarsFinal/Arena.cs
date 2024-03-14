using System;
using System.Collections.Generic;

namespace StarWarsFinal

{
    class Arena
    {
        public string name;
        public Shop shop;
        public Hospital hospital;
        public int lvl;
        public List<Character> warriors = new List<Character>();

        Combat interactiveCombat;

        public static int charactersQuantity = 0;

        public Arena(string name, int lvl, Equipment first, Equipment second, Equipment third, Equipment fourth)
        {
            this.name = name;
            this.lvl = lvl;

            CreateCharacters();
            interactiveCombat = new Combat();
            string shopName = "Targ w " + name;
            this.shop = new Shop(shopName, first, second, third, fourth, name);
            string hospitalName = "Szpital w " + name;
            this.hospital = new Hospital(hospitalName, lvl, lvl * 15);
        }

        public void CreateCharacters()
        {

            int counter = 0;
            int numOfNew = 0;
            string line;
            string name;
            string type;
            string strength;
            string health;

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\kamil\source\repos\StarWarsFinal\StarWarsFinal\data\postacie.txt");
            while ((line = file.ReadLine()) != null && numOfNew < 5)
            {
                if (counter >= charactersQuantity)
                {
                    string[] subs = line.Split(",");
                    name = subs[0];
                    type = subs[1];
                    strength = subs[2];
                    health = subs[3];
                    warriors.Add(new Character(name, type, 1, int.Parse(strength), int.Parse(health), 1, 3, 600));
                    charactersQuantity++;
                    numOfNew++;
                }
                counter++;
            }
            file.Close();






        }




        public void wyswietl()
        {
            foreach (var i in warriors)
            {
                Console.WriteLine("Imie: " + i.name + ", Typ: " + i.type);
            }

        }
        public void Training(Character player, int cost)
        {

            interactiveCombat.DisplayTraining(player, cost, Photos.yoda);

        }
        public int Combat(Character player, string photo)

        {
            int charactersQuantity = 0;
            int score = 0;

            foreach (var character in warriors)
            {
                charactersQuantity++;
            }

            Console.WriteLine("ilość zawodników: " + charactersQuantity);

            if (charactersQuantity > 0)
            {

                int playerNumber = 0;
                bool playerTurn = true;
                string gun = player.ChooseGun();



                while (player.health > 0 && warriors[playerNumber].health > 0)
                {
                    Console.Clear();
                    if (playerTurn)
                    {
                        int damage = (int)(player.Attack(gun) * interactiveCombat.DisplayAttack(player, warriors[playerNumber], gun, photo) / 100);

                        if (damage > 0) warriors[playerNumber].health -= damage;

                    }
                    else
                    {
                        int obrona = warriors[playerNumber].Attack("BRAK");
                        int damage = interactiveCombat.DisplayDefense(player, warriors[playerNumber], obrona, photo);
                        if (damage > 0) player.health -= damage;


                    }
                    playerTurn = !playerTurn;

                }
                int defense1 = warriors[playerNumber].Attack("BRAK");
                interactiveCombat.DisplayDefense(player, warriors[playerNumber], defense1, photo);

                if (player.health <= 0) player.health = 0;
                if (warriors[playerNumber].health <= 0)
                {
                    player.wallet += 200;
                    player.experience += 1;
                    warriors.Remove(warriors[playerNumber]);
                    score = 1;

                }
            }
            else { Console.WriteLine("Brak przeciwników"); }

            return score;
        }




    }
}
