using static System.Console;

namespace StarWarsFinal
{
    class Level7State : IScenarioState
    {

        static string[] pozycjeMenu0 = { "IDŹ DALEJ " };
        Menu menu_p0 = new Menu("Wciśnij ENTER aby przejść dalej", pozycjeMenu0);

        public void Execute(Scenario context)
        {
            context.currentLevel = 7;

            while (context.GameMenu(context.MainScreen(menu_p0, context.Plot, "poziom1_7", Photos.logo), context.Planet1, Photos.jedi2)) { menu_p0.index = 0; };
            Clear();
            if (context.run) context.Planet1.Training(context.Player, 0);            
            context.TransitionToState(new Level8State());
        }
    }
}
