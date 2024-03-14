using static System.Console;

namespace StarWarsFinal
{
    class Game
    {

        private Character player;
        private Arena planetNr1;
        private Arena planetNr2;
        private Plot plot;



        public Game()
        {
            OutputEncoding = System.Text.Encoding.Unicode;

            //Gracz
            this.player = new Character("Anakin Skywalker", "jedi", 1, 150, 1000, 1, 3, 100);

            //Fabuła
            this.plot = new Plot(Photos.plane);

            // Pierwsza Planeta 
            Blaster pisBla1 = new Blaster("Pistolet Blaster", 100, 80, 3, 70);
            Blaster karBla1 = new Blaster("Karabin Blaster", 150, 120, 10, 120);
            Shield woodenShield = new Shield("Drewniana Tarcza", 60, 70, 1, 30);
            Armor helmet1 = new Armor("Hełm", 70, 100, 10, 80);
            planetNr1 = new Arena("Naboo", 10, pisBla1.Transmit(), karBla1.Transmit(), woodenShield.Transmit(), helmet1.Transmit());

            // Druga Planeta
            Blaster pisBla2 = new Blaster("Pistolet Blaster", 100, 80, 3, 70);
            Blaster karBla2 = new Blaster("Karabin Blaster", 200, 1200, 10, 200);
            Lightsaber sword1 = new Lightsaber("Miecz Świetlny", 90, 70, 40, 30);
            Armor panc2 = new Armor("Hełm", 70, 100, 10, 80);
            planetNr2 = new Arena("Coruscant", 10, pisBla2.Transmit(), karBla2.Transmit(), sword1.Transmit(), panc2.Transmit());

        }

        public void Start(int chapter, int playerPower = 100)
        {

            this.player.strength = playerPower;
            Scenario scenario = new Scenario(plot, player, planetNr1, planetNr2, chapter);
            while (scenario.run)
            {
                scenario.ExecuteState();
            }
        }
    }
}
