namespace StarWarsFinal
{
    class Level3State : IScenarioState
    {
        static string[] pozycjeMenu0 = { "IDŹ DALEJ " };
        Menu menu_p0 = new Menu("Wciśnij ENTER aby przejść dalej", pozycjeMenu0);
        public void Execute(Scenario context)
        {
            context.currentLevel = 3;

            switch (context.MainScreen(menu_p0, context.Plot, "poziom1_3", Photos.tlo1))
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
                    context.Planet1.Combat(context.Player, Photos.droid3);
                    context.TransitionToState(new Level4State());
                    break;

            }



        }
    }
}
