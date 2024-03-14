namespace StarWarsFinal
{
    abstract class Offensive : Gun
    {
        protected int power;
        protected Offensive()
        {
            this.type = "Offensive";

        }

        public int Attack()
        {
            int x = 0;

            if (this.type != "pancerz")
            {
                x = (int)(this.power * (this.condition * 0.01));
                if (condition >= 5)
                {
                    this.condition -= 5;
                }
            }

            return x;
        }

        public void ShowOffInfo(string txt, int txt1)
        {
            ShowInfo("power", this.power, txt, txt1);
        }

        protected Equipment TransmitOff(int add)
        {
            Equipment item = new Equipment(this.name, this.price, this.type, this.condition, this.power, add);
            return item;
        }
    }



}
