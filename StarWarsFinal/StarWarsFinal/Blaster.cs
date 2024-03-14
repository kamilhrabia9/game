namespace StarWarsFinal
{
    class Blaster : Offensive
    {
        int accuracy;
        public Blaster(string name, int price, int condition, int power, int accuracy)
        {
            this.name = name;
            this.price = price;
            this.condition = condition;
            this.power = power;
            this.accuracy = accuracy;
        }

        public void Show()
        {
            ShowOffInfo("accuracy", this.accuracy);
        }

        public Equipment Transmit()
        {
            Equipment item;
            return item = TransmitOff(this.accuracy);

        }
    }
}
