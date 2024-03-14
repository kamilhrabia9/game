using System;
using static System.Console;


namespace StarWarsFinal
{
    class LevelShowEQState : IScenarioState
    {
        public void Execute(Scenario context)
        {
            Clear();
            context.Player.ShowEq();
            Console.WriteLine(context.currentLevel);
            ReadKey();
            context.TransitionToState(new LevelSelectorState());
        }
    }
}
