namespace StarWarsFinal
{
    class Level9State : IScenarioState
    {
        static string[] pozycjeMenu0 = { "IDŹ DALEJ " };
        Menu menu_p0 = new Menu("Wciśnij ENTER aby przejść dalej", pozycjeMenu0);
        public void Execute(Scenario context)
        {
            context.currentLevel = 9;


            switch (context.MainScreen(menu_p0, context.Plot, "poziom2_1", Photos.plane))
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
                    
                    context.Planet2.Combat(context.Player, Photos.jedi3);

                    context.TransitionToState(new Level10State());
                    break;

            }
        }
    }
}
