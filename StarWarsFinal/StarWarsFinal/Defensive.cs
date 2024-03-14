namespace StarWarsFinal
{
    abstract class Defensive : Gun
    {
        protected int defence;

        protected Defensive()
        {
            this.type = "Defensive";

        }


        public int Defence()
        {
            int x = 0;

            if (this.type == "pancerz")
            {

                x = (int)(this.defence * (this.condition * 0.01));
                if (condition >= 10)
                {
                    this.condition -= 10;
                }
            }

            return x;

        }

        public void ShowDefInfo(string txt, int txt1)
        {
            ShowInfo("defence", this.defence, txt, txt1);
        }

        protected Equipment TransmitDef(int add)
        {
            Equipment item = new Equipment(this.name, this.price, this.type, this.condition, this.defence, add);
            return item;
        }
    }
}

