using System;
using static System.Console;

namespace StarWarsFinal
{
    class Scenario
    {
        private IScenarioState currentState;
        public bool Game { get; set; }
        public Plot Plot { get; }
        // public Menu Menu { get; }
        public Character Player { get; }
        public Arena Planet1 { get; }
        public Arena Planet2 { get; }
        public int currentLevel = 0;
        public int chapter = 0;
        public bool run;

        public static int screenWidth = 35;

        public Scenario(Plot plot, Character player, Arena planet1, Arena planet2, int chapter)
        {
            currentState = new Level1State();
            Game = true;
            Plot = plot;

            Player = player;
            Planet1 = planet1;
            Planet2 = planet2;
            this.chapter = chapter;
            run = true;
        }


        public void TransitionToState(IScenarioState newState)
        {
            currentState = newState;
        }

        public void ExecuteState()
        {
            currentState.Execute(this);
        }
        public int MainScreen(Menu menu, Plot plot, string fileName, string picture)
        {
            ConsoleKey pressedButton;

            do
            {
                Clear();
                SetCursorPosition(0, 0);
                TextDisplay.UpperBeam(Player);
                SetCursorPosition(0, 25);
                TextDisplay.DownBeam();
                SetCursorPosition(0, 4);
                plot.Display(fileName, picture);

                menu.ShowMenu();
                ConsoleKeyInfo przyciskInfo = ReadKey(true);
                pressedButton = przyciskInfo.Key;
                if (pressedButton == ConsoleKey.UpArrow)
                {
                    menu.index--;
                    if (menu.index == -1)
                    {
                        menu.index = menu.positions.Length - 1;
                    }
                }
                else if (pressedButton == ConsoleKey.DownArrow)
                {
                    menu.index++;
                    if (menu.index == menu.positions.Length)
                    {
                        menu.index = 0;
                    }
                }
                else if (pressedButton == ConsoleKey.W)
                {
                    menu.index = 98;
                }

                else if (pressedButton == ConsoleKey.E)
                {
                    menu.index = 99;
                }
                ResetColor();
            }
            while (pressedButton != ConsoleKey.Enter && pressedButton != ConsoleKey.W && pressedButton != ConsoleKey.E);

            return menu.index;
        }

        public bool GameMenu(int indexGry, Arena planet, string zdj)

        {
            bool stay = true;

            switch (indexGry)
            {
                case 0:
                    planet.Combat(Player, zdj);
                    stay = false;
                    break;
                case 1:
                    planet.shop.Start(Player);
                    stay = false;
                    break;
                case 2:
                    planet.hospital.Start(Player);
                    stay = false;
                    break;
                case 3:
                    planet.Training(Player, 100);
                    stay = false;
                    break;
                case 98:
                    stay = false;
                    currentState = new LevelExitState();
                    currentState.Execute(this);
                    break;

                case 99:
                    currentState = new LevelShowEQState();
                    currentState.Execute(this);
                    break;

            }
            return stay;
        }
    }
}
