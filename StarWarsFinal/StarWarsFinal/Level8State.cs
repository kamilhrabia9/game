namespace StarWarsFinal
{
    class Level8State : IScenarioState
    {

        static string[] pozycjeMenu0 = { "IDŹ DALEJ " };
        Menu menu_p0 = new Menu("Wciśnij ENTER aby przejść dalej", pozycjeMenu0);
        public void Execute(Scenario context)
        {
            context.currentLevel = 8;

            switch (context.MainScreen(menu_p0, context.Plot, "poziom2", Photos.plane))
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
                    context.TransitionToState(new Level9State());
                    break;

            }


        }
    }
}
