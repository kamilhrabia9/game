using static System.Console;

namespace StarWarsFinal
{
    class TextDisplay
    {

        public static int screenWidth = 35;


        public static void UpperBeam(Character Player)
        {
            string upperBeam = $"♥: {(int)(Player.health * 0.1)}%   Siła: {Player.strength}   Obrona: {Player.defense}   Doświadczenie: {Player.experience}   Ekwipunek: {Player.equipment.Count}/5   Kredyt: {Player.wallet}$";
            Frame(upperBeam);
        }

        public static void DownBeam()
        {
            string downBeam = $"(W)yjdz   (E)kwipunek";
            Frame(CenterText(downBeam));
        }

        public static void Frame(string text)
        {
            string upFrame = " ";
            string dwnFrame = "|";


            screenWidth = text.Length;

            for (int i = 0; i < text.Length + 2; i++)
            {
                upFrame += "_";
                dwnFrame += "_";
                if (i == text.Length + 1) dwnFrame += "|";

            }

            WriteLine(upFrame);
            WriteLine($"| {text} |");
            WriteLine(dwnFrame);
        }

        public static string CenterText(string text)
        {
            int size = screenWidth - text.Length;
            string beforeTxt = " ";
            string afterTxt = " ";

            int before = size / 2;
            int after = size - before;

            for (int i = 0; i < before - 1; i++)
            {
                beforeTxt += " ";

            }

            for (int i = 0; i < after - 1; i++)
            {
                afterTxt += " ";

            }



            return beforeTxt + text + afterTxt;

        }

        public static string CenterTextTo(string text, int width)
        {
            int size = width - text.Length;
            string beforeTxt = " ";
            string afterTxt = " ";

            int before = size / 2;
            int after = size - before;

            for (int i = 0; i < before - 1; i++)
            {
                beforeTxt += " ";

            }

            for (int i = 0; i < after - 1; i++)
            {
                afterTxt += " ";

            }



            return beforeTxt + text + afterTxt;

        }
    }


}
