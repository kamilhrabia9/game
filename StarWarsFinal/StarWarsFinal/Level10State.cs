namespace StarWarsFinal
{
    class Level10State : IScenarioState
    {
        static string[] pozycjeMenu0 = { "IDŹ DALEJ " };
        Menu menu_p0 = new Menu("Wciśnij ENTER aby przejść dalej", pozycjeMenu0);

        static string[] pozycjeMenu = { "NASTĘPNY PRZECIWNIK", "ODWIEDŹ TARG", "ODWIEDŹ SZPITAL", "TRENUJ" };
        Menu menu = new Menu("Wybierz co chcesz zrobić", pozycjeMenu);
        public void Execute(Scenario context)
        {
            context.currentLevel = 10;

            while (context.run && context.GameMenu(context.MainScreen(menu, context.Plot, "poziom2_2", Photos.plane), context.Planet2, Photos.jedi1)) { menu.index = 0; };

            menu.index = 0;

            while (context.run && context.GameMenu(context.MainScreen(menu, context.Plot, "poziom2_3", Photos.plane), context.Planet2, Photos.jedi2)) { menu.index = 0; };
            menu.index = 0;

            while (context.run && context.GameMenu(context.MainScreen(menu, context.Plot, "poziom2_4", Photos.plane), context.Planet2, Photos.jedi3)) { menu.index = 0; };
            context.Player.name = "Darth Vader";
            menu.index = 0;


            while (context.run && context.GameMenu(context.MainScreen(menu, context.Plot, "poziom2_5", Photos.plane), context.Planet2, Photos.anakinvsobiwan)) { menu.index = 0; };
            menu.index = 0;

            while (context.run && context.GameMenu(context.MainScreen(menu_p0, context.Plot, "poziom2_6", Photos.plane), context.Planet2, Photos.jedi1)) { menu_p0.index = 0; };
            // gameLvl++;
            menu.index = 0;


            while (context.run && context.GameMenu(context.MainScreen(menu_p0, context.Plot, "poziom2_7", Photos.plane), context.Planet2, Photos.anakinvsobiwan)) { menu_p0.index = 0; };
            context.Player.health = 1000;
            menu.index = 0;
            //gameLvl++;
            context.TransitionToState(new Level11State());

        }
    }
}
