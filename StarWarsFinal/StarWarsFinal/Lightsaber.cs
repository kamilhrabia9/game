namespace StarWarsFinal
{
    class Lightsaber : Offensive
    {
        int range;

        public Lightsaber(string name, int price, int condition, int power, int range)
        {
            this.name = name;
            this.price = price;
            this.condition = condition;
            this.power = power;
            this.range = range;
        }

        public void Show()
        {
            ShowOffInfo("range", this.range);
        }

        public Equipment Transmit()
        {
            Equipment item;
            return item = TransmitOff(this.range);

        }



    }
}
