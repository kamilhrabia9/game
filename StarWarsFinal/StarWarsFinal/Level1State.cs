namespace StarWarsFinal
{
    class Level1State : IScenarioState
    {
        static string[] pozycjeMenu0 = { "IDŹ DALEJ " };
        Menu menu_p0 = new Menu("Wciśnij ENTER aby przejść dalej", pozycjeMenu0);
        public void Execute(Scenario context)
        {
            if (context.chapter > 0)
            {
                context.currentLevel = context.chapter + 1;
                context.TransitionToState(new LevelSelectorState());

            }
            else
            {
                context.currentLevel = 1;

                switch (context.MainScreen(menu_p0, context.Plot, "poziom0", Photos.logo))
                {
                    case 98:

                        context.TransitionToState(new LevelExitState());

                        menu_p0.index = 0;


                        break;

                    case 99:

                        menu_p0.index = 0;
                        context.TransitionToState(new LevelShowEQState());

                        break;
                    default:
                        // gameLvl++;
                        context.TransitionToState(new Level2State());
                        break;

                }
            }

            // Symulacja zmiany stanu lub zakończenia gry

        }
    }
}
