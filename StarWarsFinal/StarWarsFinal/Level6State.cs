namespace StarWarsFinal
{
    class Level6State : IScenarioState
    {
        static string[] pozycjeMenu1 = { "WALCZ", "IDŹ DO SZPITALA" };
        Menu menu_p1 = new Menu("Wybierz co chcesz zrobić", pozycjeMenu1);

        public void Execute(Scenario context)
        {
            context.currentLevel = 6;

            switch (context.MainScreen(menu_p1, context.Plot, "poziom1_6", Photos.plane))
            {
                case 0:
                    context.Planet1.Combat(context.Player, Photos.jedi1);
                    context.TransitionToState(new Level7State());
                    break;
                case 1:

                    context.Planet1.hospital.Start(context.Player);
                    break;

                case 98:
                    context.TransitionToState(new LevelExitState());
                    menu_p1.index = 0;

                    break;

                case 99:
                    menu_p1.index = 0;
                    context.TransitionToState(new LevelShowEQState());
                    break;

                default:

                    break;
            }
        }

    }
}
