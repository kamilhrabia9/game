using static System.Console;

namespace StarWarsFinal
{
    class LevelExitState : IScenarioState
    {
        public void Execute(Scenario context)
        {
            string[] pozycjeMenuGra = { "TAK", "NIE" };
            Menu menuGame = new Menu("Wybierz co chcesz zrobić", pozycjeMenuGra);

            Clear();
            int index = 0;
            index = menuGame.StartInterface("Czy napewno chcesz opuścić grę ?");
            switch (index)
            {
                case 0:
                    context.run = false;
                    break;
                case 1:
                    context.TransitionToState(new LevelSelectorState());
                    break;
            }






        }
    }
}
