using static System.Console;

namespace StarWarsFinal
{
    class MainMenu

    {
        private Game newGame;
        private Menu mainMenu;
        private Menu rulesMenu;
        private Menu exitMenu;
        private Menu chapterMenu;
        private int mainIndex;

        public MainMenu()
        {
            string titleMenu = "Menu Główne";
            string[] positionsMenu = { "Graj", "Wybierz Rozdział", "Zasady Gry", "Wyjdź" };
            string titleRules = "Witaj w grze StarWars Ciemna Strona Mocy by Kamil Hrabia. W tej grze wcielisz się w postać Anakina Skywalkera, poznasz jego historię. Będziesz musiał pokonać swoich wrogów. Za każdą wygraną walkę będziesz otrzymywał wynagrodzenie, dzięki któremu będziesz mógł zakupić broń lub pancerz na targu. Będziesz mógł także naprawić lub sprzedać swoje wyposażenie. Za zgromadzone pieniądze możesz się również leczyć, oraz trenować u mistrza. Każy trening w zależności od tego jak sobie poradzisz doda Ci odpowiednią ilość punktów siły.\n\nWALKA: Aby uderzyć przeciwnika musisz trafić jak największą wartość na pasku uderzenia za pomocą wciśnięcia któregokolwiek klawisza, a następnie musisz się bronić aby nie zostać zbyt mocno trafionym, w zależności od wyświetlonej strzałki naekranie musisz kliknąć odpowiednią strzałkę na klawiaturze, im szybsza twoja rekacja tym lepiej się obronisz. POWODZENIA! ";
            string[] positionsRules = { "Wroć" };
            string titleExit = "Czy na pewno chcesz wyjść z gry?";
            string[] positionsExit = { "Tak", "Nie" };
            string[] positionsChapter = { "Rozdział I", "Rozdział II", "Rozdział III", "Rozdział IV", "Rozdział V", "Rozdział VI", "Rozdział VII", "Rozdział VIII", "Rozdział IX", "Rozdział X", "Rozdział XI" };

            this.mainMenu = new Menu(titleMenu, positionsMenu);
            this.rulesMenu = new Menu(titleRules, positionsRules);
            this.exitMenu = new Menu(titleExit, positionsExit);
            mainIndex = 0;
            this.newGame = new Game();
            this.chapterMenu = new Menu("Wybierz Rozdział od którego chcesz zacząć grę", positionsChapter);


        }

        public void Start()
        {
            mainIndex = mainMenu.Start();

            switch (mainIndex)
            {
                case 0:
                    StartGame(0);
                    break;
                case 1:
                    int chapter = chapterMenu.StartInterface("Wybór rozdziału");
                    StartGame(chapter, chapter * 75);
                    break;
                case 2:
                    StartRules();
                    break;
                case 3:
                    StartExit();
                    break;
                default:
                    WriteLine("default case");
                    break;
            }

        }

        public void StartGame(int chapter, int playerPower = 150)
        {


            Clear();
            newGame.Start(chapter, playerPower);
            ReadKey();
            Clear();
            WriteLine("KONIEC GRY");

        }

        public void StartRules()
        {
            mainIndex = rulesMenu.Start();
            switch (mainIndex)
            {
                case 0:
                    Start();    // powrót do menu głównego
                    break;

            }


        }

        public void StartExit()
        {
            mainIndex = exitMenu.Start();

            switch (mainIndex)
            {
                case 0:

                    break;
                case 1:
                    Start();
                    break;
                default:
                    WriteLine("default case");
                    break;
            }

        }
    }
}
