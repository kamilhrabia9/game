namespace StarWarsFinal
{
    class Level4State : IScenarioState
    {

        static string[] pozycjeMenu0 = { "IDŹ DALEJ " };
        Menu menu_p0 = new Menu("Wciśnij ENTER aby przejść dalej", pozycjeMenu0);
        public void Execute(Scenario context)
        {
            context.currentLevel = 4;

            switch (context.MainScreen(menu_p0, context.Plot, "poziom1_4", Photos.tlo2))
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
                    context.Planet1.hospital.Start(context.Player);
                    context.TransitionToState(new Level5State());
                    break;

            }


        }
    }
}
