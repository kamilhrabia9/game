using System;
using static System.Console;


namespace StarWarsFinal
{
    class Menu
    {
        private string title;
        public string[] positions;
        public int index;

        public Menu(string title, string[] positions)
        {
            this.title = title;
            this.positions = positions;
            index = 0;
        }

        public void ShowMenu()
        {
            WriteLine(" " + TextDisplay.CenterText(title) + "\n");

            for (int i = 0; i < positions.Length; i++)
            {
                string prefix;
                string currentPosition = positions[i];

                if (i == index)
                {
                    prefix = ">";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;

                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }

                WriteLine(" " + TextDisplay.CenterText(($"{prefix} {currentPosition}")) + "  ");
            }

        }

        public int Start()
        {
            ConsoleKey pressedButton;

            do
            {
                Clear();

                ShowMenu();
                ConsoleKeyInfo buttonInfo = ReadKey(true);
                pressedButton = buttonInfo.Key;
                if (pressedButton == ConsoleKey.UpArrow)

                {
                    index--;
                    if (index == -1)
                    {
                        index = positions.Length - 1;
                    }
                }
                else if (pressedButton == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == positions.Length)
                    {
                        index = 0;

                    }
                }
                ResetColor();
            }
            while (pressedButton != ConsoleKey.Enter);
            return index;
        }

        public int StartInterface(string txt)         //To samo co start z możliwością dopisania dodatkowego tekstu
        {
            index = 0;


            ConsoleKey pressedButton;

            do
            {
                Clear();
                TextDisplay.Frame(TextDisplay.CenterText(txt));
                WriteLine("\n");
                ShowMenu();
                ConsoleKeyInfo buttonInfo = ReadKey(true);
                pressedButton = buttonInfo.Key;

                if (pressedButton == ConsoleKey.UpArrow)
                {
                    index--;

                    if (index == -1)
                    {
                        index = positions.Length - 1;
                    }
                }
                else if (pressedButton == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index == positions.Length)
                    {
                        index = 0;

                    }
                }


                else if (pressedButton == ConsoleKey.M)
                {
                    index = 99;


                }
                ResetColor();
            }
            while (pressedButton != ConsoleKey.Enter);

            return index;

        }



    }


}
