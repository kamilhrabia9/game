using System;
using static System.Console;

namespace StarWarsFinal
{
    class Combat
    {
        private Menu menu;
        public Combat()
        {

            OutputEncoding = System.Text.Encoding.Unicode;
            string[] menuPostions = { "TRENUJ", "WYJDZ" };


            menu = new Menu("Wybierz Jedną z poniższych opcji:", menuPostions);
        }

        public int Training(Character player1, string photo)
        {
            Clear();


            int points = 0;
            SetCursorPosition(0, 1);
            Write(photo);

            for (int i = 0; i < 10; i++)

            {
                Clear();
                SetCursorPosition(0, 1);
                Write(photo);
                points += StrikeBar(0, 28, player1.experience, 50);
                Clear();
                SetCursorPosition(0, 1);
                Write(photo);

                points += Defense(0, 23, 100);
            }
            int score = (int)(points / 20);

            Clear();
            SetCursorPosition(0, 2);
            TextDisplay.Frame(TextDisplay.CenterText($"Zdobyłeś {score}, które zostały dodane do towojej siły"));
            System.Threading.Thread.Sleep(3500);


            return score;
        }
        public void DisplayTraining(Character player, int cost, string photo)
        {

            int index = 0;
            index = menu.StartInterface($"Koszt treningu to: {cost}");
            switch (index)
            {
                case 0:
                    if (player.wallet >= cost)
                    {

                        player.wallet -= cost;
                        player.strength += Training(player, photo);


                    }
                    else
                    {
                        Clear();
                        TextDisplay.Frame(TextDisplay.CenterText("Masz zbyt mało pieniędzy"));
                        System.Threading.Thread.Sleep(1000);
                    }
                    break;
                case 1:
                    break;
            }



        }

        public int DisplayAttack(Character player1, Character player2, string gunName, string photo)
        {
            Clear();
            int life1 = (int)(player1.health * 0.02);
            int life2 = (int)(player2.health * 0.02);

            LifeBar(0, 0, life1, player1.name);
            LifeBar(59, 0, life2, player2.name);
            GunWindow(0, 24, gunName);

            SetCursorPosition(0, 2);
            Write(photo);

            return StrikeBar(0, 28, player1.experience, 50);
        }

        public int DisplayDefense(Character player1, Character player2, int strikePower, string photo)
        {
            Clear();
            int life1 = (int)(player1.health * 0.02);
            int life2 = (int)(player2.health * 0.02);

            LifeBar(0, 0, life1, player1.name);
            LifeBar(59, 0, life2, player2.name);


            SetCursorPosition(0, 2);
            Write(photo);

            return Defense(0, 23, strikePower);
        }

        public void GunWindow(int left, int up, string gunName)
        {


            CursorVisible = false;
            SetCursorPosition(left, up);


            TextDisplay.Frame($"Wybrana Broń: {gunName}");

        }

        public void LifeBar(int left, int up, int life, string name)
        {



            int x = 20;
            int y = life;
            string initDescription = "[ 0% ";
            string finalDescription = " 100% ]";
            int cursor = left + initDescription.Length;
            CursorVisible = false;
            SetCursorPosition(left, up);
            Write(TextDisplay.CenterTextTo(name, initDescription.Length + finalDescription.Length + x));
            SetCursorPosition(left, up + 1);
            Write(initDescription);
            SetCursorPosition(cursor + x, up + 1);
            Write(finalDescription);

            SetCursorPosition(cursor, up + 1);

            for (int i = 0; i < life; i++)
            {


                Write("█");

                cursor++;
            }


        }


        public int StrikeBar(int left, int up, int experience, int barWidth = 50)
        {
            int x = barWidth;
            int time = 1 + (int)(experience / 2);
            int strikePower = 0;
            string initDescription = "0% ";
            string finalDescription = " 100% -> Wciśnij przycisk aby uderzyć..";
            int cursor = left + initDescription.Length;


            CursorVisible = false;
            SetCursorPosition(left, up + 0);
            Write(initDescription);
            SetCursorPosition(cursor + x, up + 0);
            Write(finalDescription);


            bool start = true;
            while (start)
            {



                SetCursorPosition(cursor, up + 0);

                for (int i = 0; i < x; i++)
                {


                    Write("█");
                    System.Threading.Thread.Sleep(time);
                    cursor++;
                    strikePower++;

                    while (KeyAvailable)
                    {

                        start = false;
                        break;

                    }
                    if (!start)
                    {
                        break;
                    }

                }
                if (start)
                {
                    for (int i = 0; i < x; i++)
                    {
                        SetCursorPosition(cursor - 1, up + 0);
                        Write(" ");
                        System.Threading.Thread.Sleep(time);
                        cursor--;
                        strikePower--;
                        while (KeyAvailable)
                        {


                            start = false;
                            break;

                        }
                        if (!start)
                        {
                            break;
                        }

                    }
                }
            }


            return 100 * strikePower / x;
        }

        public int Defense(int left, int up, int strikePower)
        {
            int power = strikePower;
            int time = 10;
            int defensePoints = 0;

            string[] direction = { "Góra", "Lewo", "Prawo", "Dół" };
            Random random = new Random();
            int choice = random.Next(0, 4);
            Random random1 = new Random();
            int response = random1.Next(0, 2000);


            ConsoleKeyInfo button;


            System.Threading.Thread.Sleep(response);
            SetCursorPosition(left, up);
            if (direction[choice] == "Góra")
            {
                WriteLine(Photos.upArrow);
            }
            else if (direction[choice] == "Lewo")
            {
                WriteLine(Photos.leftArrow);
            }
            else if (direction[choice] == "Prawo")
            {
                WriteLine(Photos.rightArrow);
            }
            else if (direction[choice] == "Dół")
            {
                WriteLine(Photos.downArrow);
            }





            bool status = true;
            do
            {



                while (!KeyAvailable)
                {
                    defensePoints++;
                    System.Threading.Thread.Sleep(time);

                }



                button = ReadKey(true);

                switch (choice)
                {
                    case 0:
                        if (button.Key == ConsoleKey.UpArrow) status = false;
                        break;
                    case 1:
                        if (button.Key == ConsoleKey.LeftArrow) status = false;
                        break;
                    case 2:
                        if (button.Key == ConsoleKey.RightArrow) status = false;
                        break;
                    case 3:
                        if (button.Key == ConsoleKey.DownArrow) status = false;
                        break;
                    default:
                        WriteLine("default case");
                        break;
                }



            }
            while (status);
            if (defensePoints > power) defensePoints = power;


            return defensePoints;
        }








    }
}
