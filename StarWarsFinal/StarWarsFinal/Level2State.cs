namespace StarWarsFinal
{
    class Level2State : IScenarioState
    {
        static string[] pozycjeMenu0 = { "IDŹ DALEJ " };
        Menu menu_p0 = new Menu("Wciśnij ENTER aby przejść dalej", pozycjeMenu0);

        public void Execute(Scenario context)
        {
            context.currentLevel = 2;

            switch (context.MainScreen(menu_p0, context.Plot, "poziom1", Photos.puste))
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
                    int i = 0;
                    i += context.Planet1.Combat(context.Player, Photos.droid1);
                    if (i == 1)/* gameLvl += */context.Planet1.Combat(context.Player, Photos.droid2);
                    context.TransitionToState(new Level3State());
                    break;

            }





        }
    }
}
