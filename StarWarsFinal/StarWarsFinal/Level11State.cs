using static System.Console;

namespace StarWarsFinal
{
    class Level11State : IScenarioState
    {
        public void Execute(Scenario context)
        {
            context.currentLevel = 11;

            Clear();
            Write(Photos.dartvaderPic);
            ReadKey();

        }
    }
}
