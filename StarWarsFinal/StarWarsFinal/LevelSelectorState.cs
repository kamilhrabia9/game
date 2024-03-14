namespace StarWarsFinal
{
    class LevelSelectorState : IScenarioState
    {
        public void Execute(Scenario context)
        {
            switch (context.currentLevel)
            {
                case 1:
                    context.TransitionToState(new Level1State());

                    break;

                case 2:
                    context.TransitionToState(new Level2State());


                    break;
                case 3:
                    context.TransitionToState(new Level3State());


                    break;
                case 4:
                    context.TransitionToState(new Level4State());

                    break;
                case 5:
                    context.TransitionToState(new Level5State());

                    break;
                case 6:
                    context.TransitionToState(new Level6State());
                    break;
                case 7:

                    context.TransitionToState(new Level7State());
                    break;
                case 8:
                    context.TransitionToState(new Level8State());

                    break;
                case 9:

                    context.TransitionToState(new Level9State());
                    break;
                case 10:

                    context.TransitionToState(new Level10State());
                    break;
                case 11:

                    context.TransitionToState(new Level11State());
                    break;

                default:

                    break;

            }



        }
    }

}
